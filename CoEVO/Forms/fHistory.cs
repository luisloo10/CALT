using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoEVO.Properties;
using System.Data.OleDb;
using System.Data.SqlClient;


namespace CoEVO.Forms
{
    public partial class fHistory : Form
    {
        public string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
        public CoEVO.IniFile MyIni;

        SQL SQL = new SQL();
        SqlDataReader d;

        public fHistory()
        {
            InitializeComponent();
        }

        private void fHistory_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sQLData.VesselType' Puede moverla o quitarla según sea necesario.
            this.vesselTypeTableAdapter.Fill(this.sQLData.VesselType);
            // TODO: esta línea de código carga datos en la tabla 'sQLData.POPDemanding' Puede moverla o quitarla según sea necesario.
            this.pOPDemandingTableAdapter.Fill(this.sQLData.POPDemanding);
            try
            {
                path = path.Substring(6);
                path = path + @"\Datos.ini";
                MyIni = new CoEVO.IniFile(path);

                dFrom.Value = Convert.ToDateTime(MyIni.IniReadValue("Load", "From"));
                dTo.Value = Convert.ToDateTime(MyIni.IniReadValue("Load", "To"));

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dFrom_ValueChanged(object sender, EventArgs e)
        {
            MyIni.IniWriteValue("Load", "From", dFrom.Value.ToShortDateString().ToString() + " 00:01");
            LoadHistoryData();
        }

        private void dTo_ValueChanged(object sender, EventArgs e)
        {
            MyIni.IniWriteValue("Load", "To", dTo.Value.ToShortDateString().ToString() + " 23:59");
            LoadHistoryData();
        }

        private void LoadHistoryData()
        {
            historyTableAdapter.Fill(sQLData.History, dFrom.Value, dTo.Value);
            pOPDemandingTableAdapter.Fill(sQLData.POPDemanding);
            vesselTypeTableAdapter.Fill(sQLData.VesselType);

            gDatos.DisplayLayout.GroupByBox.Prompt = "History: " + gDatos.Rows.Count().ToString() + " Records.-";
        }

        private void gDatos_AfterCellUpdate(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
        {
            try
            {
                if (e.Cell.Column.Key == "MOV")
                { 
                d = SQL.Query("update History set MOV='" + e.Cell.Value.ToString() + "' where ID='" + e.Cell.Row.Cells["ID"].Value.ToString() + "'").ExecuteReader();
                d.Read();
                SQL.command.Connection.Close();
                }

                if (e.Cell.Column.Key == "Status")
                {
                d = SQL.Query("update History set Status='" + e.Cell.Value.ToString() + "' where ID='" + e.Cell.Row.Cells["ID"].Value.ToString() + "'").ExecuteReader();
                d.Read();
                SQL.command.Connection.Close();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gDatos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Go down one row
                gDatos.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell);
                
            }
        }
    }
}
