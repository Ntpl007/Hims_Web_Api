using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hims_WebAPI.ViewModel
{
    public class tblP
    {

               public string FirstName { get; set; }
               public string Prefix { get; set; }
               public int Sex { get; set; }
              public DateTime DateOfBirth { get; set; }
        public int DoctorId { get; set; }
        public int ReferringPhysicianId { get; set; }
        public string Occupation { get; set; }
        // MaritalStatusId = inputMaritalStatusId;
        public int StatusId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        // BloodGroup = inputBloodGroup;
        //  Age = inputAge;
        public string MobileNumber { get; set; }
        public int AreaId { get; set; }
        public string SOWODO { get; set; }
        public int Relationtype { get; set; }

        //  RfId = inputRfId;
        public string MotherName { get; set; }
        // AadharNo = inputAadharNo;
        public int CorporateId { get; set; }
        public int Religion { get; set; }
        public int Nationality { get; set; }
    }
}
