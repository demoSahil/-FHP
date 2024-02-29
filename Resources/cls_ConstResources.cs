using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Resources
{
    public class Resource
    {
        //cls_ConstResourceHandler obj_constResource;
        /// <summary>
        /// Enumeration representing the edit modes for an employee.
        /// </summary>
        public enum EditMode
        {
            add,
            edit,
            readOnly
        }

        /// <summary>
        /// Enumeration representing various validation messages for employee fields.
        /// </summary>
        public enum ValidationMessage
        {
            [Description("First Name Field cannot be Empty")]
            FirstNameEmpty,

            [Description("Current Company Field cannot be Empty")]
            CurrentCompanyEmpty,

            [Description("Qualification Must be selected From drop down list")]
            QualificationEmpty,

            [Description("First Name cannot be more than 50 characters")]
            FirstNameTooLong,

            [Description("Last Name cannot be more than 50 characters")]
            LastNameTooLong,

            [Description("Middle Name cannot be more than 25 characters")]
            MiddleNameTooLong,

            [Description("Current Address cannot be more than 500 characters")]
            CurrentAddressTooLong,

            [Description("Current Company cannot be more than 255 characters")]
            CurrentCompanyTooLong,

            [Description("Cannot Delete as the User don't have permissions other than read only")]
            ReadOnlyUserCannotDelete,
            [Description("Age limit must be between 18 and 90S")]
            AgeLimit
        }

        /// <summary>
        /// Enumeration representing different educational qualifications.
        /// </summary>
        public enum QualificationEnum
        {
            [Description("Pre Tenth")]
            PreTenth,
            [Description("10th")]
            TenthGrade,
            [Description("12th")]
            TwelfthGrade,
            [Description("Diploma")]
            Diploma,
            [Description("B.Tech")]
            BTech,
            [Description("B.Sc")]
            BSc,
            [Description("B.C.A")]
            BCA,
            [Description("BA")]
            BA,
            [Description("B.E")]
            BE,
            [Description("M.Sc")]
            MSc,
            [Description("M.C.A")]
            MCA
        }

        /// <summary>
        /// Enumeration representing results of operations on an employee.
        /// </summary>
        public enum EmployeeOperationResult
        {
            [Description("Employee added successfully")]
            AddedSuccessfully,

            [Description("Employee deleted successfully")]
            DeletedSuccessfully,

            [Description("Employee updated successfully")]
            UpdatedSuccessfully,

            [Description("Are you Sure you want to delete this employee")]
            areYouSureWantToDelete,

            [Description("Logged in As Super Admin")]
            loggedInSuperAdmin,
            [Description("Logged in As Admin")]
            loggedInAdmin,
            [Description("Logged in As Self")]
            loggedInSelf,
            [Description("Logged in As Guest")]
            loggedInGuest,
            [Description("User not present!")]
            userNotPresent
        }
        /// <summary>
        /// Enumeration representing the content in about us section
        /// </summary>
        public enum AboutUsSection
        {
            AboutUs,
            OurBusiness
        }

        /// <summary>
        /// Gets the description of the educational qualification at the specified index.
        /// </summary>
        /// <param name="index">The index of the educational qualification.</param>
        /// <returns>The description of the educational qualification.</returns>
        public string GetQualificationDescriptionAtIndex(byte index)
        {
            QualificationEnum[] enumValues = (QualificationEnum[])Enum.GetValues(typeof(QualificationEnum));

            if (index < 0 || index >= enumValues.Length)
            {
                return "";
            }

            QualificationEnum enumValue = enumValues[index];
            var descriptionAttribute = (DescriptionAttribute[])enumValue.GetType().GetField(enumValue.ToString())
                                                          .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descriptionAttribute.Length > 0 ? descriptionAttribute[0].Description : enumValue.ToString();
        }

        /// <summary>
        /// Gets a list of descriptions for all educational qualifications.
        /// </summary>
        /// <returns>A list of educational qualification descriptions.</returns>
        public List<string> GetQualificationDescriptions()
        {
            List<string> descriptions = new List<string>();

            foreach (QualificationEnum qualification in Enum.GetValues(typeof(QualificationEnum)))
            {
                string description = GetEnumDescription(qualification);
                descriptions.Add(description);
            }

            return descriptions;
        }

        /// <summary>
        /// Gets the description attribute for a given enumeration value.
        /// </summary>
        /// <param name="value">The enumeration value.</param>
        /// <returns>The description attribute value or the enum value if not found.</returns>
        public string GetEnumDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        /// <summary>
        /// Gets the byte index of an educational qualification from its description.
        /// </summary>
        /// <param name="description">The description of the educational qualification.</param>
        /// <returns>The byte index of the educational qualification.</returns>
        public byte GetEnumIndexFromDescription(string description)
        {
            foreach (QualificationEnum qualification in Enum.GetValues(typeof(QualificationEnum)))
            {
                if (GetEnumDescription(qualification) == description)
                {
                    return (byte)qualification;
                }
            }
            return 0;
        }

        /// <summary>
        /// Converts a byte value to a ValidationMessage enumeration.
        /// </summary>
        /// <param name="byteValue">The byte value representing a ValidationMessage.</param>
        /// <returns>The corresponding ValidationMessage enumeration value.</returns>
        public ValidationMessage GetValidationMessageFromByte(byte byteValue)
        {
            return (ValidationMessage)byteValue;
        }

        /// <summary>
        /// Gets the description string for a ValidationMessage enumeration value.
        /// </summary>
        /// <param name="message">The ValidationMessage enumeration value.</param>
        /// <returns>The description of the ValidationMessage.</returns>
        public string GetDescriptionString(ValidationMessage message)
        {
            var enumType = typeof(ValidationMessage);
            var memberInfo = enumType.GetMember(message.ToString());

            if (memberInfo.Length > 0)
            {
                var descriptionAttribute = (DescriptionAttribute)Attribute.GetCustomAttribute(memberInfo[0], typeof(DescriptionAttribute));

                if (descriptionAttribute != null)
                {
                    return descriptionAttribute.Description;
                }
            }

            return "Unknown Validation Message Description";
        }

        public string GetAboutUsContent(AboutUsSection section)
        {
            switch (section)
            {
                case AboutUsSection.AboutUs:
                    return "Headquartered in Mohali, India, the company was incorporated in the year 1999.\r\n\r\n Today, with over 20 years of experience, we are one of the fastest-growing companies in the marine IT field,serving many top shipping companies around the globe.\r\n\r\nOur comprehensive and integrated Ship Management Software titled “SMMS – Ship Maintenance & Management System” has been implemented on more than 1500 vessels worldwide.";

                case AboutUsSection.OurBusiness:
                    return "Our Business\r\n" +
                           "▪ Development of Software Applications\r\n" +
                           "▪ Creation of PMS & Inventory Databases for Vessels\r\n" +
                           "▪ 24x7 Technical Support\r\n" +
                           "▪ On-Site Implementations and Trainings\r\n" +
                           "▪ Remote and On-board I.T. Services\r\n" +
                           "▪ Documents Digitization";
                default:
                    return "No content available for this section.";
            }
        }
        public string GetDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo != null)
            {
                var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(fieldInfo, typeof(DescriptionAttribute));

                if (attribute != null)
                {
                    return attribute.Description;
                }
            }

            return value.ToString();
        }


        public void GetValidationMessageDescription(string shortName)
        {

        }






        /*  VISPL VISPL SUPERADMIN
  ADMIN123 ADMIN123 ADMIN
  GUEST123 GUEST123 GUEST
  USER123 USER123 SELF*/
    }



}

