using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.HMS.EntityLayer
{
    public class EntityPhysician
    {
        // public string PhysicianId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearsOfExperience { get; set; }
        public string DepartmentId { get; set; }
        public string StateId { get; set; }
        public string PlanId { get; set; }
        public string EduQualification { get; set; }
    }
}
