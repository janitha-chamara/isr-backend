using DataMigrations.DataModels;
using DataMigrations.Migrations;
using ISRDataAccess.Models;

namespace ISRDataAccess.Extentions
{
    public static class EmployeeExtenion
    {
        public static EmployeeModel ToEmployeeModel(this Employee employee)
        {
            var ds = new EmployeeModel
            {
                EmployeeId = employee.EmployeeId,
                FirstName = employee.FirstName,
                
                EmployeeType = employee.EmployeeType,
                UUID = employee.UUID,
            };

            return ds;
        }

        public static Employee ToEmployee(this EmployeeModel employeeModel)
        {
            var ds = new Employee
            {
                EmployeeId = employeeModel.EmployeeId,
                FirstName = employeeModel.FirstName,
                EmployeeType = employeeModel.EmployeeType,
                UUID= employeeModel.UUID,
             
            };
            return ds;

        }
    }
}
