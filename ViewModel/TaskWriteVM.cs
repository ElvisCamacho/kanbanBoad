using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task = Roles.Models.Task;

namespace Roles.ViewModel
{
    public class TaskWriteVM
    {
        public Task Task { get; set; }
        public List<SelectListItem> Users { get; set; }
        public string ReturnUrl { get; set; }
        public int ProjectId { get; set; }
    }
}
