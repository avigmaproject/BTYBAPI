using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTYBApi.Models.Avigma
{
    public class NotificationMasterDTO
    {
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }
        [JsonProperty("isAndroiodDevice")]
        public bool IsAndroiodDevice { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("body")]
        public string Body { get; set; }
    }

    public class NotificationMasterTokenDTO
    {

        [JsonProperty("userToken")]
        public string userToken { get; set; }
        [JsonProperty("message")]
        public string message { get; set; }
        [JsonProperty("msgtitle")]
        public string msgtitle { get; set; }
        [JsonProperty("data")]
        public string data { get; set; }
    }

    public class GoogleNotification
    {
        public class DataPayload
        {
            [JsonProperty("title")]
            public string Title { get; set; }
            [JsonProperty("body")]
            public string Body { get; set; }
        }
        [JsonProperty("priority")]
        public string Priority { get; set; } = "high";
        [JsonProperty("data")]
        public DataPayload Data { get; set; }
        [JsonProperty("notification")]
        public DataPayload Notification { get; set; }
    }
    public class FcmNotificationSetting
    {
        public string SenderId { get; set; }
        public string ServerKey { get; set; }
    }
    public class ResponseModel
    {
        [JsonProperty("isSuccess")]
        public bool IsSuccess { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
    public class NotificationMasterNewDTO
    {
        public String UserId { get; set; }
        //public String OTP { get; set; }
        public String JSONFormat { get; set; }
    }

    public class ViewNotification
    {

        public String UserId { get; set; }
        public String OTP { get; set; }

    }

    public class NotificationDTO
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MobileNumber { get; set; }
        public String EmailId { get; set; }
        public Int64? UserId { get; set; }
        public String message { get; set; }
        public int StatusID { get; set; }
        public Boolean IsActive { get; set; }
        public String Notificationdetails { get; set; }
        public string UserToken { get; set; }
    }
    public class Notification
    {
        //public String FirstName { get; set; }
        //public String LastName { get; set; }
        //public String MobileNumber { get; set; }
        //public String EmailId { get; set; }
        public Int64? UserId { get; set; }
        public String message { get; set; }
        //public int StatusID { get; set; }
        //public Boolean IsActive { get; set; }
        public String UserToken { get; set; }
    }
    public class sendNotification
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String MobileNumber { get; set; }
        public String EmailId { get; set; }
        public Int64? UserId { get; set; }
        public String message { get; set; }
        public String Notificationdetails { get; set; }
        public Boolean IsActive { get; set; }
        public int StatusID { get; set; }
        public String UserToken { get; set; }
        public string ReferenceCode { get; internal set; }
    }

}