namespace BTYBApi.Models.Project
{
    public class UP_Price_Master_DTO
    {
        public Int64 UPPM_PkeyID { get; set; }
        public Decimal UPPM_Amount { get; set; }
        public Int64 UPPM_UP_PkeyID { get; set; }

        public String? UPPM_No_Stripe_ProductID { get; set; }
        public String? UPPM_No_Stripe_PriceID { get; set; }
        public Int64 UPPM_No_Stripe_UserID { get; set; }

        public Boolean? UPPM_IsActive { get; set; }
        public Boolean? UPPM_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }

    }
    public class UP_Price_Master_DTO_Input
    {
        public int Type { get; set; }
        public Int64 UPPM_PkeyID { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }
}
