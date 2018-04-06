using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.HMS.EntityLayer
{
    public class EntityPatientDiagnosis
    {
        //Diagnosis Id is automatically assigned   
        public int DiagnosisId { get; set; }
        public int PatientId { get; set; }   
        public string Symptoms { get; set; }
        public string DiagnosisProvided { get; set;}
        public string AdministeredBy { get; set; }
        public DateTime DateofDiagnosis { get; set; }
        public string FollowUpRequired { get; set; }
        public DateTime DateOfFollowUp { get; set; }
    }
}
