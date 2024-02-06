using AppointmentAPI.DTO;
using AppointmentAPI.Models;

namespace AppointmentAPI.Service
{
    public interface IAppointmentService
    {
        Task<Appointment?> CreateAppointment(AppointmentCreateDTO appointmentDTO);
        Task UpdateAppointment(int id, AppointmentUpdateDTO appointmentDTO);
        Task DeleteAppointment(int id);
        Task<AppointmentReadOnlyDTO?> GetAppointmentById(int id);
        Task<List<AppointmentReadOnlyDTO>> GetAllAppointments();
        /*Task<Appointment?> GetAppointmentById(int id);
        Task<List<Appointment>> GetAllAppointments();*/
    }
}
