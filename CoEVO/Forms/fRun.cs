using System;
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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinGrid.ExcelExport;

namespace CoEVO
{
    public partial class fRun : Form
    {
        SQL SQL = new SQL();
      
        SqlDataReader d;

        //DateTime From = Convert.ToDateTime("01-05-2017 00:00:00");
        //DateTime To = Convert.ToDateTime("01-05-2017 23:59:59");

        //int IterationsGA = 5000;
        //int IterationsCoEA = 5000;
        //int IniPOPSize = 2;
        //double CrossoverRate = 1;
        //double MutationRate = 1;
        ////int Hours = 24;
        //public int CompareType=1; //1=Ships; 2=Ports; 3=All

        int TotalShips;
        POPDemanding[] Ships;
        POPDemanding LoadShip;

        int TotalVesselTypes;
        int TotalVesselSizes;
        VesselType[] VesselsTypes;
        VesselType VesselType;
        VesselSizes[] VesselSizes;
        VesselSizes VesselSize;

        int TotalPorts;
        POPSupplying[] Ports;
        POPSupplying Port;
        POPSupplyingRelations[] PortsRelations;
        POPSupplyingRelations PortsRelation;
        POPSupplyingTimes[] PortTimes;
        POPSupplyingTimes PortTime;

        int TotalDocks;
        Dock[] DocksArray;
        Dock DockUnit;

        Rates[] Rates;
        Rates RateUnit;

        QueueService[] QueQueServices;
        QueueService QueQueService;

        DataRow DataSchedule;
        DataRow NewCR;

        CoEVO.CoEvolution Algorithm;
        //CoEvolution Algorithm;

        DateTime StartProcess;
        DateTime FinishProcess;

        public fRun()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ProcessRegistration(1, 1);
            SQL.SetValues();
            bStart_Click(sender, e);
            ProcessRegistration(1, 2);
        }
        
        private void bStart_Click(object sender, EventArgs e)
        {
            try
            {
                CleanTables();
                LoadAllFunctions();

                Algorithm = new CoEVO.CoEvolution();
                Algorithm.IniPOP(Ships, VesselsTypes, VesselSizes, Ports, PortsRelations, PortTimes, Rates, QueQueServices, Globals.IniPOPSize,Globals.CompareType);

                LoadTables();
                FillChartTypes(Globals.CompareType);

                //this.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message + " / " + ex.ToString());
            }
        }

        private void bAllocate_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessRegistration(2, 1);
                CleanTables();
                Algorithm.ExecuteGA(Globals.IterationsGA,Globals.CrossoverRate);
                LoadTables();
                ProcessRegistration(2, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bCoEVO_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessRegistration(3, 1);
                CleanTables();
                Algorithm.ExecuteCoEA(Globals.IterationsCoEA, Globals.IterationsGA, Globals.CrossoverRate, Globals.MutationRate);
                LoadTables();
                ProcessRegistration(3, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CleanTables()
        {
            ds.Schedule.Rows.Clear();
            ds.Sch_QueueService.Rows.Clear();
            ds.Chromosome.Rows.Clear();
            ds.Ships.Rows.Clear();
            ds.VesselType.Rows.Clear();
            ds.QueueService.Rows.Clear();
            ds.Docks.Rows.Clear();
            ds.Ports.Rows.Clear();
            ds.FitnessHistory.Rows.Clear();
        }

        public void LoadAllFunctions()
        {
            LoadShips();
            LoadVesselsTypes();
            LoadVesselsSizes();
            LoadQuequeServices();
            LoadDocks();
            LoadRates();
            LoadPorts();
            LoadPOPSupplyingRelations();
            LoadPOPSupplyingTimes();
        }

        public void LoadTables()
        {
            //DataRow NewCR = ds.Tables["Schedule"].NewRow();
            
            foreach (Chromosome Chr in Algorithm.Utilities.C)
            {
                foreach (QueueService Qs in Chr.QueueList)
                {
                    NewCR = ds.Tables["Schedule"].NewRow();
                    NewCR["POPID"] = Qs.POPSupplyingID;
                    NewCR["Chromosome"] = Qs.ChromosomeID;
                    NewCR["Dock"] = Qs.CurrentDock;
                    NewCR["Hour"] = Qs.CurrentHour;
                    NewCR["QueueServiceID"] = Qs.GetID;
                    NewCR["VesselID"] = Qs.VesselID;
                    NewCR["Fitness"] = Qs.Fitness;
                    ds.Tables["Schedule"].Rows.Add(NewCR);

                    NewCR = ds.Tables["Sch_QueueService"].NewRow();
                    NewCR["ChromosomeID"] = Qs.ChromosomeID;
                    NewCR["QID"] = Qs.GetID;
                    NewCR["VesselID"] = Qs.VesselID;
                    NewCR["POP"] = Qs.POPSupplyingID;
                    NewCR["Direction"] = Qs.Direction;
                    NewCR["OldPOP"] = Qs.OldPOPSupplyingID;
                    NewCR["OldDirection"] = Qs.OldDirection;
                    NewCR["Units"] = Qs.Units;
                    NewCR["MOV"] = Qs.MOV;
                    NewCR["CD"] = Qs.CurrentDock;
                    NewCR["CH"] = Qs.CurrentHour;
                    NewCR["OD"] = Qs.OldDock;
                    NewCR["OH"] = Qs.OldHour;
                    NewCR["TimeInPort"] = Qs.TimeInPort;
                    //NewCR["ExtraTime"] = Qs.ExtraTime;
                    NewCR["CrossTime"] = Qs.CrossTime;
                    NewCR["AwaitingTime"] = Qs.AwaitingTime;
                    NewCR["DelayTime"] = Qs.DelayTime;
                    NewCR["ArrivalTime"] = Qs.ArrivalTime;
                    NewCR["DepartureTime"] = Qs.DepartureTime;
                    NewCR["OldArrivalTime"] = Qs.OldArrivalTime;
                    NewCR["OldDepartureTime"] = Qs.OldDepartureTime;
                    NewCR["Status"] = Qs.Status;
                    NewCR["Cost"] = Qs.Cost;
                    NewCR["FixedCost"] = Qs.FixedCost;
                    NewCR["VariableCost"] = Qs.VariableCost;
                    NewCR["ReAlocatedDock"] = Qs.ReAllocatedDock;
                    NewCR["ReAlocatedTime"] = Qs.ReAllocatedTime;
                    NewCR["ForRealocate"] = Qs.ForReAllocate;
                    NewCR["Fitness"] = Qs.Fitness;
                    ds.Tables["Sch_QueueService"].Rows.Add(NewCR);
                }
            }

            for (int i = 0; i < Algorithm.Utilities.C.Count(); i++)
            {
                NewCR = ds.Tables["Chromosome"].NewRow();
                NewCR["ID"] = Algorithm.Utilities.C[i].ID1;
                NewCR["POPID"] = Algorithm.Utilities.C[i].POPID;
                NewCR["VesselsQty"] = Algorithm.Utilities.C[i].VesselsQty;
                NewCR["Units"] = Algorithm.Utilities.C[i].Units;
                NewCR["Movements"] = Algorithm.Utilities.C[i].Movements;
                NewCR["AwaitingTime"] = Algorithm.Utilities.C[i].AwaitingTime;
                NewCR["CrossTime"] = Algorithm.Utilities.C[i].CrossTime;
                NewCR["DelayTime"] = Algorithm.Utilities.C[i].DelayTime;
                NewCR["IdleTime"] = Algorithm.Utilities.C[i].IdleTime;
                NewCR["TimeInPort"] = Algorithm.Utilities.C[i].TimeInPort;
                NewCR["TotalPortTime"] = Algorithm.Utilities.C[i].TotalPortTime;
                //NewCR["ExtraTime"] = Algorithm.Utilities.C[i].ExtraTime;
                NewCR["CrossTime"] = Algorithm.Utilities.C[i].CrossTime;
                NewCR["ShipsCost"] = Algorithm.Utilities.C[i].ShipsCost;
                NewCR["PortCost"] = Algorithm.Utilities.C[i].PortCost;
                NewCR["FixedCost"] = Algorithm.Utilities.C[i].FixedCost;
                NewCR["VariableCost"] = Algorithm.Utilities.C[i].VariableCost;
                NewCR["FitnessPorts"] = Algorithm.Utilities.C[i].FitnessPorts;
                NewCR["FitnessShips"] = Algorithm.Utilities.C[i].FitnessShips;
                NewCR["Fitness"] = Algorithm.Utilities.C[i].Fitness;
                ds.Tables["Chromosome"].Rows.Add(NewCR);
            }

            for (int i = 0; i < QueQueServices.Count(); i++)
            {
                NewCR = ds.Tables["QueueService"].NewRow();
                NewCR["QID"] = QueQueServices[i].GetID;
                NewCR["VesselID"] = QueQueServices[i].VesselID;
                NewCR["VCategory"] = QueQueServices[i].VCategory;
                NewCR["POP"] = QueQueServices[i].POPSupplyingID;
                NewCR["Direction"] = QueQueServices[i].Direction;
                NewCR["Units"] = QueQueServices[i].Units;
                NewCR["MOV"] = QueQueServices[i].MOV;
                NewCR["CD"] = QueQueServices[i].CurrentDock;
                NewCR["CH"] = QueQueServices[i].CurrentHour;
                NewCR["OD"] = QueQueServices[i].OldDock;
                NewCR["OH"] = QueQueServices[i].OldHour;
                NewCR["TimeInPort"] = QueQueServices[i].TimeInPort;
                //NewCR["ExtraTime"] = QueQueServices[i].ExtraTime;
                NewCR["CrossTime"] = QueQueServices[i].CrossTime;
                NewCR["AwaitingTime"] = QueQueServices[i].AwaitingTime;
                NewCR["DelayTime"] = QueQueServices[i].DelayTime;
                NewCR["ArrivalTime"] = QueQueServices[i].ArrivalTime;
                NewCR["DepartureTime"] = QueQueServices[i].DepartureTime;
                NewCR["OldArrivalTime"] = QueQueServices[i].OldArrivalTime;
                NewCR["OldDepartureTime"] = QueQueServices[i].OldDepartureTime;
                NewCR["Status"] = QueQueServices[i].Status;
                NewCR["ToUse"] = QueQueServices[i].ToUse;
                NewCR["Cost"] = QueQueServices[i].Cost;
                NewCR["FixedCost"] = QueQueServices[i].FixedCost;
                NewCR["VariableCost"] = QueQueServices[i].VariableCost;
                NewCR["ReAlocatedTime"] = QueQueServices[i].ReAllocatedTime;
                NewCR["Fitness"] = QueQueServices[i].Fitness;
                ds.Tables["QueueService"].Rows.Add(NewCR);
            }

            for (int i = 0; i < Ships.Count(); i++)
            {
                NewCR = ds.Tables["Ships"].NewRow();
                NewCR["VesselID"] = Ships[i].VesselID1;
                NewCR["VesselName"] = Ships[i].ShipName1;
                NewCR["VesselType"] = Ships[i].VesselType1;
                NewCR["Fitness"] = Ships[i].Fitness1;
                ds.Tables["Ships"].Rows.Add(NewCR);
            }

            for (int i = 0; i < VesselsTypes.Count(); i++)
            {
                NewCR = ds.Tables["VesselType"].NewRow();
                NewCR["ID"] = VesselsTypes[i].ID1;
                NewCR["AIS"] = VesselsTypes[i].AISVesselTypeDescription1;
                NewCR["Category"] = VesselsTypes[i].VesselTypeCategory1;
                NewCR["ToUse"] = VesselsTypes[i].ToUse1;
                ds.Tables["VesselType"].Rows.Add(NewCR);
            }

            for (int i = 0; i < VesselSizes.Count(); i++)
            {
                NewCR = ds.Tables["VesselSizes"].NewRow();
                NewCR["Generation"] = VesselSizes[i].Generation1;
                NewCR["Year"] = VesselSizes[i].Year1;
                NewCR["TEU"] = VesselSizes[i].TEU1;
                NewCR["LOA"] = VesselSizes[i].LOA1;
                NewCR["BOA"] = VesselSizes[i].BOA1;
                NewCR["Draft"] = VesselSizes[i].Draft1;
                ds.Tables["VesselSizes"].Rows.Add(NewCR);
            }

            for (int i = 0; i < Ports.Count(); i++)
            {
                NewCR = ds.Tables["Ports"].NewRow();
                NewCR["ID"] = Ports[i].ID1;
                NewCR["Description"] = Ports[i].Description1;
                NewCR["Group"] = Ports[i].Group1;
                NewCR["ATime"] = Ports[i].AwaitingTime1;
                NewCR["DelayTime"] = Ports[i].DelayTime;
                NewCR["Earn"] = Ports[i].Earn1;
                NewCR["MovementRate"] = Ports[i].MovementRate1;
                NewCR["Crane"] = Ports[i].Crane1;
                NewCR["EnvironmentConstant"] = Ports[i].EnvironmentConstant1; 
                NewCR["TotalShips"] = Ports[i].TotalShips1;
                NewCR["TotalUnits"] = Ports[i].TotalUnits;
                NewCR["TotalMovs"] = Ports[i].TotalMovs;
                NewCR["Fitness"] = Ports[i].Fitness1;
                ds.Tables["Ports"].Rows.Add(NewCR);
            }

            for (int i = 0; i < DocksArray.Count(); i++)
            {
                NewCR = ds.Tables["Docks"].NewRow();
                NewCR["ID"] = DocksArray[i].ID1;
                NewCR["Description"] = DocksArray[i].Description1;
                NewCR["UnitCapacity"] = DocksArray[i].UnitCapacity1;
                NewCR["UnitCost"] = DocksArray[i].UnitCost1;
                NewCR["TotalShips"] = DocksArray[i].TotalShips;
                NewCR["TotalHours"] = DocksArray[i].TotalHours;
                NewCR["PortID"] = DocksArray[i].POPSupplyingID1;
                NewCR["QtyVesselsToMove"] = DocksArray[i].QtyVesselsToMove;
                ds.Tables["Docks"].Rows.Add(NewCR);
            }

            for (int i = 0; i < Rates.Count(); i++)
            {
                NewCR = ds.Tables["Rates"].NewRow();
                NewCR["OPID"] = Rates[i].OPID1;
                NewCR["RateID"] = Rates[i].RateID1;
                NewCR["Operation"] = Rates[i].Operation1;
                NewCR["Reference"] = Rates[i].Reference1;
                NewCR["BaseRate"] = Rates[i].BaseRate1;
                NewCR["Rate"] = Rates[i].Rate1;
                NewCR["POPSupplyingID"] = Rates[i].POPSupplyingID1;
                ds.Tables["Rates"].Rows.Add(NewCR);
            }


            for (int i = 0; i < Algorithm.Utilities.FitnessHistory.Count(); i++)
            {
                NewCR = ds.Tables["FitnessHistory"].NewRow();
                NewCR["ID"] = Algorithm.Utilities.FitnessHistory[i].ID;
                NewCR["ChromosomeID"] = Algorithm.Utilities.FitnessHistory[i].ChromosomeID;
                NewCR["POPSupplyingID"] = Algorithm.Utilities.FitnessHistory[i].POPSupplyingID;
                NewCR["FitnessPorts"] = Algorithm.Utilities.FitnessHistory[i].FitnessPorts;
                NewCR["FitnessShips"] = Algorithm.Utilities.FitnessHistory[i].FitnessShips;
                NewCR["FitnessChromosome"] = Algorithm.Utilities.FitnessHistory[i].FitnessChromosome;
                ds.Tables["FitnessHistory"].Rows.Add(NewCR);
            }

        }

        public void FillChartTypes(int FitnessType)
        {
            ds.ChartFitnessPorts.Rows.Clear();
            ds.ChartFitnessShips.Rows.Clear();
            ds.ChartFitnessChromosome.Rows.Clear();

            for (int i = 0; i < Algorithm.Utilities.FitnessHistory.Count(); i++)
            {
                switch (FitnessType)
                {
                    case 0:
                        break;

                    case 1:
                        if(Algorithm.Utilities.FitnessHistory[i].ChromosomeID ==0)
                        {
                            NewCR = ds.Tables["ChartFitnessShips"].NewRow();
                            NewCR["Fitness"] = Algorithm.Utilities.FitnessHistory[i].FitnessShips;
                            ds.Tables["ChartFitnessShips"].Rows.Add(NewCR);
                        }
                        

                        break;

                    case 2:
                        break;
                }
            }
        }
        public void LoadVesselsTypes()
        {

            try
            {   
                int cont = 0;
                d = SQL.Query(SQL.GetVesselTypes).ExecuteReader();
                while (d.Read()) cont++;
                SQL.command.Connection.Close();
                TotalVesselTypes = cont;
                VesselsTypes = new VesselType[TotalVesselTypes];

                cont = 0;
                d = SQL.Query(SQL.GetVesselTypes).ExecuteReader();
                while (d.Read())
                {
                    VesselType = new VesselType(Convert.ToInt16(d["VesselTypeID"]), d["AISVesselTypeDescription"].ToString().Trim(), d["VesselTypeCategory"].ToString().Trim(), Convert.ToInt16(d["ToUse"]));
                    VesselsTypes[cont] = VesselType;
                    cont++;
                }
                SQL.command.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " / " + ex.ToString());
            }
        }

        public void LoadVesselsSizes()
        {
            try
            {
                int cont = 0;
                d = SQL.Query(SQL.GetVesselSizes).ExecuteReader();
                while (d.Read()) cont++;
                SQL.command.Connection.Close();
                TotalVesselSizes = cont;
                VesselSizes = new VesselSizes[TotalVesselSizes];

                cont = 0;
                d = SQL.Query(SQL.GetVesselSizes).ExecuteReader();
                while (d.Read())
                {
                    VesselSize = new VesselSizes(Convert.ToInt16(d["Generation"]), Convert.ToInt16(d["Year"]), Convert.ToInt16(d["TEU"]), Convert.ToInt16(d["LOA"]), Convert.ToInt16(d["BOA"]), Convert.ToInt16(d["Draft"]));
                    VesselSizes[cont] = VesselSize;
                    cont++;
                }
                SQL.command.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " / " + ex.ToString());
            }
        }
        public void LoadShips()
        {
            try
            {
                DateTime Today = DateTime.Now;
                Today = Convert.ToDateTime("01/01/1900 00:00:01");
                int cont = 0;

                d = SQL.Query(SQL.GetShips).ExecuteReader();
                while (d.Read()) cont++;
                SQL.command.Connection.Close();
                TotalShips = cont;
                Ships = new POPDemanding[TotalShips];

                cont = 0;
                d = SQL.Query(SQL.GetShips).ExecuteReader();
                while (d.Read())
                {
                    LoadShip = new POPDemanding(Convert.ToInt16(d["IDVessel"]),d["ShipName"].ToString().Trim(),d["IMO"].ToString().Trim(), Convert.ToInt16(d["VesselTypeID"]),0, Convert.ToInt16(d["Units"]),0,Convert.ToDouble(d["LOA"]), Convert.ToDouble(d["BOA"]),0,0,0,0,0);
                    Ships[cont] = LoadShip;
                    cont++;
                }
                SQL.command.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " / " + ex.ToString());
            }
        }

        public void LoadPorts()
        {
            try
            {
                int cont = 0;
                d = SQL.Query(SQL.GetPorts).ExecuteReader();
                while (d.Read()) cont++;
                SQL.command.Connection.Close();
                TotalPorts = cont;
                Ports = new CoEVO.POPSupplying[TotalPorts];

                cont = 0;
                d = SQL.Query(SQL.GetPorts).ExecuteReader();
                while (d.Read())
                {
                    Dock[] Dc = new CoEVO.Dock[GetDocksSizeForPOPID(Convert.ToInt16(d["ID"]))];
                    foreach(Dock D in DocksArray)
                    {
                        if(D.POPSupplyingID1==Convert.ToInt16(d["ID"]))
                        {
                            for(int i=0;i<Dc.Count();i++)
                            {
                                if(Dc[i]==null)
                                {
                                    Dc[i] = D;
                                    i = Dc.Count();
                                }
                            }
                        }
                    }
                    
                    Port = new CoEVO.POPSupplying(Convert.ToInt16(d["ID"]),d["Description"].ToString(),Dc, Convert.ToDouble(d["Earn"]), Convert.ToInt16(d["MovementRate"]), Convert.ToInt16(d["Crane"]),
                                                  Convert.ToDouble(d["EnvironmentConstant"]), Convert.ToInt16(d["Group"]));
                    Ports[cont] = Port;
                    cont++;
                }
                SQL.command.Connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " / " + ex.ToString());
            }
        }

        public void LoadDocks()
        {
            
            int cont = 0;
            d = SQL.Query(SQL.GetDocks).ExecuteReader();
            while (d.Read()) cont++;
            SQL.command.Connection.Close();
            TotalDocks = cont;
            DocksArray = new CoEVO.Dock[TotalDocks];

            cont = 0;
            d = SQL.Query(SQL.GetDocks).ExecuteReader();
            while (d.Read())
            {
                DockUnit = new Dock(Convert.ToInt16(d["ID"]), d["Description"].ToString(), Convert.ToInt32(d["Capacity"]), Convert.ToDouble(d["Cost"]), Convert.ToInt16(d["MaterialType"]),
                                    Convert.ToDouble(d["Performance"]), Convert.ToInt16(d["TotalShips"]), Convert.ToInt16(d["POPSupplyingID"]));
                DocksArray[cont] = DockUnit;
                cont++;
            }
            SQL.command.Connection.Close();
        }

        public void LoadRates()
        {
            int cont = 0;
            d = SQL.Query(SQL.GetRates).ExecuteReader();
            while (d.Read()) cont++;
            SQL.command.Connection.Close();
            Rates = new CoEVO.Rates[cont];

            cont = 0;
            d = SQL.Query(SQL.GetRates).ExecuteReader();
            while (d.Read())
            {
                RateUnit = new Rates(Convert.ToInt16(d["OPID"]), Convert.ToInt16(d["RateID"]), d["Operation"].ToString(), d["Reference"].ToString(), Convert.ToInt16(d["BaseRate"]), Convert.ToDouble(d["Rate"]), Convert.ToInt16(d["POPSupplyingID"]));
                Rates[cont] = RateUnit;
                cont++;
            }
            SQL.command.Connection.Close();
        }

        public void LoadQuequeServices()
        {
            try
            {
                int cont = 0;

                //MessageBox.Show(Globals.From.ToString());
                //MessageBox.Show(Globals.To.ToString());

                d = SQL.Query(SQL.SQLCommand_GetQueQueService(Globals.From.ToString(), Globals.To.ToString(),0)).ExecuteReader();
                while (d.Read()) cont++;
                SQL.command.Connection.Close();
                QueQueServices = new QueueService[cont];
                
                cont = 0;
                d = SQL.Query(SQL.SQLCommand_GetQueQueService(Globals.From.ToString(), Globals.To.ToString(),0)).ExecuteReader();
                while (d.Read())
                {
                    QueQueService = new QueueService(0,Convert.ToInt16(d["VesselID"]), d["VesselTypeCategory"].ToString(), Convert.ToInt16(d["Direction"]), Convert.ToDateTime(d["Date"]), Convert.ToInt16(d["AwaitingTime"]),Convert.ToInt16(d["MOV"]), Convert.ToInt16(d["Status"]), Convert.ToInt16(d["ToUse"]));
                    QueQueServices[cont] = QueQueService;
                    cont++;
                    //Console.WriteLine("Cont: " + cont);
                }
                SQL.command.Connection.Close();
                //QueQueService.RestartID();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " / " + ex.ToString());
            }
        }

        public int GetDocksSizeForPOPID(int POP_ID)
        {
            int cont = 0;
            foreach(Dock D in DocksArray)
            {
                if(D.POPSupplyingID1==POP_ID)
                {
                    cont++;
                }
            }
            return cont;
        }

        public void LoadPOPSupplyingRelations()
        {
                int cont = 0;

                d = SQL.Query(SQL.POPSupplyingRelations).ExecuteReader();
                while (d.Read()) cont++;
                SQL.command.Connection.Close();
                PortsRelations = new CoEVO.POPSupplyingRelations[cont];

                cont = 0;
                d = SQL.Query(SQL.POPSupplyingRelations).ExecuteReader();
                while (d.Read())
                {
                    PortsRelation = new CoEVO.POPSupplyingRelations(Convert.ToInt16(d["POPID"]), Convert.ToInt16(d["Relation"]));
                    PortsRelations[cont] = PortsRelation;
                    cont++;
                }
                SQL.command.Connection.Close();
        }

        public void LoadPOPSupplyingTimes()
        {
            int cont = 0;

            d = SQL.Query(SQL.POPSupplyingTimes).ExecuteReader();
            while (d.Read()) cont++;
            SQL.command.Connection.Close();
            PortTimes = new CoEVO.POPSupplyingTimes[cont];

            cont = 0;
            d = SQL.Query(SQL.POPSupplyingTimes).ExecuteReader();
            while (d.Read())
            {
                PortTime = new CoEVO.POPSupplyingTimes(Convert.ToInt16(d["ID"]), d["Description"].ToString().Trim(), Convert.ToInt16(d["Time"]), Convert.ToInt16(d["TypeTime"]), Convert.ToInt16(d["POPSupplyingID"]));
                PortTimes[cont] = PortTime;
                cont++;
            }
            SQL.command.Connection.Close();
        }

        private void dQueueService_DoubleClickRow(object sender, Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e)
        {
            try
            {
                MessageBox.Show("VesselID: " + Algorithm.Utilities.GetShipIndexByVesselID(Convert.ToInt16(e.Row.Cells["VesselID"].Value)).ShipName1 + "/ LOA:" +
                    Algorithm.Utilities.GetShipIndexByVesselID(Convert.ToInt16(e.Row.Cells["VesselID"].Value)).LOA1 + "/ BOA:" +
                    Algorithm.Utilities.GetShipIndexByVesselID(Convert.ToInt16(e.Row.Cells["VesselID"].Value)).BOA1 + "/ MOV:" +
                    Algorithm.Utilities.GetShipIndexByVesselID(Convert.ToInt16(e.Row.Cells["VesselID"].Value)).MOV1 + "/ Unit:" +
                    Algorithm.Utilities.GetShipIndexByVesselID(Convert.ToInt16(e.Row.Cells["VesselID"].Value)).Units1);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bCheck_Click(object sender, EventArgs e)
        {
            try
            {
                Forms.fViews FViews = new CoEVO.Forms.fViews();
                FViews.ds = this.ds;
                FViews.dsBindingSource = this.dsBindingSource;
                FViews.queueServiceBindingSource = this.fitnessHistoryBindingSource;
                FViews.portsBindingSource = this.portsBindingSource;
                
                //FViews.dQueueService.DataMember = "FitnessHistory";
                FViews.MdiParent = this.MdiParent;
                FViews.Show();
                
                //return;
                //FViews.queueServiceBindingSource = this.queueServiceBindingSource;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ExcelExport(Infragistics.Win.UltraWinGrid.UltraGrid Grid, string FileName)
        {
            try
            {
                Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter Export = new Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter();
                SaveFileDialog Save = new SaveFileDialog();

                Save.Filter = "Excel File (.xlsx) |*.xlsx|Excel File 97-2003 (.xls)|*.xls";
                Save.Title = "Save The QueueService File";
                Save.FileName = FileName;

                if (Save.ShowDialog() == DialogResult.OK)
                {
                    Export.Export(Grid, Save.FileName);
                    MessageBox.Show("Excel File was exported successfully!", "Excel File Exportation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dQueueService_DoubleClick(object sender, EventArgs e)
        {
            ExcelExport(dQueueService, "QueueService Report");           
        }

        private void dSchedule_DoubleClick(object sender, EventArgs e)
        {
            ExcelExport(dSchedule, "Schedulling Report");
        }

        private void dPorts_DoubleClick(object sender, EventArgs e)
        {
            ExcelExport(dSchedule, "POPSupplyings Report");
        }

        private void ProcessRegistration(int ProcessType, int TimeType)
        {
            
            //ProcessType: 1.Load; 2.Allocation; 3.Re-Allocation
            //TimeType: 1.Start; 2.Finish
            string Legend = "";

            if(TimeType==1)
            {
                StartProcess = DateTime.Now;
                Legend = " Start: " + StartProcess;
                Cursor.Current = Cursors.WaitCursor;
            }
            else
            {
                FinishProcess = DateTime.Now;
                Legend = " Finished: " + FinishProcess;
                Cursor.Current = Cursors.Arrow;
            }
            
            switch(ProcessType)
            {
                case 1:
                    Console.WriteLine("Load " + Legend);
                    break;
                case 2:
                    Console.WriteLine("GA " + Legend);
                    break;
                case 3:
                    Console.WriteLine("CoEA " + Legend);
                    break;
            }
            if (TimeType == 2) Console.WriteLine("Total Time: " + (FinishProcess - StartProcess).Minutes);
        }

        private void dSchedule_InitializeLayout(object sender, InitializeLayoutEventArgs e)
        {

        }
    }
}
