using AppointmentAPI.Data;
using AppointmentAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AppointmentAPI.DAO
{
    public class AppointmentDAOImpl : IAppointmentDAO
    {
        private readonly AppointmentDbContext _context;

        public AppointmentDAOImpl(AppointmentDbContext context)
        {
            _context = context;
        }

        public async Task<Appointment?> Insert(Appointment appointment)
        {
            if (_context.Appointments == null)
            {
                return null;
            }
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        public async Task<bool> Update(int id, Appointment appointment)
        {
            bool updated;

            if (id != appointment.Id)
            {
                return false;
            }

            _context.Entry(appointment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                updated = true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    updated = false;
                }
                else
                {
                    throw;
                }
            }
            return updated;
        }

        public async Task<bool> Delete(int id)
        {
            if (_context.Appointments == null)
            {
                return false;
            }

            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return false;
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Appointment>> GetAll()
        {
            var list = new List<Appointment>();
            if (_context.Appointments == null)
            {
                return list;
            }

            list = await _context.Appointments.ToListAsync();
            return list;
        }

        public async Task<Appointment?> GetById(int id)
        {
            if (_context.Appointments == null)
            {
                return null;
            }

            return await _context.Appointments.FindAsync(id);
        }

        private bool AppointmentExists(int id)
        {
            return (_context.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
