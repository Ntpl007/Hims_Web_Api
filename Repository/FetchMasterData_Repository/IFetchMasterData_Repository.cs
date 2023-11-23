using Hims_WebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hims_WebAPI.Repository.FetchMasterData_Repository
{
    interface IFetchMasterData_Repository
    {
        public IEnumerable<DocotorVo> GetDoctor();
        public IEnumerable<DocotorVo> GetRefDoctors();
        public IEnumerable<AreaVo> GetArea();
        public IEnumerable<CorporateVo> GetCorporate();
        public IEnumerable<NationalityVo> GetNationality();
        public IEnumerable<SpecialityVo> GetSpeciality();
        public IEnumerable<OccupationVo> GetOccupation();
        public IEnumerable<PatientRelationVo> GetPatientRelation();
        public IEnumerable<PatientVo> GetPatientDetails(string MobileNumber);
        public IEnumerable<RelegionVo> GetReligion();
    }
}
