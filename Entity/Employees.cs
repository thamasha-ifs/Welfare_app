using System.ComponentModel.DataAnnotations;

namespace Welfare_App.Entity
{
    public class Employees
    {
        [Key]
        public int EmpNo { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }

    }
}
