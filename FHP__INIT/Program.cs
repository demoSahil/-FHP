using FHP_Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            string filePath = Environment.CurrentDirectory + "\\config.ini";

            try
            {
                cls_IniFile iniFile = new cls_IniFile(filePath);

                string storageType = iniFile.Read("FileHandler", "StorageType");
                string connectionString = iniFile.Read("FileHandler", "ConnectionString");

                //------ Defining assembly Locations
                string assemblyBlName = Environment.CurrentDirectory + "\\FHP_BL.dll";
                string assemblyDLName = Environment.CurrentDirectory + "\\FHP_DL.dll";


                //-----------Early Binding--------------\\
                Assembly assemblyBL = Assembly.LoadFrom(assemblyBlName);
                Assembly assemblyDL = Assembly.LoadFrom(assemblyDLName);

                //--------Lazy binding -------------\\
                /* Assembly assemblyBL = Assembly.Load("FHP_BL");
                 Assembly assemblyDL = Assembly.Load("FHP_DL");*/


                object dataProcessing_BL = CreateInstance(assemblyBL, "FHP_BL.cls_DataProcessing_BL");
                object validateUser_BL = CreateInstance(assemblyBL, "FHP_BL.cls_ValidateUser_BL");

                //--------------Injecting  Objects using setter Injections

                if (storageType == "Database")
                {
                    SetPropertyValue(dataProcessing_BL, "EmployeeDataObject", CreateInstance(assemblyDL, "FHP_DL.cls_DataHandlerDB_DL", connectionString));
                    SetPropertyValue(validateUser_BL, "UserDataObject", CreateInstance(assemblyDL, "FHP_DL.cls_UsersDataDB_DL", connectionString));
                }
                else if (storageType == "FlatFile")
                {
                    SetPropertyValue(dataProcessing_BL, "EmployeeDataObject", CreateInstance(assemblyDL, "FHP_DL.cls_DataHandlerFF_DL"));
                    SetPropertyValue(validateUser_BL, "UserDataObject", CreateInstance(assemblyDL, "FHP_DL.cls_UserDataFF_DL"));
                }

                //--------Application Starts from here

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Frm_UserLogin userLogin = new Frm_UserLogin();

                //-----Setting Properties of user login form
                SetPropertyValue(userLogin, "SetBLDataProcessingEmpObject", dataProcessing_BL);
                SetPropertyValue(userLogin, "SetBLValidateUserObject", validateUser_BL);

                Application.Run(userLogin);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while setting Configurations","Something Went Wrong" +ex.Message);

            }
        }

        private static object CreateInstance(Assembly assembly, string className, params object[] parameters)
        {
            Type type = assembly.GetType(className);
            return Activator.CreateInstance(type,parameters);
        }


        private static void SetPropertyValue(object obj, string propertyName, object value)
        {
            Type type = obj.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propertyName);
            propertyInfo.SetValue(obj, value);
        }
    }
}
