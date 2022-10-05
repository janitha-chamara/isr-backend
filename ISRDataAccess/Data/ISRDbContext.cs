namespace ISRDataAccess.Data
{
    using ISRDataAccess.Models;
    using Microsoft.EntityFrameworkCore;

    public class ISRDbContext : DbContext
    {
        public ISRDbContext(DbContextOptions<ISRDbContext> options) : base(options)
        {
            
        }

     

    }
}
