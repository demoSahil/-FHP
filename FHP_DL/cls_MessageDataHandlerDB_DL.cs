using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    public class cls_MessageDataHandlerDB_DL : IDataHandlerMessages
    {
        private readonly string connectionString;
        public cls_MessageDataHandlerDB_DL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public byte GetKey(string shortMessage, string tableName)
        {
            byte key = 0;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string queryString = $"SELECT MessageKey FROM {tableName} WHERE shortMessage=@shortMessage";

                using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                {
                    cmd.Parameters.AddWithValue("@shortMessage", shortMessage);
                    try
                    {
                        cnn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                key = Convert.ToByte(reader["MessageKey"]);
                            }
                        }
                        cnn.Close();
                    }

                    catch (SqlException ex)
                    {
                        throw new cls_DataLayerException("Error while getting message key from database", ex);

                    }

                }
            }

            return key;

        }

        public string GetMessageDesc(byte key,string tableName)
        {
            string messageDesc = "";
            using (SqlConnection cnn = new SqlConnection(connectionString))
            {
                string queryString = $"SELECT MessageDesc FROM {tableName} WHERE MessageKey = @key";
                using (SqlCommand cmd = new SqlCommand(queryString, cnn))
                {
                    cmd.Parameters.AddWithValue("@key", key);

                    try
                    {
                        cnn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                messageDesc = reader["MessageDesc"].ToString();
                            }
                        }
                        cnn.Close();
                    }

                    catch (SqlException ex)
                    {
                        throw new cls_DataLayerException("Error while Reading message from database", ex);
                    }
                }
            }

            return messageDesc;

        }

    }
}
