using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HomeLoanapi.Models
{
    public class Loandetails
    {
        [Key]
        public int LoanId { get; set; }
        [Required] public string Name { get; set; }
        [Required] public float Loan_Amount { get; set; }
        [Required] public float EMI { get; set; }
        public string Status { get; set; }

        //Navigational Property
        public int Application_Id { get; set; } // Foriegn Key
        public virtual Application_Form ApplicationForm { get; set; } // Navigational Property

    }
}
