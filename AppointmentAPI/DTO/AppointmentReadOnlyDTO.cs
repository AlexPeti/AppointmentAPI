namespace AppointmentAPI.DTO
{
    public  class AppointmentReadOnlyDTO
    {
        public int Id { get; set; }

        public string Firstname { get; set; } = null!;

        public string Lastname { get; set; } = null!;

        public DateTime StartTime { get; set; }
    }
}
