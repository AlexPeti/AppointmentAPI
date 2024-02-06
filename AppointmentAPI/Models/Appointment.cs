using System;
using System.Collections.Generic;

namespace AppointmentAPI.Models;

public partial class Appointment
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime StartTime { get; set; }
}
