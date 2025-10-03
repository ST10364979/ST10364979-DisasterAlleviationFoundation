using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models
{
    public class VolunteerTask
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Title { get; set; } = string.Empty;

        [Required, DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        [StringLength(80)] public string? Location { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ScheduledAt { get; set; }

        [Range(1, 500)]
        public int Slots { get; set; } = 10;
    }
}
