using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models
{
    // Represents a volunteer job/activity that people can sign up for
    public class VolunteerTask
    {
        // Primary key
        public int Id { get; set; }

        // Short, clear task name (required, max 80 chars)
        [Required, StringLength(80)]
        public string Title { get; set; } = string.Empty;

        // What volunteers will do / instructions (required, multiline)
        [Required, DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        // Where to meet / work (optional, max 80 chars)
        [StringLength(80)]
        public string? Location { get; set; }

        // When it starts (optional; use description to note end time if needed)
        [DataType(DataType.DateTime)]
        public DateTime? ScheduledAt { get; set; }

        // Number of volunteer slots available (1–500), default 10
        [Range(1, 500)]
        public int Slots { get; set; } = 10;
    }
}
