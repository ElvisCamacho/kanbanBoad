using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Roles.Models;

namespace Roles.ViewModel
{
    public class BoardVM
    {
        public Project Project { get; set; }
        public List<GroupedTasks> Tasks { get; set; }
    }

    public class GroupedTasks
    {
        public string Status { get; set; }
        public List<TaskReadVM> Tasks { get; set; }
    }
}
