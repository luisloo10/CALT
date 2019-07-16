using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace CoEVO
{
    public partial class Menu : Form
    {
        SQL MySQL = new SQL();
        MySqlDataReader d;

        private int childFormNumber = 0;

        public Menu()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void Options_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            OpenWindows(e.Item.Key);
        }

        private void ultraDockManager1_BeforeDockChange(object sender, Infragistics.Win.UltraWinDock.BeforeDockChangeEventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            try
            {

                //d = MySQL.MySqlQuery("select count(*) from Dock").ExecuteReader();
                //if (d.Read() == true)
                //{
                //    MessageBox.Show(d[0].ToString());
                //}


                //// Or specify a specific name in the current dir


                //// Or specify a specific name in a specific dir
                
                LoadParameterValues();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LoadParameterValues()
        {
            var MyIni = new IniFile(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6) + @"\Datos.ini");
            Globals.From = MyIni.IniReadValue("Load", "From");
            //Globals.To = Convert.ToDateTime(MyIni.IniReadValue("Load", "To"));
            Globals.To = MyIni.IniReadValue("Load", "To");
            Globals.IterationsGA = Convert.ToInt16(MyIni.IniReadValue("Load", "IterationsGA"));
            Globals.IterationsCoEA = Convert.ToInt16(MyIni.IniReadValue("Load", "IterationsCoEA"));
            Globals.IniPOPSize = Convert.ToInt16(MyIni.IniReadValue("Load", "IniPOPSize"));
            Globals.CrossoverRate = Convert.ToDouble(MyIni.IniReadValue("Load", "CrossoverRate"));
            Globals.MutationRate = Convert.ToDouble(MyIni.IniReadValue("Load", "MutationRate"));
            Globals.CompareType = Convert.ToInt16(MyIni.IniReadValue("Load", "CompareType"));
        }

        public void SetValues()
        {

        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.Control)
                {
                    switch(e.KeyCode)
                    {
                        case Keys.R:
                            OpenWindows("0.1");
                            break;
                        case Keys.M:
                            OpenWindows("0.2");
                            break;
                        case Keys.V:
                            OpenWindows("0.3");
                            break;
                        case Keys.H:
                            OpenWindows("1.1");
                            break;
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenWindows(string Value)
        {
            switch(Value)
            {
                case "0.1":
                    fRun FRun = new CoEVO.fRun();
                    FRun.MdiParent = this;
                    FRun.Show();
                    break;
                case "0.2":
                    
                    break;
                case "0.3":
                    Forms.fViews FViews = new CoEVO.Forms.fViews();
                    FViews.MdiParent = this;
                    FViews.Show();
                    break;
                case "1.1":
                    Forms.fHistory FHistory = new Forms.fHistory();
                    FHistory.MdiParent = this;
                    FHistory.Show();
                    break;
                default:
                    break;
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Parameters fParameters = new Forms.Parameters();
            fParameters.ShowDialog();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(DateTime.Now.ToShortDateString());
            MessageBox.Show(DateTime.Now.ToString());
            MessageBox.Show(DateTime.Now.ToShortTimeString());
            

        }
    }
}
