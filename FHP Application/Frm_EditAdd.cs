using FHP_BL;
using FHP_DL;
using FHP_ValueObject;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Resources.Resource;

namespace FHP_Application
{
    /// <summary>
    /// Partial class for the form responsible for editing, viewing or adding employees.
    /// </summary>
    public partial class Frm_EditAdd : Form
    {
        //------------------------------Data members--------------------------------\\
        /// <summary>
        /// Represents the employee being edited or added.
        /// </summary>
        cls_Employee_VO employee;

        /// <summary>
        /// Object for handling data processing operations.
        /// </summary>
        cls_DataProcessing_BL dataProcessing;

        /// <summary>
        /// Object containing constant messages and resources.
        /// </summary>
        Resource resource;

        /// <summary>
        /// List of employees to be displayed.
        /// </summary>
        private List<cls_Employee_VO> employees;

        /// <summary>
        /// Index of the currently viewed employee.
        /// </summary>
        private int currentIndexOfEmployee;

        /// <summary>
        /// Dictionary containing the current user's permissions, indicating access rights for various operations.
        /// </summary>
        Dictionary<string, bool> userPermissions;

        /// <summary>
        /// Represents in which mode user is opening this form
        /// </summary>
        String openMode;

        IDataHandlerMessages dataHandlerMessages;

        //---------------------------------Constructor----------------------------------\\

        /// <summary>
        /// Constructor for the Frm_EditAdd form, responsible for initializing form components and handling different operational modes.
        /// </summary>
        /// <param name="employee">The employee data being edited or added.</param>
        /// <param name="dataProcessing">An instance of the DataProcessing class for handling data operations.</param>
        /// <param name="resource">An instance of the Resource class providing access to application resources.</param>
        /// <param name="openMode">The operational mode of the form (Add, Edit, or View).</param>
        /// <param name="userPermissions">Optional dictionary containing user permissions for specific actions.</param>
        /// <param name="employees">Optional list of employees for navigation when viewing multiple records.</param>
        public Frm_EditAdd(IDataHandlerMessages dataHandlerMessage,cls_Employee_VO employee, cls_DataProcessing_BL dataProcessing, Resource resource, string openMode, [Optional] Dictionary<string, bool> userPermissions, [Optional] List<cls_Employee_VO> employees)
        {
            InitializeComponent();


            this.employee = employee;
            this.dataProcessing = dataProcessing;
            this.resource = resource;
            this.userPermissions = userPermissions;
            this.openMode = openMode;
            this.employees = employees;
            this.dataHandlerMessages= dataHandlerMessage;

            //------------- AddingDrop Down List for Qualification --------------\\
            foreach (Resource.QualificationEnum value in Enum.GetValues(typeof(Resource.QualificationEnum)))
            {
                var descriptionAttribute = (DescriptionAttribute[])value.GetType().GetField(value.ToString())
                                                               .GetCustomAttributes(typeof(DescriptionAttribute), false);
                string description = descriptionAttribute.Length > 0 ? descriptionAttribute[0].Description : value.ToString();
                comboBox_Qualification.Items.Add(description);
            }

            EnableRequiredFields(openMode);

            if (openMode == "Add")
            {
                btn_Add.Enabled = true;
                btn_Edit.Enabled = false;

                txtBox_SerialNoEditAdd.Text = employee.SerialNo.ToString();

                date_DOB.Value = DateTimePicker.MinimumDateTime;
                date_DOB.CustomFormat = " ";
                date_DOB.Format = DateTimePickerFormat.Custom;

                date_Joining.Value = DateTimePicker.MinimumDateTime;
                date_Joining.CustomFormat = " ";
                date_Joining.Format = DateTimePickerFormat.Custom;
            } // editMode = Add

            else if (openMode == "Edit")
            {
                btn_Add.Enabled = false;
                btn_Edit.Enabled = true;

                txtBox_SerialNoEditAdd.Text = employee.SerialNo.ToString();

                //------------------Showing Fields That can be edited----------------\\
                ShowingFields(employee);

            }  // editMode=Edit

            else if (openMode == "View")
            {
                this.currentIndexOfEmployee = employees.IndexOf(employee);

                //----- If there exists Only single record
                if (employees.Count == 1)
                {
                    btn_FirstRecord.Enabled = false;
                    btn_Last.Enabled = false;
                    btn_Previous.Enabled = false;
                    btn_Next.Enabled = false;
                }

                else if (currentIndexOfEmployee == 0)
                {
                    btn_FirstRecord.Enabled = false;
                    btn_Previous.Enabled = false;
                }

                else if (currentIndexOfEmployee == employees.Count - 1)
                {
                    btn_Next.Enabled = false;
                    btn_Last.Enabled = false;
                }
                ShowingFields(employee);

            }




        }

        //------------------------------------Events---------------------------------------\\

        private void Form_Model_EditAdd_Load(object sender, EventArgs e)
        {

        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //---------------------Setting properties--------------------\\
            TakingInputsFromUser(employee);

            //-------------Checking if data is valid or not----------------\\
            ValidateEmployeeData(employee, resource);
        }
        private void Form_Model_EditAdd_FormClosing_1(object sender, FormClosingEventArgs e)
        {

        }
        private void lbl_JoiningDate_Click(object sender, EventArgs e)
        {

        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            TakingInputsFromUser(employee);
            //-------------Checking if data is valid or not----------------\\
            ValidateEmployeeData(employee, resource);
        }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            ClearingFields();
        }
        private void date_DOB_ValueChanged(object sender, EventArgs e)
        {
            if (date_DOB.Value == DateTimePicker.MinimumDateTime)
            {
                date_DOB.CustomFormat = "dd-MM-yyyy";
                date_DOB.Format = DateTimePickerFormat.Custom;

            }
        }
        private void date_Joining_ValueChanged_1(object sender, EventArgs e)
        {
            if (date_Joining.Value == DateTimePicker.MinimumDateTime)
            {
                date_Joining.CustomFormat = "dd-MM-yyyy";
                date_Joining.Format = DateTimePickerFormat.Custom;
            }
        }
        private void btn_FirstRecord_Click(object sender, EventArgs e)
        {
            currentIndexOfEmployee = 0;

            ShowingFields(employees[currentIndexOfEmployee]);

            //----- If user is at first record the disabling the first and previous button
            btn_FirstRecord.Enabled = false;
            btn_Previous.Enabled = false;

            //----- Enabling the other buttons
            btn_Last.Enabled = true;
            btn_Next.Enabled = true;
        }
        private void btn_Last_Click(object sender, EventArgs e)
        {
            currentIndexOfEmployee = employees.Count - 1;

            ShowingFields(employees[currentIndexOfEmployee]);

            //----- If user is at Last record the disabling the Next and Last button
            btn_Next.Enabled = false;
            btn_Last.Enabled = false;

            //----- Enabling the other buttons
            btn_FirstRecord.Enabled = true;
            btn_Previous.Enabled = true;
        }
        private void btn_Previous_Click(object sender, EventArgs e)
        {
            currentIndexOfEmployee--;

            ShowingFields(employees[currentIndexOfEmployee]);

            //----- If user is viewing first record by clicking previous button
            if (currentIndexOfEmployee == 0)
            {
                btn_FirstRecord.Enabled = false;
                btn_Previous.Enabled = false;
            }

            //----- Enabling the other buttons
            btn_Last.Enabled = true;
            btn_Next.Enabled = true;



        }
        private void btn_Next_Click(object sender, EventArgs e)
        {
            currentIndexOfEmployee++;

            ShowingFields(employees[currentIndexOfEmployee]);

            //----- If user is viewing last record by clicking next button
            if (currentIndexOfEmployee == employees.Count - 1)
            {
                btn_Next.Enabled = false;
                btn_Last.Enabled = false;
            }
            //----- Enabling the other buttons
            btn_FirstRecord.Enabled = true;
            btn_Previous.Enabled = true;

        }

        //---------------------------------Member Functions ----------------------------------\\

        /// <summary>
        /// Displays the fields of the provided employee for 
        /// ing.
        /// </summary>
        /// <param name="employee">The employee whose details are displayed for editing.</param>
        private void ShowingFields(cls_Employee_VO employee)
        {
            txtBox_SerialNoEditAdd.Text = employee.SerialNo.ToString();
            txtBox_PrefixEditAdd.Text = employee.Prefix;
            txtBox_FirstNameEditAdd.Text = employee.FirstName;
            txtBox_MiddleNameEditAdd.Text = employee.MiddleName;
            txtBox_LastNameEditAdd.Text = employee.LastName;
            txtBox_CurrentCompanyEditAdd.Text = employee.CurrentCompany;
            txtBox_CurrentAddressEditAdd.Text = employee.CurrentAddress;
            comboBox_Qualification.DropDownStyle = ComboBoxStyle.DropDown;
            comboBox_Qualification.Text = resource.GetQualificationDescriptionAtIndex(Convert.ToByte(employee.Education));


            try
            {
                date_DOB.Text = employee.DOB.ToString("dd-MM-yyyy");
            }
            catch
            {
                date_DOB.CustomFormat = "";
                date_DOB.Format = DateTimePickerFormat.Custom;
                date_DOB.Text = "";
            }
            date_Joining.Text = employee.JoiningDate.ToString("dd-MM-yyyy");

            if (userPermissions != null)
            {
                if (userPermissions["CanDownGrade"] == false)
                {
                    ValidateEducationDownGrade(Convert.ToByte(employee.Education));
                }
            } // Adhering to User Permissions

        }

        /// <summary>
        /// Clears all input fields on the form.
        /// </summary>
        private void ClearingFields()
        {

            date_DOB.Value = DateTimePicker.MinimumDateTime;
            date_DOB.CustomFormat = " ";
            date_DOB.Format = DateTimePickerFormat.Custom;

            date_Joining.Value = DateTimePicker.MinimumDateTime;
            date_Joining.CustomFormat = " ";
            date_Joining.Format = DateTimePickerFormat.Custom;

            txtBox_PrefixEditAdd.Text = "";
            txtBox_FirstNameEditAdd.Text = "";
            txtBox_MiddleNameEditAdd.Text = "";
            txtBox_LastNameEditAdd.Text = "";
            txtBox_CurrentCompanyEditAdd.Text = "";
            txtBox_CurrentAddressEditAdd.Text = "";
            comboBox_Qualification.Text = "";
            date_DOB.Text = "";
            date_Joining.Text = "";
        }

        /// <summary>
        /// Takes inputs from the user and updates the provided employee object.
        /// </summary>
        /// <param name="employee">The employee object to be updated with user inputs.</param>
        private void TakingInputsFromUser(cls_Employee_VO employee)
        {
            employee.FirstName = txtBox_FirstNameEditAdd.Text;
            employee.MiddleName = txtBox_MiddleNameEditAdd.Text;
            employee.LastName = txtBox_LastNameEditAdd.Text;
            employee.Prefix = txtBox_PrefixEditAdd.Text;
            try
            {
                employee.DOB = (Convert.ToDateTime(date_DOB.Text));

            }
            catch
            {
                employee.DOB = DateTimePicker.MinimumDateTime;
            }
            employee.JoiningDate = date_Joining.Value;
            employee.CurrentAddress = txtBox_CurrentAddressEditAdd.Text;
            employee.CurrentCompany = txtBox_CurrentCompanyEditAdd.Text;
            employee.Education = (byte)comboBox_Qualification.SelectedIndex;


        }

        /// <summary>
        /// Enables or disables form fields and buttons based on the specified mode.
        /// </summary>
        /// <param name="mode">The mode to set the form to, such as "View," "Edit," or "Add."</param>
        private void EnableRequiredFields(string mode)
        {
            if (mode == "View")
            {
                //------making fields disable
                MakeFieldsDisable(false);
            }

            else if (mode == "Edit" || mode == "Add")
            {
                MakeFieldsDisable(true);

            }
        }

        /// <summary>
        /// Enables or disables multiple form fields and buttons based on the specified flag.
        /// </summary>
        /// <param name="flag">A boolean indicating whether to enable (true) or disable (false) form elements.</param>
        private void MakeFieldsDisable(bool flag)
        {
            txtBox_FirstNameEditAdd.Enabled = flag;
            txtBox_LastNameEditAdd.Enabled = flag;
            txtBox_CurrentAddressEditAdd.Enabled = flag;
            txtBox_PrefixEditAdd.Enabled = flag;
            txtBox_CurrentCompanyEditAdd.Enabled = flag;
            comboBox_Qualification.Enabled = flag;
            date_DOB.Enabled = flag;
            date_Joining.Enabled = flag;
            txtBox_MiddleNameEditAdd.Enabled = flag;


            btn_Add.Visible = flag;
            btn_Clear.Visible = flag;
            btn_Edit.Visible = flag;

            btn_Previous.Visible = !flag;
            btn_Next.Visible = !flag;
            btn_Last.Visible = !flag;
            btn_FirstRecord.Visible = !flag;

        }

        /// <summary>
        /// Sets focus on specific form fields based on the provided validation message.
        /// </summary>
        /// <param name="validationMessage">The validation message indicating which fields need highlighting.</param>
        private void HighlightCellsForValidation(string validationMessage)
        {
            if (validationMessage.StartsWith("First"))
            {
                txtBox_FirstNameEditAdd.Focus();
            }

            else if (validationMessage.StartsWith("Middle"))
            {
                txtBox_MiddleNameEditAdd.Focus();
            }
            else if (validationMessage.StartsWith("Last"))
            {
                txtBox_LastNameEditAdd.Focus();
            }

            else if (validationMessage.StartsWith("Qualification"))
            {
                comboBox_Qualification.Focus();
            }
            else if (validationMessage.StartsWith("Current Company"))
            {
                txtBox_CurrentCompanyEditAdd.Focus();
            }
            else if (validationMessage.StartsWith("Current Address"))
            {
                txtBox_CurrentAddressEditAdd.Focus();
            }
            else if (validationMessage.StartsWith("Age"))
            {
                date_Joining.Focus();
            }


        }

        /// <summary>
        /// Validates employee data, saves it, and displays appropriate messages.
        /// </summary>
        /// <param name="employee">The employee data to validate and save.</param>
        /// <param name="resource">The resource containing messages and descriptions.</param>
        private void ValidateEmployeeData(cls_Employee_VO employee, Resource resource)
        {
            bool isValid = false;

            // Validating the Employee if Validated then Saving it in DB
            try
            {
                isValid = dataProcessing.SaveIntoDB(employee, resource);

            }
            catch (cls_BusinessLayerException ex)
            {
                MessageBox.Show(ex.Message, "Something Went Wrong");
            }

            if (isValid)
            {
                EmployeeOperationResult result = 0 ;
                if (employee.editMode == (byte)Resource.EditMode.add)
                {
                     result = Resource.EmployeeOperationResult.AddedSuccessfully;

                }
                else if (employee.editMode == (byte)Resource.EditMode.edit)
                {
                     result = Resource.EmployeeOperationResult.UpdatedSuccessfully;
                }

                MessageBox.Show(resource.GetDescription(result), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            } // if data is valid

            else
            {
                string validationMessage = dataHandlerMessages.GetMessageDesc(employee.ValidationMessage, "ValidationMessages");
                Resource.ValidationMessage retrievedMessage = resource.GetValidationMessageFromByte(employee.ValidationMessage);
                MessageBox.Show(resource.GetDescriptionString(retrievedMessage), "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HighlightCellsForValidation(resource.GetDescriptionString(retrievedMessage));
            }


        }

        /// <summary>
        /// Updates the qualification combo box based on the selected education level, So that user cannot downgrade the education.
        /// </summary>
        /// <param name="currentEducationIndex">The index representing the current education level.</param>
        private void ValidateEducationDownGrade(byte currentEducationIndex)
        {
            ComboBox comboBoxEducation = comboBox_Qualification; // Replace with your actual combo box instance

            List<byte> validEducationIndices = new List<byte>();

            if (currentEducationIndex == (byte)QualificationEnum.PreTenth)
            {
                validEducationIndices.AddRange(new byte[] {
            (byte)QualificationEnum.PreTenth,
            (byte)QualificationEnum.TenthGrade,
            (byte)QualificationEnum.TwelfthGrade,
            (byte)QualificationEnum.Diploma,
            (byte)QualificationEnum.BTech,
            (byte)QualificationEnum.BSc,
            (byte)QualificationEnum.BCA,
            (byte)QualificationEnum.BA,
            (byte)QualificationEnum.BE,
            (byte)QualificationEnum.MSc,
            (byte)QualificationEnum.MCA
        });
            }
            else if (currentEducationIndex == (byte)QualificationEnum.TenthGrade)
            {
                validEducationIndices.AddRange(new byte[] {
            (byte)QualificationEnum.TenthGrade,
            (byte)QualificationEnum.TwelfthGrade,
            (byte)QualificationEnum.Diploma,
            (byte)QualificationEnum.BTech,
            (byte)QualificationEnum.BSc,
            (byte)QualificationEnum.BCA,
            (byte)QualificationEnum.BA,
            (byte)QualificationEnum.BE,
            (byte)QualificationEnum.MSc,
            (byte)QualificationEnum.MCA
        });
            }

            else if (currentEducationIndex == (byte)QualificationEnum.TwelfthGrade)
            {
                validEducationIndices.AddRange(new byte[] {
            (byte)QualificationEnum.TwelfthGrade,
            (byte)QualificationEnum.Diploma,
            (byte)QualificationEnum.BTech,
            (byte)QualificationEnum.BSc,
            (byte)QualificationEnum.BCA,
            (byte)QualificationEnum.BA,
            (byte)QualificationEnum.BE,
            (byte)QualificationEnum.MSc,
            (byte)QualificationEnum.MCA
        });
            }

            else if (currentEducationIndex == (byte)QualificationEnum.Diploma)
            {
                validEducationIndices.AddRange(new byte[] {
            (byte)QualificationEnum.Diploma,
            (byte)QualificationEnum.BTech,
            (byte)QualificationEnum.BSc,
            (byte)QualificationEnum.BCA,
            (byte)QualificationEnum.BA,
            (byte)QualificationEnum.BE,
            (byte)QualificationEnum.MSc,
            (byte)QualificationEnum.MCA
        });
            }
            else if (currentEducationIndex == (byte)QualificationEnum.BTech || currentEducationIndex == (byte)QualificationEnum.BSc || currentEducationIndex == (byte)QualificationEnum.BCA || currentEducationIndex == (byte)QualificationEnum.BA || currentEducationIndex == (byte)QualificationEnum.BE)
            {
                validEducationIndices.AddRange(new byte[] {
            (byte)QualificationEnum.BTech,
            (byte)QualificationEnum.BSc,
            (byte)QualificationEnum.BCA,
            (byte)QualificationEnum.BA,
            (byte)QualificationEnum.BE,
            (byte)QualificationEnum.MSc,
            (byte)QualificationEnum.MCA
        });
            }

            else if (currentEducationIndex == (byte)QualificationEnum.MSc || currentEducationIndex == (byte)QualificationEnum.MCA)
            {
                validEducationIndices.AddRange(new byte[] {
            (byte)QualificationEnum.MSc,
            (byte)QualificationEnum.MCA
        });
            }
            comboBoxEducation.Items.Clear();
            comboBox_Qualification.Items.Clear();

            // Add the new items inside the loop
            comboBoxEducation.Items.AddRange(validEducationIndices.Select(index => resource.GetQualificationDescriptionAtIndex(index)).ToArray());

        }

        private void txtBox_CurrentAddressEditAdd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
