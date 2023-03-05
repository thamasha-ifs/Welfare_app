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
        public DbSet<Transactions> Transactions => Set<Transactions>();

        public DbSet<Trips> Trips => Set<Trips>();
        public DbSet<Employees> Employees => Set<Employees>();
        public DbSet<EventAgenda> EventAgenda => Set<EventAgenda>();
        public DbSet<EmailNotifications> EmailNotifications => Set<EmailNotifications>();
        public DbSet<EmployeeInfoForTrip> EmployeeInfoForTrip => Set<EmployeeInfoForTrip>();
        public DbSet<AccomodationVendorRoomTypes> AccomodationVendorRoomTypes => Set<AccomodationVendorRoomTypes>();
        public DbSet<RoomAllocations> RoomAllocations => Set<RoomAllocations>();
    }
}
