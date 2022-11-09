using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public int SlNo { get; set; }

        public string EmployeeID { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage ="Use Alphabets Only")]

        public string EmployeeName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        
        public string MailId { get; set; }
        public string Address { get; set; }

    }
}
