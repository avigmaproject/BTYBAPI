using BTYBApi.IRepository.Avigma;
using BTYBApi.Models;
using BTYBApi.Repository.Lib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BTYBApi.Models.Avigma;
using BTYBApi.IRepository;
using BTYBApi.Repository.Avigma;

namespace BTYBApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("AllowAll")]
    public class LoginController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<LoginController> _logger;
        private readonly IUnitOfWork _uof;
        AuthRepository authRepository = new AuthRepository();


        public LoginController(IConfiguration configuration, ILogger<LoginController> logger, IUnitOfWork uof)
        {
            _configuration = configuration;
            _logger = logger;
            _uof = uof;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(RootUserLoginRegistraion input)
        {
            RootUserLogin_input userLogin = new RootUserLogin_input();
            UserLogin userLogin2 = new UserLogin();
            UserLoginResp userLogin1 = new UserLoginResp();
            GetSetUser getSetUser = new GetSetUser(_configuration);

            userLogin.User_Name = input.User_Name;
            userLogin.User_Email = input.User_Email;
            userLogin.User_Password = input.User_Password;
            userLogin.User_Token_val = input.User_Token_Val;
            userLogin.User_Firebase_UID = input.User_Firebase_UID;
            userLogin.User_Gmail_ID = input.User_Gmail_ID;
            userLogin.User_FB_ID = input.User_Gmail_ID;
            userLogin.User_iOS_ID = input.User_Gmail_ID;
            userLogin.Type = input.Type;
            userLogin.User_Login_Type = input.User_Login_Type;

            if (input.User_Password == null || input.User_Password == "")
            {
                userLogin.User_Password = "1234";
            }

            if (userLogin.Type == 2)
            {
                OTPGenerator oTPGenerator = new OTPGenerator();
                userLogin.User_OTP = oTPGenerator.GenerateRandomNo();
            }
        var user = Authenticate(userLogin);

            if (user != null)
            {
                if (user.User_PkeyID == 0 || user.User_PkeyID == -99 || user.User_PkeyID == -90)
                {
                    switch (user.User_PkeyID)
                    {

                        case 0:
                            {
                                userLogin1.UserToken = "The UserCode or password is incorrect.";
                                userLogin1.ErrorCode = "0";
                                return Ok(userLogin1);
                            }
                        case -90:
                            {
                                userLogin1.UserToken = "EmailID / Mobile Number is Not Verified.";
                                userLogin1.ErrorCode = "-90";
                                return Ok(userLogin1);
                            }
                        case -99:
                            {
                                userLogin1.UserToken = "The UserEmail Already Exist.";
                                userLogin1.ErrorCode = "-99";
                                return Ok(userLogin1);
                            }
                    }
                }
                else
                {
                    var token = Generate(user);
                    if (userLogin.Type == 2)
                    {
                        EmailDTO emailDTO = new EmailDTO();
                        EmailTemplate emailTemplate = new EmailTemplate(_configuration);
                        emailDTO.FirstName = userLogin.User_Name;
                        emailDTO.To = userLogin.User_Email;

                        var MasterDetails = Task.Run(() => emailTemplate.VerifiedRegistration(emailDTO, userLogin.User_OTP));

                        //userLogin2.User_PkeyID = user.User_PkeyID;
                        //userLogin2.Device = 1;
                        //userLogin2.Email_Url = _configuration["sendEmailUrl"];
                        //userLogin2.EmailID = userLogin.User_Email;
                        //var MasterDetails = Task.Run(() => getSetUser.GetVerificationLinkOTP(userLogin2));
                    }

                    userLogin1.UserToken = token;
                    userLogin1.ErrorCode = "1";
                    return Ok(userLogin1);

                }

            }
            return NotFound("Please Enter Correct Email and Password !!!");
        }

        private string Generate(UserMaster_DTO user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("ID", user.User_PkeyID.ToString())
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddYears(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserMaster_DTO Authenticate(RootUserLogin_input userLogin)
        {
            List<dynamic> objDynamic = new List<dynamic>();
            int intUSerId = 0;
            //var user = _UserMasterData.Get(userLogin.Username);
            //var currentUser = UserConstant.User.FirstOrDefault(o => o.Username.ToLower() == userLogin.UserCode.ToLower() && o.Password.ToLower() == userLogin.Password.ToLower());
            DataSet ds = _uof.userMaster_Data.Get_UserMasterLogin(userLogin);

            if (ds.Tables.Count > 0)
            {
                var myEnumerableFeaprd = ds.Tables[0].AsEnumerable();
                List<UserMaster_DTO> ViewLogin =
                   (from item in myEnumerableFeaprd
                    select new UserMaster_DTO
                    {
                        User_PkeyID = item.Field<Int64>("User_PkeyID"),
                        //User_Name = item.Field<String>("User_Name"),
                        User_IsVerified = item.Field<Boolean?>("User_IsVerified"),
                    }).ToList();
                objDynamic.Add(ViewLogin);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (!string.IsNullOrEmpty(ds.Tables[0].Rows[i]["User_PkeyID"].ToString()))
                    {
                        intUSerId = Convert.ToInt32(ds.Tables[0].Rows[i]["User_PkeyID"].ToString());
                    }

                }

                //Int64 isValid = authRepository.ValidateUser(rootUser);

                //Int64 isValid = authRepository.ValidateUser(model);

                var result = ViewLogin.FirstOrDefault();
                return result;
            }
            //if (currentUser != null) 
            //{
            //    return currentUser;
            //}
            return null;
        }

    }
}
