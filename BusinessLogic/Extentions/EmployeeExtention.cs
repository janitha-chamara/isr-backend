using DataMigrations.DataModels;
using ISRDataAccess.Models;

namespace BusinessLogic
{
    public static class EmployeeExtention
    {
        public static EmployeeModel ToEmployeeModel(this Manager manager)
        {
            var ds = new EmployeeModel
            {
               // EmployeeId = manager.Id,
                FirstName = manager.Name,
                EmployeeType = "SDM",
                UUID = manager.UUID,
                
            };

            return ds;
        }

        public static EmployeeModel ToEmployeeModel(this Partner manager)
        {
            var ds = new EmployeeModel
            {
                // EmployeeId = manager.Id,
                FirstName = manager.Name,
                EmployeeType = "Project Manager",
                UUID= manager.UUID,
            };

            return ds;
        }

        public static Manager ToManager(this EmployeeModel employeeModel)
        {
            var ds = new Manager
            {
                Id = employeeModel.EmployeeId.ToString(),
                Name = employeeModel.FirstName,
                
             
            };
            return ds;

        }
    }
}
