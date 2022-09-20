using Data.DataAccess.Interfaces;
using DataMigrations.DataModels;

namespace Data.DataAccess.Services
{

    public class BaseDal : IBaseDal
    {
        public ISRContext _db { get; set; }

        public BaseDal()
        {
            _db = new ISRContext();

        }
    }
}
