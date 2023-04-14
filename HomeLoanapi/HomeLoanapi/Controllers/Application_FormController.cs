using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeLoanapi.Models;
using HomeLoanapi.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeLoanapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Application_FormController : ControllerBase
    {
        private readonly ApplicationRepo_Form _department;
        public Application_FormController(ApplicationRepo_Form department)
        {
            _department = department ??
                throw new ArgumentNullException(nameof(department));
        }
        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _department.GetApplicationForm());
        }
        [HttpGet]
        [Route("GetDepartmentByID/{Id}")]
        public async Task<IActionResult> GetDeptById(int Id)
        {
            return Ok(await _department.GetApplication_FormByID(Id));
        }
        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> Post(Application_Form dep)
        {
            await _department.InsertApplication_Form(dep);
            
            return Ok("Added Successfully");
        }
        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> Put(Application_Form dep)
        {
            await _department.UpdateApplication_Form(dep);
            return Ok("Updated Successfully");
        }
        [HttpDelete]
        //[HttpDelete("{id}")]
        [Route("DeleteDepartment")]
        public JsonResult Delete(int id)
        {
            _department.DeleteApplication_Form(id);
            return new JsonResult("Deleted Successfully");
        }
    }
}