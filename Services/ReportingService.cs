using Welfare_App.Context;
using Welfare_App.Entity;

namespace Welfare_App.Services
{
    public class ReportingService
    {
        private DataContext _context;
        public ReportingService(DataContext context)
        {
            _context = context;
        }
        public async Task GetEmployeeInfoForTrip(int tripID)
        {
            var query = await (from info in _context.EmployeeInfoForTrip
                        join emp in _context.Employees on info.EmpId equals emp.EmpID
                        join noti in _context.EmailNotifications on emp.EmpID equals noti.EmpID
                        where info.TripEmpDetailID == tripID
                        select new
                        {
                            emp.EmpNo,
                            emp.Fname,
                            emp.Lname,
                            emp.Designation,
                            info.Spouse,
                            info.ChildernCount,
                            info.Transport,
                            info.IsVeg,
                            noti.Replied
                        }).ToListAsync();

            Console.WriteLine("EmpNo", "First Name", "Last Name", "Designation", "Is Spouse Coming", "ChildernCount", "Transport", "IsVeg", "Replied to Mail");
            foreach (var result in query)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}", result.EmpNo, result.Fname, result.Lname, result.Designation, result.Spouse, result.ChildernCount, result.Transport,
                    result.IsVeg, result.Replied);
            }
        }
    }
}
