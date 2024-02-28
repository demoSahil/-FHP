using FHP_ValueObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    /// <summary>
    /// Handles reading from and writing to a binary file to manage employee data.
    /// </summary>
    public class FileHandler
    {

        private string filePath = Properties.Resources.filePath;

        /// <summary>
        /// Appends employee information to the binary file.
        /// </summary>
        /// <param name="employee">The employee data to be added to the file.</param>
        public void AddEmployeeInfoIntoFile(Employee employee)
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
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// Deletes an employee entry from the file based on the provided employee data.
        /// </summary>
        /// <param name="empDataToBeDelete">The employee data to be deleted from the file.</param>
        public void DeleteEmployeeFromFile(Employee empDataToBeDelete)
        {
            List<Employee> employees = GetAllEmployee();    // Getting all employees

            Employee empToBeDelted = employees.Where(t => t.SerialNo == empDataToBeDelete.SerialNo).FirstOrDefault(); // Getting the employe to be delete

            employees.Remove(empToBeDelted); // Removing that employee

            File.Delete(filePath);

            foreach (Employee emp in employees)
            {
                AddEmployeeInfoIntoFile(emp);

            }
        }

        /// <summary>
        /// Retrieves all employee data from the binary file.
        /// </summary>
        /// <returns>A list of all employees stored in the file.</returns>
        public List<Employee> GetAllEmployee()
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                if (File.Exists(filePath))
                {


                    using (BinaryReader reader = new BinaryReader(File.OpenRead(filePath)))
                    {
                        while (reader.BaseStream.Position < reader.BaseStream.Length)
                        {
                            // ----------- getting all the trainee from the file
                            Employee employee = new Employee();
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

                            employees.Add(employee);
                        }
                    }
                }
                return employees;
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// Updates an existing employee entry in the file with new data.
        /// </summary>
        /// <param name="employee">The updated employee data to replace the existing entry.</param>
        public void UpdateEntry(Employee employee)
        {
            List<Employee> employees = GetAllEmployee();
            Employee presentEmp = employees.Where(t => t.SerialNo == employee.SerialNo).FirstOrDefault();
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
            foreach (Employee emp in employees)
            {
                AddEmployeeInfoIntoFile(emp);
            }
        }


    }
}
