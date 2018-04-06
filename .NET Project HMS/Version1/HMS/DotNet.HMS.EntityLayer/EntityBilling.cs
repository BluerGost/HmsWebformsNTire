using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet.HMS.EntityLayer
{
   public class EntityBilling
    {
        //BillId -> Primary Key ->set automatically
        public int BillId { get; set; } 
        public int BillAmount { get; set; }
        public string CardNumber { get; set; }
        public string ModeOfPayment { get; set; }

        //DiagnosisId -> Foreign Key -> Will be assigned with the output value we 
        //got from spEnterPatientDiagnosisDetails Stored Procedure 
        public int DiagnosisId { get; set; }
    }
}
