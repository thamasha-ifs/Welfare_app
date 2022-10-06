using Welfare_App.Context;
using Welfare_App.Entity;

namespace Welfare_App.Services
{
    public class EmployeeService
    {
        private DataContext _context;
        public EmployeeService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Employees>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public IResult GetEmployeeByEmpNo(int EmpNo)
        {
            var emp = _context.Employees.Where(e => e.EmpNo == EmpNo);
            return !(emp == null) ? Results.Ok(emp) : Results.NotFound("Sorry employee not found");
        }

        private async Task<Employees> GetEmployeeByEmpID(int EmpID)
        {
            return await _context.Employees.FindAsync(EmpID);
        }

        public async Task<List<Employees>> GetEmployeeByName(string FName)
        {
            return await _context.Employees.Where(e => e.Fname == FName).ToListAsync();
        }

        public async Task<IResult> AddEmployees(Employees employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Results.Ok(employee);
        }

        public async Task<bool> EditEmployee(int EmpID, Employees employee)
        {
            var existingEmployee = await GetEmployeeByEmpID(EmpID);
            if (existingEmployee != null)
            {
                existingEmployee.EmpNo = employee.EmpNo;
                existingEmployee.Fname = employee.Fname;
                existingEmployee.Lname = employee.Lname;
                existingEmployee.Email = employee.Email;
                existingEmployee.Designation = employee.Designation;
                existingEmployee.Gender = employee.Gender;
                existingEmployee.UserRole = employee.UserRole;

                _context.Employees.Update(existingEmployee);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveEmployee(int EmpID)
        {
            var employee = await GetEmployeeByEmpID(EmpID);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
