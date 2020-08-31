using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

        [Required]
        public string PasswordSalt { get; set; }
    }
}
