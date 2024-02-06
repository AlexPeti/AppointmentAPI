using AppointmentAPI.DAO;
using AppointmentAPI.Data;
using AppointmentAPI.DTO;
using AppointmentAPI.Models;
using AutoMapper;

namespace AppointmentAPI.Service
{
    public class AppointmentServiceImpl : IAppointmentService
    {
        private readonly AppointmentDbContext context;
        private readonly IAppointmentDAO appointmentDAO;
        private readonly IMapper mapper;

        public AppointmentServiceImpl(AppointmentDbContext context, IAppointmentDAO appointmentDAO, IMapper mapper)
        {
            this.context = context;
            this.appointmentDAO = appointmentDAO;
            this.mapper = mapper;
        }

        public async Task<Appointment?> CreateAppointment(AppointmentCreateDTO appointmentDTO)
        {
            var appointment = mapper.Map<Appointment>(appointmentDTO);

            try
            {
                return await appointmentDAO.Insert(appointment);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateAppointment(int id, AppointmentUpdateDTO appointmentDTO)
        {
            var appointment = await appointmentDAO.GetById(id);
            mapper.Map(appointmentDTO, appointment);

            if (appointment != null)
            {
                bool updated = await appointmentDAO.Update(id, appointment);
                if (!updated)
                {
                    throw new KeyNotFoundException("Appointment not found or ID mismatch.");
                }
            }
            else
            {
                throw new Exception("Update failed.");
            }
        }

        public async Task DeleteAppointment(int id)
        {
            bool deleted = await appointmentDAO.Delete(id);
            if (!deleted)
            {
                throw new KeyNotFoundException("Appointment not found.");
            }
        }

        public async Task<List<AppointmentReadOnlyDTO>> GetAllAppointments()
        {
            var appointments = await appointmentDAO.GetAll();
            return mapper.Map<List<AppointmentReadOnlyDTO>>(appointments);
        }

        public async Task<AppointmentReadOnlyDTO?> GetAppointmentById(int id)
        {
            var appointment = await appointmentDAO.GetById(id);
            return appointment != null ? mapper.Map<AppointmentReadOnlyDTO>(appointment) : null;
        }
    }
}
