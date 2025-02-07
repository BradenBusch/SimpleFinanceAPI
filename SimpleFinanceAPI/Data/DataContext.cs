using Microsoft.EntityFrameworkCore;
using SimpleFinanceAPI.Controllers;
using SimpleFinanceAPI.Models;

namespace SimpleFinanceAPI.Data
{
    public class DataContext : DbContext
    {     
        public IConfiguration _config { get; set; }
        public DataContext(IConfiguration config, DbContextOptions<DataContext> options) : base(options) 
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }

        public DbSet<User> User { get; set; }
        public DbSet<AccountHeader> AccountHeader { get; set; }
        public DbSet<AccountDetail> AccountDetail { get; set; }
    }
}
