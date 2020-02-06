using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KenkoApp.Models
{
    public class HealthRecord
    {
        public int HealthRecordID { get; set; }
        public string Title { get; set; }
        public byte[] RecordData { get; set; }
        public string FileType { get; set; }
        public string RecordNotes { get; set; }
        public CustomIdentityUser CustomIdentityUser { get; set; }

    }
}
