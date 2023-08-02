namespace BTYBApi.Models.Project
{
    public class User_Subscription_DTO
    {
        public Int64 SUB_PKeyID { get; set; }
        public String SUB_Name { get; set; }
        public String SUB_Description { get; set; }
        public Boolean SUB_Status { get; set; }
        public int SUB_Period { get; set; }
        public DateTime? SUB_CurrentDate { get; set; }
        public DateTime? SUB_ExpiryDate { get; set; }
        public String SUB_Offer { get; set; }
        public Decimal SUB_Amount { get; set; }
        public int SUB_No_IP { get; set; }
        public String SUB_No_Stripe_ProductID { get; set; }
        public String SUB_No_Stripe_PriceID { get; set; }
        public Int64 SUB_No_Stripe_UserID { get; set; }
        public Boolean? SUB_IsActive { get; set; }
        public Boolean? SUB_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }
    }

    public class User_Subscription_DTO_Input
    {
        public int Type { get; set; }
        public Int64 SUB_PkeyID { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }
}
