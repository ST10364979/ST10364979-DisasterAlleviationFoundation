using System.ComponentModel.DataAnnotations;

namespace DisasterAlleviationFoundation.Models
{

    // Categories of donated items
    public enum DonationType { Food = 1, Clothing = 2, MedicalSupplies = 3, Hygiene = 4, Other = 5 }

    // Lifecycle of a donation record
    public enum DonationStatus { Pledged = 1, Received = 2, Distributed = 3 }

    // Donation entity stored in the database
    public class Donation
    {
        //Primary key
        public int Id { get; set; }

        [Required, StringLength(80)]
        public string DonorName { get; set; } = string.Empty;

        [EmailAddress] public string? DonorEmail { get; set; }

        [Required] public DonationType Type { get; set; }
        [Range(1, 100000)] public int Quantity { get; set; } = 1;

        [StringLength(200)]
        public string? Notes { get; set; }

        [Required] public DonationStatus Status { get; set; } = DonationStatus.Pledged;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
