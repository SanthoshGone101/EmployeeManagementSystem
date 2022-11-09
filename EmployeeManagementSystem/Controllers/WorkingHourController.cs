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
    public class WorkingHourController : ControllerBase
    {
        DataContext context = null;
        public WorkingHourController(DataContext _obj)
        {
            context = _obj;
        }


        [HttpGet]
        public List<WorkingHour> GetWorkingHour()
        {
            try
            {
                var workingHourList = context.workingHours.ToList();
                return workingHourList;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public ActionResult InsertWorkingHour(WorkingHour work)
        {
            try
            {
                context.workingHours.Add(work);

                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "inserted Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut("{SlNo}")]
        public ActionResult UpdateWorkingHour(WorkingHour work,int SlNo)
        {
            try
            {
                var Work = context.workingHours.Where(x => x.SlNo == SlNo).SingleOrDefault();
                Work.CompanyHour = work.CompanyHour;
                Work.EmployeeHour = work.EmployeeHour;
                Work.MonthlyCompanyHour = work.MonthlyCompanyHour;
                Work.MonthlyEmployeeHour = work.MonthlyEmployeeHour;

                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "updated Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete("{SlNo}")]
        public ActionResult DeleteWorkingHour(int SlNo)
        {
            try
            {
                var work = context.workingHours.Where(x => x.SlNo == SlNo).First();
                context.Remove(work);
                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "deleted Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("{SlNo}")]
        public WorkingHour getWorkingHourId(int SlNo)
        {
            try
            {
                var work = context.workingHours.Where(x => x.SlNo == SlNo).First();
                return work;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
