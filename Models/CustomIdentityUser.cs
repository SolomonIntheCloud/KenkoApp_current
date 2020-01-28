using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace KenkoApp.Models
{
    public class CustomIdentityUser : IdentityUser  

    {
        //Emilee, add new patient user properties 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateofBirth { get; set; }
        public string Gender { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string SecondaryPhone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string MaritalStatus { get; set; }
        public string EmergencyContact { get; set; }
        public string Relationship { get; set; }
        public string InsuranceProvider { get; set; }
        public string InsurancePolicyNumber { get; set; }


    }
}
