using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hims_WebAPI.ViewModel
{
    public class SearchPatientsbyNurseVo
    {
       
        public int PatientId { get; set; }
        public string PatientMrn { get; set; }
        public string Name { get; set; }
        public string OpId { get; set; }
        public decimal? Age { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string AgeModeId { get; set; }
        public string Speciality { get; set; }
        public string Doctor { get; set; }
        public int SpecialityId { get; set; }
        public int EncounterId { get; set; }


    }
}
