﻿using System;
using System.Data.SqlClient;
using System.IO;

namespace FormulaOneConsole
{
    class Program
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private const string CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";
        static void Main(string[] args)
        {          
            char scelta = ' ';
            do
            {
                Console.WriteLine("*** FORMULA ONE - BATCH OPERATIONS ***");
                Console.WriteLine("1 - Create Countries");
                Console.WriteLine("2 - Create Teams");
                Console.WriteLine("3 - Create Drivers");
                Console.WriteLine("4 - Create Circuits");
                Console.WriteLine("5 - Create Races");
                Console.WriteLine("6 - Create RacesScores");
                Console.WriteLine("7 - Create Scores");
                Console.WriteLine("8 - Set Constraints");
                Console.WriteLine("------------------");
                Console.WriteLine("R - Reset");
                Console.WriteLine("------------------");
                Console.WriteLine("X - EXIT\n");
                scelta = Console.ReadKey(true).KeyChar;
                switch (scelta)
                {
                    case '1':
                        callExecuteSqlScript("Countries");
                        break;
                    case '2':
                        callExecuteSqlScript("Teams");
                        break;
                    case '3':
                        callExecuteSqlScript("Drivers");
                        break;
                    case '4':
                        callExecuteSqlScript("Circuits");
                        break;
                    case '5':
                        callExecuteSqlScript("Races");
                        break;
                    case '6':
                        callExecuteSqlScript("RacesScores");
                        break;
                    case '7':
                        callExecuteSqlScript("Scores");
                        break;
                    case '8':
                        callExecuteSqlScript("SetConstraints");
                        break;
                    case 'R':
                        bool OK;
                        //System.IO.File.Copy(DbTools.WORKINGPATH + "FormulaOne.mdf", DbTools.WORKINGPATH + "Backup.mdf");
                        OK = callDropTable("RacesScores");
                        if (OK) OK = callDropTable("Scores");
                        if (OK) OK = callDropTable("Races");
                        if (OK) OK = callDropTable("Circuits");
                        if (OK) OK = callDropTable("Teams");
                        if (OK) OK = callDropTable("Drivers");
                        if (OK) OK = callDropTable("Countries");
                        if (OK) OK = callExecuteSqlScript("Countries");
                        if (OK) OK = callExecuteSqlScript("Drivers");
                        if (OK) OK = callExecuteSqlScript("Teams");
                        if (OK) OK = callExecuteSqlScript("Circuits");
                        if (OK) OK = callExecuteSqlScript("Races");
                        if (OK) OK = callExecuteSqlScript("Scores");
                        if (OK) OK = callExecuteSqlScript("RacesScores");
                        if (OK) OK = callExecuteSqlScript("SetConstraints");
                        if (OK)
                        {
                            //System.IO.File.Delete(DbTools.WORKINGPATH + "Backup.mdf");
                            Console.WriteLine("OK");
                        }
                        else
                        {
                            //System.IO.File.Copy(DbTools.WORKINGPATH + "Backup.mdf", DbTools.WORKINGPATH + "FormulaOne.mdf", true);
                            //System.IO.File.Delete(DbTools.WORKINGPATH + "Backup.mdf");
                        }
                        break;
                    default:
                        if (scelta != 'X' && scelta != 'x') Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
        }

        public static bool callExecuteSqlScript(string scriptName)
        {
            try
            {
                ExecuteSqlScript(scriptName + ".sql");
                Console.WriteLine("\nCreate " + scriptName + " - SUCCESS\n");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nCreate " + scriptName + " - ERROR: " + ex.Message + "\n");
                return false;
            }
        }

        public static bool callDropTable(string tableName)
        {
            try
            {
                DropTable(tableName);
                Console.WriteLine("\nDROP " + tableName + " - SUCCESS\n");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nDROP " + tableName + " - ERROR: " + ex.Message + "\n");
                return false;
            }
        }

        public static void ExecuteSqlScript(string sqlScriptName)
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
            string finalMessage = nErr == 0 ? "Script completed without error" : "Script completed with "+nErr+" ERRORS";
            con.Close();
        }

        public static void DropTable(string tableName)
        {
            var con = new SqlConnection(CONNECTION_STRING);
            var cmd = new SqlCommand("Drop Table " + tableName + ";", con);
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
    }
}
