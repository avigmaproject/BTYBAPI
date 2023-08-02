namespace BTYBApi.Models.Project
{
    public class Order_Master_DTO
    {
        public Int64 ORDM_PKeyID { get; set; }
        public Int64 ORDM_UP_PkeyID { get; set; }
        public Int64 ORDM_User_PkeyID { get; set; }
        public String? ORDM_OrderID { get; set; }
        public int ORDM_Discount_Pers { get; set; }
        public Decimal ORDM_Discount_Total { get; set; }
        public Decimal ORDM_Tot_Amount { get; set; }
        public int ORDM_IsStatus { get; set; }
        public Boolean? ORDM_IsActive { get; set; }
        public Boolean? ORDM_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64 UserID { get; set; }

        //public string ORDM_Pro_Detail { get; set; }

        public List<Order_Master_Child_DTO> ORDM_Pro_Detail { get; set; }
        //public String ORDM_Pro_Data { get; set; }
        public Int64 ORD_UP_User_PkeyID { get; set; }
        public List<Payment_Master_DTO> ORDM_Payment_Detail { get; set; }
        public String? ORDM_Payment_Data { get; set; }




        //public Int64 ORD_PKeyID { get; set; }
        //public Int64 ORD_UP_PkeyID { get; set; }
        //public Int64 ORD_Pro_PkeyID { get; set; }
        //public Int64 ORD_UP_User_PkeyID { get; set; }
        //public Int64 ORD_UP_Purchase_PkeyID { get; set; }
        //public Boolean? ORD_IsActive { get; set; }
        //public Boolean? ORD_IsDelete { get; set; }

    }

    public class Order_Master_DTO_Input
    {
        public int Type { get; set; }
        public Int64 ORDM_PkeyID { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }

}
