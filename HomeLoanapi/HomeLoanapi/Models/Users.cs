using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeLoanapi.Models
{
    public class Users
    {
        
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }

        //Navigational Property
        public virtual List<Application_Form> ApplicationForm { get; set; }
    }

}

