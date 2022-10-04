using Welfare_App.Context;
using Welfare_App.Entity;

namespace Welfare_App.Services
{
    public class ReportingService
    {
        private DataContext _context;
        public ReportingService(DataContext context)
        {
            _context = context;
        }
    }
}
