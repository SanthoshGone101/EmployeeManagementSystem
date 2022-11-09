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
    public class EmployeeController : ControllerBase
    {
        DataContext context = null;
        

        public EmployeeController(DataContext _obj)
        {
            context = _obj;
        }

       

        [HttpGet]
        public List<Employee> GetEmployees()
        {
            try
            {
                var listEmployees = context.employees.ToList();
                return listEmployees;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        [HttpPost]
        public ActionResult InsertEmployee(Employee emp)
        {
            try
            {
                context.employees.Add(emp);
                if (emp != null)
                {
                    context.SaveChanges();
                    return Ok(new { statusCode=200 , message="Inserted Successfully"});
                }
                else
                {
                    return Ok(new { statusCode = 400, message = "Enter Valid Data" });
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        [HttpPut]
        public ActionResult UpdateEmployee(Employee emp)
        {
            try
            {
                var employee = context.employees.First();
                employee.EmployeeID = emp.EmployeeID;
                employee.EmployeeName = emp.EmployeeName;
                employee.PhoneNumber = emp.PhoneNumber;
                employee.MailId = emp.MailId;
                employee.Address = emp.Address;
                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "updated Successfully" });
            }
            catch(Exception ex)
            {
               
                Console.WriteLine(ex.Message);
                throw ex;
            }
           
        }

        [HttpDelete("{Employeeid}")]
        public ActionResult DeleteEmployee(string Employeeid)
        {
            try
            {
                var emp = context.employees.Where(x => x.EmployeeID == Employeeid).First();
                context.Remove(emp);
                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "deleted Successfully" });
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        [HttpGet("{Employeeid}")]
        public Employee getEmployee(string Employeeid)
        {
            try
            {
                var emp = context.employees.Where(x => x.EmployeeID == Employeeid).First();
                return emp;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
