namespace BTYBApi.Models.Project
{
    public class UP_Highlight_Master_DTO
    {
        public Int64 UPHM_PkeyID { get; set; }
        public Decimal UPHM_Amount { get; set; }
        public Int64 UPHM_UP_PkeyID { get; set; }
        public List<String?> UPHM_FromDate { get; set; }
        public String? UPHM_FromDate_Data { get; set; }

        public String? UPHM_No_Stripe_ProductID { get; set; }
        public String? UPHM_No_Stripe_PriceID { get; set; }
        public Int64 UPHM_No_Stripe_UserID { get; set; }

        public Boolean? UPHM_IsActive { get; set; }
        public Boolean? UPHM_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }

    }
    public class UP_Highlight_Master_DTO_Input
    {
        public int Type { get; set; }
        public Int64 UPHM_PkeyID { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }
}
