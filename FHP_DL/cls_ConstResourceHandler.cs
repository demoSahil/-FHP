using Resources;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    /// <summary>
    /// Gets the Description which will be used by application to indicate any message/Validation to the user 
    /// </summary>
    public class cls_ConstResourceHandler
    {
        //------------- currently Working on it

        /// <summary>
        /// Gets the Description from the database for particular shortName provided
        /// </summary>
        /// <param name="shortName"> the short name for description</param>
        /// <param name="tableName"> table name from which description is to be extracted</param>
        public void GetDescription(string shortName, string tableName)
        {
            using (SqlConnection cnn = new SqlConnection(""))
            {
                cnn.Open();
                string query = $"SELECT Description FROM {tableName} WHERE ShortName=@ShortName";
                using (SqlCommand cmd = new SqlCommand(query,cnn))
                {

                    cmd.Parameters.AddWithValue("@ShortName", shortName);

                    cmd.ExecuteNonQuery();

                }

            }
        }
    }
}
