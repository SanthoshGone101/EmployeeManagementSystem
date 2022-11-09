using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class WorkingHour
    {
        [Key]
        public int SlNo { get; set; }
        public int CompanyHour { get; set; }
        public int EmployeeHour { get; set; }
        public int MonthlyCompanyHour { get; set; }
        public int MonthlyEmployeeHour { get; set; }

    }
}
