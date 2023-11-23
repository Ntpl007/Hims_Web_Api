using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hims_WebAPI.ViewModel
{
    public class OpCreateResult
    {
        public long? PatientID { get; set; }

        public long EncounterID { get; set; }

       public string OpID { get; set; }

        public string Message { get; set; }
    }
}
