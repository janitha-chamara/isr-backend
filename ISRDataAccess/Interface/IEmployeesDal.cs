using ISRDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISRDataAccess.Interface
{
    public interface IEmployeesDal
    {
        int AddEmployees(EmployeeModel employeeModel);
    }
}
