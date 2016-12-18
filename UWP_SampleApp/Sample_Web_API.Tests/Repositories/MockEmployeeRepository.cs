using BusinessObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Sample_Web_API.Tests.Repositories
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        public List<Employee> emps = new List<Employee>();
        public void Add(Employee emp)
        {
            emps.Add(emp);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return emps;
        }
    }
}
