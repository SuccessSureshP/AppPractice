using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample_Web_API.Controllers;
using Sample_Web_API.Tests.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample_Web_API.Tests.Controllers
{
    [TestClass]
    public class EmployeeControllerTest
    {
        MockEmployeeRepository mockEmployeeRepository = new MockEmployeeRepository();
        [TestMethod]
        public void GetEmployeesTest()
        {
           
            EmployeesController empController = new EmployeesController(mockEmployeeRepository);
            var emps =  empController.GetEmployees();

            Assert.AreEqual(emps.Count(), mockEmployeeRepository.emps.Count());
        }
        [TestMethod]
        public void PostEmployee()
        {
            var countBeoreAdding = mockEmployeeRepository.emps.Count();
            EmployeesController empController = new EmployeesController(mockEmployeeRepository);
            var emps = empController.PostEmployee(new BusinessObjects.Employee() { EmployeeId = "4", EmployeeName = "coolSuresh" });

            Assert.AreEqual(mockEmployeeRepository.emps.Count(), countBeoreAdding+1);            
        }
    }
}
