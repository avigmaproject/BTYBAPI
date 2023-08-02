using System.Runtime.Intrinsics.X86;
using System.Text.Json.Nodes;
using System.Web.Helpers;

namespace BTYBApi.Models.Project
{
    public class User_Post_DTO
    {
        public Int64 UP_PKeyID { get; set; }
        public String UP_ImageName { get; set; }
        public int UP_Size { get; set; }
        public String UP_ImagePath { get; set; }
        public Boolean UP_IsFirst { get; set; }
        public int UP_Number { get; set; }
        public Int64 UP_UserID { get; set; }
        public Boolean? UP_IsActive { get; set; }
        public Boolean? UP_IsDelete { get; set; }
        public int? Type { get; set; }
        public Int64? UserID { get; set; }
        public String UP_Web_URL { get; set; }
        public String UP_Coll_Desc { get; set; }
        public Boolean UP_IsAdmin { get; set; }
        public String? UP_Location { get; set; }
        public String? UP_latitude { get; set; }
        public String? UP_longitude { get; set; }
        public String? UP_Doc_Type { get; set; }
        public String? UP_Title { get; set; }
        public String? UP_Tags { get; set; }
        public String? UP_Price { get; set; }
        public String? UP_Promo_Code { get; set; }
        public Boolean UP_Shop_Now { get; set; }
        public String? UP_Poster_Img_Name { get; set; }
        public String? UP_Poster_Img_Path { get; set; }
        public Decimal? UP_Duration { get; set; }
        public String? UP_Product_Name { get; set; }
        public Decimal? UP_Product_Price { get; set; }
        public String? UP_Address { get; set; }
        public int UP_No_IP { get; set; }
        public String UP_No_Stripe_ProductID { get; set; }
        public String UP_No_Stripe_PriceID { get; set; }
        public Int64 UP_No_Stripe_UserID { get; set; }
        public Decimal UP_Net_Amount { get; set; }
        public Boolean UP_Payment_Status { get; set; }

        public JsonArray? UP_ProductData { get; set; }
        public String? UP_ProductData1 { get; set; }
        public Int64? UPC_PkeyID { get; set; }
        public Int64? US_PKeyID { get; set; }
        public Int64? SUB_PKeyID { get; set; }
        public Int64? FLL_PKeyID { get; set; }
        public Int64? UL_PKeyID { get; set; }
        public Int64? UPG_PkeyID { get; set; }

        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }

    }
    public class User_Post_DTO_Input
    {
        public int Type { get; set; }
        public Int64 UP_PkeyID { get; set; }
        public Int64 UP_UserID { get; set; }
        public String? WhereClause { get; set; }
        public String? Search_Data { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }
    }

    public class User_Post_Like_Share_DTO
    {
        public Int64 UP_PkeyID { get; set; }
        public Int64 UserID { get; set; }
        public int Type { get; set; }
    }
    public class Product_Shop_Purchase_DTO
    {
        public Int64 Pro_PKeyID { get; set; }
        public Int64 UserID { get; set; }
        public int Type { get; set; }
    }

    public class User_Post_Search_DTO
    {
        public String? User_Name { get; set; }
        public String? UP_Tags { get; set; }

        public Int64 Distance { get; set; }
        public Decimal? UP_longitude { get; set; }
        public Decimal? UP_latitude { get; set; }
        //public Boolean? Time_Period_Week { get; set; }
        //public Boolean? Time_Period_Month { get; set; }
        public DateTime? Time_Period_Week { get; set; }
        public DateTime? Time_Period_Month { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? End_Date { get; set; }

        public Boolean? MostShared { get; set; }
        public Boolean? MostLiked { get; set; }
        public Boolean? MostShop { get; set; }
        public Boolean? MostPurchased { get; set; }

        public int Type { get; set; }
        public String? WhereClause { get; set; }
        //public String? Search_Data { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public Int64 UserID { get; set; }

    }
    public class User_Post_Notification_DTO
    {
        public Int64? UP_PKeyID { get; set; }
        public Int64? UL_PKeyID { get; set; }
        public Int64? UPC_PkeyID { get; set; }
        public Int64? UPR_PkeyID { get; set; }
        public Int64 UserID { get; set; }
        public String? WhereClause { get; set; }
        public int PageNumber { get; set; }
        public int NoofRows { get; set; }
        public String? Orderby { get; set; }
        public int Type { get; set; }
    }

}
