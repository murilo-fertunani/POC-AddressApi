using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AddressApi.DAL.Entities
{
    public class AddressEntity
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        [StringLength(8, MinimumLength = 8)]
        public string PostalCode { get; set; }

        [StringLength(100, MinimumLength = 4)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string Complement { get; set; }

        [StringLength(50, MinimumLength = 4)]
        public string Neighborhood { get; set; }

        [StringLength(50, MinimumLength = 4)]
        public string City { get; set; }

        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }

        public AddressEntity()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            IsActive = true;
        }
    }
}