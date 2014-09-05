using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MVCCodeChallenges.Models
{
    // represents a "contact us" form for a user requesting more information
    public class Contact : DbContext
    {   
        // PK
        public string ContactId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }

        [Required, StringLength(2000)]
        public string Comment { get; set; }
    }
}