using Welfare_App.Context;
using Welfare_App.Entity;

namespace Welfare_App.Services
{
    public class EventAgendaService
    {
        private DataContext _context;
        public EventAgendaService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<EventAgenda>> GetEventAgendaByTrip(int tripId)
        {
            return await _context.EventAgenda.Where(e => e.TripID == tripId).ToListAsync();
        }

        private async Task<EventAgenda> GetEventByEventID(int eventId)
        {
            return await _context.EventAgenda.FindAsync(eventId);
        }

        public async Task AddEventForAgenda(EventAgenda newItem)
        {
            _context.EventAgenda.Add(newItem);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAgendaEvent(EventAgenda item)
        {
            var existingEvent = await GetEventByEventID(item.EventID);
            if (existingEvent != null)
            {
                existingEvent.Description = item.Description;

                _context.EventAgenda.Update(existingEvent);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveEventFromAgenda(int eventId)
        {
            var existingEvent = await GetEventByEventID(eventId);
            if (existingEvent != null)
            {
                _context.EventAgenda.Remove(existingEvent);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
