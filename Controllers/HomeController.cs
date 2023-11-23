using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hims_WebAPI.Management;
using Hims_WebAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Hims_WebAPI.Repository;
using Hims_WebAPI.Repository.SaveOP_Repository;

namespace Hims_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
      private readonly IRepository _repository;
        public HomeController(IRepository repository)
        {
            this._repository = repository;
        }

        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<List<SearchPatientVo>> SearchPatients(PatientSearchInput Pinput)
        {
         
          var response=await _repository.SearchPatients(Pinput);
          return response;


        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<List<SearchPatientVo>> GetSearchPatientToday(int OrganizationId, int FacilityId)
        {
            var response = await _repository.GetSearchPatientToday(OrganizationId, FacilityId);
            return response;

        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<bool>CheckAadhaarValid(string Aadhaar)
       {
          
             var response =await _repository.CheckIsAadharValid(Aadhaar);
             return response;

        }


        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        public int UpdateAge()
        {
            SaveOP_Repository obj = new SaveOP_Repository();
            var response = obj.UpdateAge();
            return response;
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<List<RegistrationPaymentsVo>> GetRegistrationPaymentDetails(int PatientId)
        {
            List<RegistrationPaymentsVo> registrationPaymentsVos = new List<RegistrationPaymentsVo>();
            try
            {
               registrationPaymentsVos = await _repository.GetRegistrationPaymentDetails(PatientId);
                
            }
            catch(Exception e)
            {
               
            }
            return registrationPaymentsVos;
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<List<RegistrationConsulatationPaymentVo>> GetRegistrationandConsulatationPaymentDetails(int PatientId, int EncounterId)
        {
            List<RegistrationConsulatationPaymentVo> registrationPaymentsVos = new List<RegistrationConsulatationPaymentVo>();
            try
            {
                registrationPaymentsVos = await _repository.GetRegistrationandConsulatationPaymentDetails(PatientId, EncounterId);

            }
            catch (Exception e)
            {

            }
            return registrationPaymentsVos;
        }
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("[action]")]
        public async Task<int> AddVitalsTosepciality(AddVitalSignsToSpecialityVo obj)
        {
            var response = await _repository.AddVitalsTosepciality(obj);
            return response;
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<int> RemoveVitalsignForSpeciality(int Id)
        {
            return await _repository.RemoveVitalsignForSpeciality(Id);
        }

        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<int> UpdateVitalsignOrder(List<UpdateVitalsignOrderVo> objList)
        {
            return await _repository.UpdateVitalsignOrder(objList);
        }
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<int> SavePatientVitalSigns(List<VitalsForPatient> obj)
        {
            return await _repository.SavePatientVitalSigns(obj);
        }

     
        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        [Route("[action]")]
        public async Task<List<SearchRegistrationPatientsVo>> SearchRegistrationPatients(PatientSearchInput Pinput)
        {
            try
            {
               return await _repository.SearchRegistrationPatients(Pinput);

            }
            catch (Exception e)
            {
                throw e;
            }
           
        }
        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        [Route("[action]")]
        public async Task<List<SearchRegistrationPatientsVo>> GetSearchRegisterPatientToday(int OrganizationId, int FacilityId)
        {

            try
            {
                return await _repository.GetSearchRegisterPatientToday(OrganizationId, FacilityId);

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
