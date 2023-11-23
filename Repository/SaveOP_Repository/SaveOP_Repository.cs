using Hims_WebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hims_WebAPI.BHISHAK_APP_DB;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Hims_WebAPI.Repository.SaveOP_Repository
{
    public class SaveOP_Repository : ISaveOP_Repository
    {

        private int getage(DateTime dob)
        {
            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
           // age = age / 365;
           // return age;

            if (age >= 365)
            {
                age = age / 365;
                return age;
            }
            else
               if (age < 365 && age >= 30)
            {
                age = age / 30;
                return age;
            }
            else
               if (age < 30)
            {
               return age;
            }
            else return 0;

        }
        private string GetFullOpID(int OrganizationId, int FacilityId)
        {
            GetOPIdFormat objopidformat = new GetOPIdFormat();
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
         
            using (var context =new bhishak_app_dbContext())
            {
                int encCount =(from d in context.TblEncounters.Where(x => x.DateOfVisit.Year == year && x.DateOfVisit.Month == month && x.OrganizationId == OrganizationId  && x.FacilityId==FacilityId) select d.EncounterId).Count();
               
                string opidf = objopidformat.opFormat +"-"+ DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") +  "-" + String.Format("{0:D5}", encCount+1);
               
                return opidf;
            }
              
        }
        #region
        //public string GetFullOpID()
        //{

        //    string fullOpID = null;
        //    List<OpVo> obj = new List<OpVo>();

        //    // string objList = null;
        //    try
        //    {
        //        using (var context = new bhishak_app_dbContext())
        //        {
        //            List<TblEncounter> o = new List<TblEncounter>();


        //            string query = "EXEC SP_GetOpID";
        //            IDbCommand cmd;
        //            IDataReader rdr;

        //            cmd = context.Database.GetDbConnection().CreateCommand();
        //            cmd.CommandText = query;

        //            context.Database.OpenConnection();
        //            rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

        //            while (rdr.Read())
        //            {
        //                obj.Add(new OpVo
        //                {
        //                    OpID = rdr.GetString(0)

        //                });
        //                fullOpID = obj.FindAll(x => x.OpID != "").First().OpID;

        //            }
        //            context.Database.CloseConnection();



        //        }


        //        return fullOpID;
        //    }
        //    catch (Exception e)
        //    {

        //    }
        //    return fullOpID = obj.Find(x => x.OpID != null).ToString();
        //}
        // ------------------------------------------
        //public IEnumerable<OpCreateResult> SaveOpForExistingPatient(OpForExistingVo objOp)
        //{

        //    List<OpCreateResult> objResult = new List<OpCreateResult>();


        //    string error = null;
        //    Guid _SecurityUserId = Guid.NewGuid();
        //    string _Rfid = null;
        //    Guid _paymentEntryId = Guid.NewGuid();
        //    Guid _EncounterBillingEntryId = Guid.NewGuid();

        //    try
        //    {
        //        string OP_Id = GetFullOpID();

        //        _Rfid = objOp.RFId == null ? "" : objOp.RFId;

        //        DateTime CurrentDate = DateTime.Now;
        //        DateTime MonthStartDate = CurrentDate.AddDays(-CurrentDate.Day + 1);

        //        DateTime modifieddate = DateTime.Now;


        //        string Query = "SP_OPRegistrationExisting @Patientid, @MotherName, @MobileNumber, @DoctorId" +
        //            ", @ModifiedBy,  @ModifiedDate" +
        //            ", @ReferringPhysicianId, @AreaId,@RFId ,@PROVINCE_ID, @DISTRICT_ID,@MUNICIPALITY_ID " +
        //            ", @GRAMTOLE_ID, @WARD_ID,@FacilityId ,@AppointmentDate,@StartTime , @EndTime, @IsProviderAppointment,@StatusId " +
        //            ", @IsLocked,@IsConcurrentLocked,@IsAdmission , @Mode, @BillTypeId, @ConsultationChargeGroupId, @SequenceNumber,@CorporateId ,@IsEmergencyRegistration " +
        //            ", @IsReview, @ReviewCount, @LastDateOfChargedVisit,@ConsultationDate , @IsFreeConsultation, @ConsultationTypeId, @OPId,@ChargeItemId ,@EncounterBillingEntryId " +
        //            ",@PaymentChargeInd ,@DateOfService , @NoOfUnits, @RegisterId, @Unitprice, @ChargeAmount,@PaidAmount , @Discount, @IsFromLabBill, @Comments,@ProviderCommissionAmount " +
        //            ",@RefPhysicianCommissionAmount ,@PaymentEntryId ,@IsAuthorizedPayment ,@PaymentChargeItemId ,@PaymentOnTheHouse ,@PaymentComments , @PaymentAmount, @BillNo" +
        //            ", @PaymentPaidAmount,@RFIdRelativeId ,@SecurityUserId";

        //        SqlParameter Patientid = new SqlParameter("@Patientid", objOp.Patientid);
        //        SqlParameter MotherName = new SqlParameter("@MotherName", objOp.MotherName);
        //        SqlParameter MobileNumber = new SqlParameter("@MobileNumber", objOp.MobileNumber);
        //        SqlParameter DoctorId = new SqlParameter("@DoctorId", objOp.DoctorId);
        //        SqlParameter ModifiedBy = new SqlParameter("@ModifiedBy", objOp.ModifiedBy);
        //        SqlParameter ModifiedDate = new SqlParameter("@ModifiedDate", modifieddate);
        //        SqlParameter ReferringPhysicianId = new SqlParameter("@ReferringPhysicianId", objOp.ReferringPhysicianId);
        //        SqlParameter AreaId = new SqlParameter("@AreaId", objOp.AreaId);
        //        SqlParameter RFId = new SqlParameter("@RFId", _Rfid);
        //        SqlParameter PROVINCE_ID = new SqlParameter("@PROVINCE_ID", objOp.PROVINCE_ID);
        //        SqlParameter DISTRICT_ID = new SqlParameter("@DISTRICT_ID", objOp.DISTRICT_ID);
        //        SqlParameter MUNICIPALITY_ID = new SqlParameter("@MUNICIPALITY_ID", objOp.MUNICIPALITY_ID);
        //        SqlParameter GRAMTOLE_ID = new SqlParameter("@GRAMTOLE_ID", objOp.GRAMTOLE_ID);
        //        SqlParameter WARD_ID = new SqlParameter("@WARD_ID", objOp.WARD_ID);
        //        SqlParameter FacilityId = new SqlParameter("@FacilityId", objOp.FacilityId);
        //        SqlParameter AppointmentDate = new SqlParameter("@AppointmentDate", objOp.AppointmentDate);
        //        SqlParameter StartTime = new SqlParameter("@StartTime", objOp.StartTime);
        //        SqlParameter EndTime = new SqlParameter("@EndTime", objOp.EndTime);
        //        SqlParameter IsProviderAppointment = new SqlParameter("@IsProviderAppointment", objOp.IsProviderAppointment);
        //        SqlParameter StatusId = new SqlParameter("@StatusId", objOp.StatusId);
        //        SqlParameter IsLocked = new SqlParameter("@IsLocked", objOp.IsLocked);
        //        SqlParameter IsConcurrentLocked = new SqlParameter("@IsConcurrentLocked", objOp.IsConcurrentLocked);
        //        SqlParameter IsAdmission = new SqlParameter("@IsAdmission", objOp.IsAdmission);
        //        SqlParameter Mode = new SqlParameter("@Mode", objOp.Mode);
        //        SqlParameter BillTypeId = new SqlParameter("@BillTypeId", objOp.BillTypeId);
        //        SqlParameter ConsultationChargeGroupId = new SqlParameter("@ConsultationChargeGroupId", objOp.ConsultationChargeGroupId);
        //        SqlParameter SequenceNumber = new SqlParameter("@SequenceNumber", objOp.SequenceNumber);
        //        SqlParameter CorporateId = new SqlParameter("@CorporateId", objOp.CorporateId);
        //        SqlParameter IsEmergencyRegistration = new SqlParameter("@IsEmergencyRegistration", objOp.IsEmergencyRegistration);
        //        SqlParameter IsReview = new SqlParameter("@IsReview", objOp.IsReview);
        //        SqlParameter ReviewCount = new SqlParameter("@ReviewCount", objOp.ReviewCount);
        //        SqlParameter LastDateOfChargedVisit = new SqlParameter("@LastDateOfChargedVisit", objOp.LastDateOfChargedVisit);
        //        SqlParameter ConsultationDate = new SqlParameter("@ConsultationDate", objOp.ConsultationDate);
        //        SqlParameter IsFreeConsultation = new SqlParameter("@IsFreeConsultation", objOp.IsFreeConsultation);
        //        SqlParameter ConsultationTypeId = new SqlParameter("@ConsultationTypeId", objOp.ConsultationTypeId);
        //        SqlParameter OPId = new SqlParameter("@OPId", OP_Id);
        //        SqlParameter ChargeItemId = new SqlParameter("@ChargeItemId", objOp.ChargeItemId);
        //        SqlParameter PaymentChargeInd = new SqlParameter("@PaymentChargeInd", objOp.PaymentChargeInd);
        //        SqlParameter EncounterBillingEntryId = new SqlParameter("@EncounterBillingEntryId", _EncounterBillingEntryId);
        //        SqlParameter DateOfService = new SqlParameter("@DateOfService", objOp.DateOfService);
        //        SqlParameter NoOfUnits = new SqlParameter("@NoOfUnits", objOp.NoOfUnits);
        //        SqlParameter RegisterId = new SqlParameter("@RegisterId", objOp.RegisterId);
        //        SqlParameter Unitprice = new SqlParameter("@Unitprice", objOp.Unitprice);
        //        SqlParameter ChargeAmount = new SqlParameter("@ChargeAmount", objOp.ChargeAmount);
        //        SqlParameter PaidAmount = new SqlParameter("@PaidAmount", objOp.PaidAmount);
        //        SqlParameter Discount = new SqlParameter("@Discount", objOp.Discount);
        //        SqlParameter IsFromLabBill = new SqlParameter("@IsFromLabBill", objOp.IsFromLabBill);
        //        SqlParameter Comments = new SqlParameter("@Comments", objOp.Comments);
        //        SqlParameter ProviderCommissionAmount = new SqlParameter("@ProviderCommissionAmount", objOp.ProviderCommissionAmount);
        //        SqlParameter RefPhysicianCommissionAmount = new SqlParameter("@RefPhysicianCommissionAmount", objOp.RefPhysicianCommissionAmount);
        //        SqlParameter PaymentEntryId = new SqlParameter("@PaymentEntryId", _paymentEntryId);
        //        SqlParameter IsAuthorizedPayment = new SqlParameter("@IsAuthorizedPayment", objOp.IsAuthorizedPayment);
        //        SqlParameter PaymentChargeItemId = new SqlParameter("@PaymentChargeItemId", objOp.PaymentChargeItemId);
        //        SqlParameter PaymentOnTheHouse = new SqlParameter("@PaymentOnTheHouse", objOp.PaymentOnTheHouse);
        //        SqlParameter PaymentComments = new SqlParameter("@PaymentComments", objOp.PaymentComments);
        //        SqlParameter PaymentAmount = new SqlParameter("@PaymentAmount", objOp.PaymentAmount);
        //        SqlParameter BillNo = new SqlParameter("@BillNo", objOp.BillNo);
        //        SqlParameter PaymentPaidAmount = new SqlParameter("@PaymentPaidAmount", objOp.PaymentPaidAmount);
        //        SqlParameter RFIdRelativeId = new SqlParameter("@RFIdRelativeId", objOp.RFIdRelativeId);
        //        SqlParameter SecurityUserId = new SqlParameter("@SecurityUserId", _SecurityUserId);


        //        using (var context = new HIMS_APP_DBContext())
        //        {
        //            bool isRegistered = false;


        //            int count = context.Database.ExecuteSqlRaw(Query, Patientid, MotherName, MobileNumber, DoctorId, ModifiedBy, ModifiedDate, ReferringPhysicianId, AreaId, RFId
        //                , PROVINCE_ID, DISTRICT_ID, MUNICIPALITY_ID, GRAMTOLE_ID, WARD_ID, FacilityId, AppointmentDate, StartTime, EndTime, IsProviderAppointment, StatusId
        //                   , IsLocked, IsConcurrentLocked, IsAdmission, Mode, BillTypeId, ConsultationChargeGroupId, SequenceNumber, CorporateId, IsEmergencyRegistration, IsReview, ReviewCount
        //                   , LastDateOfChargedVisit, ConsultationDate, IsFreeConsultation, ConsultationTypeId, OPId, ChargeItemId, EncounterBillingEntryId, PaymentChargeInd, DateOfService, NoOfUnits, RegisterId
        //                   , Unitprice, ChargeAmount, PaidAmount, Discount, IsFromLabBill, Comments, ProviderCommissionAmount
        //                   , RefPhysicianCommissionAmount, PaymentEntryId, IsAuthorizedPayment, PaymentChargeItemId, PaymentOnTheHouse, PaymentComments, PaymentAmount, BillNo, PaymentPaidAmount
        //                   , RFIdRelativeId, SecurityUserId);


        //            //  patientid =  context.TblPatients.Where(x => x.MobileNumber == objOp.MobileNumber && x.FirstName == objOp.FirstName).FirstOrDefault().PatientId;// context.TblPatients.Max(x => x.MobileNumber == objOp.MobileNumber && x.FirstName == objOp.FirstName x);
        //            long _encounterid = context.TblEncounters.Where(e => e.OpId == OP_Id).FirstOrDefault().EncounterId;
        //            // var e = context.TblEncounters.FromSqlRaw<TblEncounter>("select encounter_id from tbl_encounter where OP_ID='" + OP_Id + "'");
        //            //  var eid = e.Select(d => d.EncounterId).FirstOrDefault();
        //            OpCreateResult RES = new OpCreateResult();
        //            RES.EncounterID = _encounterid;
        //            RES.PatientID = objOp.Patientid;
        //            RES.OpID = OP_Id;
        //            RES.Message = "OP Created Successfully ";
        //            objResult.Add(RES);

        //            return objResult;





        //        }
        //    }
        //    catch (Exception E)
        //    {

        //        error = E.Message;
        //    }
        //    OpCreateResult RES2 = new OpCreateResult();

        //    RES2.Message = "Error found :" + error;
        //    objResult.Add(RES2);

        //    return objResult;




        //}
        #endregion

        private static DateTime RoundDown(DateTime dateTime)
        {
            int unroundedMinutes = dateTime.Minute;
            unroundedMinutes = (unroundedMinutes / 15) * 15 + ((unroundedMinutes % 15) % 15 < 8 ? (unroundedMinutes % 15) / 15 * 15 : ((unroundedMinutes % 15) / 15 + 1) * 15);
            DateTime roundedDate = DateTime.Today;
            return roundedDate.Date.AddHours(DateTime.Now.Hour).AddMinutes(unroundedMinutes);
        }
        public bool isAadhaarExisted(string aadhaar)
        {
            using(var context=new bhishak_app_dbContext())
            {
                var check = context.TblPatients.Where(x => x.AadhaarNumber == aadhaar).FirstOrDefault();
                if(check!=null)
                {
                    return true;
                }
                else return false;
            }
           
        }
       
        public string ToTitlecase(string word)
        {
            string convertedText = new CultureInfo("en-US").TextInfo.ToTitleCase(word);
            return convertedText;
        }
        public void AddRefDoctor(AddUserVo user)
        {
            using(var context=new bhishak_app_dbContext())
            {
                var speciality = context.TblAdmSpecialities.Where(x => x.SpecialityId == user.Speciality).FirstOrDefault();
                TblUser obj = new TblUser();
                obj.FirstName = user.First_Name;
                obj.FacilityId = user.facility_id;
                obj.OrganizationId = user.Organization_id;
                obj.Status = true;
                obj.IsProvider = false;
                obj.SpecialityId = user.Speciality;
                obj.ListName = user.First_Name + " (" + speciality.SpecialityId + ")";
                obj.CreatedDate = DateTime.Now;
                var dt = obj.CreatedDate;
                obj.CreatedBy = user.CreatedBy;
                context.TblUsers.Add(obj);
                context.SaveChanges();
                var userdata = context.TblUsers.Where(x => (x.FirstName == user.First_Name)).FirstOrDefault();
                TblUserrole objuserrole = new TblUserrole();
                objuserrole.UserId = userdata.UserId;
                objuserrole.Roleid = (from x in context.TblRoles where x.RoleName == "Doctor" select x.RoleId).First();                                 
                objuserrole.CreatedDate = DateTime.Now;
                objuserrole.CreatedBy = user.CreatedBy;
                context.TblUserroles.Add(objuserrole);
                context.SaveChanges();
            }
        }

        public int GetAgeModeId(DateTime dob)
        {
            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
            //  age = age / 365;
            // return age;
            if (age >= 365)
            {
                return 3;
            }
            else
                 if (age < 365 && age >= 30)
            {
                return 2;
            }
            else
                 if (age < 30)
            {
                return 1;
            }
            else return 0;
        }

        public int UpdateAge()
        {
            try { 
            bhishak_app_dbContext obj = new bhishak_app_dbContext();
            TblPatient p = new TblPatient();
            var list = (from x in obj.TblPatients select new { x.DateOfBirth, x.PatienTId,x.AgeMode }).ToList();
            for(int i=0;i<list.Count;i++)
            {
                var listobj = (from x in obj.TblPatients where x.PatienTId == list[i].PatienTId select x).FirstOrDefault();
                listobj.AgeMode = GetAgeModeId((DateTime)list[i].DateOfBirth);
                    obj.SaveChanges();
            }
                return 1;
            }
            catch(Exception e)
            {
                return 0;
            }



        }
        public int UpdateAppointmentStatus(int? AppointmentId)
        {
            using (var context = new bhishak_app_dbContext())
            {
                var obj = context.TblAppointments.Where(x => x.PatientAppointmentId == AppointmentId).FirstOrDefault();
                obj.AppointmentStatusId = 5;
                return context.SaveChanges();
            }

        }
        public OpCreateResult SaveOP(OpInput input)
        {
           // bool isaadhaarExist = isAadhaarExisted(input.Aadhaar);
           
                TblEncounter e = new TblEncounter();
                OpCreateResult obj = new OpCreateResult();
            using (var context = new bhishak_app_dbContext())
            {
                //tbl_patient table
                #region
                TblPatient objpatient = new TblPatient();
                int intIdt = Convert.ToInt32(context.TblPatients.Max(u => u.PatienTId));
                objpatient.PatienTMrn = String.Format("{0:D9}", intIdt + 1);
                objpatient.FirstNAme = ToTitlecase(input.FirstName);
                objpatient.LastNAme = ToTitlecase(input.LastName);
                objpatient.Prefix = input.Prefix;
                objpatient.Sex = input.Sex;
                objpatient.DateOfBirth = input.dob;
                objpatient.OrganizationId = input.Organization_id;
                objpatient.FacilityId = input.FacilityId;
                if (input.DoctorId != 0 && input.DoctorId != null)
                {
                    objpatient.DoctorId = input.DoctorId;
                }
                var inputData = new AddUserVo
                {
                    First_Name = input.txtRefDoctor,
                    facility_id = input.FacilityId,
                    Organization_id = input.Organization_id,
                    Speciality = input.SpacialityId,
                    CreatedBy = input.CreatedBy
                };
                if ((input.txtRefDoctor != "") && (input.txtRefDoctor != null))
                {
                    AddRefDoctor(inputData);
                    var data = context.TblUsers.Where(x => (x.FirstName == input.txtRefDoctor) && (x.SpecialityId == input.SpacialityId)).FirstOrDefault();
                    objpatient.ReferrinGPhysicianId = data.UserId;
                }
                else
                {
                    if (input.RefDoctorId != 0)
                    {
                        objpatient.ReferrinGPhysicianId = input.RefDoctorId;
                    }

                }

                //objpatient.Age =decimal.Round(getage(Convert.ToDateTime(objpatient.DateOfBirth)),0,MidpointRounding.AwayFromZero);
                objpatient.Age = Convert.ToDecimal(getage(Convert.ToDateTime(objpatient.DateOfBirth)));
                objpatient.Occupation = input.Occupation;
                // objpatient.MaritalStatusId = input.MaritalStatusId;
                objpatient.StatusId = 1;
                objpatient.PatienTEmail = input.EmailId;
                objpatient.CreatedBy = input.CreatedBy;
                objpatient.CreationDate = DateTime.Now;
                objpatient.MobileNUmber = input.MobileNumber;
                if ((input.City != null) || (input.City != ""))
                {
                    objpatient.City = ToTitlecase(input.City);
                }
                if ((input.Village != null) || (input.Village != ""))
                {
                    objpatient.Village = ToTitlecase(input.Village);
                }
                objpatient.AadhaarNumber = input.Aadhaar;
                objpatient.DistrictId = input.District;
                objpatient.Pincode = input.Pincode;
                objpatient.StateId = input.State;
                objpatient.Religion = input.ReligionId;
                objpatient.HouseNumber = input.HouseNo;
                objpatient.NAtionAlity = input.NationalityId;
                objpatient.AgeMode = GetAgeModeId((DateTime)input.dob);
                context.TblPatients.Add(objpatient);
                context.SaveChanges();
                #endregion

                var lastIdentityValue = context.TblRegistrationBillings.OrderByDescending(e => e.RegId).Where(e=>e.FecilityId== input.FacilityId && e.OrganigationId==input.Organization_id).Select(e => e.RegId).FirstOrDefault();
                var incrementId = 0;
                if (lastIdentityValue > 0)
                {
                    // Set other properties of the new record
                    incrementId = lastIdentityValue + 1;
                }
                if (input.SpacialityId == 0)
                {
                    TblRegistrationBilling tblRegistrationBilling = new TblRegistrationBilling();
                    
                    tblRegistrationBilling.PatientId = objpatient.PatienTId;
                    tblRegistrationBilling.PatientMrn = objpatient.PatienTMrn;
                    tblRegistrationBilling.RegistrationAmount = 50;
                    tblRegistrationBilling.PaidAmount = 50;
                    tblRegistrationBilling.OrganigationId = input.Organization_id;
                    tblRegistrationBilling.FecilityId = input.FacilityId;
                    tblRegistrationBilling.CreatedBy = input.CreatedBy;
                    tblRegistrationBilling.CreatedDateTime = DateTime.Now;
                    tblRegistrationBilling.PaymentModeId = input.PaymentMode;
                    tblRegistrationBilling.ReceiptNumber = GetFullReceiptNumer(input.Organization_id, input.FacilityId);
                    context.TblRegistrationBillings.Add(tblRegistrationBilling);
                    context.SaveChanges();
                    obj.EncounterID = 0;
                    obj.PatientID = objpatient.PatienTId;
                    obj.OpID = "";
                    if (objpatient.PatienTId != 0)
                    {
                        obj.Message = "Success";
                    }

                }

                else
                {
                    TblRegistrationBilling tblRegistrationBilling = new TblRegistrationBilling();
                    tblRegistrationBilling.PatientId = objpatient.PatienTId;
                    tblRegistrationBilling.PatientMrn = objpatient.PatienTMrn;
                    tblRegistrationBilling.RegistrationAmount = 50;
                    tblRegistrationBilling.PaidAmount = 50;
                    tblRegistrationBilling.OrganigationId = input.Organization_id;
                    tblRegistrationBilling.FecilityId = input.FacilityId;
                    tblRegistrationBilling.CreatedBy = input.CreatedBy;
                    tblRegistrationBilling.CreatedDateTime = DateTime.Now;
                    tblRegistrationBilling.PaymentModeId = input.PaymentMode;
                    tblRegistrationBilling.ReceiptNumber = GetFullReceiptNumer(input.Organization_id, input.FacilityId);
                    context.TblRegistrationBillings.Add(tblRegistrationBilling);
                    context.SaveChanges();

                    DateTime CurrentDate = DateTime.Now;
                    DateTime MonthStartDate = CurrentDate.AddDays(-CurrentDate.Day + 1);
                    string PatId = string.Empty;
                    var objpatDetails = context.TblPatients.Where(c => c.PatienTId == objpatient.PatienTId).FirstOrDefault();

                    //   TBL_SCHEDULE_PROVIDER objSchedule = null;

                    //Appointment section
                    #region
                    //var objSchedule = context.TblScheduleProviders.Where(p => p.IsDefaultSchedule == true && p.ProviderId == objpatDetails.DoctorId).FirstOrDefault();
                    //TblAdmAppointmentType objAppointmentType = null;
                    //objAppointmentType = context.TblAdmAppointmentTypes.Where(p => p.AppointmentType == "Walk In Appointment").Single();
                    //TblAdmAppointmentStatus objAppointmentStatus = null;
                    //objAppointmentStatus = context.TblAdmAppointmentStatuses.Where(p => p.AppointmentStatus == "ARRIVED").Single();

                    //TblPatientAppointment objTblPatientAppointment = new TblPatientAppointment();
                    ////  objTblPatientAppointment.ScheduleId = objSchedule.ScheduleId;
                    //objTblPatientAppointment.PatientId = objpatDetails.PatienTId;
                    //objTblPatientAppointment.DoctorId = objpatDetails.DoctorId;
                    //objTblPatientAppointment.FacilityId = input.FacilityId;
                    //objTblPatientAppointment.ReferringPhysicianId = objpatDetails.ReferrinGPhysicianId;
                    //objTblPatientAppointment.AppointmentDate = DateTime.Now.AddDays(1);
                    //DateTime StartTime = RoundDown(DateTime.Today);
                    //// DateTime StartTime = objAdmissionVo.AdmissionDate.Add(DateTime.Now.TimeOfDay);
                    //objTblPatientAppointment.StartTime = StartTime;
                    //objTblPatientAppointment.EndTime = StartTime.AddMinutes(15.0); ;
                    //objTblPatientAppointment.AppointmentTypeId = objAppointmentType.AppointmentTypeId;
                    //objTblPatientAppointment.AppointmentStatusId = objAppointmentStatus.AppointmentStatusId;
                    //objTblPatientAppointment.StatusId = 1;
                    //objTblPatientAppointment.IsProviderAppointment = true;
                    //objTblPatientAppointment.CreatedBy = input.CreatedBy;
                    //objTblPatientAppointment.CreationDate = DateTime.Now;
                    ////  objTblPatientAppointment.MODIFIED_BY = objUserProfile.LogInUserName;
                    ////   objTblPatientAppointment.MODIFIED_DATE = DateTime.Now;
                    ////if (objAdmissionVo.IsMedicoLegalCase != null && objAdmissionVo.IsMedicoLegalCase == true)
                    ////{
                    ////    objTblPatientAppointment.IS_MEDICO_LEGAL_CASE = true;
                    ////    objTblPatientAppointment.NAME_OF_THE_INFORMENT = objAdmissionVo.NameofTheInforment;
                    ////    objTblPatientAppointment.POLICE_STATION = objAdmissionVo.PoliceStation;
                    ////    objTblPatientAppointment.PC_NO = objAdmissionVo.PCNo;
                    ////    objTblPatientAppointment.PC_WHO_IS_BROUGHT = objAdmissionVo.PCWhoBrought;
                    ////}

                    //context.TblPatientAppointments.Add(objTblPatientAppointment);
                    //context.SaveChanges();
                    #endregion

                  //  int appointmentId = context.TblPatientAppointments.Max(i => i.PatientAppointmentId);
                    //Create Encounter
                   // int appointmentCount = (from f in context.TblPatientAppointments.Where(x => x.StartTime.Date == StartTime && x.CheckinDate != null) select f.PatientAppointmentId).Count();
                    //int sequenceNumber = 0;
                    //if (appointmentCount == 0)
                    //{
                    //    sequenceNumber = 1;
                    //}
                    //else
                    //{
                    //    sequenceNumber = appointmentCount;
                    //}
                    //Encounter aection
                    #region
                    TblEncounter tblEncounter = new TblEncounter();
                    tblEncounter.PatientId = objpatDetails.PatienTId;
                    tblEncounter.StatusId = 1;
                    if ((input.SpacialityId != 0) || input.SpacialityId != null)
                    {
                        tblEncounter.SpecialityId = (int)input.SpacialityId;
                    }
                    if (input.CorporateId != 0)
                    {
                        tblEncounter.CorporateId = input.CorporateId;
                    }
                    if (input.PaymentCategoryId != 0)
                    {
                        tblEncounter.PaymentCategoryId = input.PaymentCategoryId;
                    }

                    tblEncounter.PaymentCategoryId = input.PaymentCategoryId;
                    //(from p in context.TBL_PATIENT_APPOINTMENTs.Where(x => x.PATIENT_APPOINTMENT_ID == appointmentId) select p.TBL_PROVIDER.SPECIALITY_TYPE_ID.Value).FirstOrDefault();
                  //  tblEncounter.AppointmentId = appointmentId;
                    tblEncounter.DoctorId = objpatDetails.DoctorId;
                    // tblEncounter.CHAMBER_NO = objAdmissionVo.ChamberNo;
                    tblEncounter.FacilityId = Convert.ToInt32(objpatDetails.FacilityId);
                    //   tblEncounter.A = PatEncounterId;
                   // tblEncounter.DateOfVisit = StartTime;
                    tblEncounter.DateOfVisit = DateTime.Now;
                    //  tblEncounter.MODIFIED_DATE = DateTime.Now;
                    tblEncounter.CreatedBy = input.CreatedBy;
                    //     tblEncounter.MODIFIED_BY = objUserProfile.LogInUserName;
                    //  tblEncounter.IS_LOCKED = false;
                    //  tblEncounter.IS_CONCURRENT_LOCKED = false;
                    //  tblEncounter.IS_ADMISSION = false;
                    tblEncounter.Mode = e.Mode;
                    // tblEncounter.BILL_TYPE_ID = Convert.ToInt32(BillTypeIds.OP);
                    //   tblEncounter.MARKETING_EMPLOYEE_ID = objAdmissionVo.MarketingEmpoyeeId;

                    //  tblEncounter.CONSULTATION_CHARGE_GROUP_ID = objAdmissionVo.ConsultationChargeGroupId;
                    // tblEncounter.OP_SPECIALITY_ID = objAdmissionVo.OpSpecialityId;
                    //tblEncounter.IS_OP_LAB_BILL = objAdmissionVo.IsLabBill;
                    //TBL_ENCOUNTER objTblEncounter = context.TBL_ENCOUNTERs.Where(i => i.DATE_OF_VISIT.Date == DateTime.Now.Date && i.FACILITY_ID == objUserProfile.SelectedFacilityId && i.IS_ADMISSION == false).OrderByDescending(i => i.ENCOUNTER_ID).FirstOrDefault();
                    //  if (objTblEncounter == null && !Convert.ToBoolean(tblEncounter.IS_ADMISSION))
                    //      tblEncounter.SEQUENCE_NUMBER = 1;
                    //  else if (!Convert.ToBoolean(tblEncounter.IS_ADMISSION))
                    //     tblEncounter.SEQUENCE_NUMBER = objTblEncounter.SEQUENCE_NUMBER + 1;

                    //  tblEncounter.IS_AROGYASREE = objAdmissionVo.IsArogyasree;
                    // tblEncounter.AROGYASREE_ID = objAdmissionVo.ArogyasreeId;
                    //   if (//.CorporateId.HasValue)
                    //  tblEncounter.CorporateId = e.CorporateId;
                    //  tblEncounter.IS_EMERGENCY_REGISTRATION = objAdmissionVo.IsEmergency;
                    tblEncounter.IsReview = false;
                    //  tblEncounter.REVIEW_COUNT = objAdmissionVo.ReviewCount;
                    //   tblEncounter.LAST_DATE_OF_CHARGED_VISIT = objAdmissionVo.LastdateofChargedvisit;
                    //   if (objAdmissionVo.ConsultationDate != null)
                    //   {
                    tblEncounter.ConsultationDate = CurrentDate;
                    //    }
                    //   if (objAdmissionVo.IsFreeConsultation != null && objAdmissionVo.IsFreeConsultation == true)
                    //    {
                    tblEncounter.IsFreeConsultation = false;
                    tblEncounter.OrganizationId = input.Organization_id;//Added by vijay
                    tblEncounter.OpId = GetFullOpID(input.Organization_id, input.FacilityId);
                    context.TblEncounters.Add(tblEncounter);
                    context.SaveChanges();
                    long encounterId = tblEncounter.EncounterId;
                    obj.EncounterID = encounterId;
                    obj.PatientID = tblEncounter.PatientId;
                    obj.OpID = tblEncounter.OpId;
                    if (encounterId != 0)
                    {
                        obj.Message = "Success";
                    }


                    
                    context.SaveChanges();
                    #endregion
                    //-------------------------------------------Payment section------------------


                    if (input.AppointmentId != null)
                    {
                        UpdateAppointmentStatus(input.AppointmentId);
                    }






                    #region
                    //-------------------------------------------------------------------------------
                    //TblPatientAppointmentSecuUserLink tblLink = new TblPatientAppointmentSecuUserLink();
                    //tblLink.AppointmentId = appointmentId;
                    //tblLink.EncounterId = encounterId;
                    //tblLink.ProviderId = objpatDetails.DoctorId;
                    //tblLink.SecurityUserId = Guid.NewGuid().ToString();
                    //tblLink.StatusId = 1;
                    //tblLink.CreatedBy = input.CreatedBy;
                    //tblLink.CreationDate = DateTime.Now;
                    //// tblLink.MODIFIED_BY = objUserProfile.LogInUserName;
                    ////tblLink.MODIFIED_DATE = DateTime.Now;
                    //context.TblPatientAppointmentSecuUserLinks.Add(tblLink);
                    //context.SaveChanges();
                    #endregion
                }
            }
                return  obj;

           
            return null;
           
        }

        public OpCreateResult SaveOPExisting(OpInput input)
        {
            // bool isaadhaarExist = isAadhaarExisted(input.Aadhaar);

            TblEncounter e = new TblEncounter();
            OpCreateResult obj = new OpCreateResult();
            using (var context = new bhishak_app_dbContext())
            {
                //tbl_patient table
                #region
                //TblPatient objpatient = new TblPatient();
                //int intIdt = Convert.ToInt32(context.TblPatients.Max(u => u.PatienTId));
                //objpatient.PatienTMrn = String.Format("{0:D9}", intIdt + 1);
                //objpatient.FirstNAme = ToTitlecase(input.FirstName);
                //objpatient.LastNAme = ToTitlecase(input.LastName);
                //objpatient.Prefix = input.Prefix;
                //objpatient.Sex = input.Sex;
                //objpatient.DateOfBirth = input.dob;
                //objpatient.OrganizationId = input.Organization_id;
                //objpatient.FacilityId = input.FacilityId;
                //if (input.DoctorId != 0 && input.DoctorId != null)
                //{
                //    objpatient.DoctorId = input.DoctorId;
                //}
                //var inputData = new AddUserVo
                //{
                //    First_Name = input.txtRefDoctor,
                //    facility_id = input.FacilityId,
                //    Organization_id = input.Organization_id,
                //    Speciality = input.SpacialityId,
                //    CreatedBy = input.CreatedBy
                //};
                //if ((input.txtRefDoctor != "") && (input.txtRefDoctor != null))
                //{
                //    AddRefDoctor(inputData);
                //    var data = context.TblUsers.Where(x => (x.FirstName == input.txtRefDoctor) && (x.SpecialityId == input.SpacialityId)).FirstOrDefault();
                //    objpatient.ReferrinGPhysicianId = data.UserId;
                //}
                //else
                //{
                //    if (input.RefDoctorId != 0)
                //    {
                //        objpatient.ReferrinGPhysicianId = input.RefDoctorId;
                //    }

                //}

                ////objpatient.Age =decimal.Round(getage(Convert.ToDateTime(objpatient.DateOfBirth)),0,MidpointRounding.AwayFromZero);
                //objpatient.Age = Convert.ToDecimal(getage(Convert.ToDateTime(objpatient.DateOfBirth)));
                //objpatient.Occupation = input.Occupation;
                //// objpatient.MaritalStatusId = input.MaritalStatusId;
                //objpatient.StatusId = 1;
                //objpatient.PatienTEmail = input.EmailId;
                //objpatient.CreatedBy = input.CreatedBy;
                //objpatient.CreationDate = DateTime.Now;
                //objpatient.MobileNUmber = input.MobileNumber;
                //if ((input.City != null) || (input.City != ""))
                //{
                //    objpatient.City = ToTitlecase(input.City);
                //}
                //if ((input.Village != null) || (input.Village != ""))
                //{
                //    objpatient.Village = ToTitlecase(input.Village);
                //}
                //objpatient.AadhaarNumber = input.Aadhaar;
                //objpatient.DistrictId = input.District;
                //objpatient.Pincode = input.Pincode;
                //objpatient.StateId = input.State;
                //objpatient.Religion = input.ReligionId;
                //objpatient.HouseNumber = input.HouseNo;
                //objpatient.NAtionAlity = input.NationalityId;
                //objpatient.AgeMode = GetAgeModeId((DateTime)input.dob);
                //context.TblPatients.Add(objpatient);
                //context.SaveChanges();
                #endregion

                var lastIdentityValue = context.TblRegistrationBillings.OrderByDescending(e => e.RegId).Where(e => e.FecilityId == input.FacilityId && e.OrganigationId == input.Organization_id).Select(e => e.RegId).FirstOrDefault();
                var incrementId = 0;
                if (lastIdentityValue > 0)
                {
                    // Set other properties of the new record
                    incrementId = lastIdentityValue + 1;
                }
                string ptnMrn = (from x in context.TblPatients where x.PatienTId == input.PatientId select x.PatienTMrn).First();
                if (input.SpacialityId == 0)
                {
                    TblRegistrationBilling tblRegistrationBilling = new TblRegistrationBilling();

                    tblRegistrationBilling.PatientId = input.PatientId;
                    tblRegistrationBilling.PatientMrn = ptnMrn;
                    tblRegistrationBilling.RegistrationAmount = 50;
                    tblRegistrationBilling.PaidAmount = 50;
                    tblRegistrationBilling.OrganigationId = input.Organization_id;
                    tblRegistrationBilling.FecilityId = input.FacilityId;
                    tblRegistrationBilling.CreatedBy = input.CreatedBy;
                    tblRegistrationBilling.CreatedDateTime = DateTime.Now;
                    tblRegistrationBilling.PaymentModeId = input.PaymentMode;
                    tblRegistrationBilling.ReceiptNumber = GetFullReceiptNumer(input.Organization_id, input.FacilityId);
                    context.TblRegistrationBillings.Add(tblRegistrationBilling);
                    context.SaveChanges();
                    obj.EncounterID = 0;
                    obj.PatientID = input.PatientId;
                    obj.OpID = "";
                    if (input.PatientId != 0)
                    {
                        obj.Message = "Success";
                    }

                }

                else
                {
                    TblRegistrationBilling tblRegistrationBilling = new TblRegistrationBilling();
                    tblRegistrationBilling.PatientId = input.PatientId;
                    tblRegistrationBilling.PatientMrn = ptnMrn;
                    tblRegistrationBilling.RegistrationAmount = 50;
                    tblRegistrationBilling.PaidAmount = 50;
                    tblRegistrationBilling.OrganigationId = input.Organization_id;
                    tblRegistrationBilling.FecilityId = input.FacilityId;
                    tblRegistrationBilling.CreatedBy = input.CreatedBy;
                    tblRegistrationBilling.CreatedDateTime = DateTime.Now;
                    tblRegistrationBilling.PaymentModeId = input.PaymentMode;
                    tblRegistrationBilling.ReceiptNumber = GetFullReceiptNumer(input.Organization_id, input.FacilityId);
                    context.TblRegistrationBillings.Add(tblRegistrationBilling);
                    context.SaveChanges();

                    DateTime CurrentDate = DateTime.Now;
                    DateTime MonthStartDate = CurrentDate.AddDays(-CurrentDate.Day + 1);
                    string PatId = string.Empty;
                    var objpatDetails = context.TblPatients.Where(c => c.PatienTId == input.PatientId).FirstOrDefault();

                    //   TBL_SCHEDULE_PROVIDER objSchedule = null;

                    //Appointment section
                   
                    var objSchedule = context.TblScheduleProviders.Where(p => p.IsDefaultSchedule == true && p.ProviderId == objpatDetails.DoctorId).FirstOrDefault();
                    TblAdmAppointmentType objAppointmentType = null;
                    objAppointmentType = context.TblAdmAppointmentTypes.Where(p => p.AppointmentType == "Walk In Appointment").Single();
                    TblAdmAppointmentStatus objAppointmentStatus = null;
                    objAppointmentStatus = context.TblAdmAppointmentStatuses.Where(p => p.AppointmentStatus == "ARRIVED").Single();
                   // TblPatientAppointment comented because not using
                    #region
                    //TblPatientAppointment objTblPatientAppointment = new TblPatientAppointment();
                    ////  objTblPatientAppointment.ScheduleId = objSchedule.ScheduleId;
                    //objTblPatientAppointment.PatientId = objpatDetails.PatienTId;
                    //objTblPatientAppointment.DoctorId = objpatDetails.DoctorId;
                    //objTblPatientAppointment.FacilityId = input.FacilityId;
                    //objTblPatientAppointment.ReferringPhysicianId = objpatDetails.ReferrinGPhysicianId;
                    //objTblPatientAppointment.AppointmentDate = DateTime.Now.AddDays(1);
                    //DateTime StartTime = RoundDown(DateTime.Today);
                    //// DateTime StartTime = objAdmissionVo.AdmissionDate.Add(DateTime.Now.TimeOfDay);
                    //objTblPatientAppointment.StartTime = StartTime;
                    //objTblPatientAppointment.EndTime = StartTime.AddMinutes(15.0); ;
                    //objTblPatientAppointment.AppointmentTypeId = objAppointmentType.AppointmentTypeId;
                    //objTblPatientAppointment.AppointmentStatusId = objAppointmentStatus.AppointmentStatusId;
                    //objTblPatientAppointment.StatusId = 1;
                    //objTblPatientAppointment.IsProviderAppointment = true;
                    //objTblPatientAppointment.CreatedBy = input.CreatedBy;
                    //objTblPatientAppointment.CreationDate = DateTime.Now;
                    ////  objTblPatientAppointment.MODIFIED_BY = objUserProfile.LogInUserName;
                    ////   objTblPatientAppointment.MODIFIED_DATE = DateTime.Now;
                    ////if (objAdmissionVo.IsMedicoLegalCase != null && objAdmissionVo.IsMedicoLegalCase == true)
                    ////{
                    ////    objTblPatientAppointment.IS_MEDICO_LEGAL_CASE = true;
                    ////    objTblPatientAppointment.NAME_OF_THE_INFORMENT = objAdmissionVo.NameofTheInforment;
                    ////    objTblPatientAppointment.POLICE_STATION = objAdmissionVo.PoliceStation;
                    ////    objTblPatientAppointment.PC_NO = objAdmissionVo.PCNo;
                    ////    objTblPatientAppointment.PC_WHO_IS_BROUGHT = objAdmissionVo.PCWhoBrought;
                    ////}

                    //context.TblPatientAppointments.Add(objTblPatientAppointment);
                    //context.SaveChanges();
                    #endregion

                    //  int appointmentId = context.TblPatientAppointments.Max(i => i.PatientAppointmentId);
                    //Create Encounter
                    // int appointmentCount = (from f in context.TblPatientAppointments.Where(x => x.StartTime.Date == StartTime && x.CheckinDate != null) select f.PatientAppointmentId).Count();
                    //   int sequenceNumber = 0;
                    //if (appointmentCount == 0)
                    //{
                    //    sequenceNumber = 1;
                    //}
                    //else
                    //{
                    //    sequenceNumber = appointmentCount;
                    //}
                    //Encounter aection
                    #region
                    TblEncounter tblEncounter = new TblEncounter();
                    tblEncounter.PatientId = objpatDetails.PatienTId;
                    tblEncounter.StatusId = 1;
                    if ((input.SpacialityId != 0) || input.SpacialityId != null)
                    {
                        tblEncounter.SpecialityId = (int)input.SpacialityId;
                    }
                    if (input.CorporateId != 0)
                    {
                        tblEncounter.CorporateId = input.CorporateId;
                    }
                    if (input.PaymentCategoryId != 0)
                    {
                        tblEncounter.PaymentCategoryId = input.PaymentCategoryId;
                    }

                    tblEncounter.PaymentCategoryId = input.PaymentCategoryId;
                    //(from p in context.TBL_PATIENT_APPOINTMENTs.Where(x => x.PATIENT_APPOINTMENT_ID == appointmentId) select p.TBL_PROVIDER.SPECIALITY_TYPE_ID.Value).FirstOrDefault();
                    //tblEncounter.AppointmentId = appointmentId;
                    tblEncounter.DoctorId = objpatDetails.DoctorId;
                    // tblEncounter.CHAMBER_NO = objAdmissionVo.ChamberNo;
                    tblEncounter.FacilityId = Convert.ToInt32(objpatDetails.FacilityId);
                    //   tblEncounter.A = PatEncounterId;
                   // tblEncounter.DateOfVisit = StartTime;
                    tblEncounter.DateOfVisit = DateTime.Now;
                    //  tblEncounter.MODIFIED_DATE = DateTime.Now;
                    tblEncounter.CreatedBy = input.CreatedBy;
                    //     tblEncounter.MODIFIED_BY = objUserProfile.LogInUserName;
                    //  tblEncounter.IS_LOCKED = false;
                    //  tblEncounter.IS_CONCURRENT_LOCKED = false;
                    //  tblEncounter.IS_ADMISSION = false;
                    tblEncounter.Mode = e.Mode;
                    // tblEncounter.BILL_TYPE_ID = Convert.ToInt32(BillTypeIds.OP);
                    //   tblEncounter.MARKETING_EMPLOYEE_ID = objAdmissionVo.MarketingEmpoyeeId;

                    //  tblEncounter.CONSULTATION_CHARGE_GROUP_ID = objAdmissionVo.ConsultationChargeGroupId;
                    // tblEncounter.OP_SPECIALITY_ID = objAdmissionVo.OpSpecialityId;
                    //tblEncounter.IS_OP_LAB_BILL = objAdmissionVo.IsLabBill;
                    //TBL_ENCOUNTER objTblEncounter = context.TBL_ENCOUNTERs.Where(i => i.DATE_OF_VISIT.Date == DateTime.Now.Date && i.FACILITY_ID == objUserProfile.SelectedFacilityId && i.IS_ADMISSION == false).OrderByDescending(i => i.ENCOUNTER_ID).FirstOrDefault();
                    //  if (objTblEncounter == null && !Convert.ToBoolean(tblEncounter.IS_ADMISSION))
                    //      tblEncounter.SEQUENCE_NUMBER = 1;
                    //  else if (!Convert.ToBoolean(tblEncounter.IS_ADMISSION))
                    //     tblEncounter.SEQUENCE_NUMBER = objTblEncounter.SEQUENCE_NUMBER + 1;

                    //  tblEncounter.IS_AROGYASREE = objAdmissionVo.IsArogyasree;
                    // tblEncounter.AROGYASREE_ID = objAdmissionVo.ArogyasreeId;
                    //   if (//.CorporateId.HasValue)
                    //  tblEncounter.CorporateId = e.CorporateId;
                    //  tblEncounter.IS_EMERGENCY_REGISTRATION = objAdmissionVo.IsEmergency;
                    tblEncounter.IsReview = false;
                    //  tblEncounter.REVIEW_COUNT = objAdmissionVo.ReviewCount;
                    //   tblEncounter.LAST_DATE_OF_CHARGED_VISIT = objAdmissionVo.LastdateofChargedvisit;
                    //   if (objAdmissionVo.ConsultationDate != null)
                    //   {
                    tblEncounter.ConsultationDate = CurrentDate;
                    //    }
                    //   if (objAdmissionVo.IsFreeConsultation != null && objAdmissionVo.IsFreeConsultation == true)
                    //    {
                    tblEncounter.IsFreeConsultation = false;
                    tblEncounter.OrganizationId = input.Organization_id;//Added by vijay
                    tblEncounter.OpId = GetFullOpID(input.Organization_id, input.FacilityId);
                    context.TblEncounters.Add(tblEncounter);
                    context.SaveChanges();
                    long encounterId = tblEncounter.EncounterId;
                    obj.EncounterID = encounterId;
                    obj.PatientID = tblEncounter.PatientId;
                    obj.OpID = tblEncounter.OpId;
                    if (encounterId != 0)
                    {
                        obj.Message = "Success";
                    }



                    context.SaveChanges();
                    #endregion
                    //-------------------------------------------Payment section------------------
                    if (input.AppointmentId != null)
                    {
                        UpdateAppointmentStatus(input.AppointmentId);
                    }







                    //TblPatientAppointmentSecuUserLink coment code
                    #region
                    //-------------------------------------------------------------------------------
                    //TblPatientAppointmentSecuUserLink tblLink = new TblPatientAppointmentSecuUserLink();
                    //tblLink.AppointmentId = appointmentId;
                    //tblLink.EncounterId = encounterId;
                    //tblLink.ProviderId = objpatDetails.DoctorId;
                    //tblLink.SecurityUserId = Guid.NewGuid().ToString();
                    //tblLink.StatusId = 1;
                    //tblLink.CreatedBy = input.CreatedBy;
                    //tblLink.CreationDate = DateTime.Now;
                    //// tblLink.MODIFIED_BY = objUserProfile.LogInUserName;
                    ////tblLink.MODIFIED_DATE = DateTime.Now;
                    //context.TblPatientAppointmentSecuUserLinks.Add(tblLink);
                    //context.SaveChanges();
                    #endregion
                }
            }
            return obj;


            return null;

        }
        public OpCreateResult SaveExistingOP(OpInput input)
        {
            TblEncounter e = new TblEncounter();
            OpCreateResult obj = new OpCreateResult();
            string createdBy = "Admin";
            using (var context = new bhishak_app_dbContext())
            {
                
                var objpatient = context.TblPatients.Where(x => x.PatienTId == input.PatientId).FirstOrDefault();

                objpatient.DoctorId = input.DoctorId;
                if(input.Address!=null && input.Address!="")
                {
                    objpatient.Address = input.Address;
                }

                if(input.AreaId!=0)
                {
                    objpatient.AreaId = input.AreaId;
                }
               
                objpatient.ReferrinGPhysicianId = input.RefDoctorId;
               if(input.EmailId!=null && input.EmailId!="")
                {
                    objpatient.PatienTEmail = input.EmailId;
                }
              
                objpatient.CreatedBy = createdBy;
                objpatient.CreationDate = DateTime.Now;
                // objpatient.BloodGroup = input.BloodGroup;
                //  objpatient.Age = input.Age;
              if(input.MobileNumber!=null && input.MobileNumber!="")
                {
                    objpatient.MobileNUmber = input.MobileNumber;
                }
              
               
              
                //  objpatient.RfId = input.RfId;
               // objpatient.MotherNAme = "divya"; //input.MotherName;
                                                 // objpatient.AadharNo = input.AadharNo;
                if (input.CorporateId != null && input.CorporateId != 0)
                {
                    objpatient.CorporateId = Convert.ToInt32(input.CorporateId);
                }

               
               // context.TblPatients.Add(objpatient);
                context.SaveChanges();
                DateTime CurrentDate = DateTime.Now;
                DateTime MonthStartDate = CurrentDate.AddDays(-CurrentDate.Day + 1);
                string PatId = string.Empty;
                var objpatDetails = context.TblPatients.Where(c => c.PatienTId == objpatient.PatienTId).FirstOrDefault();

                //   TBL_SCHEDULE_PROVIDER objSchedule = null;
                var objSchedule = context.TblScheduleProviders.Where(p => p.IsDefaultSchedule == true && p.ProviderId == objpatDetails.DoctorId).FirstOrDefault();
                TblAdmAppointmentType objAppointmentType = null;
                objAppointmentType = context.TblAdmAppointmentTypes.Where(p => p.AppointmentType == "Walk In Appointment").Single();
                TblAdmAppointmentStatus objAppointmentStatus = null;
                objAppointmentStatus = context.TblAdmAppointmentStatuses.Where(p => p.AppointmentStatus == "ARRIVED").Single();



                TblPatientAppointment objTblPatientAppointment = new TblPatientAppointment();
                //  objTblPatientAppointment.ScheduleId = objSchedule.ScheduleId;
                objTblPatientAppointment.PatientId = objpatDetails.PatienTId;
                objTblPatientAppointment.DoctorId = objpatDetails.DoctorId;
                  objTblPatientAppointment.FacilityId = input.FacilityId;
                objTblPatientAppointment.ReferringPhysicianId = objpatDetails.ReferrinGPhysicianId;
                objTblPatientAppointment.AppointmentDate = DateTime.Now.AddDays(1);
                DateTime StartTime = RoundDown(DateTime.Today);
                // DateTime StartTime = objAdmissionVo.AdmissionDate.Add(DateTime.Now.TimeOfDay);
                objTblPatientAppointment.StartTime = StartTime;
                objTblPatientAppointment.EndTime = StartTime.AddMinutes(15.0); ;
                objTblPatientAppointment.AppointmentTypeId = objAppointmentType.AppointmentTypeId;
                objTblPatientAppointment.AppointmentStatusId = objAppointmentStatus.AppointmentStatusId;
                objTblPatientAppointment.StatusId = 1;
                objTblPatientAppointment.IsProviderAppointment = true;
                objTblPatientAppointment.CreatedBy = createdBy;
                objTblPatientAppointment.CreationDate = DateTime.Now;
                //  objTblPatientAppointment.MODIFIED_BY = objUserProfile.LogInUserName;
                //   objTblPatientAppointment.MODIFIED_DATE = DateTime.Now;
                //if (objAdmissionVo.IsMedicoLegalCase != null && objAdmissionVo.IsMedicoLegalCase == true)
                //{
                //    objTblPatientAppointment.IS_MEDICO_LEGAL_CASE = true;
                //    objTblPatientAppointment.NAME_OF_THE_INFORMENT = objAdmissionVo.NameofTheInforment;
                //    objTblPatientAppointment.POLICE_STATION = objAdmissionVo.PoliceStation;
                //    objTblPatientAppointment.PC_NO = objAdmissionVo.PCNo;
                //    objTblPatientAppointment.PC_WHO_IS_BROUGHT = objAdmissionVo.PCWhoBrought;
                //}

                context.TblPatientAppointments.Add(objTblPatientAppointment);
                context.SaveChanges();
                int appointmentId = context.TblPatientAppointments.Max(i => i.PatientAppointmentId);
                //Create Encounter
                int appointmentCount = (from f in context.TblPatientAppointments.Where(x => x.StartTime.Date == StartTime && x.CheckinDate != null) select f.PatientAppointmentId).Count();
                int sequenceNumber = 0;
                if (appointmentCount == 0)
                {
                    sequenceNumber = 1;
                }
                else
                {
                    sequenceNumber = appointmentCount;
                }
                // if (objpatDetails.LastName.Length > 4)
                //   objPatientDetails.LastName = objPatientDetails.LastName.Substring(0, 4);
                //string PatEncounterId = string.Format("{0}-{1}-{2}", objPatientDetails.LastName.ToUpper(), DateTime.Today.ToString("MMdd"), string.Format("{0:0000}", sequenceNumber));
                //using (PatientBillingModelDataContext Encountercontext = new PatientBillingModelDataContext())
                //{
                TblEncounter tblEncounter = new TblEncounter();
                tblEncounter.PatientId = objpatDetails.PatienTId;
                tblEncounter.StatusId = 1;
                tblEncounter.SpecialityId =(int)input.SpacialityId; //(from p in context.TBL_PATIENT_APPOINTMENTs.Where(x => x.PATIENT_APPOINTMENT_ID == appointmentId) select p.TBL_PROVIDER.SPECIALITY_TYPE_ID.Value).FirstOrDefault();
                tblEncounter.AppointmentId = appointmentId;
                tblEncounter.DoctorId = objpatDetails.DoctorId;
                // tblEncounter.CHAMBER_NO = objAdmissionVo.ChamberNo;
                tblEncounter.FacilityId = Convert.ToInt32(objpatDetails.FacilityId);
                //   tblEncounter.A = PatEncounterId;
                tblEncounter.DateOfVisit = StartTime;
                tblEncounter.DateOfVisit = DateTime.Now;
                //  tblEncounter.MODIFIED_DATE = DateTime.Now;
                tblEncounter.CreatedBy = createdBy;
                //     tblEncounter.MODIFIED_BY = objUserProfile.LogInUserName;
                //  tblEncounter.IS_LOCKED = false;
                //  tblEncounter.IS_CONCURRENT_LOCKED = false;
                //  tblEncounter.IS_ADMISSION = false;
                tblEncounter.Mode = e.Mode;
                // tblEncounter.BILL_TYPE_ID = Convert.ToInt32(BillTypeIds.OP);
                //   tblEncounter.MARKETING_EMPLOYEE_ID = objAdmissionVo.MarketingEmpoyeeId;

                //  tblEncounter.CONSULTATION_CHARGE_GROUP_ID = objAdmissionVo.ConsultationChargeGroupId;
                // tblEncounter.OP_SPECIALITY_ID = objAdmissionVo.OpSpecialityId;
                //tblEncounter.IS_OP_LAB_BILL = objAdmissionVo.IsLabBill;
                //TBL_ENCOUNTER objTblEncounter = context.TBL_ENCOUNTERs.Where(i => i.DATE_OF_VISIT.Date == DateTime.Now.Date && i.FACILITY_ID == objUserProfile.SelectedFacilityId && i.IS_ADMISSION == false).OrderByDescending(i => i.ENCOUNTER_ID).FirstOrDefault();
                //  if (objTblEncounter == null && !Convert.ToBoolean(tblEncounter.IS_ADMISSION))
                //      tblEncounter.SEQUENCE_NUMBER = 1;
                //  else if (!Convert.ToBoolean(tblEncounter.IS_ADMISSION))
                //     tblEncounter.SEQUENCE_NUMBER = objTblEncounter.SEQUENCE_NUMBER + 1;

                //  tblEncounter.IS_AROGYASREE = objAdmissionVo.IsArogyasree;
                // tblEncounter.AROGYASREE_ID = objAdmissionVo.ArogyasreeId;
                //   if (//.CorporateId.HasValue)
                tblEncounter.CorporateId = e.CorporateId;
                //  tblEncounter.IS_EMERGENCY_REGISTRATION = objAdmissionVo.IsEmergency;
                tblEncounter.IsReview = false;
                //  tblEncounter.REVIEW_COUNT = objAdmissionVo.ReviewCount;
                //   tblEncounter.LAST_DATE_OF_CHARGED_VISIT = objAdmissionVo.LastdateofChargedvisit;
                //   if (objAdmissionVo.ConsultationDate != null)
                //   {
                tblEncounter.ConsultationDate = CurrentDate;
                //    }
                //   if (objAdmissionVo.IsFreeConsultation != null && objAdmissionVo.IsFreeConsultation == true)
                //    {
                tblEncounter.IsFreeConsultation = false;
                tblEncounter.OrganizationId = input.Organization_id;//Added by vijay
                tblEncounter.OpId = GetFullOpID(input.Organization_id, input.FacilityId);//Added by vijay
                //   }
                //   if (objAdmissionVo.IsCoupon != null && objAdmissionVo.IsCoupon == true)
                //  {
                //  tblEncounter.IsCoupon = objAdmissionVo.IsCoupon;
                //    }
                //  tblEncounter.CONSULTATION_TYPE_ID = objAdmissionVo.ChargeItemId;
                //  if (objAdmissionVo.IsFromAmbulanceTrip != null)
                //   {
                //       tblEncounter.ID_FROM_AMBULANCE = objAdmissionVo.IsFromAmbulanceTrip;
                //      tblEncounter.AMBULANCE_TRIP_ID = objAdmissionVo.AmbulanceTripId;
                //   }
                context.TblEncounters.Add(tblEncounter);
                context.SaveChanges();
                long encounterId = tblEncounter.EncounterId;
                obj.EncounterID = encounterId;
                obj.PatientID = tblEncounter.PatientId;
               
                obj.OpID = tblEncounter.OpId;////Added by vijay
                if (encounterId != null)
                {
                    obj.Message = "Success";
                }
                                    
                //   objEncEntryVo.EncounterId = encounterId;
                //  int encounterCountId = context.TBL_ENCOUNTERs.Where(s => s.DATE_OF_VISIT > MonthStartDate.Date && s.IS_ADMISSION == false && s.IS_OP_LAB_BILL == null && s.IS_FROM_CASUALITY == null).Count();
                // if (encounterCountId == 0)
                //     encounterCountId = 1;
               
                //= ConfigurationManager.AppSettings["OPIdFormat"].ToString() + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yy") + "-" + String.Format("{0:D5}", encounterCountId);
                context.SaveChanges();

                //-------------------------------------------

                //}
                TblPatientAppointmentSecuUserLink tblLink = new TblPatientAppointmentSecuUserLink();
                tblLink.AppointmentId = appointmentId;
                tblLink.EncounterId = encounterId;
                tblLink.ProviderId = objpatDetails.DoctorId;
                tblLink.SecurityUserId = Guid.NewGuid().ToString();
                tblLink.StatusId = 1;
                tblLink.CreatedBy = createdBy;
                tblLink.CreationDate = DateTime.Now;
                // tblLink.MODIFIED_BY = objUserProfile.LogInUserName;
                //tblLink.MODIFIED_DATE = DateTime.Now;
                context.TblPatientAppointmentSecuUserLinks.Add(tblLink);
                context.SaveChanges();
            }
            return obj;
        }

        private string GetFullReceiptNumer(int OrganizationId, int FacilityId)
        {
            int year = DateTime.Now.Year;

            using (var context = new bhishak_app_dbContext())
            {
                int RegCount = (from d in context.TblRegistrationBillings.Where(x => x.CreatedDateTime.Year==year && x.CreatedDateTime.Month==DateTime.Now.Month && x.OrganigationId == OrganizationId && x.FecilityId == FacilityId) select d.RegId).Count();

                string reciptNo = DateTime.Now.ToString("yyyy") + DateTime.Now.ToString("MM") + "-" + OrganizationId+"-" + FacilityId+"-"+String.Format("{0:D5}", RegCount + 1);
                
                return reciptNo;
            }

        }

    }
}
