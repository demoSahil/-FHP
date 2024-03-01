using FHP_ValueObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    /// <summary>
    /// Handles reading from and writing to a database to manage employee data.
    /// </summary>
    public class cls_DataHandlerDB_DL : IDataHandlerEmployee
    {
        private readonly string connectionString;

        public cls_DataHandlerDB_DL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Appends employee information to the database.
        /// </summary>
        /// <param name="employee">The employee data to be added to the database.</param>
        public void AddEmployeeInfoIntoFile(cls_Employee_VO employee)
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();

                    string insertQuery = "INSERT INTO employee(SerialNo, Prefix, FirstName, MiddleName, LastName, DOB, Education, CurrentAddress, CurrentCompany, JoiningDate) " +
                                         "VALUES (@SerialNo, @Prefix, @FirstName, @MiddleName, @LastName, @DOB, @Education, @CurrentAddress, @CurrentCompany, @JoiningDate)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnn))
                    {
                        cmd.Parameters.AddWithValue("@SerialNo", employee.SerialNo);
                        cmd.Parameters.AddWithValue("@Prefix", employee.Prefix);
                        cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                        cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                        cmd.Parameters.AddWithValue("@DOB", employee.DOB);
                        cmd.Parameters.AddWithValue("@Education", employee.Education);
                        cmd.Parameters.AddWithValue("@CurrentAddress", employee.CurrentAddress);
                        cmd.Parameters.AddWithValue("@CurrentCompany", employee.CurrentCompany);
                        cmd.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new cls_DataLayerException("Error while adding employee details!", ex);
            }

        }

        /// <summary>
        /// Deletes an employee entry from the database based on the provided employee data.
        /// </summary>
        /// <param name="empDataToBeDelete">The employee data to be deleted from the database.</param>
        public void DeleteEmployeeFromFile(cls_Employee_VO empDataToBeDelete)
        {

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();
                    String deleteQuery = "DELETE FROM employee WHERE SerialNo=@SerialNo";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, cnn))
                    {
                        cmd.Parameters.AddWithValue("@SerialNo", empDataToBeDelete.SerialNo);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new cls_DataLayerException("Error while deleting employee details!", ex);
            }

        }

        /// <summary>
        /// Retrieves all employee data from the database.
        /// </summary>
        /// <returns>A list of all employees stored in the database.</returns>
        public List<cls_Employee_VO> GetAllEmployee()
        {
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();

                    string selectQuery = "SELECT * FROM employee";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<cls_Employee_VO> employees = new List<cls_Employee_VO>();

                            while (reader.Read())
                            {
                                cls_Employee_VO employee = new cls_Employee_VO
                                {
                                    SerialNo = Convert.ToInt64(reader["SerialNo"]),
                                    Prefix = reader["Prefix"].ToString(),
                                    FirstName = reader["FirstName"].ToString(),
                                    MiddleName = reader["MiddleName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    DOB = Convert.ToDateTime(reader["DOB"]),
                                    Education = Convert.ToByte(reader["Education"]),
                                    CurrentAddress = reader["CurrentAddress"].ToString(),
                                    CurrentCompany = reader["CurrentCompany"].ToString(),
                                    JoiningDate = Convert.ToDateTime(reader["JoiningDate"]),
                                    editMode = (byte)Resources.Resource.EditMode.edit
                                };

                                employees.Add(employee);
                            }

                            return employees;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new cls_DataLayerException("Error while retrieving employees details!", ex);
            }

        }

        /// <summary>
        /// Updates an existing employee entry in the database with new data.
        /// </summary>
        /// <param name="employee">The updated employee data to replace the existing entry.</param>
        public void UpdateEntry(cls_Employee_VO employee)
        {

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();

                    string updateQuery = "UPDATE employee SET " +
                                         "Prefix = @Prefix, " +
                                         "FirstName = @FirstName, " +
                                         "MiddleName = @MiddleName, " +
                                         "LastName = @LastName, " +
                                         "Education = @Education, " +
                                         "JoiningDate = @JoiningDate, " +
                                         "CurrentCompany = @CurrentCompany, " +
                                         "CurrentAddress = @CurrentAddress, " +
                                         "DOB = @DOB " +
                                         "WHERE SerialNo = @SerialNo";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, cnn))
                    {
                        cmd.Parameters.AddWithValue("@SerialNo", employee.SerialNo);
                        cmd.Parameters.AddWithValue("@Prefix", employee.Prefix);
                        cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                        cmd.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                        cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                        cmd.Parameters.AddWithValue("@Education", employee.Education);
                        cmd.Parameters.AddWithValue("@JoiningDate", employee.JoiningDate);
                        cmd.Parameters.AddWithValue("@CurrentCompany", employee.CurrentCompany);
                        cmd.Parameters.AddWithValue("@CurrentAddress", employee.CurrentAddress);
                        cmd.Parameters.AddWithValue("@DOB", employee.DOB);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new cls_DataLayerException("Error while updating employee details!", ex);
            }
        }
    }
}
