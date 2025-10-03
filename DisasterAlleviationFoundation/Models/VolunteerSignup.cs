using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models
{
    public class VolunteerSignup
    {
        public int Id { get; set; }

        [Required] public int VolunteerTaskId { get; set; }
        public VolunteerTask? VolunteerTask { get; set; }

        // who signed up (Identity user)
        public string? UserId { get; set; }
        public DateTime SignedAt { get; set; } = DateTime.UtcNow;
    }
}
