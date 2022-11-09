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
    public class RequestLeaveController : ControllerBase
    {
        DataContext context = null;
        public RequestLeaveController(DataContext _obj)
        {
            context = _obj;
        }


        [HttpGet]
        public List<RequestLeave> GetLeaveRequest()
        {
            try
            {
                var listLeaves = context.requestLeaves.ToList();
                return listLeaves;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]
        public ActionResult InsertLeaveRequests(RequestLeave req)
        {
            try
            {
                context.requestLeaves.Add(req);

                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "inserted Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPut]
        public ActionResult UpdateLeaveRequest(RequestLeave req)
        {
            try
            {

                var Req = context.requestLeaves.FirstOrDefault();
                Req.LeaveType = req.LeaveType;
                Req.DateOfLeave = req.DateOfLeave;
                Req.EndOfLeave = req.EndOfLeave;

                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "updated Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpDelete("{SlNo}")]
        public ActionResult DeleteLeaveRequest(int SlNo)
        {
            try
            {
                var req = context.requestLeaves.Where(x => x.SlNo == SlNo).First();
                context.Remove(req);
                context.SaveChanges();
                return Ok(new { statusCode = 200, message = "deleted Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet("{SlNo}")]
        public RequestLeave getLeaveById(int SlNo)
        {
            try
            {
                var req = context.requestLeaves.Where(x => x.SlNo == SlNo).First();
                return req;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
