//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DMS
{
    using System;
    using System.Collections.Generic;
    
    public partial class PatientDetail
    {
        public int Patient_Id { get; set; }
        public string Patient_State { get; set; }
        public string Patient_Country { get; set; }
        public string Patient_Hospital { get; set; }
        public string Patient_Disease { get; set; }
        public string Patient_Age { get; set; }
        public string Patient_Gender { get; set; }
        public string Patient_Report { get; set; }
        public string Patient_Name { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> User_Id { get; set; }
        public string Appo_Id { get; set; }
        public Nullable<int> Doc_Id { get; set; }
        public string Appo_Date { get; set; }
        public Nullable<bool> IsConfirm { get; set; }
    }
}
