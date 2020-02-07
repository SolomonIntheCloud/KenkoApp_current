using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenkoApp.Models
{
    public class CareAdministrator
    {
        public int CareAdministratorId { get; set; }
        public string AdminEmail { get; set; }
        public string AdminPassword { get; set; }
        public ICollection<PCM> PCMs { get; set; }
    }
}
