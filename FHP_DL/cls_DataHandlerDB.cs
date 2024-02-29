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
    public class cls_FileHandler
    {


        /// <summary>
        /// Appends employee information to the database.
        /// </summary>
        /// <param name="employee">The employee data to be added to the database.</param>
        public void AddEmployeeInfoIntoFile(cls_Employee employee)
        {
            try
            {
                string connectionString = "Data Source=SAHIL;Database=FHP;Integrated Security=True;TrustServerCertificate=True";
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
                throw new cls_DataLayerException("Error Connecting to Database!", ex);
            }

        }

        /// <summary>
        /// Deletes an employee entry from the database based on the provided employee data.
        /// </summary>
        /// <param name="empDataToBeDelete">The employee data to be deleted from the database.</param>
        public void DeleteEmployeeFromFile(cls_Employee empDataToBeDelete)
        {

            try
            {
                string connectionString = "Data Source=SAHIL;Database=FHP;Integrated Security=True;TrustServerCertificate=True";
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
                throw new cls_DataLayerException("Error Connecting to Database!", ex);
            }

        }

        /// <summary>
        /// Retrieves all employee data from the database.
        /// </summary>
        /// <returns>A list of all employees stored in the database.</returns>
        public List<cls_Employee> GetAllEmployee()
        {
            try
            {
                string connectionString = "Data Source=SAHIL;Database=FHP;Integrated Security=True;TrustServerCertificate=True";
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();

                    string selectQuery = "SELECT * FROM employee";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<cls_Employee> employees = new List<cls_Employee>();

                            while (reader.Read())
                            {
                                cls_Employee employee = new cls_Employee
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
                                    JoiningDate = Convert.ToDateTime(reader["JoiningDate"])
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
                throw new cls_DataLayerException("Error Connecting to Database!", ex);
            }

        }

        /// <summary>
        /// Updates an existing employee entry in the database with new data.
        /// </summary>
        /// <param name="employee">The updated employee data to replace the existing entry.</param>
        public void UpdateEntry(cls_Employee employee)
        {
            string connectionString = "Data Source=SAHIL;Database=FHP;Integrated Security=True;TrustServerCertificate=True";

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
                throw new cls_DataLayerException("Error Connecting to Database!", ex);
            }
        }


    }
    /// <summary>
    /// Custom exception class for handling errors in the Data layer.
    /// </summary>

   
}
