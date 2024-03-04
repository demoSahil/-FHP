using FHP_ValueObject;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{

    /// <summary>
    /// Handles reading from and writing to a flat file to manage employee data.
    /// </summary>
    public class cls_DataHandlerFF_DL : IDataHandlerEmployee
    {
        private string filePath = Environment.CurrentDirectory + "\\fhp.abc";

        /// <summary>
        /// Appends employee information to the flat file.
        /// </summary>
        /// <param name="employee">The employee data to be added to the flat file.</param>
        public void AddEmployeeInfoIntoFile(cls_Employee_VO employee)
        {
            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Append)))
                {
                    writer.Write(employee.SerialNo);
                    writer.Write(employee.Prefix);
                    writer.Write(employee.FirstName);
                    writer.Write(employee.MiddleName);
                    writer.Write(employee.LastName);
                    writer.Write(employee.Education);
                    writer.Write(employee.JoiningDate.ToBinary());
                    writer.Write(employee.CurrentCompany);
                    writer.Write(employee.CurrentAddress);
                    writer.Write(employee.DOB.ToBinary());
                }
            }
            catch (Exception ex)
            {
                throw new cls_DataLayerException("Error While adding employee", ex);
            }
        }

        /// <summary>
        /// Deletes an employee entry from the flat file (Not Implemented).
        /// </summary>
        /// <param name="employee">The employee data to be deleted from the flat file.</param>
        public void DeleteEmployeeFromFile(cls_Employee_VO employee)
        {
            List<cls_Employee_VO> employees = GetAllEmployee();    // Getting all employees

            cls_Employee_VO empToBeDeleted = employees.Where(t => t.SerialNo == employee.SerialNo).FirstOrDefault(); // Getting the employe to be delete

            employees.Remove(empToBeDeleted); // Removing that employee

            File.Delete(filePath);

            foreach (cls_Employee_VO emp in employees)
            {
                AddEmployeeInfoIntoFile(emp);

            }
        }

        /// <summary>
        /// Retrieves all employee data from the flat file.
        /// </summary>
        /// <returns>A list of all employees stored in the flat file.</returns>

        public List<cls_Employee_VO> GetAllEmployee()
        {
            try
            {
                List<cls_Employee_VO> employees = new List<cls_Employee_VO>();
                if (File.Exists(filePath))
                {
                    using (BinaryReader reader = new BinaryReader(File.OpenRead(filePath)))
                    {
                        while (reader.BaseStream.Position < reader.BaseStream.Length)
                        {
                            cls_Employee_VO employee = new cls_Employee_VO();
                            employee.SerialNo = reader.ReadInt64();
                            employee.Prefix = reader.ReadString();
                            employee.FirstName = reader.ReadString();
                            employee.MiddleName = reader.ReadString();
                            employee.LastName = reader.ReadString();
                            employee.Education = reader.ReadByte();
                            employee.JoiningDate = DateTime.FromBinary(reader.ReadInt64());
                            employee.CurrentCompany = reader.ReadString();
                            employee.CurrentAddress = reader.ReadString();
                            employee.DOB = DateTime.FromBinary(reader.ReadInt64());
                            employee.editMode = (byte)Resources.Resource.EditMode.edit;
                            employees.Add(employee);
                        }
                    }
                }
                return employees;
            }
            catch (Exception ex)
            {
                throw new cls_DataLayerException("Error while retrieving employees detials", ex);
            }
        }


        /// <summary>
        /// Updates an existing employee entry in the flat file with new data.
        /// </summary>
        /// <param name="employee">The updated employee data to replace the existing entry.</param>

        public void UpdateEntry(cls_Employee_VO employee)
        {
            List<cls_Employee_VO> employees = GetAllEmployee();
            cls_Employee_VO presentEmp = employees.Where(t => t.SerialNo == employee.SerialNo).FirstOrDefault();

            if (presentEmp != null)
            {
                presentEmp.Prefix = employee.Prefix;
                presentEmp.FirstName = employee.FirstName;
                presentEmp.MiddleName = employee.MiddleName;
                presentEmp.LastName = employee.LastName;
                presentEmp.Education = employee.Education;
                presentEmp.JoiningDate = employee.JoiningDate;
                presentEmp.CurrentCompany = employee.CurrentCompany;
                presentEmp.CurrentAddress = employee.CurrentAddress;
                presentEmp.DOB = employee.DOB;
            }
            File.Delete(filePath);
            foreach (cls_Employee_VO emp in employees)
            {
                AddEmployeeInfoIntoFile(emp);
            }
        }
    }
}
