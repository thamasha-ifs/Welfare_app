using System.ComponentModel.DataAnnotations;

namespace Welfare_App.Entity
{
    public class EmailNotifications
    {
        [Key]
        public int NotificationID { get; set; }
        public int EmpNo { get; set; }
        public bool Replied { get; set; }
        public int TripEmpDetailID { get; set; }
    }
}
