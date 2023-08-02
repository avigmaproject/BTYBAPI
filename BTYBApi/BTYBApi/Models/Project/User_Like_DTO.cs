namespace BTYBApi.Models.Project
{
    public class User_Like_DTO
    {
        public Int64 UL_PKeyID { get; set; }
        public String UL_Name { get; set; }
        public Int64 UL_UP_PKeyID { get; set; }
        public Int64 UL_User_PkeyID { get; set; }
        public Boolean? UL_IsActive { get; set; }
        public Boolean? UL_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }

    }
    public class User_Like_DTO_Input
    {
        public int Type { get; set; }
        public Int64 UL_PkeyID { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }

}
