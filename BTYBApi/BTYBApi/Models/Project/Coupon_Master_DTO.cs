namespace BTYBApi.Models.Project
{
    public class Coupon_Master_DTO
    {
        public Int64 CM_PkeyID { get; set; }
        public String CM_Name { get; set; }
        public String CM_Description { get; set; }
        public String CM_Code { get; set; }
        public Decimal CM_Discount_Perc { get; set; }
        public int CM_Discount_Flat { get; set; }
        public DateTime CM_Expiry_Date { get; set; }
        public int CM_Expiry_Days { get; set; }
        public Boolean? CM_IsActive { get; set; }
        public Boolean? CM_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }
    }

    public class Coupon_Master_DTO_Input
    {
        public int Type { get; set; }
        public Int64 CM_PkeyID { get; set; }
        public String? Promo_Code { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }

}
