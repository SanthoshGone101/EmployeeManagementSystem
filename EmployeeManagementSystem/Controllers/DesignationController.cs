using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        DataContext context = null;
        public DesignationController(DataContext _obj)
        {
            context = _obj;
        }


        [HttpGet]
        public List<Designation> GetDesignation()
        {
            try
            {
                var listDesignation = context.designations.ToList();
                return listDesignation;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public ActionResult InsertDesignation(Designation des)
        {
            try
            {
                context.designations.Add(des);

                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "Inserted Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut]
        public ActionResult UpdateDesignation(Designation des)
        {
            try
            {
                var Des = context.designations.First();
                Des.DesignationName = des.DesignationName;
                Des.RoleName = des.RoleName;
                Des.DepartmentName = des.DepartmentName;
               
                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "updated Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete("{DesignationName}")]
        public ActionResult DeleteDesignation(string DesignationName)
        {
            try
            {
                var des = context.designations.Where(x => x.DesignationName == DesignationName).First();
                context.Remove(des);
                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "deleted Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("{DesignationName}")]
        public Designation getDesignation(string DesignationName)
        {
            try
            {
                var des = context.designations.Where(x => x.DesignationName == DesignationName).First();
                return des;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
