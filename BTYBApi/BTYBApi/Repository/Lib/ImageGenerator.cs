using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.IO;
using BTYBApi.Repository.Lib;
using BTYBApi.Models.Avigma;

namespace BTYBApi.Repository.Lib
{
    public class ImageGenerator
    {
        Log log = new Log();

        public List<dynamic> GetImagePath(ImageData model)
        {
            List<dynamic> objdynamicobj = new List<dynamic>();
            try
            {
                model.Image_Path = Base64ToImage(model.Image_Base);
                model.Image_Base = string.Empty;
                objdynamicobj.Add(model);
            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.StackTrace);
                log.logErrorMessage(ex.Message);
            }
            return objdynamicobj;
        }

        public string Base64ToImage(string base64String)
        {
            string imgPath = "";
            string ImagePath = string.Empty;
            string strpath = System.Configuration.ConfigurationManager.AppSettings["UserImagePath"];
            string strDBpath = System.Configuration.ConfigurationManager.AppSettings["UserUploadImageDBPath"];

            try
            {
                if (!string.IsNullOrEmpty(base64String))
                {
                    string imageName = Regex.Match(base64String, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
                    string imageextension = "";

                    //string imageName = ".jpg";

                    //if (imageextension==".jpg"|| imageextension==".bmp"|| imageextension==".jpeg"|| imageextension==".svg" || imageextension == ".png")
                    //{
                    //    imageName = imageextension;
                    //}
                    if (base64String.Split(',')[0].Contains("png"))
                    {
                        imageextension = ".png";
                    }

                    imageextension = ".png";
                    var newfileName = Guid.NewGuid() + imageextension;
                    ImagePath = strDBpath + newfileName;
                    var path = strpath + "\\" + newfileName;
                    //files.SaveAs(path);
                    //set the image path
                    imgPath = Path.Combine(path, newfileName);

                    byte[] imageBytes = Convert.FromBase64String(imageName);

                    File.WriteAllBytes(path, imageBytes);

                }
                return ImagePath;
            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);

                imgPath = ex.Message;
                return ImagePath;
            }


        }


        public string Base64ToImageList(string base64String)
        {
            string imgPath = "";
            string ImagePath = string.Empty;
            string strpath = System.Configuration.ConfigurationManager.AppSettings["UserImagePath"];
            string strDBpath = System.Configuration.ConfigurationManager.AppSettings["UserUploadImageDBPath"];

            try
            {
                if (!string.IsNullOrEmpty(base64String))
                {
                    string imageName = base64String;
                    string imageextension = "";

                    //string imageName = ".jpg";

                    //if (imageextension==".jpg"|| imageextension==".bmp"|| imageextension==".jpeg"|| imageextension==".svg" || imageextension == ".png")
                    //{
                    //    imageName = imageextension;
                    //}
                    if (base64String.Split(',')[0].Contains("png"))
                    {
                        imageextension = ".png";
                    }

                    imageextension = ".png";
                    var newfileName = Guid.NewGuid() + imageextension;
                    ImagePath = strDBpath + newfileName;
                    var path = strpath + "\\" + newfileName;
                    //files.SaveAs(path);
                    //set the image path
                    imgPath = Path.Combine(path, newfileName);

                    byte[] imageBytes = Convert.FromBase64String(imageName);

                    File.WriteAllBytes(path, imageBytes);

                }
                return ImagePath;
            }
            catch (Exception ex)
            {
                log.logErrorMessage(ex.Message);
                log.logErrorMessage(ex.StackTrace);
                imgPath = ex.Message;
                return ImagePath;
            }


        }
    }
}