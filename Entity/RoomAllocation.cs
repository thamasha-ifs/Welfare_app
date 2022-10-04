using System.ComponentModel.DataAnnotations;

namespace Welfare_App.Entity
{
    public class RoomAllocation
    {
        [Key]
        public int AllocationID { get; set; }
        public int TypeID { get; set; }
        public string EmpNos { get; set; }
        public string Others { get; set; }
    }
}
