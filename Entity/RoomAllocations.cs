using System.ComponentModel.DataAnnotations;

namespace Welfare_App.Entity
{
    public class RoomAllocations
    {
        [Key]
        public int AllocationID { get; set; }
        public int TypeID { get; set; }
        public string RoomNumber { get; set; }
        public string EmpIDs { get; set; }
        public string Remarks { get; set; }
    }
}
