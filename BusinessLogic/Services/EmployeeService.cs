using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using ISRDataAccess.Interface;
using ISRDataAccess.Models;

namespace BusinessLogic.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeesDal _employeesDal;

        public EmployeeService(IEmployeesDal employeesDal)
        {
            _employeesDal = employeesDal;
        }

        public ServiceResponse<int> AddEmployee(EmployeeModel employeeModel)
        {
            var allJobs = _employeesDal.AddEmployees(employeeModel);
            return new ServiceResponse<int>(allJobs);
        }


    }
}