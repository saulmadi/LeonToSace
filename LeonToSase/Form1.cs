using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            txtLeon.Text =  GetFileName();
        }

        private static string GetFileName()
        {
            using (var fdlg = new OpenFileDialog
            {
                Title = @"Abrir Excel", Filter = @"Excel Files|*.xls;*.xlsx", FilterIndex = 2, RestoreDirectory = true
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
            var datosSace = ExcelDataExtracter.ExtractSheetToDataTable(txtSace.Text, 0, true);


            

            var datosLeon =  ExcelDataExtracter.ExtractSheetToDataTable(txtLeon.Text, 5);

            
            foreach (var dataRow in datosLeon)
            {
                var identidad = dataRow["F2"].ToString();
                var inacistenciasF1 = dataRow["F4"];

                ExcelDataExtracter.UpdateValue(txtSace.Text,identidad,"F4",69);



            }
        }
    }
}
