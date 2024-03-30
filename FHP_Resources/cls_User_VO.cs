using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_ValueObject
{
    /// <summary>
    /// Represents an User in the system
    /// </summary>
    public class cls_User_VO
    {
        /// <summary>
        /// Gets or sets the username for the User 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password for the user
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the user role for the user
        /// </summary>
        public string UserRole { get; set; }

        /// <summary>
        /// Gets or sets the Error Message for the user operation
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Constructor of user class
        /// </summary>
        public cls_User_VO()
        {
            ErrorMessage = string.Empty;
        }
    }
}
