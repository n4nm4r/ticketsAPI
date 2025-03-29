using System.ComponentModel.DataAnnotations;

namespace ticketsAPI
{
    public class Ticket
    {

        [Required]
        public int ConcertID { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(60)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [Range(1, 12, ErrorMessage = "Quantity must be between 1 and 12.")]
        public int Quantity { get; set; }

        [Required]
        [CreditCard]
        public string CreditCard { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"\d{2}/\d{2}", ErrorMessage = "Expiration must be in the format MM/YY.")]
        public string Expiration { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"\d{3,4}", ErrorMessage = "Security code must be 3 or 4 digits.")]
        public string SecurityCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string City { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Province { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d", ErrorMessage = "Postal code must be in the format A1B 2C3.")]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;
    }
}
