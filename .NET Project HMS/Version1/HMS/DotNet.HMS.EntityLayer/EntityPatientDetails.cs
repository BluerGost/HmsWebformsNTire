using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.HMS.EntityLayer
{
    public class EntityPatientDetails
    {
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public int Age { get; set; }
        public string Sex { get; set; }
        public string BloodType { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string StateId { get; set; }
        public string PlanId { get; set; }
    }
}
