using System.ComponentModel.DataAnnotations;

namespace Welfare_App.Entity
{
    public class BudgetCategories
    {
        [Key]
        public int Id { get; set; } 
        public string CategoryName { get; set; }
        public bool Active  { get; set; }   

    }
}
