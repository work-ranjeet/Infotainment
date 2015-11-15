using Infotainment.Areas.Admin.Models;
using Infotainment.Data;
using Infotainment.Data.Controls;
using Infotainment.Data.Entities;
using PCL.DBHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Infotainment.Areas.Admin.Controllers
{
    public class AdvertismentController : Controller
    {
        public async Task<ActionResult> Select()
        {
            return await Task.Run(() =>
            {
                ViewBag.Message = "Insert New Avertisment.";

                var resultList = new List<AdvertismentModal>(); 

                var advertismentList = AdvertismentBL.Instance.SelectAll(AdvertismentType.TopNewsAdd);
                if(advertismentList != null && advertismentList.Count > 0)
                {
                    advertismentList.ForEach(addvertise =>
                   {
                       resultList.Add(new AdvertismentModal
                       {
                           DisplayOrder = addvertise.DisplayOrder,
                           Heading = addvertise.Heading,
                           ShortDesc = addvertise.ShortDesc,
                           WebUrl = addvertise.WebUrl,
                           ImgUrl = addvertise.ImgUrl,
                           IsActive = addvertise.IsActive == 1 ? true : false,
                           IsApproved = addvertise.IsApproved == 1 ? true : false
                       });
                   });
                }

                return View(resultList);
            });
        }

        public async Task<ActionResult> Insert()
        {
            return await Task.Run(() =>
            {
                ViewBag.Message = "Insert New Avertisment.";
                return View(new AdvertismentModal());
            });
        }

        [HttpPost]
        public async Task<ActionResult> Insert(AdvertismentModal advertise)
        {
            var dbHelpre = DBHelper.Instance;
            dbHelpre.BeginTransaction();

            return await Task.Run(() =>
            {
                try
                {
                    bool IsValid = false;
                    ViewBag.Message = "Insert New Avertisment.";

                    if (ModelState.IsValid)
                    {
                        var objAdvertise = new Advertisment();

                        objAdvertise.Heading = advertise.Heading.Trim();
                        objAdvertise.WebUrl =  advertise.WebUrl.Trim();
                        objAdvertise.ShortDesc = advertise.ShortDesc.Trim();
                        objAdvertise.DisplayOrder = advertise.DisplayOrder;
                        objAdvertise.IsActive = advertise.IsActive ? 1 : 0;
                        objAdvertise.IsApproved = advertise.IsApproved ? 1 : 0;
                        objAdvertise.Position = (Int32)Position.PageRight;
                        objAdvertise.AdvertismentType = (Int32)AdvertismentType.TopNewsAdd;

                        var fileName = string.Empty;
                        if (advertise.Image != null && advertise.Image.ContentLength > 0)
                        {
                            fileName = new Random().Next(1000000000).ToString() + Path.GetFileName(advertise.Image.FileName);
                            objAdvertise.ImgUrl = ImagePath.TopTenAdvertisment + "/" + fileName;
                        }

                        AdvertismentDB.Instance.Insert(ref dbHelpre, objAdvertise);

                        if (!string.IsNullOrEmpty(fileName))
                        {
                            IsValid = SaveImage(ImagePath.TopTenAdvertisment, fileName, advertise.Image);
                        }

                        if (!IsValid)
                        {
                            dbHelpre.RollbackTransaction();
                            ModelState.AddModelError("INSERT", "Oops ! There is some error.");
                            ViewBag.Message = "Oops ! There is some error.";
                        }

                        if (IsValid)
                        {
                            dbHelpre.CommitTransaction();
                            ViewBag.Message = "Advertise Successfully Ceated..";
                            ModelState.Clear();
                            advertise = new AdvertismentModal();
                        }
                    }
                    else
                    {
                        //ModelState.AddModelError("INSERT", "Oops ! There is some error.");
                        ViewBag.Message = "Oops ! There is some error.";
                    }
                }
                catch (Exception ex)
                {
                    dbHelpre.RollbackTransaction();
                    throw ex;
                }
                finally
                {
                    dbHelpre.ClearAllParameters();
                    dbHelpre.CloseConnection();
                    dbHelpre.Dispose();
                }

                return View(advertise);
            });

        }

        private bool SaveImage(string dirPath, string fileName, HttpPostedFileBase image)
        {
            bool saveFlag = false;

            if (image == null)
            {
                ModelState.AddModelError("File", "Please Upload Your file");
                ViewBag.Message = "Please Upload Your file";
            }
            else if (image.ContentLength > 0)
            {
                int MaxContentLength = 1024 * 1024 * 10; //Size = 10 MB
                string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png" };
                if (!AllowedFileExtensions.Contains(image.FileName.Substring(image.FileName.LastIndexOf('.'))))
                {
                    ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    ViewBag.Message = "Please file of type: " + string.Join(", ", AllowedFileExtensions);
                }
                else if (image.ContentLength > MaxContentLength)
                {
                    ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    ViewBag.Message = "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB";
                }
                else
                {
                    // var fileName = new Random(1000000000).ToString() + Path.GetFileName(image.FileName);
                    var serverPath = Server.MapPath(dirPath);
                    if (Path.IsPathRooted(serverPath))
                    {
                        //imgUrl = dirPath + "/" + fileName;
                        var path = Path.Combine(serverPath, fileName);
                        image.SaveAs(path);
                        saveFlag = true;
                    }
                }
            }

            return saveFlag;
        }

        private bool DeleteImage(string dirPath, string imgUrl)
        {
            bool flag = false;
            var filenameAray = imgUrl.Split('/');
            var fileName = filenameAray[filenameAray.Length - 1];

            var serverPath = Server.MapPath(dirPath);
            if (Path.IsPathRooted(serverPath))
            {
                var path = Path.Combine(serverPath, fileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }

                flag = true;
            }

            return flag;
        }
    }
}
