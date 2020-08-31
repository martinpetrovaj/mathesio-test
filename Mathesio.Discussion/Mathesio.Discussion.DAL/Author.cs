using System;
using System.ComponentModel.DataAnnotations;

namespace Mathesio.Discussion.DAL
{
    public class Author
    {
        [Key]
        public Guid ID { get; set; }

        [Required]
        [StringLength(maximumLength: 56, MinimumLength = 6)]
        public string Name { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
