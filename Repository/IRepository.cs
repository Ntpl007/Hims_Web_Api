using Hims_WebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hims_WebAPI.Repository
{
    public interface IRepository
    {
        public Task<List<SearchPatientVo>> GetSearchPatientToday(int OrganizationId, int FacilityId);
        public Task<List<SearchPatientVo>> SearchPatients(PatientSearchInput Pinput);

        public Task<List<RegistrationPaymentsVo>> GetRegistrationPaymentDetails(int PatientId);

        public Task<List<RegistrationConsulatationPaymentVo>> GetRegistrationandConsulatationPaymentDetails(int PatientId, int EncounterId);
        public Task<bool>CheckIsAadharValid(string Aadhaar);
        public Task<int> AddVitalsTosepciality(AddVitalSignsToSpecialityVo Aadhaar);
        public Task<int> RemoveVitalsignForSpeciality(int Id);
        public Task<int> UpdateVitalsignOrder(List<UpdateVitalsignOrderVo> objList);
        public Task<int> SavePatientVitalSigns(List<VitalsForPatient> obj);
      
        //public Task<int> UpdateVitalsignOrder(List<UpdateVitalsignOrderVo> objList);
      
        //public Task<List<SearchPatientsbyNurseVo>> OpNurseStation(PatientSearchForNursingVo Pinput);

        public Task<List<SearchRegistrationPatientsVo>> SearchRegistrationPatients(PatientSearchInput Pinput);
      
        public Task<List<SearchRegistrationPatientsVo>> GetSearchRegisterPatientToday(int OrganizationId, int FacilityId);
    }

}
