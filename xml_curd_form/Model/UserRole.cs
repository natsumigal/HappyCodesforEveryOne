using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xml_curd_form.Model
{
    public  class UserRole
    {
        public Dictionary<string, string> userPasswords = new Dictionary<string, string>
        {
            {"ADMINISTRATOR", "Admin2024"},
            {"OPERATOR", "Operator2024"}
        };
    }
}
