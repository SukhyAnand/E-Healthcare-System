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
       

        #region --Account Details--
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
                role = tran.RoleDetails.Where(m => m.Role_Id == x.Role_Id).Select(y => y.Role).FirstOrDefault(),
                email = x.User_Mail,
                IsActive = x.IsActive,
                country = x.User_Country

            }).ToList();



            return model;

        }

        #endregion

        public string Key { get; set; }
        public object value { get; set; }
        public object type { get; set; }

    }
}