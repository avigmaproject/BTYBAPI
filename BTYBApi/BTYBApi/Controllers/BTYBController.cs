using API.Repository.Project;
using BTYBApi.IRepository;
using BTYBApi.Models.Avigma;
using BTYBApi.Models.Project;
using BTYBApi.Repository.Avigma;
using BTYBApi.Repository.Lib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Web.Helpers;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using BTYBApi.Repository.Project;

namespace BTYBApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class BTYBController : BaseController
    {
        Log log = new Log();
        private readonly IUnitOfWork _uof;
        private readonly IConfiguration _configuration;
        public BTYBController(IUnitOfWork uof, IConfiguration configuration)
        {
            _uof = uof;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        [Authorize]
        [Route("Log")]
        public IActionResult Index()
        {
            log.logDebugMessage("Log Message from Debug Method");
            log.logErrorMessage("Log Message from Error Method");
            log.logInfoMessage("Log Message from Info Method");

            return Ok();

       }


        [Route("GetHomeData")]
        [HttpPost]
        [Authorize]
        [AllowAnonymous]
        public async Task<dynamic> HomeData(UserMaster_DTO_Input InputData)
        {

            //UserMaster_DTO userMaster = new UserMaster_DTO();
            InputData.User_PkeyID = LoggedInUserId;
            InputData.UserID = LoggedInUserId;
            InputData.Type = InputData.Type;

            var result = _uof.userMaster_Data.Get_LoginUserDetails(InputData);
            return result;
        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateUserMasterData")]
        public async Task<List<dynamic>> AddUserMasterData(UserMaster_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                //Data.User_PkeyID = LoggedInUserId;
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.userMaster_Data.AddUserMaster_Data(Data));

                return Output;
           }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUserMasterData")]
        public async Task<List<dynamic>> GetUserMasterData(UserMaster_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var result = await Task.Run(() => _uof.userMaster_Data.Get_UserMasterDetails(InputData));
                objdynamicobj.Add(result);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }


        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateCouponMasterData")]
        public async Task<List<dynamic>> AddCouponMasterData(Coupon_Master_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.coupon_Master_Data.AddUpdateCoupon_Master_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetCouponMasterData")]
        public async Task<List<dynamic>> GetCouponMasterData(Coupon_Master_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var result = await Task.Run(() => _uof.coupon_Master_Data.Get_Coupon_MasterDetailsDTO(InputData));
                objdynamicobj.Add(result);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateSubscriptionMasterData")]
        public async Task<List<dynamic>> AddSubscriptionMasterData(Subscription_Master_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.subscription_Master_Data.AddUpdateSubscription_Master_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetSubscriptionMasterData")]
        public async Task<List<dynamic>> GetSubscriptionMasterData(Subscription_Master_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.subscription_Master_Data.Get_Subscription_MasterDetailsDTO(InputData));
                objdynamicobj.Add(output);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateUPPriceMasterData")]
        public async Task<List<dynamic>> AddUPPriceMasterData(UP_Price_Master_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.uP_Price_Master_Data.AddUpdateUP_Price_Master_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUPPriceMasterData")]
        public async Task<List<dynamic>> GetUPPriceMasterData(UP_Price_Master_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.uP_Price_Master_Data.Get_UP_Price_MasterDetailsDTO(InputData));
                objdynamicobj.Add(output);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }


        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateUPHighlightMasterData")]
        public async Task<List<dynamic>> AddUPHighlightMasterData(UP_Highlight_Master_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                string result = string.Join(", ", Data.UPHM_FromDate);
                //string result = String.Concat(Data.UPHM_FromDate_Input);
                Data.UPHM_FromDate_Data = result;
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.uP_Highlight_Master_Data.AddUpdateUP_Highlight_Master_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUPHighlightMasterData")]
        public async Task<List<dynamic>> GetUPHighlightMasterData(UP_Highlight_Master_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.uP_Highlight_Master_Data.Get_UP_Highlight_MasterDetailsDTO(InputData));
                objdynamicobj.Add(output);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateUPTagsMasterData")]
        public async Task<List<dynamic>> AddUPTagsMasterData(UP_Tags_Master_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.uP_Tags_Master_Data.AddUpdateUP_Tags_Master_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUPTagsMasterData")]
        public async Task<List<dynamic>> GetUPTagsMasterData(UP_Tags_Master_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.uP_Tags_Master_Data.Get_UP_Tags_MasterDetailsDTO(InputData));
                objdynamicobj.Add(output);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateUserCommentsReplyData")]
        public async Task<List<dynamic>> AddUserCommentsReplyData(User_Comments_Reply_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.user_Comments_Reply_Data.AddUpdateUser_Comments_Reply_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUserCommentsReplyData")]
        public async Task<List<dynamic>> GetUserCommentsReplyData(User_Comments_Reply_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.user_Comments_Reply_Data.Get_User_Comments_ReplyDetailsDTO(InputData));
                objdynamicobj.Add(output);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateUserFavoriteData")]
        public async Task<List<dynamic>> AddUserFavoriteData(User_Favorite_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.user_Favorite_Data.AddUpdateUser_Favorite_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUserFavoriteData")]
        public async Task<List<dynamic>> GetUserFavoriteData(User_Favorite_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.user_Favorite_Data.Get_User_FavoriteDetailsDTO(InputData));
                objdynamicobj.Add(output);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateUserFollowersData")]
        public async Task<List<dynamic>> AddUserFollowersData(User_Followers_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.user_Followers_Data.AddUpdateUser_Followers_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUserFollowersData")]
        public async Task<List<dynamic>> GetUserFollowersData(User_Followers_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.user_Followers_Data.Get_User_FollowersDetailsDTO(InputData));
                objdynamicobj.Add(output);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateUserLikeData")]
        public async Task<List<dynamic>> AddUserLikeData(User_Like_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UL_User_PkeyID = LoggedInUserId;
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.user_Like_Data.AddUpdateUser_Like_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUserLikeData")]
        public async Task<List<dynamic>> GetUserLikeData(User_Like_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.user_Like_Data.Get_User_LikeDetailsDTO(InputData));
                objdynamicobj.Add(output);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateUserPostCommentsData")]
        public async Task<List<dynamic>> AddUserPostCommentsData(User_Post_Comments_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.user_Post_Comments_Data.AddUpdateUser_Post_Comments_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUserPostCommentsData")]
        public async Task<List<dynamic>> GetUserPostCommentsData(User_Post_Comments_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.user_Post_Comments_Data.Get_User_Post_CommentsDetailsDTO(InputData));
                objdynamicobj.Add(output);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateUserPostData")]
        public async Task<List<dynamic>> AddUserPostData(User_Post_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            //var settings = new JsonSerializerSettings
            //{
            //    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            //};
            
            //string json1 = JsonConvert.SerializeObject(Data.UP_ProductData1, settings);

            string json = Data.UP_ProductData.ToString();

            Data.UP_ProductData1 = json;

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.user_Post_Data.AddUpdateUser_Post_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("UpdateUserPostLikeSharedCount")]
        public async Task<List<dynamic>> UpdateUserPostLikeShareData(User_Post_Like_Share_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.user_Post_Data.AddUpdateUser_Post_Like_Share_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }
        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("UpdateProductShopPurchaseCount")]
        public async Task<List<dynamic>> AddUpdateProduct_Shop_Purchase_Count_Data(Product_Shop_Purchase_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.user_Post_Data.AddUpdateProduct_Shop_Purchase_Count_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUserPostData")]
        public async Task<List<dynamic>> GetUserPostData(User_Post_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UP_UserID = LoggedInUserId;
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.user_Post_Data.Get_User_PostDetailsDTO(InputData));
                objdynamicobj.Add(output);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUserPostSearchData")]
        public async Task<List<dynamic>> GetUserPostSearchData(User_Post_Search_DTO InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.user_Post_Data.Get_User_Post_SearchDetailsDTO(InputData));
                objdynamicobj.Add(output);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [HttpPost]
        [Route("ForGotPassword")]
        public async Task<List<dynamic>> ForGotPassword(UserLogin user_Child_DTO)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                GetSetUser getSetUser = new GetSetUser(_configuration);
                //System.IO.Stream body = System.Web.HttpContext.Current.Request.InputStream;
                //System.Text.Encoding encoding = System.Web.HttpContext.Current.Request.ContentEncoding;
                //System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
                //string s = reader.ReadToEnd();
                //log.logDebugMessage("----------ForGotPassword Start--------------");
                //log.logDebugMessage(s);
                //log.logDebugMessage("----------ForGotPassword End--------------");
                //var user_Child_DTO = JsonConvert.DeserializeObject<UserLogin>(s);


                var output = await Task.Run(() => getSetUser.GetForGetPassword(user_Child_DTO));

                return output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }
        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateProviderMaster")]
        public async Task<List<dynamic>> CreateUpdate_Provider_Master(Provider_Master_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                //System.IO.Stream body = System.Web.HttpContext.Current.Request.InputStream;
                //System.Text.Encoding encoding = System.Web.HttpContext.Current.Request.ContentEncoding;
                //System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
                //string s = reader.ReadToEnd();
                //log.logDebugMessage("----------CreateUpdateProviderMaster Start--------------");
                //log.logDebugMessage(s);
                //log.logDebugMessage("----------CreateUpdateProviderMaster End--------------");
                //var Data = JsonConvert.DeserializeObject<Provider_Master_DTO>(s);
                Data.UserID = LoggedInUserId;
                if (Data.PD_Role_Type == 3 && Data.PD_Current_User_Role == 2)
                {
                    Data.PD_PKeyID_Parent = Data.UserID;
                }

                var output = await Task.Run(() => _uof.provider_Master_Data.CreateUpdate_Provider_Master_DataDetails(Data));

                return output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage("CreateUpdateProviderMaster");
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }
        }

        [HttpPost]
        [Route("GetUserViryficationDetails")]
        public async Task<List<dynamic>> GetUserViryficationDetails(UserVerificationMaster_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                UserVerificationMaster_Data userVerificationMaster_Data = new UserVerificationMaster_Data(_configuration);
                //System.IO.Stream body = System.Web.HttpContext.Current.Request.InputStream;
                //System.Text.Encoding encoding = System.Web.HttpContext.Current.Request.ContentEncoding;
                //System.IO.StreamReader reader = new System.IO.StreamReader(body, encoding);
                //string s = reader.ReadToEnd();
                //log.logDebugMessage("----------GetUserViryficationDetails Start--------------");
                //log.logDebugMessage(s);
                //log.logDebugMessage("----------GetUserViryficationDetails End--------------");
                ////log.logDebugMessage(s);
                //var Data = JsonConvert.DeserializeObject<UserVerificationMaster_DTO>(s);
                //Data.Type = 1;

                var output = await Task.Run(() => userVerificationMaster_Data.Check_User(Data));
                return output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("sendNotification")]
        public async Task<IActionResult> SendNotification(NotificationMasterDTO notificationModel)
        {
            var output = await Task.Run(() => _uof.notification_Data.SendNotification(notificationModel));
            return Ok(output);
        }


        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("sendNotifications")]
        public async Task<string> SendNotification(NotificationMasterTokenDTO notification)
        {
            var output = await Task.Run(() => _uof.notification_Data.SendNotificationToken(notification));

            return output;
        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateUserSubscriptionData")]
        public async Task<List<dynamic>> AddUserSubscriptionData(User_Subscription_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.user_Subscription_Data.AddUpdateUser_Subscription_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUserSubscriptionData")]
        public async Task<List<dynamic>> GetUserSubscriptionData(User_Subscription_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.user_Subscription_Data.Get_User_SubscriptionDetailsDTO(InputData));
                objdynamicobj.Add(output);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }


        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateUserSubscription_Group")]
        public async Task<List<dynamic>> AddUserSubscription_GroupData(User_Subscription_Group_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.user_Subscription_Group_Data.AddUpdateUser_Subscription_Group_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUserSubscription_Group")]
        public async Task<List<dynamic>> GetUserSubscription_GroupData(User_Subscription_Group_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.user_Subscription_Group_Data.Get_User_Subscription_GroupDetailsDTO(InputData));

                objdynamicobj.Add(output);
                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }


        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateOrderMasterChild")]
        public async Task<List<dynamic>> AddOrderMasterChildData(Order_Master_Child_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.order_Master_Child_Data.AddUpdateOrder_Master_Child_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetOrderMasterChild")]
        public async Task<List<dynamic>> GetOrderMasterChildData(Order_Master_Child_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var result = await Task.Run(() => _uof.order_Master_Child_Data.Get_Order_Master_ChildDetailsDTO(InputData));
                objdynamicobj.Add(result);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateOrderMaster")]
        public async Task<List<dynamic>> AddOrderMasterData(Order_Master_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();
            //Convert_Json_Array convert_Json_Array = new Convert_Json_Array();
            //Payment_Master_DTO OutPayment = new Payment_Master_DTO();
            try
            {
                //string result = string.Join(", ", Data.ORDM_Pro_Detail);
                //string result = String.Concat(Data.UPHM_FromDate_Input);
                //Data.ORDM_Pro_Data = result;

                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.order_Master_Data.AddUpdateOrder_Master_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetOrderMaster")]
        public async Task<List<dynamic>> GetOrderMasterData(Order_Master_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var result = await Task.Run(() => _uof.order_Master_Data.Get_Order_MasterDetailsDTO(InputData));
                objdynamicobj.Add(result);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }


        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdatePaymentMaster")]
        public async Task<List<dynamic>> AddPaymentMasterData(Payment_Master_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.payment_Master_Data.AddUpdatePayment_Master_Data(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }

        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetPaymentMaster")]
        public async Task<List<dynamic>> GetPaymentMasterData(Payment_Master_DTO_Input InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var result = await Task.Run(() => _uof.payment_Master_Data.Get_Payment_MasterDetailsDTO(InputData));
                objdynamicobj.Add(result);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }



        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("CreateUpdateUserNotification")]
        public async Task<List<dynamic>> AddNotificationData(User_Notification_DTO Data)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                Data.UserID = LoggedInUserId;
                var Output = await Task.Run(() => _uof.user_Notiffication_Data.CreateUpdate_User_NotificationDetails(Data));

                return Output;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }


        [AllowAnonymous]
        [Authorize]
        [HttpPost]
        [Route("GetUserNotification")]
        public async Task<List<dynamic>> GetUserNotification(User_Notification_DTO InputData)
        {

            List<dynamic> objdynamicobj = new List<dynamic>();

            try
            {
                InputData.UserID = LoggedInUserId;

                var output = await Task.Run(() => _uof.user_Notiffication_Data.Get_User_NotificationDetails(InputData));
                objdynamicobj.Add(output);

                return objdynamicobj;

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                objdynamicobj.Add(ex.Message);
                return objdynamicobj;
            }

        }
        //    [AllowAnonymous]
        //    [Authorize]
        //    [HttpPost]
        //    [Route("TrendTwitter")]
        //    public async Task<dynamic> TrendTwitter()
        //    {
        //        List<dynamic> objdynamic = new List<dynamic>();

        //        //var trends = Trends.GetPlaceTrends(1); // 1 corresponds to the WOEID for worldwide trends

        //        //// Extract the hashtag names from the trends response
        //        //var hashtags = trends[0].Trends.Where(trend => trend.Name.StartsWith("#")).Select(trend => trend.Name);

        //        //// Print the trending hashtags
        //        //foreach (var hashtag in hashtags)
        //        //{
        //        //    objdynamic.Add(hashtag);
        //        //    Console.WriteLine(hashtag);
        //        //}


        //        string apiKey = "R58JvERicemciveonUMS9TU3U";
        //        string apiSecretKey = "GrGyIqp5MWigpxjGlpyIq4rBcNBeJjw3fj4JX4gp7wZ9HZwMZF";
        //        string accessToken = "1351266986878185473-HzPWRY94iFInCSjtfLBdWeB9s6m9W5";
        //        string accessTokenSecret = "004wcZ54dyNragnY40pT4APCGIj9Jyg6FXaUez0WndjCs";

        //        // Set the WOEID for the location you want to get trending hashtags for
        //        int woeid = 1; // Replace with the appropriate WOEID

        //        // Create the HTTP client
        //        var httpClient = new HttpClient();

        //        // Set up the OAuth1.0a authentication header
        //        //var oauth = new OAuth1Header(apiKey, apiSecretKey, accessToken, accessTokenSecret);
        //        //httpClient.DefaultRequestHeaders.Add("Authorization", oauth.GetAuthorizationHeader());
        //        var oauth = new OAuth1Header(apiKey, apiSecretKey, accessToken, accessTokenSecret, "2.0");
        //httpClient.DefaultRequestHeaders.Add("Authorization", oauth.GetAuthorizationHeader());


        //        // Make the API request
        //        string apiUrl = $"https://api.twitter.com/1.1/trends/place.json?id={woeid}";
        //        var response = await httpClient.GetAsync(apiUrl);
        //        string responseContent = await response.Content.ReadAsStringAsync();

        //        // Parse the response
        //        var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        //        var trends = System.Text.Json.JsonSerializer.Deserialize<List<Trend>>(responseContent, jsonOptions);

        //        // Extract the hashtags from the response
        //        if (trends != null && trends.Count > 0)
        //        {
        //            var hashtags = trends[0].Trends;
        //            foreach (var hashtag in hashtags)
        //            {
        //                objdynamic.Add(hashtag.Name);
        //                Console.WriteLine(hashtag.Name);
        //            }
        //        }

        //        return objdynamic;
        //    }
    }

}
