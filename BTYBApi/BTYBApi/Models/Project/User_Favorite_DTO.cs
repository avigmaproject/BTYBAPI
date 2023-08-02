namespace BTYBApi.Models.Project
{
    public class User_Favorite_DTO
    {
        public Int64 UF_Pkey { get; set; }
        public Int64 UF_User_PkeyID { get; set; }
        public Int64 UF_UP_PKeyID { get; set; }
        public int UF_Closet_Spotlight { get; set; }
        public Boolean? UF_IsActive { get; set; }
        public Boolean? UF_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }

    }
    public class User_Favorite_DTO_Input
    {
        public int Type { get; set; }
        public Int64 UF_PkeyID { get; set; }
        public Int64 UF_User_PkeyID { get; set; }
        public Int64 UF_UP_PKeyID { get; set; }
        public Int64 UF_Closet_Spotlight { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }

}
