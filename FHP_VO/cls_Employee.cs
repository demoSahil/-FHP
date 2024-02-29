using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_ValueObject
{

    /// <summary>
    /// Represents an employee in the system.
    /// </summary>
    public class cls_Employee
    {
        /// <summary>
        /// Gets or sets the serial number of the employee.
        /// </summary>
        public long SerialNo { get; set; }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the employee.
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the prefix of the employee.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the current address of the employee.
        /// </summary>
        public string CurrentAddress { get; set; }

        /// <summary>
        /// Gets or sets the current company of the employee.
        /// </summary>
        public string CurrentCompany { get; set; }

        /// <summary>
        /// Gets or sets the edit mode of the employee.
        /// </summary>
        public byte editMode { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the employee is deleted.
        /// </summary>
        public bool isDeleted { get; set; }

        /// <summary>
        /// Gets or sets the joining date of the employee.
        /// </summary>
        public DateTime JoiningDate { get; set; }

        /// <summary>
        /// Gets or sets the date of birth of the employee.
        /// </summary>
        public DateTime DOB { get; set; }

        /// <summary>
        /// Gets or sets the education level of the employee.
        /// </summary>
        public byte Education { get; set; }

        /// <summary>
        /// Gets or sets the validation message code for the employee.
        /// </summary>
        public byte ValidationMessage { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="cls_Employee"/> class.
        /// </summary>
        public cls_Employee()
        {
            isDeleted = false;
            editMode = 1;

        }

    }
}
