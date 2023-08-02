using BTYBApi.Models.Project;
using BTYBApi.Repository.Lib;
using Newtonsoft.Json.Linq;

namespace BTYBApi.Repository.Avigma
{
    public class Convert_Json_Array
    {
        Log log = new Log();
        public Payment_Master_DTO ConvertJsonArray(Order_Master_DTO Data)
        {
            Payment_Master_DTO paymentData = new Payment_Master_DTO();
            try
            {
                if (!string.IsNullOrEmpty(Data.ORDM_Payment_Data))
                {

                    JArray jsonArray = JArray.Parse(Data.ORDM_Payment_Data);

                    JObject jsonData = jsonArray[0][0] as JObject;

                    paymentData.PAYM_No_IP = Int32.Parse(jsonData["PaymentData"][0]["PAYM_No_IP"].ToString());
                    paymentData.PAYM_No_Stripe_PriceID = jsonData["PaymentData"][0]["PAYM_No_Stripe_PriceID"].ToString();
                    paymentData.PAYM_No_Stripe_ProductID = jsonData["PaymentData"][0]["PAYM_No_Stripe_ProductID"].ToString();
                    paymentData.PAYM_No_Stripe_UserID = Int64.Parse(jsonData["PaymentData"][0]["PAYM_No_Stripe_UserID"].ToString());
                }
                //if (!string.IsNullOrEmpty(Data.ORDM_Payment_Detail))
                //{

                //}
            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
            }

            return paymentData;

        }
    }
}
