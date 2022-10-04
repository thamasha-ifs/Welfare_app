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
        public async Task<List<Employees>> GetEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employees> GetEmployeeByEmpNo(int EmpNo)
        {
            return await _context.Employees.FindAsync(EmpNo);
        }
        public async Task<List<Employees>> GetEmployeeByName(string FName, string LName)
        {
            return await _context.Employees.Where(e => e.Fname == FName && e.Lname == LName).ToListAsync();
        }
        public async Task AddEmployees(Employees employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> EditEmployee(int EmpNo, Employees employee)
        {
            var existingEmployee = await GetEmployeeByEmpNo(EmpNo);
            if (existingEmployee != null)
            {
                existingEmployee.Fname = employee.Fname;
                existingEmployee.Lname = employee.Lname;
                existingEmployee.Email = employee.Email;
                existingEmployee.Designation = employee.Designation;

                _context.Employees.Update(existingEmployee);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<bool> RemoveEmployee(int EmpNo)
        {
            var employee = await GetEmployeeByEmpNo(EmpNo);
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
