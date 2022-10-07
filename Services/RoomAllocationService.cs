using Welfare_App.Context;
using Welfare_App.Entity;

namespace Welfare_App.Services
{
    public class RoomAllocationService
    {
        DataContext _context;
        public RoomAllocationService(DataContext context)
        {
            _context = context;
        }
        public List<RoomAllocations> GetRoomAllocations()
        {
            return _context.RoomAllocations.ToList();
        }
        public RoomAllocations GetRoomAllocation(int allocationID)
        {
            return _context.RoomAllocations.Find(allocationID);
        }
        public void AddRoomAllocation(RoomAllocations roomAllocation)
        {
            _context.RoomAllocations.Add(roomAllocation);
            _context.SaveChanges();
        }
        public void UpdateRoomAllocations(int allocationID, RoomAllocations roomAllocation)
        {
            var existingRoomAllocation = GetRoomAllocation(allocationID);
            if (existingRoomAllocation != null)
            {
                existingRoomAllocation.TypeID = roomAllocation.TypeID;
                existingRoomAllocation.RoomNumber = roomAllocation.RoomNumber;
                existingRoomAllocation.EmpIDs = roomAllocation.EmpIDs;
                existingRoomAllocation.Remarks = roomAllocation.Remarks;

                _context.RoomAllocations.Update(existingRoomAllocation);
                _context.SaveChanges();
            }
        }
        public void RemoveRoomAllocation(int allocationID)
        {
            var roomAllocation = GetRoomAllocation(allocationID);
            if (roomAllocation != null)
            {
                _context.RoomAllocations.Remove(roomAllocation);
                _context.SaveChanges();

            }
        }
    }
}
