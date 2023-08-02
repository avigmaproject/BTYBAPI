using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using BTYBApi.Models.Avigma;
using BTYBApi.Repository.Lib;

namespace BTYBApi.Repository.Lib.FireBase
{

    public class FireBaseNotificationData
    {
        public List<dynamic> SendNotificationData(sendNotification sendNotification)
        {
            Log log = new Log();
            List<dynamic> obj = new List<dynamic>();
            try
            {
                NotificationGetData notificationGetData = new NotificationGetData();
                NotificationMasterNewDTO notificationMaster = new NotificationMasterNewDTO();

                

                try
                {

                    AddNotification addNotification = new AddNotification();
                    obj = addNotification.submitNotification(sendNotification);
                    for (int i = 0; i < obj.Count; i++)
                    {
                        notificationMaster.UserId = obj[i].UserId;
                        string val = "{ UserId:\"" + notificationMaster.UserId + "\",\n Message:\"" + obj[i].message + "\"\n}";
                        notificationMaster.JSONFormat = val;
                        notificationGetData.PublicStoreData(notificationMaster);
                    }
                }
                catch (Exception ex)
                {
                    log.logErrorMessage(ex.StackTrace);
                    log.logErrorMessage(ex.Message);
                }

                
                
                
            }
            catch (Exception ex)
            {

                log.logErrorMessage(ex.StackTrace);
                log.logErrorMessage(ex.Message);
            }


            return obj;
        }

        public async Task<bool> SendPushNotification(sendNotification sendNotification)
        {
            Log log = new Log();
            string strNotificationTitle = System.Configuration.ConfigurationManager.AppSettings["FireBaseTitle"];
            NotificationGetData notificationGetData = new NotificationGetData();

           return await notificationGetData.NotifyAsync(sendNotification.UserToken, strNotificationTitle, sendNotification.message);
        }

        public List<dynamic> SendPushNotificationDetails(sendNotification sendNotification)
        {
            Log log = new Log();
            List<dynamic> obj = new List<dynamic>();
            string strNotificationTitle = System.Configuration.ConfigurationManager.AppSettings["FireBaseTitle"];
            try {
                AddNotification addNotification = new AddNotification();

                NotificationGetData notificationGetData = new NotificationGetData();

                obj = addNotification.submitNotification(sendNotification);

                for (int i = 0; i < obj.Count; i++)
                {
                    notificationGetData.NotifyAsync(obj[i].UserToken, strNotificationTitle, sendNotification.message);

                }





            }
            catch (Exception ex)
            {

                log.logErrorMessage(ex.StackTrace);
                log.logErrorMessage(ex.Message);
            }


            return obj;

        }

     }
}