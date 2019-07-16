using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CoEVO
{
    class SQL
    {
        public string SQLServer;
        public string SQLDB;
        public string SQLUser;
        public string SQLPassword;
        public String DB;

        //public String DB = "server=LOO; database=CoEVO_SRSP; Persist Security Info=True;User ID=sa;Password=clave123*";
        //public String DB = "server=190.5.116.210,9096; database=CoEVO_SRSP; Persist Security Info=True;User ID=sa;Password=Server01";
        //public String DB = "server=190.5.116.210,9096; database=CoEVO_SRSP; Persist Security Info=True;User ID=srsp;Password=Password1!*";
        //public String MySQLDB = "server=200.133.2.19/; database=loal; Persist Security Info=True;User ID=loal;Password=xQAXEyCHJXStA6bR";
        //public String MySQLDB = "Server=200.133.2.19;Database=loal1;Uid=loal;Pwd=xQAXEyCHJXStA6bR;";
        public String MySQLDB = "Data Source=127.0.0.1;Initial Catalog=loal;User id=loal;Password=xQAXEyCHJXStA6bR;";

        public SqlConnection conexion;
        public SqlCommand command;
        public SqlDataReader d;

        public MySqlConnection MySqlConexion;
        public MySqlCommand MySqlCommand;
        public MySqlDataReader MySqld;


        public string GetShips = "select * from POPDemanding";
        public string GetVesselTypes = "select * from VesselType";
        public string GetVesselSizes = "select * from VesselSizes order by LOA, BOA";
        public string GetPorts = "select * from POPSupplying where Active=1";
        public string GetDocks = "select t0.* from Dock t0 " +
                                 "inner join POPSupplying t1 on t0.POPSupplyingID=t1.ID " + 
                                 "where t1.Active= 1 ";
        public string GetRates = "select OPID=t0.ID,RateID=t1.ID, t0.Operation, t0.Reference, t1.BaseRate, t1.Rate, t1.POPSupplyingID " +
                                 " from Operation t0 inner join OperationRates t1 on t0.ID=t1.OPTypeID and t1.Active=1";

        public string POPSupplyingRelations = "select t1.POPID,t1.Relation " +
                                              " from POPSupplying t0 inner join POPSupplyingRelations t1 on t0.ID=t1.POPID " +
                                              " where t0.Active=1 and t1.POPID in (select ID from POPSupplying where Active=1)";

        public string POPSupplyingTimes = "select * from POPSupplyingTimes where Active=1";
        
        public string SQLCommand_GetQueQueService(string From, string To, int Direction)
        {
            string Part1 = 
                    " set dateformat dmy " +
                    " Declare @Desde as datetime " +
                    " Declare @Hasta as datetime " +
                    " set @Desde = '" + From + "' set @Hasta = '" + To + "'" +
                    " select t0.VesselID,t2.VesselTypeCategory,t0.[Date] " +
                    " ,AwaitingTime=isnull((select top 1 Datediff(hour,t0.Date,P0.Date) from History P0 where P0.VesselID=t0.VesselID and P0.Direction=t0.Direction and P0.Date>t0.Date),0)" +
                    " ,t0.Direction,t0.PortCall,t0.MOV,t0.Status,t2.ToUse " +
                    " from History t0 " +
                    " inner join POPDemanding t1 on t0.VesselID = t1.IDVessel " +
                    " inner join VesselType t2 on t1.VesselTypeID = t2.VesselTypeID " +
                    " where t0.[Date] " +
                    " between @Desde and @Hasta ";

            string PartMed;

            switch(Direction)
            {
                case 0:
                    PartMed = " and t0.Direction >0 ";
                    break;
                default:
                    PartMed = " and t0.Direction=" + Direction;
                    break;
            }

            string Part2 = " and t0.PortCall like 'Arrival%' " +
                    " and t0.PortCall not like 'Arrival from Panama%' " +
                    " and t0.PortCall not like 'Arrival from Puerto Cortes%' " +
                    " group by t0.VesselID, t2.VesselTypeCategory, t0.[Date], t0.Direction, t0.PortCall, t0.MOV,t0.Status,t2.ToUse " +
                    " order by t0.Direction asc, t0.Date";
            //" order by t0.Direction asc, t0.Date desc";

            return Part1 + PartMed + Part2;
        }
      
        public SqlCommand Query(string Text)
        {
            conexion = new SqlConnection(DB);
            command = new SqlCommand();
            command.Connection = conexion;
            command.CommandText = Text;
            command.Connection.Open();
            return command;
        }

        public MySqlCommand MySqlQuery(string text)
        {
            MySqlConexion = new MySqlConnection(MySQLDB);
            MySqlCommand = new MySqlCommand();
            MySqlCommand.Connection = MySqlConexion;
            MySqlCommand.CommandText = text;
            MySqlCommand.Connection.Open();
            return MySqlCommand;
        }

        public void SetValues()
        {
            var MyIni = new IniFile(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase).Substring(6) + @"\Datos.ini");
            
            SQLServer = MyIni.IniReadValue("SQL","Server");
            SQLDB = MyIni.IniReadValue("SQL", "DB");
            SQLUser = MyIni.IniReadValue("SQL", "User");
            SQLPassword = MyIni.IniReadValue("SQL", "Password");
            DB = "server="+ SQLServer + "; database=" + SQLDB + "; Persist Security Info=True;User ID="+ SQLUser +";Password="+ SQLPassword;
        }
    }
}
