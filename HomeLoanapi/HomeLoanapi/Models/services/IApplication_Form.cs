using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeLoanapi.Models;

namespace HomeLoanapi.services
{
    interface IApplication_Form
    {
        Task<IEnumerable<Application_Form>> GetApplicationForm();
        Task<Application_Form> GetApplication_FormByID(int ID);
        Task<Application_Form> InsertApplication_Form(Application_Form objApplication_Form);
        Task<Application_Form> UpdateApplication_Form(Application_Form objApplication_Form);
        bool DeleteApplication_Form(int ID);
    }
}
