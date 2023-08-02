namespace BTYBApi.Models.Project
{
    public class User_Subscription_Group_DTO
    {
        public Int64 USG_PkeyID { get; set; }
        public Int64 USG_User_PkeyID { get; set; }
        public Decimal USG_Amount { get; set; }
        public int USG_Subs_Type { get; set; }
        public DateTime USG_Date_Subscription { get; set; }
        public DateTime USG_Expiry_Date { get; set; }
        public int USG_Tenure { get; set; }
        public Int64 USG_SP_PkeyID { get; set; }
        public Boolean? USG_IsActive { get; set; }
        public Boolean? USG_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }
    }

    public class User_Subscription_Group_DTO_Input
    {
        public int Type { get; set; }
        public Int64 USG_PkeyID { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }

}
