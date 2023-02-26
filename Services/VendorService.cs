using Welfare_App.Context;
using Welfare_App.Entity;

namespace Welfare_App.Services
{
    public class VendorService
    {
        DataContext _context;
        public VendorService(DataContext context)
        {
            _context = context;
        }
        public List<Vendors> GetVendors()
        {
            return _context.Vendors.ToList();
        }
        public Vendors GetVendor(int vendorId)
        {
            return _context.Vendors.Find(vendorId);
        }
        public Vendors AddVendor(Vendors vendor)
        {
            _context.Vendors.Add(vendor);
            _context.SaveChanges();
            return vendor;
        }
        public Vendors EditVendor(int vendorId, Vendors vendor)
        {
            var existingvendor = GetVendor(vendorId);
            if (existingvendor != null)
            {
                existingvendor.Phone = vendor.Phone;
                existingvendor.Email = vendor.Email;
                existingvendor.ContactName = vendor.ContactName;
                existingvendor.Name = vendor.Name;
                existingvendor.TotalCost = vendor.TotalCost;

                _context.Vendors.Update(existingvendor);
                _context.SaveChanges();
                return existingvendor;
            }
            else 
            {
                throw new Exception($"Invalid Vendor Id : {vendorId}.");
            }
            
        }
        public void UpdateBalance(int vendorId, double payment)
        {
            var vendor = GetVendor(vendorId);
            if (vendor != null)
            {
                vendor.BalancePayment = vendor.TotalCost - payment;
                _context.Vendors.Update(vendor);
                _context.SaveChanges();

            }           
        }
        public void RemoveVendor(int vendorId)
        {
            var vendor = GetVendor(vendorId);
            if (vendor != null)
            {
                _context.Vendors.Remove(vendor);
                _context.SaveChanges();

            }
        }
    }
}
