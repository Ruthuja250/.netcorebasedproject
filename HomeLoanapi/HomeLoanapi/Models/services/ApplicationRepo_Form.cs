using HomeLoanapi.Contextt;
using HomeLoanapi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLoanapi.services
{
    public class ApplicationRepo_Form
    {


        public class DepartmentRepository : IApplication_Form
        {
            private readonly Appdb _appDBContext;
            public DepartmentRepository(Appdb context)
            {
                _appDBContext = context ??
                    throw new ArgumentNullException(nameof(context));
            }
            public async Task<IEnumerable<Application_Form>> GetApplicationForm()
            {
                return await _appDBContext.application_Forms.ToListAsync();
                
            }
            public async Task<Application_Form> GetApplication_FormByID(int ID)
            {
                return await _appDBContext.application_Forms.FindAsync(ID);
            }
            public async Task<Application_Form> InsertApplication_Form(Application_Form objApplication_Form)
            {
                _appDBContext.application_Forms.Add(objApplication_Form);
                await _appDBContext.SaveChangesAsync();
                return objApplication_Form;
            }
            public async Task<Application_Form> UpdateApplication_Form(Application_Form objApplication_Form)
            {
                _appDBContext.Entry(objApplication_Form).State = EntityState.Modified;
                await _appDBContext.SaveChangesAsync();
                return objApplication_Form;
            }
            public bool DeleteApplication_Form(int ID)
            {
                bool result = false;
                var application = _appDBContext.application_Forms.Find(ID);
                if (application != null)
                {
                    _appDBContext.Entry(application).State = EntityState.Deleted;
                    _appDBContext.SaveChanges();
                    result = true;
                }
                else
                {
                    result = false;
                }
                return result;
            }
        }

        internal void DeleteApplication_Form(int id)
        {
            throw new NotImplementedException();
        }

        internal Task UpdateApplication_Form(Application_Form dep)
        {
            throw new NotImplementedException();
        }

        internal Task InsertApplication_Form(Application_Form dep)
        {
            throw new NotImplementedException();
        }

        internal Task<object> GetApplication_FormByID(int id)
        {
            throw new NotImplementedException();
        }

        internal Task<object> GetApplicationForm()
        {
            throw new NotImplementedException();
        }
    }
    }
