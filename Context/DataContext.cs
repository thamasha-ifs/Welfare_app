global using Microsoft.EntityFrameworkCore;
using Welfare_App.Entity;

namespace Welfare_App.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 
        }
        public DbSet<BudgetCategories> BudgetCategories => Set<BudgetCategories>();
    }
}
