using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hims_WebAPI.ViewModel
{
    public class RegistrationPaymentsVo
    {
        public string Patient_Id { get; set; }
        public string PatientMrn { get; set; }
        public string Name { get; set; }
        //public string OpId { get; set; }
        public decimal? Age { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Occupation { get; set; }
        public string Religion { get; set; }
        public string Nationality { get; set; }
        public string DoctorID { get; set; }
        public string ReligionName { get; set; }
        public string NationalityName { get; set; }
        //public string ListName { get; set; }
        //public string Speciaity { get; set; }
        public string Village { get; set; }
        public string City { get; set; }
        public string AgeModeId { get; set; }
        public string RegistrationAmount { get; set; }
        public string RegPaidAmount { get; set; }
        public string ReceiptNumber { get; set; }
        public string PaymentMode { get; set; }
    }
}
