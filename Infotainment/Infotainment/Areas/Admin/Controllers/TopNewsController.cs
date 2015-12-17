using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Infotainment.Areas.Admin.Models;
using Infotainment.Data.Controls;
using Infotainment.Data;
using PCL.DBHelper;
using Infotainment.Filter;
using Infotainment.Data.Entities;

namespace Infotainment.Areas.Admin.Controllers
{
    [Autherisation]
    public class TopNewsController : Controller
    {
        [Approve]
        [HttpGet]
        public async Task<ActionResult> NeedApproval()
        {
            return await Task.Run(() =>
            {
                var list = new NewsApprovalList();
                list.Message = "Select news and click on submit to approve.";

                list.ApprovalList = new List<NewsApproval>();

                var topNewsBL = new TopNewsBL();
                var result = topNewsBL.SelectTopNewsForApproval();
                result.ToList().ForEach(v =>
                {
                    list.ApprovalList.Add(
                        new NewsApproval
                        {
                            Selected = false,
                            TopNewsID = v.TopNewsID,
                            ImageUrl = v.ImageUrl,
                            IsApproved = v.IsApproved,
                            Heading = v.Heading,
                            DttmCreated = v.DttmCreated
                        });
                });

                return View(list);
            });
        }

        [Approve]
        [HttpPost]
        public ActionResult NeedApproval(NewsApprovalList selectedNewsList)
        {
            var activeList = new NewsApprovalList();
            activeList.ApprovalList = new List<NewsApproval>();
            var selectedItem = selectedNewsList.ApprovalList.Where(t => t.Selected);
            int selectedItemCount = selectedItem.Count();

            if (selectedItemCount > 0)
            {
                var list = new List<ITopNews>();
                selectedItem.ToList().ForEach(item => list.Add(new TopNews
                {
                    TopNewsID = item.TopNewsID,
                    IsApproved = item.Selected ? 1 : 0
                }));

                var user = (IUsers)this.Session[Constants.UserSessionKey];
                TopNewsBL.Instance.GiveApprovalFor(list, user);

                activeList.ApprovalList.Clear();
                TopNewsBL.Instance.SelectTopNewsForApproval().ToList().ForEach(v =>
                {
                    activeList.ApprovalList.Add(
                        new NewsApproval
                        {
                            Selected = false,
                            TopNewsID = v.TopNewsID,
                            IsApproved = v.IsApproved,
                            Heading = v.Heading,
                            DttmCreated = v.DttmCreated
                        });
                });

                ModelState.Clear();
                activeList.Message = selectedItemCount.ToString() + " news has been approves successfuly.";
            }
            else
            {
                activeList.Message = "Please select atleast one news to approve!";
            }

            return View(activeList);
        }

        [Active]
        [HttpGet]
        public async Task<ActionResult> MakeActive()
        {
            return await Task.Run(() =>
            {
                var list = new NewsActivationlList();
                list.Message = "Select news and click on submit to make active.";

                list.ActivationlList = new List<NewsActivation>();

                var topNewsBL = new TopNewsBL();
                var result = topNewsBL.SelectTopNewsForActivate();
                result.ToList().ForEach(v =>
                {
                    list.ActivationlList.Add(
                        new NewsActivation
                        {
                            Selected = false,
                            TopNewsID = v.TopNewsID,
                            ImageUrl = v.ImageUrl,
                            IsActive = v.IsActive,
                            Heading = v.Heading,
                            DttmCreated = v.DttmCreated
                        });
                });

                return View(list);
            });
        }

        [Active]
        [HttpPost]
        public ActionResult MakeActive(NewsActivationlList selectedNewsList)
        {
            var activeList = new NewsActivationlList();
            activeList.ActivationlList = new List<NewsActivation>();
            var selectedItem = selectedNewsList.ActivationlList.Where(t => t.Selected);
            int selectedItemCount = selectedItem.Count();

            if (selectedItemCount > 0)
            {
                var list = new List<ITopNews>();
                selectedItem.ToList().ForEach(item => list.Add(new TopNews()
                {
                    TopNewsID = item.TopNewsID,
                    IsActive = item.Selected ? 1 : 0
                }));

                var user = (IUsers)this.Session[Constants.UserSessionKey];
                TopNewsBL.Instance.MakeActiveFor(list, user);

                activeList.ActivationlList.Clear();

                TopNewsBL.Instance.SelectTopNewsForActivate().ToList().ForEach(v =>
                {
                    activeList.ActivationlList.Add(
                        new NewsActivation
                        {
                            Selected = false,
                            TopNewsID = v.TopNewsID,
                            IsActive = v.IsActive,
                            Heading = v.Heading,
                            DttmCreated = v.DttmCreated
                        });
                });
                ModelState.Clear();
                activeList.Message = selectedItemCount.ToString() + " news has been activeted.";
            }
            else
            {
                activeList.Message = "Please select atleast one news to approve!";
            }

            return View(activeList);
        }

        [HttpGet]
        public async Task<ActionResult> NewsList()
        {
            return await Task.Run(() =>
            {
                var topNewsBL = new TopNewsBL();
                var result = topNewsBL.SelectAll(DateTime.Now.AddDays(-1), DateTime.Now, string.Empty);
                return View(result);
            });
        }

        [Insert]
        [HttpGet]
        public async Task<ActionResult> InsertNews()
        {
            return await Task.Run(() =>
            {
                ViewBag.Message = "Inser new news.";
                return View(new CreateNews());
            });
        }

        [Insert]
        [HttpPost]
        public async Task<ActionResult> InsertNews(CreateNews newForInsert)
        {           
            return await Task.Run(() =>
            {
                var dbHelpre = DBHelper.Instance;
                var BLInstance = TopNewsBL.Instance;
                dbHelpre.BeginTransaction();
                try
                {
                    if (ModelState.IsValid)
                    {
                        var news = new TopNews
                        {
                            Heading = newForInsert.Heading.Trim(),
                            ShortDescription = newForInsert.ShortDesc.Trim(),
                            NewsDescription = string.IsNullOrEmpty(newForInsert.Description) ? string.Empty : newForInsert.Description.Trim(),
                            IsActive = 0,
                            IsApproved = 0
                        };

                        var image = new ImageDetail
                        {
                            ImageType = (int)ImageType.TopNewsImage,
                            ImageUrl = " ",
                            Caption = newForInsert.ImageCaption,
                            CaptionLink = newForInsert.CaptionLink,
                            IsActive = 0,
                            IsFirst = 0
                        };

                        var fileName = string.Empty;
                        if (newForInsert.Image != null && newForInsert.Image.ContentLength > 0)
                        {
                            fileName = new Random().Next(1000000000).ToString() + Path.GetFileName(newForInsert.Image.FileName);
                            image.ImageUrl = ImagePath.TopTenNewsImage + "/" + fileName;
                            image.IsActive = 1;
                            image.IsFirst = 1;
                        }

                        string dirPath = ImagePath.TopTenNewsImage;
                        var user = (IUsers)this.Session[Constants.UserSessionKey];
                        BLInstance.Insert(ref dbHelpre, news, image, user);

                        if (SaveImage(ImagePath.TopTenNewsImage, fileName, newForInsert.Image))
                        {
                            newForInsert = new CreateNews();
                            ViewBag.Message = "Successfully Inserter.";
                            ModelState.Clear();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("INSERT", "Oops ! There is some error.");
                        ViewBag.Message = "Oops ! There is some error.";
                    }

                    dbHelpre.CommitTransaction();
                    return View(newForInsert);
                }
                catch (Exception ex)
                {
                    dbHelpre.RollbackTransaction();
                    throw ex;
                }
                finally
                {
                    dbHelpre.Dispose();
                    BLInstance.Dispose();
                }
            });
        }

        [Update]
        [HttpGet]
        public async Task<ActionResult> UpdateNews(string NewsID)
        {
            return await Task.Run(() =>
            {
                ViewBag.Message = "Update News.";
                ViewBag.IsPopup = true;
                UpdateNews newForUpdate = null;
                var news = TopNewsBL.Instance.Select(NewsID).Result;
                if (news != null)
                {
                    var imgList = ImageDetailBL.Instance.SelectImageList(NewsID);
                    IImageDetail image = null;
                    if (imgList != null && imgList.Count() > 0)
                    {
                        image = imgList.FirstOrDefault(v => v.IsActive == 1 && v.IsFirst == 1);
                    }

                    newForUpdate = new UpdateNews
                    {
                        NewsID = news.TopNewsID,
                        Heading = news.Heading,
                        ShortDesc = news.ShortDescription,
                        Description = news.NewsDescription,
                        Image = null,
                        ImageUrl = " ",
                        Caption = " ",
                        IsActiveNews = news.IsActive == 1 ? true : false,
                        IsApprovedNews = news.IsApproved == 1 ? true : false

                    };

                    if (image != null)
                    {
                        newForUpdate.ImageUrl = string.IsNullOrEmpty(image.ImageUrl) ? " " : image.ImageUrl;
                        newForUpdate.Caption = news.ImageCaption;
                    }
                }
                return View(newForUpdate);
            });
        }

        [Update]
        [HttpPost]
        public async Task<ActionResult> UpdateNews(UpdateNews newForUpdate)
        {
            var dbHelpre = DBHelper.Instance;
            dbHelpre.BeginTransaction();

            return await Task.Run(() =>
            {
                try
                {
                    bool IsNotValid = false;
                    ViewBag.Message = "Updating News.....";
                    if (ModelState.IsValid)
                    {
                        var news = new TopNews
                        {
                            TopNewsID = newForUpdate.NewsID,
                            Heading = newForUpdate.Heading.Trim(),
                            ShortDescription = newForUpdate.ShortDesc.Trim(),
                            NewsDescription = string.IsNullOrEmpty(newForUpdate.Description) ? string.Empty : newForUpdate.Description.Trim(),
                            IsActive = newForUpdate.IsActiveNews ? 1 : 0,
                            IsApproved = newForUpdate.IsApprovedNews ? 1 : 0
                        };

                        var image = new ImageDetail
                        {
                            ImageType = 1,
                            ImageUrl = newForUpdate.ImageUrl,
                            Caption = newForUpdate.Caption,
                            IsActive = 1,
                            IsFirst = 1
                        };

                        var fileName = string.Empty;
                        if (newForUpdate.Image != null && newForUpdate.Image.ContentLength > 0)
                        {
                            fileName = new Random().Next(1000000000).ToString() + Path.GetFileName(newForUpdate.Image.FileName);
                            image.ImageUrl = ImagePath.TopTenNewsImage + "/" + fileName;
                            image.IsActive = 1;
                            image.IsFirst = 1;
                        }

                        var user = (IUsers)this.Session[Constants.UserSessionKey];
                        TopNewsBL.Instance.UpdateNews(ref dbHelpre, news, image, user);

                        if (!string.IsNullOrEmpty(fileName))
                        {

                            if (SaveImage(ImagePath.TopTenNewsImage, fileName, newForUpdate.Image))
                            {
                                if (DeleteImage(ImagePath.TopTenNewsImage, newForUpdate.ImageUrl))
                                {
                                    ViewBag.Message = "Updated successfully.";
                                    ModelState.Clear();
                                }
                                else
                                {
                                    IsNotValid = true;
                                }
                            }
                            else
                            {
                                IsNotValid = true;
                            }
                        }

                        newForUpdate.ImageUrl = image.ImageUrl;

                    }
                    else
                    {
                        IsNotValid = true;
                    }

                    if (IsNotValid)
                    {
                        dbHelpre.RollbackTransaction();
                        ModelState.AddModelError("INSERT", "Oops ! There is some error.");
                        ViewBag.Message = "Oops ! There is some error.";
                    }
                    else
                    {
                        ViewBag.Message = "Updated successfully.";
                    }

                    dbHelpre.CommitTransaction();
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

                return View(newForUpdate);
            });
        }

        // var fileName = new Random(1000000000).ToString() + Path.GetFileName(image.FileName);
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
                if (!AllowedFileExtensions.Contains(image.FileName.Substring(image.FileName.LastIndexOf('.')).ToLower()))
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
                    //var serverPath = Server.MapPath(dirPath);
                    var pathArrey = Server.MapPath("Image").Replace("Admin", "@").Split('@');
                    var serverPath = pathArrey[0] + dirPath;

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

            //var serverPath = Server.MapPath(dirPath);
            var pathArrey = Server.MapPath("Image").Replace("Admin", "@").Split('@');
            var serverPath = pathArrey[0] + dirPath;

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