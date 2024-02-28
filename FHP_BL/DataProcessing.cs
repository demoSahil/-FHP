using FHP_DL;
using FHP_ValueObject;
using Resources;
using System;
using System.Collections.Generic;

namespace FHP_BL
{
    /// <summary>
    /// Represents the business logic layer for data processing.
    /// </summary>
    public class DataProcessing
    {
        /// <summary>
        /// Object for file handling.
        /// </summary>
        FileHandler fileHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProcessing"/> class.
        /// </summary>
        public DataProcessing()
        {
            fileHandler=new FileHandler();
        }

        /// <summary>
        /// Saves employee data into a file.
        /// </summary>
        /// <param name="employee">The employee data to be saved.</param>
        /// <param name="resource">Resource object for additional functionality.</param>
        /// <returns>True if the data is saved successfully, otherwise false.</returns>
        public bool SaveIntoFile(Employee employee,Resource resource)
        {
            if (isValid(employee,resource))
            {
                if (employee.editMode == 1)
                {
                    fileHandler.AddEmployeeInfoIntoFile(employee);

                } // Adding a new Record

                else if (employee.editMode == 2)
                {
                    fileHandler.UpdateEntry(employee);
                } // Updating a present Record

                return true;

            } // if employee has valid details

            return false;
        }

        /// <summary>
        /// Checks if the employee data is valid.
        /// </summary>
        /// <param name="employee">The employee data to be validated.</param>
        /// <param name="resource">Resource object for additional functionality.</param>
        /// <returns>True if the employee data is valid, otherwise false.</returns>
        private bool isValid(Employee employee,Resource resource)
        {
            bool isValid = true;

            //--------------- Validating Empty fields--------------\\

            //------First Name
            if (string.IsNullOrEmpty(employee.FirstName) || string.IsNullOrWhiteSpace(employee.FirstName))
            {
                isValid = false;
                employee.ValidationMessage = (byte)Resource.ValidationMessage.FirstNameEmpty;
            }

            //------Current Company 
            else if (string.IsNullOrEmpty(employee.CurrentCompany) || string.IsNullOrWhiteSpace(employee.CurrentCompany))
            {
                isValid = false;
                employee.ValidationMessage = (byte)Resource.ValidationMessage.CurrentCompanyEmpty;
            }

            //------Education
            else if (employee.Education == 255)
            {
                isValid = false;
                employee.ValidationMessage = (byte)Resource.ValidationMessage.QualificationEmpty;
            }

            //-----------Validating fields length-------------\\

            //------First Name
            else if (employee.FirstName.Length > 50)
            {
                isValid = false;
                employee.ValidationMessage = (byte)Resource.ValidationMessage.FirstNameTooLong;
            }

            //------ Last Name
            else if (employee.LastName.Length > 50)
            {
                isValid = false;
                employee.ValidationMessage = (byte)Resource.ValidationMessage.LastNameTooLong;
            }

            //------ Middle Name
            else if (employee.MiddleName.Length > 25)
            {
                isValid = false;
                employee.ValidationMessage = (byte)Resource.ValidationMessage.MiddleNameTooLong;
            }

            //------ Current Address
            else if (employee.CurrentAddress.Length > 500)
            {
                isValid = false;
                employee.ValidationMessage = (byte)Resource.ValidationMessage.CurrentAddressTooLong;

            }

            //------ Current Company
            else if (employee.CurrentCompany.Length > 255)
            {
                isValid = false;
                employee.ValidationMessage = (byte)Resource.ValidationMessage.CurrentCompanyTooLong;

            }

            //----------------Validating User Age-----------------\\

            DateTime dob = employee.DOB;
            int dobYear = dob.Year;

            DateTime joiningDate = employee.JoiningDate;
            int joiningYear = joiningDate.Year;

            if(joiningYear<dobYear || joiningYear - dobYear <= 18 || joiningYear-dobYear>=90)
            {
                isValid = false;
                employee.ValidationMessage = (byte)Resource.ValidationMessage.AgeLimit;
            }



            return isValid;


        }

        /// <summary>
        /// Retrieves a list of all employees.
        /// </summary>
        /// <returns>A list of Employee objects.</returns>
        public List<Employee> GetEmployees()
        {
            return fileHandler.GetAllEmployee();
        }

        /// <summary>
        /// Deletes an employee data from the file.
        /// </summary>
        /// <param name="empDataToBeDelete">The employee data to be deleted.</param>
        /// <param name="resource">Resource object for additional functionality.</param>
        /// <returns>True if the employee data is deleted successfully, otherwise false.</returns>
        public bool DeleteEmployee(Employee empDataToBeDelete, Resource resource)
        {
            if (empDataToBeDelete.editMode != 3)
            {
                empDataToBeDelete.isDeleted = true;
                fileHandler.DeleteEmployeeFromFile(empDataToBeDelete);
                return true;

            } // Means the user is not readOnly user 

            empDataToBeDelete.ValidationMessage = (byte)Resource.ValidationMessage.ReadOnlyUserCannotDelete;
            return false;        // returning false means that user is readOnly user cannot delete data
        }
    }
}
