using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Roles.Models
{
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [StringLength(300)]
        [Column(TypeName = "varchar(300)")]
        public string Description { get; set; }

        public ICollection<Task> Tasks { get; set; }



    }
}
