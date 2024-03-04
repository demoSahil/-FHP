using FHP_ValueObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    /// <summary>
    /// Handles authentication of users against a database.
    /// </summary>
    public class cls_UsersDataDB_DL : IDataHandlerUser
    {
        private readonly string connectionString;

        public cls_UsersDataDB_DL(string connectionString)
        {
            this.connectionString = connectionString;

        }
        /// <summary>
        /// Authenticates a user based on the provided username and password.
        /// </summary>
        /// <param name="user">User object containing username and password.</param>
        /// <returns>True if authentication is successful; false otherwise.</returns>
        public bool AuthenticateUser(cls_User_VO user)
        {
            string connectionString = "Data Source=SAHIL;Database=FHP;Integrated Security=True;TrustServerCertificate=True";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();

                    string selectQuery = "SELECT PasswordHash, UserRole FROM users WHERE UserName=@UserName";

                    using (SqlCommand cmd = new SqlCommand(selectQuery, cnn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", user.UserName);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                byte[] storedPasswordHash = (byte[])reader["PasswordHash"];
                                string userRole = reader["UserRole"].ToString();

                                byte[] enteredPasswordHash = HashPassword(user.Password); //Hashing the password Entered By user    

                                //Comparing the stored hash value with calculated value
                                if (enteredPasswordHash.SequenceEqual(storedPasswordHash))
                                {
                                    user.UserRole = userRole;
                                    return true;
                                }
                                else
                                {
                                    user.ErrorMessage = "Credential Not Valid";
                                    return false;
                                }
                            }
                        }
                    }
                    cnn.Close();

                }
            }
            catch (SqlException ex)
            {
                throw new cls_DataLayerException("Error while Authenticating User!", ex);
            }
            return false;
        }

        /// <summary>
        /// Add the user data into the database (users employee)
        /// </summary>
        /// <param name="user">User object containing username, password and userRole</param>
        public void AddUserData(cls_User_VO user)
        {
            string connectionString = "Data Source=SAHIL;Database=FHP;Integrated Security=True;TrustServerCertificate=True";
            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                {
                    cnn.Open();

                    string insertQuery = "INSERT INTO users(UserName, PasswordHash, UserRole) VALUES (@UserName,@PasswordHash,@UserRole)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, cnn))
                    {
                        cmd.Parameters.AddWithValue("@UserName", user.UserName);
                        cmd.Parameters.AddWithValue("@PasswordHash", user.Password);
                        cmd.Parameters.AddWithValue("@UserRole", user.UserRole);

                        cmd.ExecuteNonQuery();
                    }
                    cnn.Close();

                }
            }
            catch (SqlException ex)
            {
                throw new cls_DataLayerException("Error while adding user!", ex);
            }
        }

        /// <summary>
        /// Hashes the provided password using SHA-256 algorithm.
        /// </summary>
        /// <param name="password">The password to be hashed.</param>
        /// <returns>Byte array representing the hashed password.</returns>
        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
