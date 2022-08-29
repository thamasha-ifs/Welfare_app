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

        public DbSet<BudgetCategoryItems> BudgetCategoryItems => Set<BudgetCategoryItems>();
        public DbSet<Documents> Documents => Set<Documents>();
        public DbSet<Vendors> Vendors => Set<Vendors>();

        public DbSet<Trips> Trips => Set<Trips>();
    }
}
