using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_BL
{
    /// <summary>
    /// Custom exception class for handling errors in the business layer.
    /// </summary>
    public class cls_BusinessLayerException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="cls_BusinessLayerException"/> class with a specified error message
        /// and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public cls_BusinessLayerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
