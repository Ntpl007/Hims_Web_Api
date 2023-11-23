using System;
namespace Hims_WebAPI.ViewModel
{
    public class OpInput
    {
        public long? PatientId { get; set; } = null;
        public string Prefix { get; set; }
        public DateTime? dob { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //  public DateTime DatOfBirth { get; set; }
        public int conamount { get; set; }
         public int Sex { get; set; }
         public string MobileNumber { get; set; }
         public string EmailId { get; set; }
        // public int RelationType { get; set; }
       //  public string RelationName { get; set; }
      //  public string MotherName { get; set; }
         public string Occupation { get; set; }
         public int ReligionId { get; set; }
         public int AreaId { get; set; }//
         public string Address { get; set; }//
        public int? SpacialityId { get; set; }
        public int? DoctorId { get; set; }
        public int? RefDoctorId { get; set; }
         public int NationalityId { get; set; }
        public int? CorporateId { get; set; } = null; 
        public string Comments { get; set; } = null;
        public decimal? PaymentAmount { get; set; } = null;
        public int? PaymentMode { get; set; } 
        public int? State { get; set; } = null;
        public string Aadhaar { get; set; } = null;
        public string HouseNo { get; set; } = null;
        
        public int? District { get; set; } = null;
        public string City { get; set; } = null;
        public string Village { get; set; } = null;
        public string CreatedBy { get; set; }
        public string txtRefDoctor { get; set; } = null;
        public int FacilityId { get; set; } 
        public int Organization_id { get; set; }
        public int Pincode { get; set; }
        public int PaymentCategoryId { get; set; }
        public string BeneficiaryId { get; set; } = null;
        public int? AppointmentId { get; set; }








    }
}
