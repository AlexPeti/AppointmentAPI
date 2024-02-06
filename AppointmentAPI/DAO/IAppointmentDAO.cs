using AppointmentAPI.Models;

namespace AppointmentAPI.DAO
{
    public interface IAppointmentDAO
    {
        Task<Appointment?> Insert(Appointment appointment);
        Task<bool> Update(int id, Appointment appointment);
        Task<bool> Delete(int id);
        Task<Appointment?> GetById(int id);
        Task<List<Appointment>> GetAll();
    }
}
