using System.Reflection.Metadata.Ecma335;
using Welfare_App.Context;
using Welfare_App.Entity;

namespace Welfare_App.Services
{
    public class BudgetCategoryService
    {
        private DataContext _context;   
        public BudgetCategoryService(DataContext context){
            _context = context;
        }

    
        public List<BudgetCategories> GetAll() {
            return _context.BudgetCategories.ToList();  
        }
    }
}
