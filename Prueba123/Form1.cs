using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using objExcel = Microsoft.Office.Interop.Excel;

namespace Prueba123
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string ruta = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string a = Interaction.InputBox("Documentos por cobrar (c/p)", "Registro", "", 200, 200);
            dvgdatos.Rows.Add("Documentos por cobrar (c/p)", a);
            string b = Interaction.InputBox("Cuentas por cobrar", "Registro", "", 200, 200);
            dvgdatos.Rows.Add("Cuentas por cobrar", b);
            string c = Interaction.InputBox("Estimacion para ctas. Incobrables", "Registro", "", 200, 200);
            dvgdatos.Rows.Add("Estimacion para ctas. Incobrables", c);
            string d = Interaction.InputBox("Impuestos pagados por anticipado", "Registro", "", 200, 200);
            dvgdatos.Rows.Add("Impuestos pagados por anticipado", d);
            string E = Interaction.InputBox("Acciones y valores", "Registro", "", 200, 200);
            dvgdatos.Rows.Add("Acciones y valores", E);
            string f = Interaction.InputBox("Documentos por cobrar (l/p)", "Registro", "", 200, 200);
            dvgdatos.Rows.Add("Documentos por cobrar (l/p)", f);
            string g = Interaction.InputBox("Caja y banco", "Registro", "", 200, 200);
            dvgdatos.Rows.Add("Caja y banco", g);
            string h = Interaction.InputBox("Inventario", "Registro", "", 200, 200);
            dvgdatos.Rows.Add("Inventario", h);


        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            objExcel.Application objAplicacion = new objExcel.Application();
            Workbook objLibro = objAplicacion.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet objHoja = (Worksheet)objAplicacion.ActiveSheet;

            objAplicacion.Visible = false;



            foreach (DataGridViewColumn columna in dvgdatos.Columns)
            {
                objHoja.Cells[1, columna.Index + 1] = columna.HeaderText;
                foreach (DataGridViewRow fila in dvgdatos.Rows)
                {
                    objHoja.Cells[fila.Index + 2, columna.Index + 1] = fila.Cells[columna.Index].Value;
                }
            }

            objLibro.SaveAs(ruta + "\\MiprimerExcel.xlsx");
            objLibro.Close();

        }

        private void btncalc_Click(object sender, EventArgs e)
        {
            double suma=0;
            foreach (DataGridViewRow row in dvgdatos.Rows) 
            {
                suma += Convert.ToDouble(row.Cells["lastname"].Value);
            }

            lbltotal.Text = suma.ToString();
        }
    }

}

