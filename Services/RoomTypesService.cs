using System;
using Welfare_App.Context;
using Welfare_App.Entity;

namespace Welfare_App.Services
{
    public class RoomTypesService
    {
        DataContext _context;
        public RoomTypesService(DataContext context)
        {
            _context = context;
        }
        public List<AccomodationVendorRoomTypes> GetRoomTypes()
        {
            return _context.AccomodationVendorRoomTypes.ToList();
        }
        public AccomodationVendorRoomTypes GetRoomType(int typeID)
        {
            return _context.AccomodationVendorRoomTypes.Find(typeID);
        }
        public void AddRoomType(AccomodationVendorRoomTypes accomodationVendorRoomType)
        {
            _context.AccomodationVendorRoomTypes.Add(accomodationVendorRoomType);
            _context.SaveChanges();
        }
        public void UpdateRoomType(int typeID, AccomodationVendorRoomTypes accomodationVendorRoomType)
        {
            var existingRoomType = GetRoomType(typeID);
            if (existingRoomType != null)
            {
                existingRoomType.VendorID = accomodationVendorRoomType.VendorID;
                existingRoomType.HeadCount = accomodationVendorRoomType.HeadCount;
                existingRoomType.Description = accomodationVendorRoomType.Description;
                existingRoomType.Availability = accomodationVendorRoomType.Availability;

                _context.AccomodationVendorRoomTypes.Update(existingRoomType);
                _context.SaveChanges();
            }
        }
        public void RemoveRoomType(int typeId)
        {
            var roomType = GetRoomType(typeId);
            if (roomType != null)
            {
                _context.AccomodationVendorRoomTypes.Remove(roomType);
                _context.SaveChanges();

            }
        }
    }
}
