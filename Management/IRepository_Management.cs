using Hims_WebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hims_WebAPI.Management
{
    interface IRepository_Management
    {
        public bool CheckIsAadhaarValid(string Aadhaar);
        public List<SearchPatientVo> SearchPatients(PatientSearchInput Pinput);


    }
}
