using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;

namespace CoEVO
{
    class Help
    {
        /*
         
        Para crear una Queue que almacene valores
        Qs es una Clase Chromosome

        Queue q = new Queue();
        q.Enqueue(Qs); 
        */

        /*
                
                int[,] x = new int[2, 3];
                x[0, 1] = 88;
                x[1, 0] = 55;
                x[1, 2] = 97;

                     0   1   2
                   _____________
                0 |     88   -
                1 | 55   -  97
                  |_____________
                
                foreach(int i in x)
                {
                    MessageBox.Show(i.ToString());
                }
                  
                */

        public void ExcelExport(Infragistics.Win.UltraWinGrid.UltraGrid Grid)
        {
            Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter Export = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter();
            SaveFileDialog Save = new SaveFileDialog();

            Save.Filter = "Excel File (.xlsx) |*.xlsx|Excel File 97-2003 (.xls)|*.xls";
            Save.Title = "Save The QueueService File";
            Save.ShowDialog();

            if (Save.FileName != "")
            {
                Export.Export(Grid, Save.FileName);
                MessageBox.Show("Excel File was exported successfully!");
            }
        }
    }
}
