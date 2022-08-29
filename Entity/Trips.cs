using System.ComponentModel.DataAnnotations;

namespace Welfare_App.Entity
{
    public class Trips
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
    }
}
