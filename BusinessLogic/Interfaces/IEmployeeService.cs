using BusinessLogic.Models;
using ISRDataAccess.Models;

namespace BusinessLogic.Interfaces
{
    public interface IEmployeeService
    {
        ServiceResponse<int> AddEmployee(EmployeeModel employeeModel);
    }
}