using FinancialApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<People> People { get; set; }
        public DbSet<Addresses> Address { get; set; }
        public DbSet<Cities> City { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Countries> Countrie { get; set; }
        public DbSet<BalancePeriods> BalancePeriods { get; set; }
        public DbSet<MonthlyBills> MonthlyBills { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}