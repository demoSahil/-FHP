using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHP_ValueObject
{
    public class cls_User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public string ErrorMessage { get; set; }
        public cls_User()
        {
            ErrorMessage = string.Empty;
        }
    }
}
