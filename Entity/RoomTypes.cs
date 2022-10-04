using System.ComponentModel.DataAnnotations;

namespace Welfare_App.Entity
{
    public class RoomTypes
    {
        [Key]
        public int TypeID { get; set; }
        public int HeadCount { get; set; }
        public string Description { get; set; }
    }
}
