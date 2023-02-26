using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Welfare_App.Context;
using Welfare_App.Entity;
using Welfare_App.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Corspolicy", builder => {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    options.TokenValidationParameters = new TokenValidationParameters() { 
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    }
);


builder.Services.AddDbContext<DataContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
 );
builder.Services.AddScoped<DataContext, DataContext>();

builder.Services.AddScoped<BudgetCategoryService, BudgetCategoryService>();
builder.Services.AddScoped<BudgetCategoryItemService, BudgetCategoryItemService>();
builder.Services.AddScoped<VendorService, VendorService>();
builder.Services.AddScoped<DocumentService, DocumentService>();
builder.Services.AddScoped<EmployeeService, EmployeeService>();
builder.Services.AddScoped<EventAgendaService, EventAgendaService>();
builder.Services.AddScoped<ReportingService, ReportingService>();
builder.Services.AddScoped<EmployeeInfoForTripService, EmployeeInfoForTripService>();
builder.Services.AddScoped<RoomTypesService, RoomTypesService>();
builder.Services.AddScoped<RoomAllocationService, RoomAllocationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Corspolicy");
app.UseHttpsRedirection();
//app.UseAuthorization();
app.UseAuthentication();

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

#RoomAllocations
 
*/
app.MapGet("/budgetCategories/{id}", async (int id, BudgetCategoryService budgetCategoryService) => {
    return await budgetCategoryService.GetBudgetCategory(id);})
    .WithName("GetBudgetCategory");

app.MapGet("/budgetCategories", async (BudgetCategoryService budgetCategoryService) => {
    return await budgetCategoryService.GetAll();
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
    return await budgetCategoryItemService.GetBudgetCategoryItem(id);})
    .WithName("GetBudgetCategoryItem");

app.MapGet("/budgetCategoryItems", async (BudgetCategoryItemService budgetCategoryItemService) => {
    return await budgetCategoryItemService.GetAll();
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
    return await budgetCategoryItemService.GetBudgetCategoryItemByTrip(id);
})
    .WithName("GetBudgetCategoryItemByTrip");

app.MapGet("/budgetCategoryItems/{category}", async (string category, BudgetCategoryItemService budgetCategoryItemService) => {
    return await budgetCategoryItemService.GetBudgetCategoryItemByType(category);
})
    .WithName("GetBudgetCategoryItemByCategory");

app.MapGet("/vendors/{id}", (int id, VendorService vendorService) => {
    return vendorService.GetVendor(id);
});

app.MapGet("/vendors", (VendorService vendorService) => {
    return vendorService.GetVendors();
});

app.MapPost("/vendors", (Vendors vendor, VendorService vendorService ) => {
    return vendorService.AddVendor(vendor);
});

app.MapPut("/vendors/{id}", (int id , Vendors vendor, VendorService vendorService) => {
     return vendorService.EditVendor(id , vendor);
});

app.MapPut("/vendors/UpdateAmount/{id}", (int id, double amount, VendorService vendorService) => {
    vendorService.UpdateBalance(id, amount);
});

app.MapDelete("/vendors/{id}", (int id, VendorService vendorService) => {
    vendorService.RemoveVendor(id);
});

app.MapGet("/documents/{id}", (int id, DocumentService documentService) => {
    return documentService.GetDocument(id);
});

app.MapGet("/documents", (DocumentService documentService) => {
    return documentService.GetDocuments();
});

app.MapPost("/documents", (Documents document, DocumentService documentService) => {
    documentService.AddDocuments(document);
});

app.MapDelete("/documents/{id}", (int id, DocumentService documentService) => {
    documentService.RemoveDocument(id);
});

//for employees
app.MapGet("/employees", async (EmployeeService employeeService) => {
    return await employeeService.GetAllEmployees();
}).WithName("GetAllEmployees");

app.MapGet("/employees/GetEmployeeByEmpNo/{id}", (int id, EmployeeService employeeService) => {
    return employeeService.GetEmployeeByEmpNo(id);
});

app.MapGet("/employees/GetEmployeeByFirstName/{fname}", async (string fname, EmployeeService employeeService) => {
    return await employeeService.GetEmployeeByName(fname);
});

app.MapPost("/employees/AddEmployee", async (Employees employee, EmployeeService employeeService) => {
    await employeeService.AddEmployees(employee);
});

app.MapPut("/employees/UpdateEmployee/{id}", async (int id, Employees employee, EmployeeService employeeService) => {
    await employeeService.EditEmployee(id, employee);
});

app.MapDelete("/employees/RemoveEmployee/{id}", async (int id, EmployeeService employeeService) => {
    await employeeService.RemoveEmployee(id);
});

//for event agenda
app.MapGet("/eventAgenda/GetEventAgendaByTripID/{id}", async (int id, EventAgendaService eventAgendaService) => {
    return await eventAgendaService.GetEventAgendaByTrip(id);
});

app.MapPost("/eventAgenda/AddEvent", async (EventAgenda newItem, EventAgendaService eventAgendaService) => {
    await eventAgendaService.AddEventForAgenda(newItem);
});

app.MapPut("/eventAgenda/UpdateEvent/{item}", async (EventAgenda item, EventAgendaService eventAgendaService) => {
    await eventAgendaService.UpdateAgendaEvent(item);
});

app.MapPost("/employees/RemoveEvent/{id}", async (int id, EventAgendaService eventAgendaService) => {
    await eventAgendaService.RemoveEventFromAgenda(id);
});

// for reporting
app.MapGet("/report/GetEmployeeInfoForTrip/{id}", async (int id, ReportingService reportingService) => {
    await reportingService.GetEmployeeInfoForTrip(id);
});

// for accomodation vendor room types
app.MapGet("/roomTypes/{id}", (int typeID, RoomTypesService roomTypesService) => {
    return roomTypesService.GetRoomType(typeID);
});

app.MapGet("/roomTypes", (RoomTypesService roomTypesService) => {
    return roomTypesService.GetRoomTypes();
});

app.MapPost("/roomTypes", (AccomodationVendorRoomTypes vendorRoom, RoomTypesService roomTypesService) => {
    roomTypesService.AddRoomType(vendorRoom);
});

app.MapPut("/roomTypes/{id}", (int typeID, AccomodationVendorRoomTypes vendorRoom, RoomTypesService roomTypesService) => {
    roomTypesService.UpdateRoomType(typeID, vendorRoom);
});

app.MapDelete("/roomTypes/{id}", (int typeID, RoomTypesService roomTypesService) => {
    roomTypesService.RemoveRoomType(typeID);
});

// for employee trip info
app.MapGet("/info/{id}", (int tripEmpDetailID, EmployeeInfoForTripService employeeInfoForTripService) => {
    return employeeInfoForTripService.GetInfo(tripEmpDetailID);
});

app.MapGet("/info", (EmployeeInfoForTripService employeeInfoForTripService) => {
    return employeeInfoForTripService.GetAllInfo();
});

app.MapPost("/info", (EmployeeInfoForTrip info, EmployeeInfoForTripService employeeInfoForTripService) => {
    employeeInfoForTripService.AddInfo(info);
});

app.MapPut("/info/{id}", (int tripEmpDetailID, EmployeeInfoForTrip info, EmployeeInfoForTripService employeeInfoForTripService) => {
    employeeInfoForTripService.UpdateInfo(tripEmpDetailID, info);
});

app.MapDelete("/info/{id}", (int tripEmpDetailID, EmployeeInfoForTripService employeeInfoForTripService) => {
    employeeInfoForTripService.RemoveInfo(tripEmpDetailID);
});

// for room allocations
app.MapGet("/roomAllocations/{id}", (int allocationID, RoomAllocationService roomAllocationService) => {
    return roomAllocationService.GetRoomAllocation(allocationID);
});

app.MapGet("/roomAllocations", (RoomAllocationService roomAllocationService) => {
    return roomAllocationService.GetRoomAllocations();
});

app.MapPost("/roomAllocations", (RoomAllocations roomAllocation, RoomAllocationService roomAllocationService) => {
    roomAllocationService.AddRoomAllocation(roomAllocation);
});

app.MapPut("/roomAllocations/{id}", (int allocationID, RoomAllocations roomAllocation, RoomAllocationService roomAllocationService) => {
    roomAllocationService.UpdateRoomAllocations(allocationID, roomAllocation);
});

app.MapDelete("/roomAllocations/{id}", (int allocationID, RoomAllocationService roomAllocationService) => {
    roomAllocationService.RemoveRoomAllocation(allocationID);
});

app.Run();
