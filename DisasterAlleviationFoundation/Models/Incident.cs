using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models
{
    // Impact level of the incident
    public enum IncidentSeverity { Low = 1, Medium = 2, High = 3, Critical = 4 }

    // Workflow state of the incident
    public enum IncidentStatus { New = 1, InProgress = 2, Resolved = 3, Closed = 4 }

    // Incident entity stored in the database
    public class Incident
    {
        // Primary key
        public int Id { get; set; }

        // Short, clear name of the incident (required, max 80 chars)
        [Required, StringLength(80)]
        public string Title { get; set; } = string.Empty;

        // Detailed description (required, multiline)
        [Required, DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        // Where it happened (required, max 120 chars)
        [Required, StringLength(120)]
        public string Location { get; set; } = string.Empty;

        // When it occurred (display label for the UI)
        [Display(Name = "Date/Time Occurred"), DataType(DataType.DateTime)]
        public DateTime OccurredAt { get; set; } = DateTime.Now;

        // Severity and status (both required; defaults set)
        [Required] public IncidentSeverity Severity { get; set; } = IncidentSeverity.Low;
        [Required] public IncidentStatus Status { get; set; } = IncidentStatus.New;

        // Identity user id of the reporter (optional)
        public string? ReporterUserId { get; set; }

        // Created timestamp (UTC) for sorting/audit
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
