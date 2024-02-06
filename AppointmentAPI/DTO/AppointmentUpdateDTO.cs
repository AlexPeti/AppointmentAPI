using System.ComponentModel.DataAnnotations;

namespace AppointmentAPI.DTO
{
    public class AppointmentUpdateDTO
    {
        /*[Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, ErrorMessage = "The {0} field must be maximum of {1} characters")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Spaces are not allowed")]
        public string? Firstname { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, ErrorMessage = "The {0} field must be maximum of {1} characters")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Spaces are not allowed")]
        public string? Lastname { get; set; }*/

        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/1/2000", "1/1/2050", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime? StartTime { get; set; }
    }
}
