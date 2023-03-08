using System.ComponentModel.DataAnnotations;
namespace Welfare_App.Entity
{
    public class Vendors
    {
        [Key]
        public int VendorId { get; set; }
        public string Name { get; set; }
        public int BudgetCategoryId { get; set; }
        public string BudgetCategoryItemId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ContactName { get; set; }
        public double TotalCost { get; set; }
        public double BalancePayment { get; set; }
        public double PayedAmount { get; set; }
        public bool vendorSelected { get; set; }
    }
}
