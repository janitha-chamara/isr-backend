using DataMigrations.DataModels;

namespace Data.DataAccess.Interfaces
{
    public interface IBaseDal
    {
        public ISRContext _db { get; set; }
    }
}
