using System;
using System.Data.SqlClient;
using System.IO;
using FormulaOneDLL;

namespace FormulaOneConsole
{
    class Program
    {
        public const string WORKINGPATH = @"C:\data\formulaone\";
        private static string DB_PATH = System.Environment.CurrentDirectory;
        private const string RESTORE_CONNECTION_STRING = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + WORKINGPATH + @"FormulaOne.mdf;Integrated Security=True";

        static DbTools dbt = new DbTools();
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
                Console.WriteLine("6 - Create Results");
                Console.WriteLine("7 - Create Constraints");
                Console.WriteLine("8 - Delete Constraints");
                Console.WriteLine("------------------");
                Console.WriteLine("R - RESET DB");
                Console.WriteLine("B - Backup all DB");
                Console.WriteLine("T - Restore DB");
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
                        callExecuteSqlScript("Results");
                        break;
                    case '7':
                        callExecuteSqlScript("setConstraints");
                        break;
                    case '8':
                            callExecuteSqlScript("deleteConstraints");
                            break;
                    case 'B':
                        dbt.Backup();
                        break;
                    case 'T':
                        dbt.Restore();
                        break;
                    case 'R':
                        bool OK;
                            
                        OK = callDropTable("deleteConstraints");
                        if (OK) OK = callDropTable("setConstraints");
                        if (OK) OK = callDropTable("Countries");
                        if (OK) OK = callDropTable("Teams");
                        if (OK) OK = callDropTable("Drivers");
                        if (OK) OK = callDropTable("Circuits");
                        if (OK) OK = callDropTable("Races");
                        if (OK) OK = callDropTable("Results");

                        if (OK) OK = callExecuteSqlScript("Countries");
                        if (OK) OK = callExecuteSqlScript("Teams");
                        if (OK) OK = callExecuteSqlScript("Drivers");
                        if (OK) OK = callExecuteSqlScript("Circuits");
                        if (OK) OK = callExecuteSqlScript("Races");
                        if (OK) OK = callExecuteSqlScript("Results");
                        if (OK) OK = callExecuteSqlScript("setConstraints");
                        if (OK)
                            Console.WriteLine("RESET DB OK");
                        break;
                    case 'X': break;

                    default:
                        if (scelta != 'X' && scelta != 'x') Console.WriteLine("\nUncorrect Choice - Try Again\n");
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
        }

        static bool callDropTable(string tableName)
        {
            try
            {
                dbt.DropTable(tableName);
                Console.WriteLine("\nDROP " + tableName + " - SUCCESS\n");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nDROP " + tableName + " - ERROR: " + ex.Message + "\n");
                return false;
            }
        }

        public static bool callExecuteSqlScript(string scriptName)
        {
            try
            {
                dbt.ExecuteSqlScript(scriptName + ".sql");
                Console.WriteLine("\nCreate " + scriptName + " - SUCCESS\n");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nCreate " + scriptName + " - ERROR: " + ex.Message + "\n");
                return false;
            }
        }
    }
}
