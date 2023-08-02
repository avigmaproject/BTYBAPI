namespace BTYBApi.Models.Project
{
    public class User_Comments_Reply_DTO
    {
        public Int64 UPR_PkeyID { get; set; }
        public Int64 UPR_UPC_PkeyID { get; set; }
        public Int64 UPR_User_PkeyID { get; set; }
        public Boolean UPR_Like { get; set; }
        public String UPR_Comments { get; set; }
        public String UPR_Location { get; set; }
        public String UPR_Latitude { get; set; }
        public String UPR_Longitude { get; set; }
        public Decimal UPR_Rating { get; set; }
        public Decimal UPC_Rating { get; set; }
        public Int64 UPR_CR_PkeyID { get; set; }

        public Boolean? UPR_IsActive { get; set; }
        public Boolean? UPR_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }
    }

    public class User_Comments_Reply_DTO_Input
    {
        public int Type { get; set; }
        public Int64 UPR_PkeyID { get; set; }
        public Int64 UPR_User_PkeyID { get; set; }
        public Int64 UPR_UPC_PkeyID { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }
}
