using BTYBApi.Repository.Lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BTYBApi.Repository.Lib.Security;
using BTYBApi.IRepository.Avigma;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.SqlClient;
using BTYBApi.Models.Avigma;
using BTYBApi.Data;
using System.Security.Claims;
using BTYBApi.Models.Project;
using BTYBApi.IRepository.Project;
using BTYBApi.Repository.Lib.FireBase;
using BTYBApi.Repository.Project;

namespace BTYBApi.Repository.Avigma
{
    public class User_Post_Data : IUser_Post_Data
    {
        Log log = new Log();
        SecurityHelper securityHelper = new SecurityHelper();
        ObjectConvert obj = new ObjectConvert();
        private readonly IConfiguration _configuration;
        public string ConnectionString { get; }
        public User_Post_Data()
        {
        }
        public User_Post_Data(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetConnectionString("Conn_dBcon");
        }


        public IDbConnection Connection
        {
            get { return new SqlConnection(ConnectionString); }
        }


        public List<dynamic> AddUpdateUser_Post_Data(User_Post_DTO model)
        {
            string msg = string.Empty;

            List<dynamic> objData = new List<dynamic>();

            using (IDbConnection con = Connection)
            {
                if (Connection.State == ConnectionState.Closed) con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CreateUpdate_User_Post", (SqlConnection)con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UP_PkeyID", model.UP_PKeyID);
                    cmd.Parameters.AddWithValue("@UP_ImageName", model.UP_ImageName);
                    cmd.Parameters.AddWithValue("@UP_Size", model.UP_Size);
                    cmd.Parameters.AddWithValue("@UP_ImagePath", model.UP_ImagePath);
                    cmd.Parameters.AddWithValue("@UP_IsFirst", model.UP_IsFirst);
                    cmd.Parameters.AddWithValue("@UP_Number", model.UP_Number);
                    cmd.Parameters.AddWithValue("@UP_UserID", model.UP_UserID);
                    cmd.Parameters.AddWithValue("@UP_Web_URL", model.UP_Web_URL);
                    cmd.Parameters.AddWithValue("@UP_Coll_Desc", model.UP_Coll_Desc);
                    cmd.Parameters.AddWithValue("@UP_IsAdmin", model.UP_IsAdmin);
                    cmd.Parameters.AddWithValue("@UP_Location", model.UP_Location);

                    cmd.Parameters.AddWithValue("@UP_latitude", model.UP_latitude);
                    cmd.Parameters.AddWithValue("@UP_longitude", model.UP_longitude);
                    cmd.Parameters.AddWithValue("@UP_Doc_Type", model.UP_Doc_Type);
                    cmd.Parameters.AddWithValue("@UP_Title", model.UP_Title);
                    cmd.Parameters.AddWithValue("@UP_Tags", model.UP_Tags);
                    cmd.Parameters.AddWithValue("@UP_Price", model.UP_Price);
                    cmd.Parameters.AddWithValue("@UP_Promo_Code", model.UP_Promo_Code);
                    cmd.Parameters.AddWithValue("@UP_Shop_Now", model.UP_Shop_Now);
                    cmd.Parameters.AddWithValue("@UP_Poster_Img_Name", model.UP_Poster_Img_Name);
                    cmd.Parameters.AddWithValue("@UP_Poster_Img_Path", model.UP_Poster_Img_Path);
                    cmd.Parameters.AddWithValue("@UP_Duration", model.UP_Duration);
                    cmd.Parameters.AddWithValue("@UP_ProductData", model.UP_ProductData1);
                    cmd.Parameters.AddWithValue("@UP_Address", model.UP_Address);

                    cmd.Parameters.AddWithValue("@UP_No_IP", model.UP_No_IP);
                    cmd.Parameters.AddWithValue("@UP_No_Stripe_ProductID", model.UP_No_Stripe_ProductID);
                    cmd.Parameters.AddWithValue("@UP_No_Stripe_PriceID", model.UP_No_Stripe_PriceID);
                    cmd.Parameters.AddWithValue("@UP_No_Stripe_UserID", model.UP_No_Stripe_UserID);
                    cmd.Parameters.AddWithValue("@UP_Net_Amount", model.UP_Net_Amount);
                    cmd.Parameters.AddWithValue("@UP_Payment_Status", model.UP_Payment_Status);

                    cmd.Parameters.AddWithValue("@UP_IsActive", model.UP_IsActive);
                    cmd.Parameters.AddWithValue("@UP_IsDelete", model.UP_IsDelete);
                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);
                    //cmd.Parameters.AddWithValue("@UP_PkeyID_Out", 0).Direction = ParameterDirection.Output;
                    //cmd.Parameters.AddWithValue("@ReturnValue", 0).Direction = ParameterDirection.Output;

                    SqlParameter UP_PkeyID_Out = cmd.Parameters.AddWithValue("@UP_PkeyID_Out", 0);
                    UP_PkeyID_Out.Direction = ParameterDirection.Output;
                    SqlParameter ReturnValue = cmd.Parameters.AddWithValue("@ReturnValue", 0);
                    ReturnValue.Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();
                    objData.Add(UP_PkeyID_Out.Value);
                    objData.Add(ReturnValue.Value);

                }
                catch (Exception ex)
                {
                    log.logErrorMessage(ex.StackTrace);
                    log.logErrorMessage(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return objData;
        }

        public List<dynamic> AddUpdateUser_Post_Like_Share_Data(User_Post_Like_Share_DTO model)
        {
            string msg = string.Empty;

            List<dynamic> objData = new List<dynamic>();

            using (IDbConnection con = Connection)
            {
                if (Connection.State == ConnectionState.Closed) con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CreateUpdate_Like_Shared_Count", (SqlConnection)con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UP_PkeyID", model.UP_PkeyID);

                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);
                    //cmd.Parameters.AddWithValue("@UP_PkeyID_Out", 0).Direction = ParameterDirection.Output;
                    //cmd.Parameters.AddWithValue("@ReturnValue", 0).Direction = ParameterDirection.Output;

                    SqlParameter UP_PkeyID_Out = cmd.Parameters.AddWithValue("@UP_PkeyID_Out", 0);
                    UP_PkeyID_Out.Direction = ParameterDirection.Output;
                    SqlParameter ReturnValue = cmd.Parameters.AddWithValue("@ReturnValue", 0);
                    ReturnValue.Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();
                    objData.Add(UP_PkeyID_Out.Value);
                    objData.Add(ReturnValue.Value);

                }
                catch (Exception ex)
                {
                    log.logErrorMessage(ex.StackTrace);
                    log.logErrorMessage(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return objData;
        }

        public List<dynamic> AddUpdateProduct_Shop_Purchase_Count_Data(Product_Shop_Purchase_DTO model)
        {
            string msg = string.Empty;

            List<dynamic> objData = new List<dynamic>();

            using (IDbConnection con = Connection)
            {
                if (Connection.State == ConnectionState.Closed) con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("CreateUpdate_Shop_Purchase_Count", (SqlConnection)con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Pro_PKeyID", model.Pro_PKeyID);

                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@UserID", model.UserID);
                    //cmd.Parameters.AddWithValue("@UP_PkeyID_Out", 0).Direction = ParameterDirection.Output;
                    //cmd.Parameters.AddWithValue("@ReturnValue", 0).Direction = ParameterDirection.Output;

                    SqlParameter Pro_PkeyID_Out = cmd.Parameters.AddWithValue("@Pro_PkeyID_Out", 0);
                    Pro_PkeyID_Out.Direction = ParameterDirection.Output;
                    SqlParameter ReturnValue = cmd.Parameters.AddWithValue("@ReturnValue", 0);
                    ReturnValue.Direction = ParameterDirection.Output;


                    cmd.ExecuteNonQuery();
                    objData.Add(Pro_PkeyID_Out.Value);
                    objData.Add(ReturnValue.Value);

                }
                catch (Exception ex)
                {
                    log.logErrorMessage(ex.StackTrace);
                    log.logErrorMessage(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
            return objData;
        }
        private DataSet Get_UserMaster(User_Post_DTO_Input model)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Get_User_Post", (SqlConnection)Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UP_PkeyID", model.UP_PkeyID);
                cmd.Parameters.AddWithValue("@UP_UserID", model.UP_UserID);
                cmd.Parameters.AddWithValue("@Type", model.Type);
                cmd.Parameters.AddWithValue("@UserID", model.UserID);

                cmd.Parameters.AddWithValue("@WhereClause", model.WhereClause);
                cmd.Parameters.AddWithValue("@PageNumber", model.PageNumber);
                cmd.Parameters.AddWithValue("@NoofRows", model.NoofRows);
                cmd.Parameters.AddWithValue("@Orderby", model.Orderby);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
            }
            return ds;

        }

        private DataSet Get_UserSearchMaster(User_Post_Search_DTO model)
        {
            DataSet ds = new DataSet();
            try
            {
                //SqlCommand cmd = new SqlCommand("Get_Search_Item", (SqlConnection)Connection);
                SqlCommand cmd = new SqlCommand("Get_Search_Item_Bac_26-07-23_II", (SqlConnection)Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Search_Data", model.Search_Data);
                cmd.Parameters.AddWithValue("@Type", model.Type);
                cmd.Parameters.AddWithValue("@UserID", model.UserID);

                cmd.Parameters.AddWithValue("@Distance", model.Distance);
                cmd.Parameters.AddWithValue("@UP_longitude", model.UP_longitude);
                cmd.Parameters.AddWithValue("@UP_latitude", model.UP_latitude);
                cmd.Parameters.AddWithValue("@WhereClause", model.WhereClause);
                cmd.Parameters.AddWithValue("@PageNumber", model.PageNumber);
                cmd.Parameters.AddWithValue("@NoofRows", model.NoofRows);
                cmd.Parameters.AddWithValue("@Orderby", model.Orderby);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
            }
            return ds;

        }


        public List<dynamic> Get_User_PostDetailsDTO(User_Post_DTO_Input model)
        {
            List<dynamic> objDynamic = new List<dynamic>(); try
            {


                DataSet ds = Get_UserMaster(model);

                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables.Count; i++)
                    {
                        objDynamic.Add(obj.AsDynamicEnumerable(ds.Tables[i]));
                    }

                }

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.StackTrace);
                log.logErrorMessage(ex.Message);
            }

            return objDynamic;
        }

        public List<dynamic> Get_User_Post_SearchDetailsDTO(User_Post_Search_DTO model)
        {
            string wherecondition = string.Empty;
            string orderBy = string.Empty;
             User_Post_DTO user_Post_DTO = new User_Post_DTO();

            if (!string.IsNullOrEmpty(model.User_Name))
            {
                wherecondition = wherecondition != null ? wherecondition + " And  umu.[User_Name] like '%"+model.User_Name+"%'" : " And  umu.[User_Name] like '%" + model.User_Name + "%'";
            }

            if (!string.IsNullOrEmpty(model.UP_Tags))
            {
                wherecondition = wherecondition != null ? wherecondition + " And  uptm.[UPTM_Name] like '%" + model.UP_Tags + "%'" : " And  uptm.[UPTM_Name] like '%" + model.UP_Tags + "%'";
            }

            if (model.Time_Period_Week != null)
            {
                wherecondition = "  And cast(up.UP_CreatedOn as date)<= CONVERT(date,'" + model.Time_Period_Week.Value.ToString("yyyy-MM-dd") + "') And CAST(up.UP_CreatedOn as date) >= cast(DATEADD(DAY,-7    ,GETDATE()) as date)";
            }

            if (model.Time_Period_Month != null)
            {
                wherecondition = "  And cast(up.UP_CreatedOn as date)<= CONVERT(date,'" + model.Time_Period_Month.Value.ToString("yyyy-MM-dd") + "') And CAST(up.UP_CreatedOn as date) >= cast(DATEADD(DAY,-30,GETDATE()) as date)";
            }

            //if (model.Time_Period_Week != false)
            //{
            //    wherecondition = "  And cast(up.UP_CreatedOn as date)<= cast(DATEADD(DAY,0,GETDATE()) as date) And CAST(up.UP_CreatedOn as date) >= cast(DATEADD(DAY,-7    ,GETDATE()) as date)";
            //}
            //if (model.Time_Period_Month != false)
            //{
            //    wherecondition = "  And cast(up.UP_CreatedOn as date)<= cast(DATEADD(DAY,0,GETDATE()) as date) And CAST(up.UP_CreatedOn as date) >= cast(DATEADD(DAY,-30,GETDATE()) as date)";
            //}

            if (model.Start_Date != null && model.End_Date != null)
            {
                wherecondition = "  And CAST(up.UP_CreatedOn as date) >=   CONVERT(date,'" + model.Start_Date.Value.ToString("yyyy-MM-dd") + "')  And CAST(up.UP_CreatedOn as date) <=   CONVERT(date,'" + model.End_Date.Value.ToString("yyyy-MM-dd") + "')";
            }

            model.WhereClause = wherecondition;

            if (model.MostShared == true)
            {
                orderBy = orderBy != null ? orderBy + " UP_Shared_Count" : " UP_PkeyID";
            }
            else if (model.MostLiked == true)
            {
                orderBy = orderBy != null ? orderBy + " UP_Like_Count" : " distance";
            }
            else if (model.MostShop == true)
            {
                orderBy = orderBy != null ? orderBy + " UP_Shop_Count" : " distance";
            }
            else if (model.MostPurchased == true)
            {
                orderBy = orderBy != null ? orderBy + " UP_Purchased_Count" : " distance";
            }
            else if(model.Type == 1)
            {
                orderBy = orderBy != null ? orderBy + " up.UP_PkeyID" : " UP_Shared_Count";
            }
            else
            {
                orderBy = orderBy != null ? orderBy + " y.UP_PkeyID" : " UP_Shared_Count";
            }

            model.Orderby = orderBy;

            List<dynamic> objDynamic = new List<dynamic>(); try
            {
                DataSet ds = Get_UserSearchMaster(model);

                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables.Count; i++)
                    {
                        objDynamic.Add(obj.AsDynamicEnumerable(ds.Tables[i]));
                    }

                }

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.StackTrace);
                log.logErrorMessage(ex.Message);
            }

            return objDynamic;
        }

        public string SendNotification(User_Notification_DTO user_Notification_DTO)
        {
            var result = "-1";
            string message = string.Empty, msgtitle = string.Empty, UserToken = string.Empty, Username = string.Empty, User_Name_Post = string.Empty;
            Int64? User_PkeyID = 0, UP_UserID = 0, UPC_User_PkeyID = 0;
            NotificationGetData notificationGet = new NotificationGetData(_configuration);
            User_Notification_Data user_Notification_Data = new User_Notification_Data(_configuration);
            //User_Post_DTO user_Post_DTO = new User_Post_DTO();
            User_Post_Notification_DTO user_Post_DTO = new User_Post_Notification_DTO();
            try
            {
                #region comment
                //if (user_Notification_DTO.NT_UP_PKeyID != null)
                //{
                //    user_Post_DTO.UP_PKeyID = Convert.ToInt64(user_Notification_DTO.NT_UP_PKeyID);
                //    user_Post_DTO.Type = 1;
                //    user_Post_DTO.UL_PKeyID = user_Notification_DTO.NT_UL_PKeyID;
                //}

                //else if (user_Notification_DTO.NT_US_PKeyID != null)
                //{
                //    user_Post_DTO.US_PKeyID = Convert.ToInt64(user_Notification_DTO.NT_US_PKeyID);
                //    user_Post_DTO.Type = 2;
                //    user_Post_DTO.UPC_PkeyID = user_Notification_DTO.NT_UPC_PkeyID;
                //}
                //else if (user_Notification_DTO.NT_SP_PKeyID != null)
                //{
                //    user_Post_DTO.SUB_PKeyID = Convert.ToInt64(user_Notification_DTO.NT_SP_PKeyID);
                //    user_Post_DTO.Type =3;
                //}
                //else if (user_Notification_DTO.NT_FLL_PKeyID != null)
                //{
                //    user_Post_DTO.FLL_PKeyID = Convert.ToInt64(user_Notification_DTO.NT_FLL_PKeyID);
                //    user_Post_DTO.Type = 4;
                //}
                #endregion

                switch (user_Notification_DTO.NT_C_L)
                {
                    case 1:
                        {

                            user_Post_DTO.UPC_PkeyID = user_Notification_DTO.NT_UPC_PkeyID;
                            user_Post_DTO.UP_PKeyID = user_Notification_DTO.NT_UP_PKeyID;
                            user_Post_DTO.Type = 1;
                            user_Post_DTO.UserID = user_Notification_DTO.UserID;
                            break;
                        }
                    case 2:
                        {
                            user_Post_DTO.UP_PKeyID = user_Notification_DTO.NT_UP_PKeyID;
                            user_Post_DTO.UL_PKeyID = user_Notification_DTO.NT_UL_PKeyID;
                            user_Post_DTO.Type = 1;
                            user_Post_DTO.UserID = user_Notification_DTO.UserID;
                            break;

                        }
                    case 3:
                        {

                            user_Post_DTO.UPC_PkeyID = user_Notification_DTO.NT_UPC_PkeyID;
                            user_Post_DTO.UPR_PkeyID = user_Notification_DTO.NT_UPR_PkeyID;
                            user_Post_DTO.Type = 2;
                            user_Post_DTO.UserID = user_Notification_DTO.UserID;
                            break;
                        }
                        //case 4:
                        //    {
                        //        user_Post_DTO.FLL_PKeyID = Convert.ToInt64(user_Notification_DTO.NT_FLL_PKeyID);
                        //        user_Post_DTO.Type = 4;
                        //        break;
                        //    }
                        //case 5:
                        //    {
                        //        user_Post_DTO.User_Creator_PkeyID = Convert.ToInt64(user_Notification_DTO.NT_Creator_PKeyID);
                        //        user_Post_DTO.Type = 4;
                        //        break;
                        //    }
                        //case 7:
                        //    {
                        //        user_Post_DTO.SUB_PKeyID = Convert.ToInt64(user_Notification_DTO.NT_SP_PKeyID);
                        //        user_Post_DTO.Type = 7;
                        //        break;
                        //    }
                        //case 9:
                        //    {
                        //        user_Post_DTO.TP_PKeyID = Convert.ToInt64(user_Notification_DTO.NT_TP_PKeyID);
                        //        user_Post_DTO.Type = 9;
                        //        break;
                        //    }
                        //case 10:
                        //    {
                        //        user_Post_DTO.UCD_User_PkeyID = Convert.ToInt64(user_Notification_DTO.NT_UCD_User_PkeyID);
                        //        user_Post_DTO.Type = 10;
                        //        break;
                        //    }
                        //case 11:
                        //    {
                        //        user_Post_DTO.UPG_PkeyID = Convert.ToInt64(user_Notification_DTO.NT_UPG_PkeyID);
                        //        user_Post_DTO.Type = 11;
                        //        break;
                        //    }
                        //case 12:
                        //    {

                        //        user_Post_DTO.UPG_PkeyID = Convert.ToInt64(user_Notification_DTO.NT_UPG_PkeyID);
                        //        user_Post_DTO.Type = 12;
                        //        break;
                        //    }
                }

                user_Notification_DTO.NT_IsActive = true;
                //DataSet ds = Get_UserDetailsByPost_Story(user_Post_DTO);
                DataSet ds = Get_User_Notification_DetailsByPost_Story(user_Post_DTO);

                if (ds.Tables.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        UserToken = ds.Tables[0].Rows[i]["User_Token_val"].ToString();
                        Username = ds.Tables[0].Rows[i]["User_Name"].ToString();
                        if (!string.IsNullOrWhiteSpace(ds.Tables[0].Rows[i]["User_PkeyID"].ToString()))
                        {
                            User_PkeyID = Convert.ToInt64(ds.Tables[0].Rows[i]["User_PkeyID"].ToString());

                        }

                        if (!string.IsNullOrWhiteSpace(UserToken))
                        {
                            switch (user_Notification_DTO.NT_C_L)
                            {
                                case 1:
                                    {
                                        if (!string.IsNullOrWhiteSpace(ds.Tables[0].Rows[i]["UP_UserID"].ToString()))
                                        {
                                            UP_UserID = Convert.ToInt64(ds.Tables[0].Rows[i]["UP_UserID"].ToString());
                                            user_Notification_DTO.NT_UserID = UP_UserID;
                                        }
                                        User_Name_Post = ds.Tables[0].Rows[i]["User_Name_Post"].ToString();
                                        //message = "Notification Received for Comments "+ User_Name_Post;
                                        //msgtitle = "New Notification Received for Comments  " + User_Name_Post;
                                        message = User_Name_Post + " commented on your post";
                                        msgtitle = User_Name_Post + " commented on your post";
                                        user_Notification_DTO.NT_Description = message;
                                        user_Notification_DTO.NT_Name = msgtitle;
                                        user_Notification_DTO.Type = 1;
                                        break;
                                    }
                                case 2:
                                    {
                                        if (!string.IsNullOrWhiteSpace(ds.Tables[0].Rows[i]["UP_UserID"].ToString()))
                                        {
                                            UP_UserID = Convert.ToInt64(ds.Tables[0].Rows[i]["UP_UserID"].ToString());
                                            user_Notification_DTO.NT_UserID = UP_UserID;
                                        }
                                        User_Name_Post = ds.Tables[0].Rows[i]["User_Name_Post"].ToString();
                                        //message = "Notification Received for Like  "+ User_Name_Post;
                                        //msgtitle = "New Notification Received for Like " + User_Name_Post ;

                                        message = User_Name_Post + " liked your post";
                                        msgtitle = User_Name_Post + " liked your post";
                                        user_Notification_DTO.NT_Description = message;
                                        user_Notification_DTO.NT_Name = msgtitle;
                                        user_Notification_DTO.Type = 1;
                                        break;
                                    }
                                case 3:
                                    {
                                        if (!string.IsNullOrWhiteSpace(ds.Tables[0].Rows[i]["UPC_User_PkeyID"].ToString()))
                                        {
                                            UPC_User_PkeyID = Convert.ToInt64(ds.Tables[0].Rows[i]["UPC_User_PkeyID"].ToString());
                                            user_Notification_DTO.NT_UserID = UPC_User_PkeyID;
                                        }
                                        User_Name_Post = ds.Tables[0].Rows[i]["User_Name_Post"].ToString();
                                        //message = "Notification Received for Comments "+ User_Name_Post;
                                        //msgtitle = "New Notification Received for Comments  " + User_Name_Post;
                                        message = User_Name_Post + " Review on your Comment";
                                        msgtitle = User_Name_Post + " Review on your Comment";
                                        user_Notification_DTO.NT_Description = message;
                                        user_Notification_DTO.NT_Name = msgtitle;
                                        user_Notification_DTO.Type = 1;
                                        break;

                                    }
                                case 8:
                                case 4:
                                    {
                                        user_Notification_DTO.NT_UserID = User_PkeyID;



                                        if (user_Notification_DTO.NT_C_L == 4)
                                        {
                                            message = "Notification Received Follower Request  from " + Username;
                                            msgtitle = "Notification Received Follower Request from " + Username;
                                        }
                                        else if (user_Notification_DTO.NT_C_L == 8)
                                        {
                                            message = Username + "  subscribed to your profile";
                                            msgtitle = Username + "  subscribed to your profile";
                                        }
                                        user_Notification_DTO.NT_Description = message;
                                        user_Notification_DTO.NT_Name = msgtitle;
                                        user_Notification_DTO.Type = 1;
                                        break;
                                    }
                                case 5:
                                    {
                                        user_Notification_DTO.NT_UserID = User_PkeyID;
                                        if (user_Notification_DTO.User_Creator_IsVerfied == true)
                                        {
                                            message = "Creator Request Approved from Admin";
                                            msgtitle = "Creator Request Approved from Admin";
                                        }
                                        else
                                        {
                                            message = "Creator Request Rejected from Admin";
                                            msgtitle = "Creator Request Rejected from Admin";
                                        }

                                        user_Notification_DTO.NT_Description = message;
                                        user_Notification_DTO.NT_Name = msgtitle;
                                        user_Notification_DTO.Type = 1;
                                        break;
                                    }
                                case 6: // Live Streaming 
                                    {
                                        break;
                                    }
                                case 7: // Sponsor Accept Reject 
                                    {
                                        //message = "Notification Received for Sponsor ";
                                        //msgtitle = "New Notification Received Sponsor";
                                        user_Notification_DTO.NT_UserID = User_PkeyID;
                                        string Name = string.Empty, Description = string.Empty, Amount = string.Empty, From_otherUsername = string.Empty, Accept_Reject = string.Empty;
                                        Name = ds.Tables[0].Rows[i]["SP_Name"].ToString();
                                        Description = ds.Tables[0].Rows[i]["SP_Description"].ToString();
                                        From_otherUsername = ds.Tables[0].Rows[i]["From_otherUsername"].ToString();
                                        string User_MotiID = ds.Tables[0].Rows[i]["User_MotiID"].ToString();
                                        Amount = ds.Tables[0].Rows[i]["SP_Amount"].ToString();
                                        if (ds.Tables[0].Rows[i]["SP_IsAccept_Reject"].ToString() == "1")
                                        {
                                            Accept_Reject = "  accepted ";
                                        }
                                        else if (ds.Tables[0].Rows[i]["SP_IsAccept_Reject"].ToString() == "2")
                                        {
                                            Accept_Reject = "  declined ";
                                        }
                                        //  message = " Sponsor Request   " + Accept_Reject + " " + From_otherUsername + " " + Name + " " + Description + "For " + Amount;
                                        //    msgtitle = "New Notification Received  Sponsor Request " + Accept_Reject + " " + From_otherUsername + "For " + Name + " " + Amount;

                                        message = User_MotiID + " " + Accept_Reject + "  your sponsorship request";
                                        msgtitle = User_MotiID + " " + Accept_Reject + " your sponsorship request";

                                        user_Notification_DTO.NT_Description = message;
                                        user_Notification_DTO.NT_Name = msgtitle;
                                        user_Notification_DTO.Type = 1;
                                        break;
                                    }
                                case 9: //  Tips
                                    {
                                        user_Notification_DTO.NT_UserID = User_PkeyID;
                                        string UserTipName = ds.Tables[0].Rows[i]["User_TipName"].ToString();
                                        message = UserTipName + " sent you a tip";
                                        msgtitle = UserTipName + " sent you a tip";

                                        user_Notification_DTO.NT_Description = message;
                                        user_Notification_DTO.NT_Name = msgtitle;
                                        user_Notification_DTO.Type = 1;
                                        break;
                                    }
                                case 10: //  purchase on demand
                                    {
                                        user_Notification_DTO.NT_UserID = User_PkeyID;
                                        string userPur = ds.Tables[0].Rows[i]["user_Pur"].ToString();
                                        string Title = ds.Tables[0].Rows[i]["UOD_Title"].ToString();
                                        message = userPur + " purchased On-Demand content " + Title;
                                        msgtitle = userPur + " purchased On-Demand content " + Title;

                                        user_Notification_DTO.NT_Description = message;
                                        user_Notification_DTO.NT_Name = msgtitle;
                                        user_Notification_DTO.Type = 1;
                                        break;
                                    }
                                case 11: //  Subscribe 
                                    {
                                        user_Notification_DTO.NT_UserID = User_PkeyID;
                                        string User_MotiID = ds.Tables[0].Rows[i]["User_MotiID"].ToString();

                                        message = User_MotiID + " subscribed to your profile";
                                        msgtitle = User_MotiID + " subscribed to your profile";

                                        user_Notification_DTO.NT_Description = message;
                                        user_Notification_DTO.NT_Name = msgtitle;
                                        user_Notification_DTO.Type = 1;
                                        break;
                                    }
                                case 12: //   Sponspor
                                    {

                                        user_Notification_DTO.NT_UserID = User_PkeyID;
                                        string User_MotiID = ds.Tables[0].Rows[i]["User_MotiID"].ToString();
                                        message = User_MotiID + " has paid the sponsorship request";
                                        msgtitle = User_MotiID + " has paid the sponsorship request";
                                        user_Notification_DTO.Type = 1;
                                        user_Notification_DTO.NT_Description = message;
                                        user_Notification_DTO.NT_Name = msgtitle;
                                        break;
                                    }
                            }
                            notificationGet.SendNotification(UserToken, message, msgtitle, "1");


                            user_Notification_Data.CreateUpdate_User_NotificationDetails(user_Notification_DTO);

                        }
                        else
                        {
                            log.logInfoMessage("No UserToken Found " + User_PkeyID);
                            user_Notification_DTO.Type = 1;
                            user_Notification_DTO.NT_UserID = User_PkeyID;
                            user_Notification_Data.CreateUpdate_User_NotificationDetails(user_Notification_DTO);
                        }

                    }
                }
                else
                {
                    log.logErrorMessage("No Taable Data Found in Notification");
                }

            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
            }

            return result;


        }

        public DataSet Get_UserDetailsByPost_Story(User_Post_DTO model)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Get_UserDetailsByPost_Story", (SqlConnection)Connection);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@UP_PKeyID", model.UP_PKeyID);
                cmd.Parameters.AddWithValue("@US_PKeyID", model.US_PKeyID);
                cmd.Parameters.AddWithValue("@UL_PKeyID", model.UL_PKeyID);
                cmd.Parameters.AddWithValue("@UPC_PkeyID", model.UPC_PkeyID);
                //cmd.Parameters.AddWithValue("@User_Creator_PkeyID", model.User_Creator_PkeyID);
                cmd.Parameters.AddWithValue("@SUB_PKeyID", model.SUB_PKeyID);
                cmd.Parameters.AddWithValue("@FLL_PKeyID", model.FLL_PKeyID);
                //cmd.Parameters.AddWithValue("@TP_PKeyID", model.TP_PKeyID);
                //cmd.Parameters.AddWithValue("@UCD_User_PkeyID", model.UCD_User_PkeyID);
                cmd.Parameters.AddWithValue("@UPG_PkeyID", model.UPG_PkeyID);
                cmd.Parameters.AddWithValue("@UserID", model.UP_UserID);
                cmd.Parameters.AddWithValue("@WhereClause", model.WhereClause);
                cmd.Parameters.AddWithValue("@PageNumber", model.PageNumber);
                cmd.Parameters.AddWithValue("@NoofRows", model.NoofRows);
                cmd.Parameters.AddWithValue("@Orderby", model.Orderby);
                cmd.Parameters.AddWithValue("@Type", model.Type);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }

            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
            }



            return ds;
        }


        public DataSet Get_User_Notification_DetailsByPost_Story(User_Post_Notification_DTO model)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("Get_Notification_Data", (SqlConnection)Connection);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@UP_PKeyID", model.UP_PKeyID);
                cmd.Parameters.AddWithValue("@UL_PKeyID", model.UL_PKeyID);
                cmd.Parameters.AddWithValue("@UPC_PKeyID", model.UPC_PkeyID);
                cmd.Parameters.AddWithValue("@UserID", model.UserID);
                cmd.Parameters.AddWithValue("@WhereClause", model.WhereClause);
                cmd.Parameters.AddWithValue("@PageNumber", model.PageNumber);
                cmd.Parameters.AddWithValue("@NoofRows", model.NoofRows);
                cmd.Parameters.AddWithValue("@Orderby", model.Orderby);
                cmd.Parameters.AddWithValue("@Type", model.Type);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }

            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
            }



            return ds;
        }


    }
}