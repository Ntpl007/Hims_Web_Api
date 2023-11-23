using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hims_WebAPI.ViewModel
{
    public class SearchPatientVo
    {
        public string PATIENT_ID { get; set; }
       public string PatientMrn { get; set; }
       public string Name { get; set; }
        public string OpId { get; set; } 
       public decimal? Age { get; set; }
       public string Gender { get; set; }
       public string MobileNumber { get; set; }
        public DateTime DateOfVisit { get; set; }
        public string Occupation { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public string DoctorID { get; set; }
        public string ReligionName { get; set; }
        public string NationalityName { get; set; }
        public string ListName { get; set; } = null;
        public string Speciaity { get; set; }
        public string Village { get; set; }
        public string City { get; set; }
        public string AgeModeId { get; set; }
        public string EncounterId { get; set; }
    }
}
