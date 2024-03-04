using FHP_Application;
using FHP_BL;
using FHP_DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FHP__INIT
{

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            cls_ValidateUser_BL validateUser_BL = new cls_ValidateUser_BL();
            cls_DataProcessing_BL dataProcessing_BL = new cls_DataProcessing_BL();

            string filePath = Environment.CurrentDirectory + "\\config.ini";
            try
            {
                cls_IniFile iniFile = new cls_IniFile(filePath);

                // Reading values from ini file
                string storageType = iniFile.Read("FileHandler", "StorageType");
                string connectionString = iniFile.Read("FileHandler", "ConnectionString");

                
                if (storageType == "Database")
                {
                    dataProcessing_BL.EmployeeDataObject = new cls_DataHandlerDB_DL(connectionString);
                    validateUser_BL.UserDataObject = new cls_UsersDataDB_DL(connectionString);
                }

                else if (storageType == "FlatFile")
                {
                    dataProcessing_BL.EmployeeDataObject = new cls_DataHandlerFF_DL();
                    validateUser_BL.UserDataObject = new cls_UserDataFF_DL();
                }
            }


            catch (Exception ex)
            {
                MessageBox.Show($"Error reading from INI file \n Applying default configurations [Flat File]: {ex.Message}");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Frm_UserLogin userLogin = new Frm_UserLogin();
            userLogin.SetBLDataProcessingEmpObject = dataProcessing_BL;
            userLogin.SetBLValidateUserObject=validateUser_BL;
            Application.Run(userLogin);

        }
    }
}
