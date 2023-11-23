using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hims_WebAPI.ViewModel
{
    public class PatientSearchForNursingVo
    {
        public DateTime? FromDate { get; set; } = null;
        public DateTime? ToDate { get; set; } = null;
        public string MobileNumber { get; set; } = null;
        public string FirstName { get; set; } = null;
        public int? SpecialityID { get; set; }
        public int? DoctorId { get; set; }
    }
}
