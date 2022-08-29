using System.ComponentModel.DataAnnotations;
namespace Welfare_App.Entity
{
    public class Documents
    {
        [Key]
        public int DocId { get; set; }
        public string DocName { get; set; }
        public string Path { get; set; }
        public int VendorId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
