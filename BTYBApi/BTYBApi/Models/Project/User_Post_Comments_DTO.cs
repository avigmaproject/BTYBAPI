namespace BTYBApi.Models.Project
{
    public class User_Post_Comments_DTO
    {
        public Int64 UPC_PkeyID { get; set; }
        public Int64 UPC_User_PkeyID { get; set; }
        public Int64 UPC_UP_PKeyID { get; set; }
        public String UPC_Comments { get; set; }
        public String UPC_Location { get; set; }
        public String UPC_Latitude { get; set; }
        public String UPC_Longitude { get; set; }


        public int UPC_Like { get; set; }
        public Decimal UPC_Rating { get; set; }
        public Int64 UPC_Comment_PkeyID { get; set; }

        public Boolean? UPC_IsActive { get; set; }
        public Boolean? UPC_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }
    }

    public class User_Post_Comments_DTO_Input
    {
        public int Type { get; set; }
        public Int64 UPC_PkeyID { get; set; }
        public Int64 UPC_User_PkeyID { get; set; }
        public Int64 UPC_UP_PKeyID { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }
}
