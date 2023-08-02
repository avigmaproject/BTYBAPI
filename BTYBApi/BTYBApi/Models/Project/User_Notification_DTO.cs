using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTYBApi.Models.Project
{
    public class User_Notification_DTO
    {
        public Int64 NT_PKeyID { get; set; }
        public String? NT_Name { get; set; }
        public String? NT_Description { get; set; }
        public Boolean? NT_IsActive { get; set; }
        public int? PageNumber { get; set; }
        public int? NoofRows { get; set; }
        public String Orderby { get; set; }
        public Boolean? NT_IsDelete { get; set; }
        public Int64? NT_UserID { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }
        public Int64? NT_UP_PKeyID { get; set; }
        public Int64? NT_US_PKeyID { get; set; }
        public Int64? NT_UPC_PkeyID { get; set; }
        public Int64? NT_UPR_PkeyID { get; set; }
        public Int64? NT_UL_PKeyID { get; set; }
        public Int64? NT_TP_PKeyID { get; set; }
        public Int64? NT_UCD_User_PkeyID { get; set; }
        
        public int? NT_C_L { get; set; }
        public Int64? NT_SP_PKeyID { get; set; }
        public Int64? NT_FLL_PKeyID { get; set; }
        public Int64? NT_Creator_PKeyID { get; set; }
        public Int64? NT_Creator_Group_PKeyID { get; set; }
        public Int64? NT_User_Subs_PkeyID { get; set; }
        public Int64? NT_UPG_PkeyID { get; set; }
        public Boolean? User_Creator_IsVerfied { get; set; }
        public Int64? NT_User_Creator_PkeyID { get; set; }
        public String? NT_ChannelName { get; set; }
        public String? NT_ChannelToken { get; set; }
    }
}