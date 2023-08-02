using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTYBApi.Models.Project
{
    public class Provider_Master_DTO
    {

        public Int64 PD_PKeyID  { get; set; }
        public String PD_Name { get; set; }
        public String PD_MiddleName { get; set; }
        public String PD_LastName { get; set; }
        public String PD_Name_Degree { get; set; }
        public String PD_License_Number { get; set; }
        public String PD_NPI { get; set; }
        public String PD_Company_Name { get; set; }
        public String PD_Email { get; set; }
        public String PD_Clinic_Email { get; set; }
        public String PD_Address { get; set; }
        public int? PD_State { get; set; }
        public String PD_City { get; set; }
        public String PD_Zip { get; set; }
        public String PD_Phone { get; set; }
        public String PD_Fax_Number { get; set; }
        public String PD_Anti_Mob_Volume { get; set; }
        public String PRD_File_Path { get; set; }
        public int? PD_Role { get; set; }
        public String PD_Account_Number { get; set; }
        public String PD_Password { get; set; }
        public Boolean? PD_IsApproved { get; set; }
        public Boolean? PD_IsAuth { get; set; }
        public Int64? PD_PKeyID_Parent { get; set; }
        public String PD_Imagepath { get; set; }
        public int? PD_Email_OTP { get; set; }
        public int? PD_Mobile_OTP { get; set; }
        public Boolean? PD_Email_OTP_chk { get; set; }
        public Boolean? PD_Mobile_OTP_chk { get; set; }
        public String PD_Address2 { get; set; }
        public String PD_Address3 { get; set; }
        public String PD_PhysicianSignature_ImgPath { get; set; }
        public String PD_PhysicianSignature_ImgName { get; set; } 
        public String PD_CopyofmedicalLicenseFilePath { get; set; }
        public String PD_CopyofmedicalLicenseFileName { get; set; }
        public String PD_MobileNo { get; set; }
        public String PD_Provider_AutherizedVal { get; set; }
        public Boolean? PD_IsTwoFactorAuth { get; set; }
        public Boolean? PD_IsActive { get; set; }
        public Boolean? PD_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64? UserID { get; set; }
        public string Provider_Documents_DTO { get; set; }
        public int PD_Role_Type { get; set; }

        public int PD_Current_User_Role { get; set; }
        public Int64? PD_CLC_PKeyID { get; set; }
    }

    public class Provider_Master_OTP
    {
        public int? PD_Email_OTP { get; set; }
        public int? PD_Mobile_OTP { get; set; }
    }

    public class State_DropDown_DTO
    {
        public Int64 SM_PkeyID { get; set; }
        public String SM_Name { get; set; }
        public Boolean? SM_IsActive { get; set; }
        public Boolean? SM_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64? UserID { get; set; }

    }

    public class List_Provider_Master_DTO
    {

        public Int64 PD_PKeyID { get; set; }
        public String PD_Name { get; set; }
        public String PD_LastName { get; set; }
        public String PD_Name_Degree { get; set; }
        
        public String PD_Company_Name { get; set; }
        public String PD_Email { get; set; }
       
        
        public String PD_Phone { get; set; }
        public String PD_Fax_Number { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public Boolean? PD_IsApproved { get; set; }
     
      

        public Boolean? PD_IsActive { get; set; }
        public Boolean? PD_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64? UserID { get; set; }
        public string Provider_Documents_DTO { get; set; }
       

        public List<List_Child_Provider_Master_DTO> list_Child_Provider_Master_DTO { get; set; }



    }


    public class List_Child_Provider_Master_DTO
    {

        public Int64 PD_PKeyID { get; set; }
        public String PD_Name { get; set; }
        public String PD_LastName { get; set; }
        public String PD_Name_Degree { get; set; }
        public String PD_License_Number { get; set; }
        public String PD_NPI { get; set; }
        public String PD_Company_Name { get; set; }
        public String PD_Email { get; set; }
        public String PD_Address { get; set; }
        public int? PD_State { get; set; }
        public String PD_City { get; set; }
        public String PD_Zip { get; set; }
        public String PD_Phone { get; set; }
        public String PD_Fax_Number { get; set; }
        public String PD_Anti_Mob_Volume { get; set; }
        public String PRD_File_Path { get; set; }
        public int? PD_Role { get; set; }
        public String PD_Account_Number { get; set; }
        public String PD_Password { get; set; }
        public Boolean? PD_IsApproved { get; set; }
        public Boolean? PD_IsAuth { get; set; }
        public Int64? PD_PKeyID_Parent { get; set; }
        public String PD_Imagepath { get; set; }

        public Boolean? PD_IsActive { get; set; }
        public Boolean? PD_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64? UserID { get; set; }
        public string Provider_Documents_DTO { get; set; }
        public int PD_Role_Type { get; set; }


    }

    public class ProviderJson
    {
        public Int64 PD_PKeyID { get; set; }
        public String PD_Name { get; set; }
    }
    public class ListProviderJson
    {
        public List<ProviderJson> listProviderJson { get; set; }
    }

    public sealed class Singleton1
    {
        private Singleton1() { }
        private static Singleton1 instance = null;
        public static Singleton1 Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton1();
                }
                return instance;
            }
        }
    }
}