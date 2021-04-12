using Roles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roles.ViewModel
{
    public class UsersVm
    {
        public string Email { get; set; }
        public IEnumerable<UserRole> Roles { get; set; }
    }
}
