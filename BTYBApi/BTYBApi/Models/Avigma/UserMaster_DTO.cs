using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BTYBApi.Models.Avigma
{
    public class UserMaster_DTO
    {
        public Int64 User_PkeyID { get; set; }
        public Int64? User_PkeyID_Master { get; set; }
        public String User_Name { get; set; }
        public String? User_Email { get; set; }
        public String? User_Password { get; set; }
        public String? User_Phone { get; set; }
        public String? User_Address { get; set; }
        public String? User_City { get; set; }
        public String? User_Country { get; set; }
        public String? User_Zip { get; set; }
        public String? User_DOB { get; set; }
        public int? User_Type { get; set; }
        public int User_OTP { get; set; }
        public Boolean? User_IsActive_Prof { get; set; }
        public int? User_Gender { get; set; }
        public String? User_Image_Path { get; set; }
        public String? User_Image_Base { get; set; }
        public String? User_MacID { get; set; }
        public Boolean? User_IsVerified { get; set; }
        public Boolean? User_IsActive { get; set; }
        public Boolean? User_IsDelete { get; set; }
        public int Type { get; set; }
        public Int64 UserID { get; set; }
        public String? User_latitude { get; set; }
        public String? User_longitude { get; set; }
       
        public String? User_Token_val { get; set; }
        public int? User_Login_Type { get; set; }
        //public Boolean? User_IsActive_Prof { get; set; }
        public String? User_LastName { get; set; }
        public String? User_Company { get; set; }
        public int User_Language { get; set; }
        public String? User_IPAddress { get; set; }

        public String? User_Occupation { get; set; }
        //public String? User_MotiID { get; set; }
        public String? User_Sponsorable_Img { get; set; }
        public String? User_Sponsorable_Img_link { get; set; }
        public String? User_Video_Path { get; set; }
        public Int64? User_PkeyID_Out { get; set; }
        public String? User_Login_Token { get; set; }
        public String? User_Store_URL { get; set; }
        public String? User_FB_URL { get; set; }
        public String? User_Insta_URL { get; set; }
        public String? User_YouTube_URL { get; set; }

        public String? User_FB_ID { get; set; }
        public String? User_Gmail_ID { get; set; }
        public String? User_iOS_ID { get; set; }
        public String? User_Bio { get; set; }
        public String? User_Image_Name { get; set; }
        public String? User_Firebase_UID { get; set; }
    }

    public class UserMaster_ChangePassword
    {
        public String User_PkeyID { get; set; }
        public String User_Password { get; set; }
        public int Type { get; set; }
        public Int64? UserID { get; set; }
        public String User_Email { get; set; }
        public int? User_Type { get; set; }

    }


    public class UserMaster_DTO_Input
    {
        public int Type { get; set; }
        public Int64 User_PkeyID { get; set; }
        public Int64? User_PkeyID_Master { get; set; }
        public String? Search_Data { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }


}