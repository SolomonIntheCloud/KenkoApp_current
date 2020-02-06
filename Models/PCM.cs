using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenkoApp.Models
{
    public class PCM
    {
        public string pcmFName { get; set; }
        public string pcmLName { get; set; }
        public int PCMID { get; set; }
        public string Specialty { get; set; }
        public CareAdministrator CareAdministrator { get; set; }

    }
}
