using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Employee emp);
        IEnumerable<Employee> GetEmployees();

    }
}
