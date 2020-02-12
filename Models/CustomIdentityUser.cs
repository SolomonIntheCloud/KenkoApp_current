using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace KenkoApp.Models
{
    public class CustomIdentityUser : IdentityUser  
    {
        public PCM PCM { get; set; }
        public ICollection<HealthRecord> HealthRecords { get; set; } 
        public ICollection<Appointment> Appointments { get; set; }

        //Emilee, add new patient user properties 
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)] //added this and the ?
        public DateTime? DateofBirth { get; set; }
        
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        public string[] Genders = new[] { "Male", "Female", "Unspecified" }; //add line 31
        
        [Display(Name = "Social Security Number")]
        public string SocialSecurityNumber { get; set; }

        [Display(Name = "Secondary Phone")]
        public string SecondaryPhone { get; set; }

        [Display(Name = "Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }

        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Display(Name = "Marital Status")]
        public string MaritalStatus { get; set; }

        [Display(Name = "Emergency Contact")]
        public string EmergencyContact { get; set; }

        [Display(Name = "Relationship")]
        public string Relationship { get; set; }

        [Display(Name = "Insurance Provider")]
        public string InsuranceProvider { get; set; }

        public enum Insurance
        {
            TogetherHealth,
            Persona,
            Peak,
            BluePlus,
            BlueArmor,
            Edna
        }

        [Display(Name = "Insurance Policy Number")]
        public string InsurancePolicyNumber { get; set; }
 
    }


}

