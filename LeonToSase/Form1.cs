using System;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace LeonToSase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtLeon.Text = GetFileName();
        }

        private static string GetFileName()
        {
            using (var fdlg = new OpenFileDialog
            {
                Title = @"Abrir Excel",
                Filter = @"Excel Files|*.xls;*.xlsx",
                FilterIndex = 2,
                RestoreDirectory = true
            })
            {
                return fdlg.ShowDialog() == DialogResult.OK ? fdlg.FileName : string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSace.Text = GetFileName();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //var datosSace = ExcelDataExtracter.ExtractSheetToDataTable(txtSace.Text, 0);

            var parciales4 = rb4Parciales.Checked;


            var datosLeon = ExcelDataExtracter.ExtractSheetToDataTable(txtLeon.Text, 5);

            var lista = datosLeon.Select(dataRow => parciales4
                ? new Datos
                {
                    Identidad = dataRow.Field<string>("F2"),
                    Ina1 = dataRow.GetValue<int>("F4"),
                    Niv1 = dataRow.GetValue<int>("F8"),
                    Total1 = dataRow.GetValue<int>("F9"),
                    Ina2 = dataRow.GetValue<int>("F10"),
                    Niv2 = dataRow.GetValue<int>("F14"),
                    Total2 = dataRow.GetValue<int>("F15"),
                    Ina3 = dataRow.GetValue<int>("F16"),
                    Niv3 = dataRow.GetValue<int>("F20"),
                    Total3 = dataRow.GetValue<int>("F21"),
                    Ina4 = dataRow.GetValue<int>("F22"),
                    Total4 = dataRow.GetValue<int>("F26")
                }
                : new Datos
                {
                    Identidad = dataRow.Field<string>("F2"),
                    Ina1 = dataRow.GetValue<int>("F4"),
                    Niv1 = dataRow.GetValue<int>("F8"),
                    Total1 = dataRow.GetValue<int>("F9"),
                    Ina2 = dataRow.GetValue<int>("F10"),
                    Total2 = dataRow.GetValue<int>("F14")
                }).ToList();


            var MyApp = new Application {Visible = false};
            var MyBook = MyApp.Workbooks.Open(txtSace.Text);
            var MySheet = (Worksheet) MyBook.Sheets[1];


            var flag = true;
            var row = 8;
            while (flag)
            {
                var identidad = (string) MySheet.get_Range("B" + row, "B" + row).Cells.Value;
                var alumano = lista.FirstOrDefault(d => d.Identidad == identidad);

                if (alumano != null)
                {
                    if (parciales4)
                    {
                        MySheet.Cells[row, "D"] = alumano.Ina1;
                        MySheet.Cells[row, "E"] = alumano.Total1 - alumano.Niv1;
                        MySheet.Cells[row, "F"] = alumano.Niv1;

                        MySheet.Cells[row, "G"] = alumano.Ina2;
                        MySheet.Cells[row, "H"] = alumano.Total2 - alumano.Niv2;
                        MySheet.Cells[row, "I"] = alumano.Niv2;

                        MySheet.Cells[row, "J"] = alumano.Ina3;
                        MySheet.Cells[row, "K"] = alumano.Total3 - alumano.Niv3;
                        MySheet.Cells[row, "L"] = alumano.Niv3;


                        MySheet.Cells[row, "M"] = alumano.Ina4;
                        MySheet.Cells[row, "N"] = alumano.Total4;

                    }
                    else
                    {
                        MySheet.Cells[row, "D"] = alumano.Ina1;
                        MySheet.Cells[row, "E"] = alumano.Total1 - alumano.Niv1;
                        MySheet.Cells[row, "F"] = alumano.Niv1;

                        MySheet.Cells[row, "G"] = alumano.Ina2;
                        MySheet.Cells[row, "H"] = alumano.Total2;
                        

                    }
                    
                }
                row++;
                if (identidad == null)
                    flag = false;
            }
            MyBook.SaveAs(txtSace.Text);
            MyBook.Close();

            Marshal.ReleaseComObject(MyBook);

            MessageBox.Show(@"Archivo Generado Correctamente");
        }
    }

    public static class MyClass
    {
        public static TValue GetValue<TValue>(this DataRow row, string col)
        {
            var value = row[col];
            if (value is DBNull)
                return default(TValue);
            return (TValue) Convert.ChangeType(value, typeof(TValue));
        }
    }
}