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
builder.Services.AddScoped<VendorService, VendorService>();
builder.Services.AddScoped<DocumentService, DocumentService>();

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
app.MapGet("/budgetCategories/{id}", async (int id, BudgetCategoryService budgetCategoryService) => {
    await budgetCategoryService.GetBudgetCategory(id);})
    .WithName("GetBudgetCategory");

app.MapGet("/budgetCategories", async (BudgetCategoryService budgetCategoryService) => {
    await budgetCategoryService.GetAll();
})
    .WithName("GetAllBudgetCategories");

app.MapPost("/budgetCategories", (BudgetCategories category, BudgetCategoryService budgetCategoryService) => {
    budgetCategoryService.AddCategory(category);})
    .WithName("AddBudgetCategory");

app.MapPut("/budgetCategories/{id}",async (int id, BudgetCategories category, BudgetCategoryService budgetCategoryService) => {
     await budgetCategoryService.UpdateCategory(id,category);})
    .WithName("UpdateBudgetCategory");

app.MapDelete("/budgetCategories/{id}", async (int id, BudgetCategoryService budgetCategoryService) => {
    await budgetCategoryService.RemoveCategory(id);})
    .WithName("RemoveBudgetCategory");

app.MapGet("/budgetCategoryItems/{id}", async (int id, BudgetCategoryItemService budgetCategoryItemService) => {
    await budgetCategoryItemService.GetBudgetCategoryItem(id);
})
    .WithName("GetBudgetCategoryItem");

app.MapGet("/budgetCategoryItems", async (BudgetCategoryItemService budgetCategoryItemService) => {
    await budgetCategoryItemService.GetAll();
}) 
    .WithName("GetAllBudgetCategoryItems");

app.MapPost("/budgetCategoryItems", (BudgetCategoryItems categoryItem, BudgetCategoryItemService budgetCategoryItemService) => {
    budgetCategoryItemService.AddCategoryItem(categoryItem);
})
    .WithName("AddBudgetCategoryItem");

app.MapPut("/budgetCategoryItems/{id}", async (int id, BudgetCategoryItems categoryItem, BudgetCategoryItemService budgetCategoryItemService) => {
    await budgetCategoryItemService.UpdateCategoryItem(id, categoryItem);
})
    .WithName("UpdateBudgetCategoryItem");

app.MapDelete("/budgetCategoryItems/{id}", async (int id, BudgetCategoryItemService budgetCategoryItemService) => {
    await budgetCategoryItemService.RemoveCategoryItem(id);
})
    .WithName("RemoveBudgetCategoryItem");

app.MapGet("/budgetCategoryItems/trips/{id}", async (int id, BudgetCategoryItemService budgetCategoryItemService) => {
    await budgetCategoryItemService.GetBudgetCategoryItemByTrip(id);
})
    .WithName("GetBudgetCategoryItemByTrip");

app.MapGet("/budgetCategoryItems/{category}", async (string category, BudgetCategoryItemService budgetCategoryItemService) => {
    await budgetCategoryItemService.GetBudgetCategoryItemByType(category);
})
    .WithName("GetBudgetCategoryItemByCategory");

app.MapGet("/vendors/{id}", (int id, VendorService vendorService) => {
    vendorService.GetVendor(id);
});

app.MapGet("/vendors", (VendorService vendorService) => {
    vendorService.GetVendors();
});

app.MapPost("/vendors", (Vendors vendor, VendorService vendorService ) => {
    vendorService.AddVendor(vendor);
});

app.MapPut("/vendors/{id}", (int id , Vendors vendor, VendorService vendorService) => {
    vendorService.EditVendor(id , vendor);
});

app.MapPut("/vendors/UpdateAmount/{id}", (int id, double amount, VendorService vendorService) => {
    vendorService.UpdateBalance(id, amount);
});

app.MapDelete("/vendors/{id}", (int id, VendorService vendorService) => {
    vendorService.RemoveVendor(id);
});

app.MapGet("/documents/{id}", (int id, DocumentService documentService) => {
    documentService.GetDocument(id);
});

app.MapGet("/documents", (DocumentService documentService) => {
    documentService.GetDocuments();
});

app.MapPost("/documents", (Documents document, DocumentService documentService) => {
    documentService.AddDocuments(document);
});

app.MapDelete("/documents/{id}", (int id, DocumentService documentService) => {
    documentService.RemoveDocument(id);
});


app.Run();
