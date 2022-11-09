using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Designation> designations { get; set; }
        public DbSet<RequestLeave> requestLeaves { get; set; }
        public DbSet<PaymentRules> paymentRules { get; set; }
        public DbSet<WorkingHour> workingHours { get; set; }

       
    }
}
