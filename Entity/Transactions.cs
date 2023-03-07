using System.ComponentModel.DataAnnotations;

namespace Welfare_App.Entity
{
    public class Transactions
    {
        [Key]
        public int TransactionID { get; set; }
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public int BudgetItemId { get; set; }
        public string BudgetItemName { get; set; }
        public int TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
