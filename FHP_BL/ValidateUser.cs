using FHP_DL;
using FHP_ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_BL
{
    /// <summary>
    /// Handles the validation and role assignment for user-related operations.
    /// </summary>
    public class ValidateUser
    {
        /// <summary>
        /// Object for reading user data.
        /// </summary>
        ReadUsers readUser;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidateUser"/> class.
        /// </summary>
        public ValidateUser()
        {
            readUser = new ReadUsers();
        }

        /// <summary>
        /// Sets the user role based on provided user credentials and retrieves user permissions.
        /// </summary>
        /// <param name="user">The user data to be validated.</param>
        /// <returns>True if the user is present and valid, false otherwise.</returns>
        private bool SetUserRole(User user)
        {
            readUser.SetValue(user);

            if (user.ErrorMessage.Length > 0)
            {
                return false;
            }
            GetUserPermission(user);
            return true;
        }

        /// <summary>
        /// Validates if the user is present and sets the user role.
        /// </summary>
        /// <param name="user">The user data to be validated.</param>
        /// <returns>True if the user is present and valid, false otherwise.</returns>
        public bool isUserPresent(User user)
        {
                return SetUserRole(user);
        }

        /// <summary>
        /// Retrieves the user permissions based on the user's role.
        /// </summary>
        /// <param name="user">The user data for which permissions are retrieved.</param>
        /// <returns>A dictionary containing permission flags for various operations.</returns>
        public Dictionary<string, bool> GetUserPermission(User user)
        {
            Dictionary<string, bool> permissions = new Dictionary<string, bool>();

            permissions.Add("CanDownGrade", false);
            permissions.Add("CanEdit", false);
            permissions.Add("CanDelete", false);
            permissions.Add("CanRead", false);
            permissions.Add("CanAddEmp", false);
            permissions.Add("CanCreateUsers", false);


            if (user.UserRole == "SUPERADMIN")
            {
                permissions["CanDownGrade"] = true;
                permissions["CanEdit"] = true;
                permissions["CanDelete"] = true;
                permissions["CanRead"] = true;
                permissions["CanAddEmp"] = true;
                permissions["CanCreateUsers"] = true;
            }

            else if (user.UserRole == "ADMIN")
            {
                permissions["CanDownGrade"] = true;
                permissions["CanEdit"] = true;
                permissions["CanDelete"] = true;
                permissions["CanRead"] = true;
                permissions["CanAddEmp"] = true;
            }

            else if (user.UserRole == "GUEST")
            {
                permissions["CanRead"] = true;
            }

            else if (user.UserRole == "SELF")
            {
                permissions["CanEdit"] = true;
                permissions["CanDelete"] = true;
                permissions["CanRead"] = true;
                permissions["CanAddEmp"] = true;
            }

            return permissions;
        }
    }
}
