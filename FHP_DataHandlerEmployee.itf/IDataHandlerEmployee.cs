using FHP_ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_DL
{
    /// <summary>
    /// Interface defining methods for handling employee data operations.
    /// </summary>
    public interface IDataHandlerEmployee
    {
        /// <summary>
        /// Appends employee information.
        /// </summary>
        /// <param name="employee">The employee data to be added.</param>
        void AddEmployeeInfoIntoFile(cls_Employee_VO employee);

        /// <summary>
        /// Deletes an employee entry (Not Implemented).
        /// </summary>
        /// <param name="employee">The employee data to be deleted.</param>
        void DeleteEmployeeFromFile(cls_Employee_VO employee);

        /// <summary>
        /// Retrieves all employee data.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        List<cls_Employee_VO> GetAllEmployee();

        /// <summary>
        /// Updates an existing employee entry with new data.
        /// </summary>
        /// <param name="employee">The updated employee data.</param>
        void UpdateEntry(cls_Employee_VO employee);
    }
}
