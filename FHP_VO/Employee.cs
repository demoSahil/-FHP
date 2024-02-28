using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_ValueObject
{
    public class Employee
    {
        public long SerialNo {  get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string MiddleName {  get; set; }
        public string Prefix {  get; set; }
        public string CurrentAddress {  get; set; }
        public string CurrentCompany {  get; set; }
        public byte editMode {  get; set; }
        public bool isDeleted {  get; set; }
        public DateTime JoiningDate {  get; set; }
        public DateTime DOB {  get; set; }
        public byte Education {  get; set; } 

        public byte ValidationMessage {  get; set; }
        public Employee()
        {
            isDeleted = false;
            editMode = 1;
            
        }

    }
}
