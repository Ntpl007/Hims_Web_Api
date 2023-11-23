using Hims_WebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hims_WebAPI.BHISHAK_APP_DB;
using MySql.Data.MySqlClient;
using Hims_WebAPI.StoreProcedures;
using Microsoft.EntityFrameworkCore;

namespace Hims_WebAPI.Repository
{
    public class Repositories : IRepository
    {
        private  bhishak_app_dbContext _context;
        private readonly StoreProceduresContext _SPcontext;
        public Repositories(StoreProceduresContext SPcontext, bhishak_app_dbContext context)
        {
            _SPcontext = SPcontext;
            _context = context;
        }

        //search patients present date
        public async Task<List<SearchPatientVo>> GetSearchPatientToday(int OrganizationId,int FacilityId)
        {
            try
            {
                var _organizationId = new MySqlParameter("OrganizationId", OrganizationId);
                var _facilityId = new MySqlParameter("FacilityId", FacilityId);
                var objList = await _SPcontext.SP_SearchPatientsbytoday
             .FromSqlRaw("call SP_SearchPatientsbytoday(@OrganizationId,@FacilityId)", _organizationId, _facilityId).ToListAsync();
                return objList.OrderBy(x => x.OpId).ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
            return null;
        }
        public async Task<int> RemoveVitalsignForSpeciality(int Id)
        {
            TblFacilityVitalsign obj = new TblFacilityVitalsign();
            var tbl = await _context.TblFacilityVitalsigns.Where(x => x.FacilityVitalsignId == Id).FirstAsync();
            tbl.StatusId = 2;
            tbl.OrderNumber = null;
            return await _context.SaveChangesAsync();
        }
        public async Task<List<SearchRegistrationPatientsVo>> GetSearchRegisterPatientToday(int OrganizationId, int FacilityId)
        {
            try
            {
                var _organizationId = new MySqlParameter("OrganizationId", OrganizationId);
                var _facilityId = new MySqlParameter("FacilityId", FacilityId);
                var objList = await _SPcontext.SP_SearchRegisterPatientsbytoday
             .FromSqlRaw("call SP_SearchRegisterPatientsbytoday(@OrganizationId,@FacilityId)", _organizationId, _facilityId).ToListAsync();
                return objList.OrderBy(x => x.Name).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
            return null;
        }

        public async Task<List<RegistrationPaymentsVo>> GetRegistrationPaymentDetails(int PatientId1)
        {
            var PatientId = new MySqlParameter("PatientId", PatientId1);
            //var EncounterId = new MySqlParameter("EncounterId", EncounterId1);
           
            var objList = await _SPcontext.SP_GetPatientRegistrationDetails
               .FromSqlRaw("call SP_GetPatientRegistrationDetails(@PatientId)", PatientId).ToListAsync();
            return objList.ToList();
        }

        public async Task<List<RegistrationConsulatationPaymentVo>> GetRegistrationandConsulatationPaymentDetails(int PatientId1,int EncounterId1)
        {
            var PatientId = new MySqlParameter("PatientId", PatientId1);
            var EncounterId = new MySqlParameter("EncounterId", EncounterId1);

            var objList = await _SPcontext.SP_GetPatientRegistrationandConsulatationDetails
               .FromSqlRaw("call SP_GetPatientRegistrationandConsulatationDetails(@PatientId,@EncounterId)", PatientId, EncounterId).ToListAsync();
            return objList.ToList();
        }


        //search patient with filters
        public async Task<List<SearchPatientVo>> SearchPatients(PatientSearchInput Pinput)
        {
            var FromDate = new MySqlParameter("FromDate", Pinput.FromDate);
            var ToDate = new MySqlParameter("ToDate", Pinput.ToDate);
            var Mobile = new MySqlParameter("MobileNumber", Pinput.MobileNumber);
            var FirstName = new MySqlParameter("FirstName", Pinput.FirstName);
            var OrganizationId = new MySqlParameter("OrganizationId", Pinput.OrganizationId);
            var FacilityId = new MySqlParameter("FacilityId", Pinput.FacilityId);
            var objList =await _SPcontext.SP_SearchPatients
                .FromSqlRaw("call SP_SearchPatients(@FromDate,@ToDate,@MobileNumber,@FirstName,@OrganizationId,@FacilityId)", FromDate,ToDate,Mobile,FirstName, OrganizationId,FacilityId).ToListAsync();
               return objList.OrderBy(x => x.OpId).ToList();

        }
        public async Task<List<SearchRegistrationPatientsVo>> SearchRegistrationPatients(PatientSearchInput Pinput)
        {
            var FromDate = new MySqlParameter("FromDate", Pinput.FromDate);
            var ToDate = new MySqlParameter("ToDate", Pinput.ToDate);
            var Mobile = new MySqlParameter("MobileNumber", Pinput.MobileNumber);
            var FirstName = new MySqlParameter("FirstName", Pinput.FirstName);
            var OrganizationId = new MySqlParameter("OrganizationId", Pinput.OrganizationId);
            var FacilityId = new MySqlParameter("FacilityId", Pinput.FacilityId);
            var objList = await _SPcontext.SP_SearchRegisteredPatients
                .FromSqlRaw("call SP_SearchRegisteredPatients(@FromDate,@ToDate,@MobileNumber,@FirstName,@OrganizationId,@FacilityId)", FromDate, ToDate, Mobile, FirstName, OrganizationId, FacilityId).ToListAsync();
            return objList.OrderBy(x => x.Name).ToList();

        }

        //check is aadhaar already existed or not
        public async  Task<bool>CheckIsAadharValid(string Aadhaar)
        {
            _context = new bhishak_app_dbContext();
            var result =await _context.TblPatients.Where(x => x.AadhaarNumber == Aadhaar).FirstOrDefaultAsync();
                if (result != null)
                {
                    return true;
                }
                else return false;
            
        }
        public async Task<int> AddVitalsTosepciality(AddVitalSignsToSpecialityVo obj)
        {
            try
            {
               // TblFacilityVitalsign result = new TblFacilityVitalsign();
                var facilitymapid = await (from x in _context.TblFacilityMappings
                                           where
                       x.FacilityId == obj.FacilityId && x.OrganizationId == obj.OrganizationId
                                           select x.FacilityMappingId).FirstAsync();
                var facilityspecialitylinkid = (from x in _context.TblFacilitySpecialityLnks
                                                where x.FacilityMappingId == facilitymapid &&
                                                x.SpecialityId == obj.SpecialityId
                                                select x.FacilitySpecialitlnkId).First();
              var   result =  _context.TblFacilityVitalsigns.Where(
                                    x=> x.VitalsignId == obj.VitalSignId &&
                                        x.FacilitySpecialitylnkId == facilityspecialitylinkid
                                    ).Count();
                TblFacilityVitalsign tbl = new TblFacilityVitalsign();
                if (result ==0)
                {

                    tbl.FacilitySpecialitylnkId = facilityspecialitylinkid;
                    tbl.VitalsignId = obj.VitalSignId;
                    tbl.CreatedBy = obj.CreatedBy;
                    tbl.CreatedDate = DateTime.Now;
                    tbl.StatusId = 1;
                    _context.TblFacilityVitalsigns.Add(tbl);
                    return await _context.SaveChangesAsync();
                }
                else
                {
                    var res = _context.TblFacilityVitalsigns.Where(
                                    x => x.VitalsignId == obj.VitalSignId &&
                                        x.FacilitySpecialitylnkId == facilityspecialitylinkid
                                    ).FirstOrDefault();
                    res.StatusId = 1;
                    return await _context.SaveChangesAsync();

                }
            }
            catch(Exception e)
            {
                throw e;
            }
          
        }
        public async Task<int> UpdateVitalsignOrder(List<UpdateVitalsignOrderVo> objList)
        {
            int Response = 0;
            try
            {
                TblFacilityVitalsign obj = new TblFacilityVitalsign();
                for (int i = 0; i < objList.Count; i++)
                {
                    var tbl = await _context.TblFacilityVitalsigns.Where(x => x.FacilityVitalsignId == objList[i].facilityVitalSignId).FirstAsync();

                    tbl.OrderNumber = objList[i].orderNumber;
                    Response += await _context.SaveChangesAsync();
                }

                return Response;
            }
            catch (Exception e)
            { throw e; }

        }

        //public async Task<int> UpdateVitalsignOrder(List<UpdateVitalsignOrderVo> objList)
        //{
        //    int Response = 0;
        //    try
        //    {
        //        TblFacilityVitalsign obj = new TblFacilityVitalsign();
        //        for (int i = 0; i < objList.Count; i++)
        //        {
        //            var tbl = await _context.TblFacilityVitalsigns.Where(x => x.FacilityVitalsignId == objList[i].facilityVitalSignId).FirstAsync();

        //            tbl.OrderNumber = objList[i].orderNumber;
        //            Response += await _context.SaveChangesAsync();
        //        }

        //        return Response;
        //    }
        //    catch(Exception e)
        //    { throw e; }

        //}

        public async Task<int> SavePatientVitalSigns(List<VitalsForPatient> obj)
        {
            try
            {
                int resp = 0;
                for(int i=0;i<obj.Count;i++)
                {
                    var res = _context.TblEncounterVitalsigns.Where(x => x.EncounterId == obj[i].EncounterId
                      && x.VitalsignId == obj[i].VitalSignId).FirstOrDefault();
                    if (res == null)
                    {
                        TblEncounterVitalsign tbl = new TblEncounterVitalsign();
                        tbl.Value = obj[i].Value;
                        tbl.VitalsignId = obj[i].VitalSignId;
                        tbl.EncounterId = obj[i].EncounterId;
                        tbl.CreatedBy = obj[i].CreatedBy;
                        tbl.CreatedDate = DateTime.Now;
                        _context.TblEncounterVitalsigns.Add(tbl);
                        resp += await _context.SaveChangesAsync();
                      
                    }
                    else
                    {
                        res.Value = obj[i].Value;
                        res.ModifiedBy = obj[i].CreatedBy;
                        res.ModifiedDate = DateTime.Now;
                        resp += await _context.SaveChangesAsync();
                    }

                }
                return resp;
               
            }
            catch (Exception e)
            { throw e; }

        }
        //public async Task<List<SearchPatientsbyNurseVo>> OpNurseStation(PatientSearchForNursingVo Pinput)
        //{
        //    try
        //    {
        //        var FromDate = new MySqlParameter("FromDate", Pinput.FromDate);
        //        var ToDate = new MySqlParameter("ToDate", Pinput.ToDate);
        //        var Mobile = new MySqlParameter("MobileNumber", Pinput.MobileNumber);
        //        var FirstName = new MySqlParameter("FirstName", Pinput.FirstName);
        //        var SpecialityID = new MySqlParameter("SpecialityID", Pinput.SpecialityID == 0 ? null : Pinput.SpecialityID);
        //        var DoctorId = new MySqlParameter("DoctorId", Pinput.DoctorId == 0 ? null : Pinput.DoctorId);
        //        var objList = await _SPcontext.SP_SearchPatientsbyNurse
        //            .FromSqlRaw("call SP_SearchPatientsbyNurse(@FromDate,@ToDate,@MobileNumber,@FirstName,@SpecialityID,@DoctorId)", FromDate, ToDate, Mobile, FirstName, SpecialityID, DoctorId).ToListAsync();
        //        return objList.OrderBy(x => x.OpId).ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }


        //}

      
    }
}
