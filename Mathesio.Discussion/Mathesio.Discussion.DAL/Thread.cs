using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mathesio.Discussion.DAL
{
    public class Thread
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public virtual Author Author { get; set; }

        public virtual ICollection<Comment> ChildrenComments { get; set; }
    }
}