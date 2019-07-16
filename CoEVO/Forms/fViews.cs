using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoEVO.Forms
{
    public partial class fViews : Form
    {

        DataRow NewCR;

        public fViews()
        {
            InitializeComponent();
        }

        private void fViews_Load(object sender, EventArgs e)
        {
            try
            {
                dQueueService.DataSource = ds;
                //dQueueService.DataMember = "QueueService";
                dQueueService.DataMember = "FitnessHistory";

                dChart.DataBind();
                dChart.DataSource = ds;
                //dChart.DataMember = "ChartFitnessShips";
                dChart.DataMember = "ChartFitnessChromosome";

                dPOPSupplying.DataSource = ds;
                //dPOPSupplying.DataSource = "portsBindingSource";
                //MessageBox.Show(ds.Ports.Rows.Count.ToString());
                //MessageBox.Show(ds.FitnessHistory.Rows.Count.ToString());

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + " / " + ex.ToString());
            }
            
        }

        public void ExcelExport(Infragistics.Win.UltraWinGrid.UltraGrid Grid, string FileName)
        {
            try
            {
                Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter Export = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter();
                SaveFileDialog Save = new SaveFileDialog();

                Save.Filter = "Excel File (.xlsx) |*.xlsx|Excel File 97-2003 (.xls)|*.xls";
                Save.Title = "Save The Fitness Value Report";
                Save.FileName = FileName;

                if (Save.ShowDialog() == DialogResult.OK)
                {
                    Export.Export(Grid, Save.FileName);
                    MessageBox.Show("Excel File was exported successfully!", "Excel File Exportation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dQueueService_DoubleClick(object sender, EventArgs e)
        {
            ExcelExport(dQueueService, "Fitness Values");
        }

        private void dOptionFitness_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ChromosomeID = 0;
                int ChromosomeID2 = 0;

                switch (dPOPSupplying.SelectedValue.ToString())
                {
                    case "1":
                        ChromosomeID = 0;
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                }

                ChromosomeID = (Convert.ToInt16(dPOPSupplying.SelectedValue) - 1) * Globals.IniPOPSize;
                ChromosomeID2 = ChromosomeID + 1;

                ds.ChartFitnessChromosome.Rows.Clear();
                for(int i=0;i<ds.FitnessHistory.Rows.Count-1;i++)
                {
                    if(ds.FitnessHistory.Rows[i].ItemArray.GetValue(2).ToString() == dPOPSupplying.SelectedValue.ToString())
                    {
                        if(ds.FitnessHistory.Rows[i].ItemArray.GetValue(1).ToString()==ChromosomeID.ToString())
                        {
                            NewCR = ds.Tables["ChartFitnessChromosome"].NewRow();
                            //NewCR["ID"] = ds.FitnessHistory.Rows[i].ItemArray.GetValue(0);
                            NewCR["Fitness"] = ds.FitnessHistory.Rows[i].ItemArray.GetValue(4);
                            ds.Tables["ChartFitnessChromosome"].Rows.Add(NewCR);
                        }

                        if (ds.FitnessHistory.Rows[i].ItemArray.GetValue(1).ToString() == ChromosomeID2.ToString())
                        {
                            NewCR = ds.Tables["ChartFitnessChromosome"].NewRow();
                            //NewCR["ID"] = ds.FitnessHistory.Rows[i].ItemArray.GetValue(0);
                            NewCR["Fitness"] = ds.FitnessHistory.Rows[i].ItemArray.GetValue(4);
                            ds.Tables["ChartFitnessChromosome"].Rows.Add(NewCR);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
