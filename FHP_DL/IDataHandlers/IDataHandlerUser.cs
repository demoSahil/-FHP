using FHP_ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    /// <summary>
    /// Interface for handling user data operations.
    /// </summary>
    public interface IDataHandlerUser
    {
        /// <summary>
        /// Authenticates a user based on provided user data.
        /// </summary>
        /// <param name="user">The user data to be authenticated.</param>
        /// <returns>True if the user is authenticated, false otherwise.</returns>
        bool AuthenticateUser(cls_User_VO user);

        /// <summary>
        /// Adds user data to the data store.
        /// </summary>
        /// <param name="user">The user data to be added.</param>
        void AddUserData(cls_User_VO user);

    }
}
