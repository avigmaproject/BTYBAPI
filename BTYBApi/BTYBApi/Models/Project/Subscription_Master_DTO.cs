namespace BTYBApi.Models.Project
{
    public class Subscription_Master_DTO
    {
        public Int64 SM_PkeyID { get; set; }
        public String SM_Name { get; set; }
        public String SM_Description { get; set; }
        public DateTime SM_Duration { get; set; }
        public Decimal SM_Subscription_Amount { get; set; }

        public Boolean? SM_IsActive { get; set; }
        public Boolean? SM_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }
    }

    public class Subscription_Master_DTO_Input
    {
        public int Type { get; set; }
        public Int64 SM_PkeyID { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }
}
