namespace BTYBApi.Models.Project
{
    public class Payment_Master_DTO
    {
        public Int64 PAYM_PKeyID { get; set; }
        public Int64 PAYM_ORDM_PkeyID { get; set; }
        public Int64 PAYM_User_PkeyID { get; set; }
        public int PAYM_No_IP { get; set; }
        public String? PAYM_No_Stripe_ProductID { get; set; }
        public String? PAYM_No_Stripe_PriceID { get; set; }
        public Int64 PAYM_No_Stripe_UserID { get; set; }
        public Int64 PAYM_Net_Amount { get; set; }
        public int PAYM_IsStatus { get; set; }
        public Boolean? PAYM_IsActive { get; set; }
        public Boolean? PAYM_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }
    }

    public class Payment_Master_DTO_Input
    {
        public int Type { get; set; }
        public Int64 PAYM_PkeyID { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }

}
