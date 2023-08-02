namespace BTYBApi.Models.Project
{
    public class User_Followers_DTO
    {
        public Int64 FLL_PKeyID { get; set; }
        public Int64 FLL_My_UserID { get; set; }
        public Int64 FLL_UserID { get; set; }
        public int FLL_IsAccepted { get; set; }
        public String User_Name { get; set; }
        public String User_Image_Path { get; set; }
        public Int64 User_PkeyID { get; set; }
        public Boolean? FLL_IsActive { get; set; }
        public Boolean? FLL_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }
    }

    public class User_Followers_DTO_Input
    {
        public int Type { get; set; }
        public Int64 FLL_PkeyID { get; set; }
        public Int64 FLL_My_UserID { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }
}
