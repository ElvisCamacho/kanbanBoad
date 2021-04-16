using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Roles.Models
{
    public class Task
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
         public string Summary { get; set; }

        [StringLength(300)]
         public string Description { get; set; }
        
         public TaskStatus Status { get; set; }
        
         public string Assignee { get; set; }
        
        public int StoryPoints { get; set; }

        public Project Project { get; set; }
    }
}
