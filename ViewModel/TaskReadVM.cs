using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Roles.Models;
using Task = Roles.Models.Task;

namespace Roles.ViewModel
{
    public class TaskReadVM
    {
        public Task Task { get; set; }
        public string Assignee { get; set; }
        public string ReturnUrl { get; set; }
    }
}
