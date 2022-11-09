using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Designation
    {
        [Key]
        public int SlNo { get; set; }
        public string DesignationName { get; set; }
        public string RoleName { get; set; }
        public string DepartmentName { get; set; }
    }
}
