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
    public partial class Parameters : Form
    {
        public Parameters()
        {
            InitializeComponent();
        }

        private void Parameters_Load(object sender, EventArgs e)
        {
            try
            {
                dFrom.Value = Convert.ToDateTime(Globals.From);
                dTo.Value = Convert.ToDateTime(Globals.To);

                nPopSize.Value = Globals.IniPOPSize;
                nIterationsGA.Value = Globals.IterationsGA;
                nIterationsCoEA.Value = Globals.IterationsCoEA;
                nCrossoverRate.Value = Convert.ToDecimal(Globals.CrossoverRate);
                nMutationRate.Value = Convert.ToDecimal(Globals.MutationRate);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "/" + ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var MyIni = new IniFile(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6) + @"\Datos.ini");
            MyIni.IniWriteValue("Load", "From", dFrom.Value.ToShortDateString().ToString() + " 00:00:01");
            MyIni.IniWriteValue("Load", "To", dTo.Value.ToShortDateString().ToString() + " 23:59:59");
            MyIni.IniWriteValue("Load", "IterationsGA", nIterationsGA.Value.ToString());
            MyIni.IniWriteValue("Load", "IterationsCoEA", nIterationsCoEA.Value.ToString());
            MyIni.IniWriteValue("Load", "IniPOPSize", nPopSize.Value.ToString());
            MyIni.IniWriteValue("Load", "CrossoverRate", nCrossoverRate.Value.ToString());
            MyIni.IniWriteValue("Load", "MutationRate", nMutationRate.Value.ToString());

            Globals.From = MyIni.IniReadValue("Load", "From");
            Globals.To = MyIni.IniReadValue("Load", "To");
            Globals.IniPOPSize = Convert.ToInt16(nPopSize.Value);
            Globals.IterationsGA = Convert.ToInt16(nIterationsGA.Value);
            Globals.IterationsCoEA=Convert.ToInt16(nIterationsCoEA.Value);
            Globals.CrossoverRate=Convert.ToDouble(nCrossoverRate.Value);
            Globals.MutationRate = Convert.ToDouble(nMutationRate.Value);

            this.Close();
        }

        public void UpdateValue()
        {
            //bOK.Text = "Update";

        }
        private void dFrom_ValueChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void dTo_ValueChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }

        private void nPopSize_ValueChanged(object sender, EventArgs e)
        {
            UpdateValue();
        }
    }
}
