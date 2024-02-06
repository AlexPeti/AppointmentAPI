using Microsoft.AspNetCore.Mvc;
using AppointmentAPI.Data;
using AppointmentAPI.Service;
using AutoMapper;
using AppointmentAPI.DTO;
using AppointmentAPI.Models;

namespace AppointmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentDbContext _context;
        private readonly IAppointmentService appointmentService;
        private readonly IMapper mapper;

        public AppointmentsController(AppointmentDbContext context, IAppointmentService appointmentService, IMapper mapper)
        {
            this._context = context;
            this.appointmentService = appointmentService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentCreateDTO>> CreateAppointment(AppointmentCreateDTO appointmentDTO)
        {
            try
            {
                Appointment? appointmentToCreate = await appointmentService.CreateAppointment(appointmentDTO);
                if (appointmentToCreate == null)
                {
                    return BadRequest();
                }

                var dto = mapper.Map<AppointmentCreateDTO>(appointmentToCreate);

                return CreatedAtAction(nameof(GetAppointmentById), new { id = appointmentToCreate.Id }, dto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAppointment(int id, AppointmentUpdateDTO appointmentDTO)
        {
            try
            {
                await appointmentService.UpdateAppointment(id, appointmentDTO);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                await appointmentService.DeleteAppointment(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            var appointments = await appointmentService.GetAllAppointments();
            var appointmentsDTO = mapper.Map<List<AppointmentReadOnlyDTO>>(appointments);
            return Ok(appointmentsDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var appointment = await appointmentService.GetAppointmentById(id);
            if (appointment == null)
            {
                return NotFound();
            }
            var appointmentDto = mapper.Map<AppointmentReadOnlyDTO>(appointment);
            return Ok(appointmentDto);
        }
    }
}
