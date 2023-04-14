using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeLoanapi.Models
{
    public class Application_Form
    {
          // PERSONAL DETAILS
        [Key]
        public int Application_id { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public string Aadhar_no { get; set; }

        // UPLOAD DETAILS
        public Byte pan_card { get; set; }
        public Byte SalarySlip { get; set; }
        public Byte NOC { get; set; }
        
        // PROPERTY DETAILS
        public string property_location { get; set; }
        public double property_price { get; set; }

        //EMPLOYEE DETAILS
        public string organisation { get; set; }
        public string employee_type { get; set; }

        public int id { get; set; }

        // Navigational Property
        public virtual Loandetails details { get; set; }
        public virtual Users User { get; set; }


    }
}
