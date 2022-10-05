using System.ComponentModel.DataAnnotations;

namespace Welfare_App.Entity
{
    public class EmployeeInfoForTrip
    {
        [Key]
        public int TripEmpDetailID { get; set; }
        public int EmpId { get; set; }
        public int TripId { get; set; }
        public bool IsVeg { get; set; }
        public bool Spouse { get; set; }
        public int ChildernCount { get; set; }
        public bool Transport { get; set; }
    }
}
