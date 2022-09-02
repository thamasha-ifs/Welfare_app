using System.ComponentModel.DataAnnotations;

namespace Welfare_App.Entity
{
    public class BudgetCategoryItems
    {
        [Key]
        public int BudgetItemId { get; set; }
        public int TripId { get; set; }
        public string BudgetItemName { get; set; }
        public string BudgetItemType { get; set; }
        public string Desciption { get; set; }
    }
}
