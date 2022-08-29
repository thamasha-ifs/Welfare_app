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
app.MapGet("/budgetCategories", async (BudgetCategoryService budgetCategoryService) =>
    await budgetCategoryService.GetAll())
    .WithName("GetAllBudgetCategories");

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
