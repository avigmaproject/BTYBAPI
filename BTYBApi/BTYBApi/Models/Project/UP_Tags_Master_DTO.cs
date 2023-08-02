namespace BTYBApi.Models.Project
{
    public class UP_Tags_Master_DTO
    {
        public Int64 UPTM_PkeyID { get; set; }
        public String UPTM_Name { get; set; }
        public Int64 UPTM_UP_PkeyID { get; set; }
        public Boolean? UPTM_IsActive { get; set; }
        public Boolean? UPTM_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }

    }
    public class UP_Tags_Master_DTO_Input
    {
        public int Type { get; set; }
        public Int64 UPTM_PkeyID { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }
}
