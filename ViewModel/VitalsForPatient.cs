using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hims_WebAPI.ViewModel
{
    public class VitalsForPatient
    {
        public int EncounterId { get; set; }
        public int VitalSignId { get; set; }
        public decimal Value { get; set; }
        public string CreatedBy { get; set; }
      
    }
}
