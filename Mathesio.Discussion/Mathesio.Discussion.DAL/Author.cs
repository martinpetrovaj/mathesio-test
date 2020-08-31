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
        // Should be set as unique thanks to index setup, see DiscussionContext
        public string Name { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}
