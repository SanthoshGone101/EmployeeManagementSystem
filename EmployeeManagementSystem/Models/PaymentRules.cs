using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Models
{
    public class PaymentRules
    {
        [Key]
        public int PaymentId { get; set; } 
        public string PaymentType  { get; set; }
        public Double Amount { get; set; } 
        public DateTime PaymentTime { get; set; }


    }
}
