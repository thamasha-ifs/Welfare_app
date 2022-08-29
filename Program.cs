using Microsoft.EntityFrameworkCore;
using Welfare_App.Context;
using Welfare_App.Entity;
using Welfare_App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
 );
builder.Services.AddScoped<DataContext, DataContext>();
builder.Services.AddScoped<BudgetCategoryService, BudgetCategoryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

/*
 
#BudgetdingCategory
GET /budgetCategory
GET /budgetCategory/{categoryId}
PUT /budgetCategory/{categoryId}
POST /budgetCategory
DELETE /budgetCategory/{categoryId}

#BudgetCategoryItems

#Trips

#Vendors

#Documents

#CashflowTransactions

---Room Allocation
#Todo

#Hotels

#RoomTypes

#RoomAllocation
 
*/
app.MapGet("/budgetCategories", async (BudgetCategoryService budgetCategoryService) =>
    await budgetCategoryService.GetAll())
    .WithName("GetAllBudgetCategories");

app.Run();
