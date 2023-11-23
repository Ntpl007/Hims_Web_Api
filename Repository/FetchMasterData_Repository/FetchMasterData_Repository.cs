using Hims_WebAPI.BHISHAK_APP_DB;
using Hims_WebAPI.ViewModel;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

using MySql.EntityFrameworkCore;
using Hims_WebAPI.StoreProcedures;
using Microsoft.EntityFrameworkCore;

namespace Hims_WebAPI.Repository.FetchMasterData_Repository
{
    public class FetchMasterData_Repository
    {
        public IEnumerable<DocotorVo> GetDoctor()
        {
            List<DocotorVo> objdoctors = new List<DocotorVo>();
           

                using (var context = new bhishak_app_dbContext())
                {


                    objdoctors = (from p in context.TblProviders.Where(x => x.StatusId == 1 && x.IsProvider == true)
                                  select new DocotorVo
                                  {
                                      firstName = p.ListName,
                                      ProviderId = p.ProviderId

                                  }

                                ).ToList();

                    return objdoctors;

                }
           

        }

        public IEnumerable<DocotorVo> GetRefDoctors()
        {
            List<DocotorVo> objdoctors = new List<DocotorVo>();
         

                using (var context = new bhishak_app_dbContext())
                {


                    objdoctors = (from p in context.TblProviders.Where(x => x.StatusId == 1)
                                  select new DocotorVo
                                  {
                                      firstName = p.ListName,
                                      ProviderId = p.ProviderId

                                  }

                                ).ToList();

                    return objdoctors;

                }
           
            return objdoctors;
        }
        public IEnumerable<AreaVo> GetArea()
        {
            List<AreaVo> objList = new List<AreaVo>();

            using (var context = new bhishak_app_dbContext())
            {
                objList = (from p in context.TblAdmAreas.Where(x => x.StatusId == 1 && x.AreaId <= 4884)
                           select new AreaVo
                           {
                               AreaId = p.AreaId,
                               AreaName = p.AreaName

                           }

                        ).ToList();

                return objList;

            }

        }

        public IEnumerable<CorporateVo> GetCorporate()
        {
            List<CorporateVo> objlist = new List<CorporateVo>();

            using (var context = new bhishak_app_dbContext())
            {

                objlist = (from p in context.TblCorporates
                           select new CorporateVo
                           {
                               CORPORATE_ID = p.CorporateId,
                               CORPORATE_NAME = p.CorporateName

                           }
                           ).ToList();
            }
            return objlist;

        }
        public IEnumerable<NationalityVo> GetNationality()
        {
            List<NationalityVo> objlist = new List<NationalityVo>();

            using (var context = new bhishak_app_dbContext())
            {

                objlist = (from p in context.TblAdmNationalities
                           select new NationalityVo
                           {
                               NATIONALITY_ID = p.NationalityId,
                               NATIONALITY_NAME = p.NationalityName

                           }
                           ).ToList();
            }
            return objlist;

        }

        public IEnumerable<SpecialityVo> GetSpeciality()
        {
            List<SpecialityVo> objlist = new List<SpecialityVo>();

            using (var context = new bhishak_app_dbContext())
            {

                objlist = (from p in context.TblAdmSpecialities
                           select new SpecialityVo
                           {
                               SpecialityID = p.SpecialityId,
                               Speciality = p.Speciality

                           }
                           ).ToList();
            }
            return objlist;

        }

        public IEnumerable<OccupationVo> GetOccupation()
        {
            List<OccupationVo> objlist = new List<OccupationVo>();

            using (var context = new bhishak_app_dbContext())
            {

                objlist = (from p in context.TblAdmOccupationMasters
                           select new OccupationVo
                           {

                               ID = p.Id,
                               Occupation = p.Occupation

                           }
                           ).ToList();
            }
            return objlist;

        }

        public IEnumerable<PatientRelationVo> GetPatientRelation()
        {
            List<PatientRelationVo> objlist = new List<PatientRelationVo>();

            using (var context = new bhishak_app_dbContext())
            {

                objlist = (from p in context.TblAdmPatientRelations
                           select new PatientRelationVo
                           {

                               RELATION_ID = p.RelationId,
                               RELATION = p.Relation

                           }
                           ).ToList();
            }
            return objlist;

        }
        //public IEnumerable<PatientVo> GetPatientDetails(string mobilenumber)
        //{
        //    List<PatientVo> objlist = new List<PatientVo>();
        //    {
        //        using (var context = new bhishak_app_dbContext())
        //        {


        //             objlist = (from e in context.TblPatients
        //                          join p in context.TblAdmGenders
        //                          on e.Sex equals p.GenderId

        //                          where e.MobileNUmber == mobilenumber
        //                          select new PatientVo
        //                          {
        //                               PatientId = e.PatienTId,
        //                               patientMrn=e.PatienTMrn,
        //                           MobileNumber = e.MobileNUmber,
        //                           FirstName = e.FirstNAme,
        //                           LastName = e.LastNAme,
        //                           Age = e.Age,
        //                            Sex = e.Sex,
        //                            Gender=p.Gender,
        //                           relationtype=e.RelationType,
        //                           relationname=e.SoWoDo,
        //                           dob=e.DateOfBirth,
        //                           prefix=e.Prefix,
        //                           occupation=e.Occupation,
        //                           religionid=e.Religion,
        //                           nationalityid=e.NAtionAlity,
        //                           areaid=e.AreaId,
        //                           emailid=e.PatienTEmail

        //                          }).ToList();




        //            return objlist;

        //        }

        //    }

        //}

        public IEnumerable<PatientDetailsSPVo> GetPatientDetails(string mobilenumber)
        {
            List<PatientDetailsSPVo> obj = new List<PatientDetailsSPVo>();
            var mobile = new MySqlParameter("mobile", mobilenumber);
            using (var context = new StoreProceduresContext())
            {

                obj = context.GetPatientDetails.FromSqlRaw("call GetPatientDetails(@mobile)", mobile).ToList();

            }
            return obj;



        }
        //public IEnumerable<PatientVo> GetPatientDetailsbypid(long patientid)
        //{

        //    List<PatientVo> objlist = new List<PatientVo>();
        //    {
        //        using (var context = new bhishak_app_dbContext())
        //        {

        //            objlist = (from p in context.TblPatients.Where(x => x.PatienTId ==  patientid)
        //                       select new PatientVo
        //                       {
        //                           PatientId = p.PatienTId,
        //                           MobileNumber = p.MobileNUmber,
        //                           FirstName = p.FirstNAme,
        //                           LastName = p.LastNAme,
        //                           Age = p.Age,
        //                           Sex = p.Sex,
        //                           relationtype = p.RelationType,
        //                           relationname = p.SoWoDo,
        //                           dob = p.DateOfBirth,
        //                           prefix = p.Prefix,
        //                           occupation = p.Occupation,
        //                           religionid = p.Religion,
        //                           nationalityid = p.NAtionAlity,
        //                           areaid = p.AreaId,
        //                           emailid = p.PatienTEmail,
        //                           address=p.Address



        //                       }
        //                        ).ToList();
        //            return objlist;


        //        }

        //    }

        //}


        public IEnumerable<PatientVo> GetPatientDetailsbypid(long patientid)
        {

            List<PatientVo> objlist = new List<PatientVo>();

            var PatientId = new MySqlParameter("PatientId", patientid);
            using (var context = new StoreProceduresContext())
            {

                objlist = context.GetPatientDetailsByID.FromSqlRaw("call GetPatientDetailsByID(@PatientId)", PatientId).ToList();

            }

            return objlist;
        }
        public IEnumerable<RelegionVo> GetReligion()
        {

            List<RelegionVo> objlist = new List<RelegionVo>();

            using (var context = new bhishak_app_dbContext())
            {

                objlist = (from p in context.TblAdmReligions
                           select new RelegionVo
                           {
                               ReligionID = p.ReligionId,
                               ReligionName = p.ReligionName

                           }
                            ).ToList();
                return objlist;

            }

           




        }
        public IEnumerable<PatientVo> get(string mobile)
        {
            List<PatientVo> objlist = new List<PatientVo>();
            using(var context=new Hims_WebAPI.BHISHAK_APP_DB.bhishak_app_dbContext())
            {
                string quey = "call GetPatientDetails('" + mobile + "')";

                MySqlConnection con = new MySqlConnection("Server=10.10.20.25;Database=bhishak_app_db; User=root;Password=root@123");
                MySqlCommand cmd = new MySqlCommand("quey", con);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
               

              
            }
            return objlist;
        }
    }
}
