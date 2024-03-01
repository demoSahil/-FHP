using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    /// <summary>
    /// Custom exception class for handling exceptions occurs in Data Layer
    /// </summary>
    public class cls_DataLayerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="cls_DataLayerSQLException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public cls_DataLayerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

}
