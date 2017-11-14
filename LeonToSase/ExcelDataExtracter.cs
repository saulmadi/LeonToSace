using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;

namespace LeonToSase
{
    public class ExcelDataExtracter
    {

        public static void UpdateValue(string fileName ,string identidad, string columana, int valor)
        {
            var connectionString =
               string.Format(
                   "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties = \"Excel 8.0;HDR=yes;IMEX=1\" ",
                   fileName);


            using (var con = new OleDbConnection(connectionString))
            {
                var dataTable = new DataTable();





                con.Open();


                DataTable dbSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dbSchema == null || dbSchema.Rows.Count < 1)
                {
                    throw new Exception("Error: Could not determine the name of the first worksheet.");
                }
                string firstSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();


                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                
                myCommand.Connection = con;

                var sql =  $"Update [{firstSheetName}] set {columana}$={valor} where F2$='{identidad}'";
                myCommand.CommandText = sql;
                myCommand.ExecuteNonQuery();
                con.Close();
            }

        }

        public static IEnumerable<DataRow> ExtractSheetToDataTable(string fileName, int fila,bool header = false)
        {
            var connectionString =
                string.Format(
                    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties = \"Excel 8.0;HDR={1};IMEX=1\" ",
                    fileName, header? "Yes" : "No");


            using (var con = new OleDbConnection(connectionString))
            {
                var dataTable = new DataTable();





                con.Open();


                DataTable dbSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                if (dbSchema == null || dbSchema.Rows.Count < 1)
                {
                    throw new Exception("Error: Could not determine the name of the first worksheet.");
                }
                string firstSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();

                var query = string.Format("SELECT * FROM [{0}]", firstSheetName);
                var adapter = new OleDbDataAdapter(query, con);
                adapter.Fill(dataTable);
                var copyToDataTable = dataTable.AsEnumerable().Skip(fila -1).CopyToDataTable();
                var extractSheetToDataTable = copyToDataTable.AsEnumerable();//.Where(row => row.ItemArray.All(o => !(o is DBNull)));
                return extractSheetToDataTable;
            }
        }
    }
}