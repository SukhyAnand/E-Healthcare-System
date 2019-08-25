using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DMS
{
    public class AccountModel
    {
       public string username {get; set;}
       public string email {get; set;}
       public string mobile {get; set;}
       public string password {get; set;}
       public string country {get; set;}
       public string gender { get; set; }
       public Byte[] photo { get; set; }
       public string dob { get; set; }
       public int userid { get; set; }
       public int? roleid { get; set; }
       public string role { get; set; }
       public bool? IsActive { get; set; }

    }

    public class HospitalModel
    {
        public int hosid { get; set; }
        public string hosname { get; set; }
        public string hosstate { get; set; }
        public string hoscountry { get; set; }

    }
    public class DoctorModel
    {
        public int Doc_IdM { get; set; }
        public string Doc_NameM { get; set; }
        public string Doc_CountryM { get; set; }
        public string Doc_StateM { get; set; }
        public string Doc_HospitalM { get; set; }
        public string Doc_SpecialistM { get; set; }
        public string Doc_RegIdM { get; set; }
        public string Doc_ExpM { get; set; }
        public string Doc_DetailsM { get; set; }
        public string Doc_Home_FeeM { get; set; }
        public string Doc_OnSite_FeeM { get; set; }
        public bool IsActiveM { get; set; }
        public int User_IdM { get; set; }

    }
    public class AppoModel
    {
        public int Appo_IdM { get; set; }
        public Nullable<int> Doc_IdM { get; set; }
        public string Appo_DateM { get; set; }
        public Nullable<int> Patient_IdM { get; set; }
        public string User_IdM { get; set; }
        public Nullable<bool> IsConfirmM { get; set; }


    }

    public  class PatientModel
    {
        public int Patient_IdM { get; set; }
        public string Patient_StateM { get; set; }
        public string Patient_CountryM { get; set; }
        public string Patient_DiseaseM { get; set; }
        public string Patient_AgeM { get; set; }
        public string Patient_GenderM { get; set; }
        public string Patient_ReportM { get; set; }
        public string Patient_NameM { get; set; }
        public Nullable<bool> IsActiveM { get; set; }
        public Nullable<int> User_IdM { get; set; }
        public string Appo_IdM { get; set; }
        public Nullable<int> Doc_IdM { get; set; }
        public string Doc_NameM { get; set; }
        public string Appo_DateM { get; set; }
        public Nullable<bool> IsConfirmM { get; set; }
        public string Patient_HospitalM { get; set; }
    }
    public class ReviewModel
    {

        public int Review_idM { get; set; }
        public Nullable<int> RatingM { get; set; }
        public string Review_TextM { get; set; }
        public string Review_DateM { get; set; }
        public Nullable<int> Raised_ByM { get; set; }
        public string Raised_ByUsernameM { get; set; }
        public string User_RoleM { get; set; }

    }
}