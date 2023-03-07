using System.ComponentModel.DataAnnotations;

namespace Welfare_App.Entity
{
    public class AccomodationVendorRoomTypes
    {
        [Key]
        public int TypeID { get; set; }
        public int VendorID { get; set; }
        public int HeadCount { get; set; }
        public string Description { get; set; }
        public int Availability { get; set; }
    }
}
