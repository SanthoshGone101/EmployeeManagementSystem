using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class RequestLeave
    {
       [Key]
        public int SlNo { get; set; }
        public string LeaveType { get; set; }
        public DateTime DateOfLeave { get; set; }
        public DateTime EndOfLeave { get; set; }
        public string Reason { get; set; }
    }
}
