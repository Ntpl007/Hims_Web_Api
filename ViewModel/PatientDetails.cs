using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hims_WebAPI.ViewModel
{
    public class PatientDetails
    {
        public long PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public decimal? Age { get; set; }
        //public string GENDER { get; set; }

        public int? Sex { get; set; }
        public int? relationtype { get; set; }
        public string relationname { get; set; }
        public DateTime? dob { get; set; }
        public string prefix { get; set; }
        public string occupation { get; set; }
        public int? religionid { get; set; }

        public int? nationalityid { get; set; }

        public int? areaid { get; set; }
        public string emailid { get; set; }

        public string address { get; set; }
    }
}
