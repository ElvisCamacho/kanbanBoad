using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roles.ViewModel
{
    public class DisplayVm
    {
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<UsersVm> Users { get; set; }
    }
}
