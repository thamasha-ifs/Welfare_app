using System.Numerics;
using Welfare_App.Context;
using Welfare_App.Entity;

namespace Welfare_App.Services
{
    public class EmployeeInfoForTripService
    {
        DataContext _context;
        public EmployeeInfoForTripService(DataContext context)
        {
            _context = context;
        }
        public List<EmployeeInfoForTrip> GetAllInfo()
        {
            return _context.EmployeeInfoForTrip.ToList();
        }
        public EmployeeInfoForTrip GetInfo(int TripEmpDetailID)
        {
            return _context.EmployeeInfoForTrip.Find(TripEmpDetailID);
        }
        public void AddInfo(EmployeeInfoForTrip employeeInfoForTrip)
        {
            _context.EmployeeInfoForTrip.Add(employeeInfoForTrip);
            _context.SaveChanges();
        }
        public void UpdateInfo(int TripEmpDetailID, EmployeeInfoForTrip employeeInfoForTrip)
        {
            var existingInfo = GetInfo(TripEmpDetailID);
            if (existingInfo != null)
            {
                existingInfo.EmpId = employeeInfoForTrip.EmpId;
                existingInfo.TripId = employeeInfoForTrip.TripId;
                existingInfo.IsVeg = employeeInfoForTrip.IsVeg;
                existingInfo.Spouse = employeeInfoForTrip.Spouse;
                existingInfo.ChildernCount = employeeInfoForTrip.ChildernCount;
                existingInfo.Transport = employeeInfoForTrip.Transport;

                _context.EmployeeInfoForTrip.Update(existingInfo);
                _context.SaveChanges();
            }
        }
        public void RemoveInfo(int TripEmpDetailID)
        {
            var info = GetInfo(TripEmpDetailID);
            if (info != null)
            {
                _context.EmployeeInfoForTrip.Remove(info);
                _context.SaveChanges();

            }
        }
    }
}
