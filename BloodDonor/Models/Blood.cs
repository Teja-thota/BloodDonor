using System.ComponentModel.DataAnnotations;

namespace BloodDonor.Models
{
    public class Blood
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string BloodType { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
