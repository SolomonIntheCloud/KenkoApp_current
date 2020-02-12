using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenkoApp.Models
{
    public class Appointment
    {
        public DateTime DateTime { get; set; }
        public int AppointmentID { get; set; }
        public string ReasonForVisit { get; set; }
        public PCM PCM { get; set; }
        public CustomIdentityUser CustomIdentityUser { get; set; }
    }
}
