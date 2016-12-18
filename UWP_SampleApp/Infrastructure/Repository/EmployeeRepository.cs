using BusinessObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        SampleDataModel context = new SampleDataModel();
        public void Add(Employee emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
        }
    }
}
