using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOLCarRent.ViewModels
{
    public class UsersViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string Passport { get; set; }
        public string IsAdmin { get; set; }
    }
}
