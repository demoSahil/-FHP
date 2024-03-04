using FHP_DL;
using IniParser;
using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FHP_Application
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Instantiate data handler interfaces for user and employee data
            IDataHandlerUser dataHandlerUser = null;
            IDataHandlerEmployee dataHandlerEmployee = null;
            IDataHandlerMessages dataHandlerMessages = null;

            string filePath = Environment.CurrentDirectory + "\\config.ini";
            try
            {
                cls_IniFile iniFile = new cls_IniFile(filePath);

                // Reading values from ini file
                string storageType = iniFile.Read("FileHandler", "StorageType");
                string connectionString = iniFile.Read("FileHandler", "ConnectionString");

                if (storageType == "Database")
                {
                    dataHandlerEmployee = new cls_DataHandlerDB_DL(connectionString);
                    dataHandlerUser = new cls_UsersDataDB_DL(connectionString);
                    dataHandlerMessages = new cls_MessageDataHandlerDB_DL(connectionString);
                }

                else if (storageType == "FlatFile")
                {
                    dataHandlerEmployee = new cls_DataHandlerFF_DL();
                    dataHandlerUser = new cls_UserDataFF_DL();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show($"Error reading from INI file \n Applying default configurations [Flat File]: {ex.Message}");
            }

            finally
            {
                // In case when there is problem reading ini file  by default consideration will be flat file
                if (dataHandlerUser == null && dataHandlerEmployee == null)
                {
                    dataHandlerEmployee = new cls_DataHandlerFF_DL();
                    dataHandlerUser = new cls_UserDataFF_DL();
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_UserLogin(dataHandlerEmployee, dataHandlerUser,dataHandlerMessages));
        }
    }
}
