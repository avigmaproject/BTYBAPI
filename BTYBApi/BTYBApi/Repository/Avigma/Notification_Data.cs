using BTYBApi.Models.Avigma;
using CorePush.Google;
using Microsoft.Extensions.Options;
using static BTYBApi.Models.Avigma.GoogleNotification;
using System.Net.Http.Headers;
using BTYBApi.IRepository;
using CorePush.Apple;
using BTYBApi.Repository.Lib;
using Newtonsoft.Json;
using System.Net;
using System.Data;
using System.Data.SqlClient;

namespace BTYBApi.Repository.Avigma
{
    public class Notification_Data : INotification_Data
    {
        Log log = new Log();
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }
        public Notification_Data()
        {
        }
        public Notification_Data(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Conn_dBcon");
        }


        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }

        public async Task<ResponseModel> SendNotification(NotificationMasterDTO notificationModel)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (notificationModel.IsAndroiodDevice)
                {
                    /* FCM Sender (Android Device) */
                    FcmSettings settings = new FcmSettings()
                    {
                        SenderId = _configuration["SenderId"],
                        ServerKey = _configuration["ServerKey"]
                    };
                    HttpClient httpClient = new HttpClient();

                    string authorizationKey = string.Format("keyy={0}", settings.ServerKey);
                    string deviceToken = notificationModel.DeviceId;

                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authorizationKey);
                    httpClient.DefaultRequestHeaders.Accept
                            .Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    DataPayload dataPayload = new DataPayload();
                    dataPayload.Title = notificationModel.Title;
                    dataPayload.Body = notificationModel.Body;

                    GoogleNotification notification = new GoogleNotification();
                    notification.Data = dataPayload;
                    notification.Notification = dataPayload;

                    var fcm = new FcmSender(settings, httpClient);
                    var fcmSendResponse = await fcm.SendAsync(deviceToken, notification);

                    if (fcmSendResponse.IsSuccess())
                    {
                        response.IsSuccess = true;
                        response.Message = "Notification sent successfully";
                        return response;
                    }
                    else
                    {
                        response.IsSuccess = false;
                        response.Message = fcmSendResponse.Results[0].Error;
                        return response;
                    }
                }
                else
                {
                    /* Code here for APN Sender (iOS Device) */
                    //var apn = new ApnSender(apnSettings, httpClient);
                    //await apn.SendAsync(notification, deviceToken);
                }
                return response;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Something went wrong";
                return response;

                log.logErrorMessage(ex.StackTrace);
                log.logErrorMessage(ex.Message);

            }
        }

        public async Task<string> SendNotificationToken(NotificationMasterTokenDTO notification)
        {
            var result = "-1";
            try
            {

                WebRequest httpWebRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                httpWebRequest.Method = "post";

                string serverKey = _configuration["ServerKey"];
                string senderId = _configuration["SenderId"];

                httpWebRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
                httpWebRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                httpWebRequest.ContentType = "application/json";
                var payload = new
                {
                    to = notification.userToken,

                    priority = "high",
                    content_available = true,
                    notification = new
                    {
                        body = notification.message,
                        title = notification.msgtitle,
                        badge = 1,

                    },
                    data = new
                    {
                        key1 = notification.data,

                    }

                };

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(payload);
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
                log.logInfoMessage("Notifcation Status---------->" + notification.userToken);
                log.logInfoMessage(result);

            }
            catch (Exception ex)
            {

                log.logErrorMessage(ex.StackTrace);
                log.logErrorMessage(ex.Message);
            }
            return result;

        }
    }
}
