using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models
{
    public enum IncidentSeverity { Low = 1, Medium = 2, High = 3, Critical = 4 }
    public enum IncidentStatus { New = 1, InProgress = 2, Resolved = 3, Closed = 4 }

    public class Incident
    {
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string Title { get; set; } = string.Empty;

        [Required, DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        [Required, StringLength(120)]
        public string Location { get; set; } = string.Empty;

        [Display(Name = "Date/Time Occurred"), DataType(DataType.DateTime)]
        public DateTime OccurredAt { get; set; } = DateTime.Now;

        [Required] public IncidentSeverity Severity { get; set; } = IncidentSeverity.Low;
        [Required] public IncidentStatus Status { get; set; } = IncidentStatus.New;

        public string? ReporterUserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
