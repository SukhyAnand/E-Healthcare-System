using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

/// <summary>
/// Summary description for Transaction
/// </summary>
namespace DMS
{
    public partial class Transaction
    {
        EHealthCareEntities tran = new EHealthCareEntities();

        #region --Account Details--
        public int GetUserIdByUsername(string Username)
        {

            int UserId = tran.UserDetails.Where(x => x.User_Name == Username).Select(x => x.User_Id).SingleOrDefault();
            return UserId;
        }
        public string GetUsernameByUserId(int? UserId)
        {

            string Username = tran.UserDetails.Where(x => x.User_Id == UserId).Select(x => x.User_Name).FirstOrDefault();
            return Username;
        }
        public bool InsertAccountDetails(AccountModel model)
        {
            try
            {
                tran.UserDetails.Add(new UserDetail
                {
                    User_Name = model.username,
                    User_Password = model.password,
                    User_Phone = model.mobile,
                    User_DOB = model.dob,
                    User_Gender = model.gender,
                    User_Country = model.country,
                    User_Mail = model.email,
                    User_Photo = model.photo,
                    Role_Id = model.roleid,
                    IsActive = false



                });

                tran.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }



        }
        public bool UpdateAccountDetails(AccountModel model)
        {
            try
            {
                UserDetail details = tran.UserDetails.Where(x => x.User_Name == model.username).SingleOrDefault();

               
                details.User_Phone = model.mobile;
                details.User_DOB = model.dob;
                details.User_Gender = model.gender;
                details.User_Country = model.country;
                details.User_Mail = model.email;
                if (model.photo != null)
                    details.User_Photo = model.photo;
                details.Role_Id = model.roleid;


                tran.SaveChanges();

                return true;
            }
            catch
            {
                return false;

            }

        }
        public AccountModel GetAccountDetailsByUserName(string Username)
        {
            AccountModel model = tran.UserDetails.Where(x => x.User_Name.Equals(Username)).Select(x=> new AccountModel
            {
              username = x.User_Name,
              mobile = x.User_Phone,
              photo = x.User_Photo,
              gender = x.User_Gender,
              userid = x.User_Id,
              roleid = x.Role_Id,
              email = x.User_Mail
                 
            }).FirstOrDefault();



            return model;

        }
        public string GetRoleByUserName(string Username)
        {
           
            int? RoleId = tran.UserDetails.Where(x => x.User_Name.Equals(Username)).Select(x => x.Role_Id).SingleOrDefault();

            String Role = tran.RoleDetails.Where(x => x.Role_Id == RoleId).Select(x => x.Role).SingleOrDefault();

            return Role;

        }
        public bool IsAuthenticateUser(string Username, string Password)
        {
            int count = tran.UserDetails.Where(x => x.User_Name.Equals(Username) && x.User_Password.Equals(Password)).Count();

            if (count > 0)
                return true;
            else
                return false;

        }
        public bool? IsActiveUser(string Username)
        {
            bool? IsActive = tran.UserDetails.Where(x => x.User_Name.Equals(Username)).Select(x=>x.IsActive).FirstOrDefault();

            return IsActive;
            

        }
        public bool IsUsernameExist(string Username)
        {
            int count = tran.UserDetails.Where(x => x.User_Name == Username).Count();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<AccountModel> GetAccountDetailsAll()
        {
            List<AccountModel> model = tran.UserDetails.Select(x => new AccountModel
            {
                username = x.User_Name,
                mobile = x.User_Phone,
                photo = x.User_Photo,
                gender = x.User_Gender,
                userid = x.User_Id,
                roleid = x.Role_Id,
                role = tran.RoleDetails.Where(m=>m.Role_Id == x.Role_Id).Select(y=>y.Role).FirstOrDefault(),
                email = x.User_Mail,
                IsActive = x.IsActive,
                country = x.User_Country

            }).ToList();



            return model;

        }
        public bool ActivatorByUserName(string Username,bool Status)
        {
            try
            {
                UserDetail details = tran.UserDetails.Where(x => x.User_Name == Username).SingleOrDefault();

                details.IsActive = Status;


                tran.SaveChanges();

                return true;
            }
            catch
            {
                return false;

            }


        }
        
        #endregion 

        #region --Admin Details--

        public List<HospitalModel> GetHospitalDetailsAll()
        {
            List<HospitalModel> model = tran.HospitaMasters.Select(x => new HospitalModel
            {
               hosid = x.Hospital_Id,
               hosname = x.Hospital_Name,
               hosstate = x.State,
               hoscountry = x.Country

            }).ToList();



            return model;

        }

        public bool AddHospital(HospitalModel model)
        {
            try
            {
                tran.HospitaMasters.Add(new HospitaMaster
                {
                    Hospital_Name = model.hosname,
                    Country = model.hoscountry,
                    State = model.hosstate
                });

                tran.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool RemoveHospital(int HospitalId)
        {
            try
            {
                HospitaMaster RemoveItem = tran.HospitaMasters.Where(x => x.Hospital_Id == HospitalId).FirstOrDefault();
                tran.HospitaMasters.Remove(RemoveItem);
                tran.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public List<HospitalModel> GetHospitalByState(string state)
        {
            try
            {
                List<HospitalModel> model = tran.HospitaMasters.Where(x => x.State == state)
                    .Select(x => new HospitalModel
                    {
                        hosid = x.Hospital_Id,
                        hosname = x.Hospital_Name
                    }).ToList();

                return model;
            }
            catch
            {
                return new List<HospitalModel>();
            }

        }

        public List<AccountModel> GetAllDocUser()
        {
            List<AccountModel> model = tran.UserDetails.Where(x=>x.Role_Id==2 && x.IsActive == true).Select(x => new AccountModel
            {
                username = x.User_Name,
                mobile = x.User_Phone,
                photo = x.User_Photo,
                gender = x.User_Gender,
                userid = x.User_Id,
                roleid = x.Role_Id,
                role = tran.RoleDetails.Where(m => m.Role_Id == x.Role_Id).Select(y => y.Role).FirstOrDefault(),
                email = x.User_Mail,
                IsActive = x.IsActive,
                country = x.User_Country

            }).ToList();

            return model;


        }

        public List<DoctorModel> GetDoctorByFilter(string state,string hospital,string specialisation)
        {
            List<DoctorModel> model = tran.DoctorsDetails.Where(x => x.Doc_Hospital == hospital && x.Doc_State == state && x.Doc_Specialist == specialisation)
                .Select(x => new DoctorModel
            {
               Doc_IdM = x.Doc_Id,
               Doc_NameM = x.Doc_Name,
               Doc_SpecialistM = x.Doc_Specialist,
               Doc_HospitalM = x.Doc_Hospital,
               Doc_DetailsM = x.Doc_Details,
               Doc_OnSite_FeeM = x.Doc_OnSite_Fee,
               Doc_Home_FeeM = x.Doc_Home_Fee

            }).ToList();

            return model;


        }

        public bool InsertDoctorDetails(DoctorModel model)
        {
            try
            {
                tran.DoctorsDetails.Add(new DoctorsDetail
                {
                   Doc_Name = model.Doc_NameM,
                   Doc_Country = model.Doc_CountryM,
                   Doc_Details = model.Doc_DetailsM,
                   Doc_Exp = model.Doc_ExpM,
                   Doc_Home_Fee = model.Doc_Home_FeeM,
                   Doc_OnSite_Fee = model.Doc_OnSite_FeeM,
                   Doc_RegId = model.Doc_RegIdM,
                   Doc_Specialist = model.Doc_SpecialistM,
                   Doc_State = model.Doc_StateM,
                   User_Id = model.User_IdM,
                   Doc_Hospital = model.Doc_HospitalM,
                   IsActive = true



                });

                tran.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }



        }
        public bool UpdateDoctorDetails(DoctorModel model)
        {
            try
            {
                DoctorsDetail m = tran.DoctorsDetails.Where(x => x.Doc_Id == model.Doc_IdM).FirstOrDefault();
                m.Doc_Country = model.Doc_CountryM;
                m.Doc_Details = model.Doc_DetailsM;
                m.Doc_Exp = model.Doc_ExpM;
                m.Doc_Home_Fee = model.Doc_Home_FeeM;
                m.Doc_Hospital = model.Doc_HospitalM;
                m.Doc_Name = model.Doc_NameM;
                m.Doc_OnSite_Fee = model.Doc_OnSite_FeeM;
                m.Doc_RegId = model.Doc_RegIdM;
                m.Doc_Specialist = model.Doc_SpecialistM;
                m.Doc_State = model.Doc_StateM;
                

               

                tran.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }



        }

        public List<DoctorModel> GetAllDocDetails()
        {
            List<DoctorModel> model = tran.DoctorsDetails.Where(x=>x.IsActive == true).Select(x => new DoctorModel
            {
               Doc_CountryM = x.Doc_Country,
               Doc_DetailsM = x.Doc_Details,
               Doc_ExpM = x.Doc_Exp,
               Doc_Home_FeeM = x.Doc_Home_Fee,
               Doc_HospitalM = x.Doc_Hospital,
               Doc_IdM = x.Doc_Id,
               Doc_NameM = x.Doc_Name,
               Doc_OnSite_FeeM = x.Doc_OnSite_Fee,
               Doc_RegIdM = x.Doc_RegId ,
               Doc_SpecialistM = x.Doc_Specialist,
               Doc_StateM = x.Doc_State,
               IsActiveM = x.IsActive,
               User_IdM = x.User_Id

            }).ToList();

            return model;


        }
        public DoctorModel GetDocDetailsById(int DocId)
        {
            DoctorModel model = tran.DoctorsDetails.Where(x => x.IsActive == true && x.Doc_Id == DocId).Select(x => new DoctorModel
            {
                Doc_CountryM = x.Doc_Country,
                Doc_DetailsM = x.Doc_Details,
                Doc_ExpM = x.Doc_Exp,
                Doc_Home_FeeM = x.Doc_Home_Fee,
                Doc_HospitalM = x.Doc_Hospital,
                Doc_IdM = x.Doc_Id,
                Doc_NameM = x.Doc_Name,
                Doc_OnSite_FeeM = x.Doc_OnSite_Fee,
                Doc_RegIdM = x.Doc_RegId,
                Doc_SpecialistM = x.Doc_Specialist,
                Doc_StateM = x.Doc_State,
                IsActiveM = x.IsActive,
                User_IdM = x.User_Id,
                

            }).FirstOrDefault();

            return model;


        }

        public bool RemoveDoctorDetails(int DocId)
        {
            try
            {
                DoctorsDetail RemoveItem = tran.DoctorsDetails.Where(x => x.Doc_Id == DocId).FirstOrDefault();
                tran.DoctorsDetails.Remove(RemoveItem);
                tran.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool InsertPatientDetails(PatientModel model)
        {
            try
            {
                tran.PatientDetails.Add(new PatientDetail
                {
                   IsActive = model.IsActiveM,
                   Patient_Age = model.Patient_AgeM,
                   Patient_Country = model.Patient_CountryM,
                   Patient_Disease = model.Patient_DiseaseM,
                   Patient_Gender = model.Patient_GenderM,
                   Patient_Name = model.Patient_NameM,
                   Patient_Report = model.Patient_ReportM,
                   Patient_State = model.Patient_StateM,
                   User_Id = model.User_IdM,
                   Doc_Id = model.Doc_IdM,
                   Appo_Date = model.Appo_DateM,
                   IsConfirm = model.IsConfirmM,
                   Patient_Hospital = model.Patient_HospitalM



                });

                tran.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }



        }

        public List<PatientModel> GetAllPatientByUsername( string Username)
        {
            int UserId =  GetUserIdByUsername(Username);
            List<PatientModel> model = tran.PatientDetails.Where(x => x.User_Id == UserId)
                .Select(x=>new PatientModel
                {
                    Appo_DateM = x.Appo_Date,
                    Appo_IdM = x.Appo_Id,
                    Doc_IdM = x.Doc_Id,
                    IsActiveM = x.IsActive,
                    IsConfirmM = x.IsConfirm,
                    Patient_AgeM = x.Patient_Age,
                    Patient_CountryM = x.Patient_Country,
                    Patient_DiseaseM = x.Patient_Disease,
                    Patient_GenderM = x.Patient_Gender,
                    Patient_IdM = x.Patient_Id,
                    Patient_NameM = x.Patient_Name,
                    Patient_ReportM = x.Patient_Report,
                    Patient_StateM = x.Patient_State,
                    User_IdM = x.User_Id,
                    Patient_HospitalM = x.Patient_Hospital,
                    Doc_NameM = tran.DoctorsDetails.Where(m=>m.Doc_Id == x.Doc_Id).Select(m=>m.Doc_Name).FirstOrDefault()

                }).ToList();

            return model;

        }
        public List<PatientModel> GetAllPatientByDocUsername(string Username)
        {
            int UserId = GetUserIdByUsername(Username);
            int DocId = tran.DoctorsDetails.Where(x=>x.User_Id == UserId).Select(x=>x.Doc_Id).FirstOrDefault();
            List<PatientModel> model = tran.PatientDetails.Where(x => x.Doc_Id == DocId)
                .Select(x => new PatientModel
                {
                    Appo_DateM = x.Appo_Date,
                    Appo_IdM = x.Appo_Id,
                    Doc_IdM = x.Doc_Id,
                    IsActiveM = x.IsActive,
                    IsConfirmM = x.IsConfirm,
                    Patient_AgeM = x.Patient_Age,
                    Patient_CountryM = x.Patient_Country,
                    Patient_DiseaseM = x.Patient_Disease,
                    Patient_GenderM = x.Patient_Gender,
                    Patient_IdM = x.Patient_Id,
                    Patient_NameM = x.Patient_Name,
                    Patient_ReportM = x.Patient_Report,
                    Patient_StateM = x.Patient_State,
                    User_IdM = x.User_Id,
                    Patient_HospitalM = x.Patient_Hospital,
                    Doc_NameM = tran.DoctorsDetails.Where(m => m.Doc_Id == x.Doc_Id).Select(m => m.Doc_Name).FirstOrDefault()

                }).ToList();

            return model;

        }

        public bool RemoveAppointment(int PatId)
        {
            try
            {
                PatientDetail RemoveItem = tran.PatientDetails.Where(x => x.Patient_Id == PatId).FirstOrDefault();
                tran.PatientDetails.Remove(RemoveItem);
                tran.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool InsertReviewDetails(ReviewModel model)
        {
            try
            {
                tran.ReviewDetails.Add(new ReviewDetail
                {
                   Raised_By = model.Raised_ByM,
                   Rating = model.RatingM,
                   Review_Date = model.Review_DateM,
                   Review_Text = model.Review_TextM,
                   User_Role = model.User_RoleM



                });

                tran.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }



        }

        public List<ReviewModel> GetAllReview()
        {
            List<ReviewModel> model = tran.ReviewDetails.Select(x => new ReviewModel
            {
               Raised_ByM = x.Raised_By,
               Raised_ByUsernameM = tran.UserDetails.Where(m => m.User_Id == x.Raised_By).Select(m => m.User_Name).FirstOrDefault(),
               RatingM = x.Rating,
               Review_DateM = x.Review_Date,
               Review_idM = x.Review_id,
               Review_TextM =x.Review_Text,
               User_RoleM = x.User_Role


            }).ToList();

            return model;


        }
        
        public bool UpdateAppointmentConfirmation(int PatId)
        {
            try
            {
                PatientDetail details = tran.PatientDetails.Where(x => x.Patient_Id == PatId).SingleOrDefault();
                details.IsConfirm = true;
                tran.SaveChanges();

                return true;
            }
            catch
            {
                return false;

            }

        }

        #endregion
        public string Key { get; set; }
        public object value { get; set; }
        public object type { get; set; }

    }
}