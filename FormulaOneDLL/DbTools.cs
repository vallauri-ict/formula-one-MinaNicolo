using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOneDLL
{
    public class DbTools
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";

        public DbTools() { }

        public void ExecuteSqlScript(string sqlScriptName)
        {
            var fileContent = File.ReadAllText(WORKINGPATH + sqlScriptName);
            fileContent = fileContent.Replace("\r\n", "");
            fileContent = fileContent.Replace("\r", "");
            fileContent = fileContent.Replace("\n", "");
            fileContent = fileContent.Replace("\t", "");
            var sqlqueries = fileContent.Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("query", con);
            con.Open(); int i = 0; int nErr = 0;
            foreach (var query in sqlqueries)
            {
                cmd.CommandText = query; i++;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException err)
                {
                    Console.WriteLine("Errore in esecuzione della query numero: " + i);
                    Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
                }
            }
            string finalMessage = nErr == 0 ? "Script completed without error" : "Script completed with " + nErr + " ERRORS";
            con.Close();
        }

        public void DropTable(string tableName)
        {
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            SqlCommand cmd = new SqlCommand("DROP TABLE IF EXISTS " + tableName + ";", con);
            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException err)
            {
                Console.WriteLine("\tErrore SQL: " + err.Number + " - " + err.Message);
            }
            con.Close();
        }
        public void Backup()
        {
            try
            {
                using (SqlConnection dbConn = new SqlConnection())
                {
                    dbConn.ConnectionString = CONNECTION_STRING;
                    dbConn.Open();

                    using (SqlCommand multiuser_rollback_dbcomm = new SqlCommand())
                    {
                        multiuser_rollback_dbcomm.Connection = dbConn;
                        multiuser_rollback_dbcomm.CommandText = @"ALTER DATABASE [" + WORKINGPATH + "FormulaOne.mdf] SET MULTI_USER WITH ROLLBACK IMMEDIATE";

                        multiuser_rollback_dbcomm.ExecuteNonQuery();
                    }
                    dbConn.Close();
                }

                SqlConnection.ClearAllPools();

                using (SqlConnection backupConn = new SqlConnection())
                {
                    backupConn.ConnectionString = CONNECTION_STRING;
                    backupConn.Open();

                    using (SqlCommand backupcomm = new SqlCommand())
                    {
                        File.Delete(WORKINGPATH + "FormulaOne_Backup.bak");
                        backupcomm.Connection = backupConn;
                        backupcomm.CommandText = @"BACKUP DATABASE [" + WORKINGPATH + "FormulaOne.mdf] TO DISK='" + WORKINGPATH + @"FormulaOne_Backup.bak'";
                        backupcomm.ExecuteNonQuery();

                        Console.WriteLine("Backup database Success\n");
                    }
                    backupConn.Close();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Backup database Failed\n");
                Console.WriteLine(ex.Message);
            }
        }

        public void Restore()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(CONNECTION_STRING))
                {
                    con.Open();
                    string sqlStmt2 = string.Format(@"ALTER DATABASE [" + WORKINGPATH + "FormulaOne.mdf] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStmt2, con);
                    bu2.ExecuteNonQuery();

                    string sqlStmt3 = @"USE MASTER RESTORE DATABASE [" + WORKINGPATH + "FormulaOne.mdf] FROM DISK='" + WORKINGPATH + @"FormulaOne_Backup.bak' WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlStmt3, con);
                    bu3.ExecuteNonQuery();

                    string sqlStmt4 = string.Format(@"ALTER DATABASE [" + WORKINGPATH + "FormulaOne.mdf] SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, con);
                    bu4.ExecuteNonQuery();

                    Console.WriteLine("Restore database Success\n");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Restore database Failed\n");
                Console.WriteLine(ex.ToString());
            }
        }

        public static List<string> GetTables()
        {
            DataTable table = new DataTable();
            List<string> ts = new List<string>();
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            string sql = "SELECT * FROM INFORMATION_SCHEMA.TABLES";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(table);
            foreach (DataRow item in table.Rows)
            {
                ts.Add((item["TABLE_NAME"].ToString()));
            }
            return ts;
        }

        public DataTable GetData(string table)
        {
            DataTable tableData = new DataTable();
            SqlConnection con = new SqlConnection(CONNECTION_STRING);
            string sql = "SELECT * FROM " + table + ";";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            // this will query your database and return the result to your datatable
            da.Fill(tableData);
            con.Close();
            da.Dispose();
            return tableData;
        }

        public List<Country> GetListCountry(bool flag, string isoCode)
        {
            List<Country> retVal = new List<Country>();
            string sql;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                if(!flag)
                    sql = "SELECT * FROM Countries;";
                else
                    sql = $"SELECT * FROM Countries WHERE countryCode = '{isoCode}';";

                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string countryCode = reader.GetString(0);
                    string countryName = reader.GetString(1);
                    Country c = new Country(countryCode, countryName);
                    retVal.Add(c);
                }
            }
            return retVal;
        }
        
        public List<Team> GetListTeams(bool flag,string tCode)
        {
            List<Team> retVal = new List<Team>();
            string sql;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                if(!flag)
                    sql = "SELECT * FROM Team;";
                else
                    sql = $"SELECT * FROM Team WHERE teamCode='{tCode}';";

                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string teamCode = reader.GetString(0);
                    string teamFullName = reader.GetString(1);
                    string teamChief = reader.GetString(2);
                    string teamPowerUnit = reader.GetString(3);
                    string teamBase = reader.GetString(4);
                    string countryCode = reader.GetString(5);
                    string logo = reader.GetString(6);
                    string img = reader.GetString(7);
                    Team t = new Team(teamCode,teamFullName,teamChief,teamPowerUnit,
                        teamBase,countryCode,logo,img);
                    retVal.Add(t);
                }
            }
            return retVal;
        }
        public List<Driver> GetListDriver(bool flag, int driverNum)
        {
            List<Driver> retVal = new List<Driver>();
            string sql;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                if (!flag)
                    sql = "SELECT * FROM Driver;";
                else
                    sql = $"SELECT * FROM Driver WHERE driverNumber = {driverNum};";

                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int driverNumber = reader.GetInt32(0);
                    string driverName = reader.GetString(1);
                    string driverSurname = reader.GetString(2);
                    string teamCode = reader.GetString(3);
                    string countryCode = reader.GetString(4);
                    string img = reader.GetString(5);
                    Driver d = new Driver(driverNumber, driverName, driverSurname,
                        teamCode,countryCode,img);
                    retVal.Add(d);
                }
            }
            return retVal;
        }

        public List<Race> GetListRace(bool flag, int idRace)
        {
            List<Race> retVal = new List<Race>();
            string sql;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                if (!flag)
                    sql = "SELECT * FROM Race;";
                else
                    sql = $"SELECT * FROM Race WHERE idRace = {idRace};";

                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id_Race = reader.GetInt32(0);
                    string nameRace = reader.GetString(1);
                    string circuitId = reader.GetString(2);
                    Race r = new Race(id_Race, nameRace, circuitId);
                    retVal.Add(r);
                }
            }
            return retVal;
        }

        public List<Circuit> GetListCircuit(bool flag, string circuitId)
        {
            List<Circuit> retVal = new List<Circuit>();
            string sql;
            using (SqlConnection dbConn = new SqlConnection())
            {
                dbConn.ConnectionString = CONNECTION_STRING;
                dbConn.Open();
                if (!flag)
                    sql = "SELECT * FROM Circuit;";
                else
                    sql = $"SELECT * FROM Circuit WHERE circuitId = '{circuitId}';";

                SqlCommand cmd = new SqlCommand(sql, dbConn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string circuit_Id = reader.GetString(0);
                    string circuitName = reader.GetString(1);
                    string circuitNation = reader.GetString(2);
                    int turnNumber = reader.GetInt32(3);
                    int circuitLength = reader.GetInt32(4);
                    string fastestLap = reader.GetString(5);
                    string thumbnailImg = reader.GetString(6);
                    string descriptionImg = reader.GetString(7);
                    Circuit c = new Circuit(circuit_Id, circuitName, circuitNation,
                        turnNumber, circuitLength, fastestLap, thumbnailImg, descriptionImg);
                    retVal.Add(c);
                }
            }
            return retVal;
        }
    }
}
