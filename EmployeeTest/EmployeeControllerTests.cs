
using EmployeeManagementSystem.Controllers;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTest
{
    [TestClass]
    class EmployeeControllerTests
    {
       [TestMethod]
       public  void GetAllEmployee_shouldReturnEmployees()
        {
           

        }
        private List<Employee> GetEmployees()
        {
            var testEmployees = new List<Employee>();
            testEmployees.Add(new Employee { EmployeeID = "M103212", EmployeeName = "Demo1", PhoneNumber = "1234567890", MailId = "Santhoshgone121@gmail.com", Address = "andugulapally,peddapally" });
            return  testEmployees;
        }
    }
}
