using Infotainment.Areas.Admin.Models;
using Infotainment.Data;
using Infotainment.Data.Controls;
using Infotainment.Data.Entities;
using Infotainment.Filter;
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
    [Autherisation]
    public class InternationalController : Controller
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

                var newsBL = new InterNewsBL();
                var result = newsBL.SelectToApprove();
                result.ToList().ForEach(v =>
                {
                    list.ApprovalList.Add(
                        new NewsApproval
                        {
                            Selected = false,
                            TopNewsID = v.NewsID,
                            ImageUrl = v.ImageUrl,
                            IsApproved = v.IsApproved,
                            IsTopNews = v.IsTopNews,
                            Heading = v.Heading,
                            DttmCreated = v.DttmCreated
                        });
                });

                return View(list);
            });
        }

        [Approve]
        [HttpPost]
        public async Task<ActionResult> NeedApproval(NewsApprovalList selectedNewsList)
        {
            return await Task.Run(() =>
            {
                var activeList = new NewsApprovalList();
                activeList.ApprovalList = new List<NewsApproval>();
                var selectedItem = selectedNewsList.ApprovalList.Where(t => t.Selected);

                if (selectedItem.Count() > 0)
                {
                    var list = new List<IInterNews>();
                    selectedItem.ToList().ForEach(item => list.Add(new InterNews()
                    {
                        NewsID = item.TopNewsID,
                        IsApproved = item.Selected ? 1 : 0
                    }));

                    var user = (IUsers)this.Session[Constants.UserSessionKey];
                    InterNewsBL.Instance.GiveApprovalFor(list, user);

                    InterNewsBL.Instance.SelectToApprove().ToList().ForEach(v =>
                    {
                        activeList.ApprovalList.Add(
                            new NewsApproval
                            {
                                Selected = false,
                                TopNewsID = v.NewsID,
                                IsApproved = v.IsApproved,
                                IsTopNews = v.IsTopNews,
                                Heading = v.Heading,
                                DttmCreated = v.DttmCreated
                            });
                    });
                    ModelState.Clear();

                    activeList.Message = selectedItem.Count().ToString() + " news has been approves successfuly.";
                }
                else
                {
                    activeList.Message = "Please select atleast one news to approve!";
                }

                return View(activeList);
            });
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

                var newsBL = new InterNewsBL();
                var result = newsBL.SelectToActive();
                result.ToList().ForEach(v =>
                {
                    list.ActivationlList.Add(
                        new NewsActivation
                        {
                            Selected = false,
                            TopNewsID = v.NewsID,
                            ImageUrl = v.ImageUrl,
                            IsActive = v.IsActive,
                            IsTopNews = v.IsTopNews,
                            Heading = v.Heading,
                            DttmCreated = v.DttmCreated
                        });
                });

                return View(list);
            });
        }

        [Active]
        [HttpPost]
        public async Task<ActionResult> MakeActive(NewsActivationlList selectedNewsList)
        {
            return await Task.Run(() =>
            {
                var activeList = new NewsActivationlList();
                activeList.ActivationlList = new List<NewsActivation>();
                var selectedItem = selectedNewsList.ActivationlList.Where(t => t.Selected);

                if (selectedItem.Count() > 0)
                {
                    var list = new List<IInterNews>();
                    selectedItem.ToList().ForEach(item => list.Add(new InterNews()
                    {
                        NewsID = item.TopNewsID,
                        IsActive = item.Selected ? 1 : 0
                    }));

                    var user = (IUsers)this.Session[Constants.UserSessionKey];
                    InterNewsBL.Instance.MakeActiveFor(list, user);

                    InterNewsBL.Instance.SelectToActive().ToList().ForEach(v =>
                    {
                        activeList.ActivationlList.Add(
                            new NewsActivation
                            {
                                Selected = false,
                                TopNewsID = v.NewsID,
                                IsActive = v.IsActive,
                                IsTopNews = v.IsTopNews,
                                Heading = v.Heading,
                                DttmCreated = v.DttmCreated
                            });
                    });
                    ModelState.Clear();
                    activeList.Message = selectedItem.Count().ToString() + " news has been activeted.";
                }
                else
                {
                    activeList.Message = "Please select atleast one news to approve!";
                }

                return View(activeList);
            });
        }

        [HttpGet]
        public async Task<ActionResult> NewsList()
        {
            return await Task.Run(() =>
            {
                var newsBL = new InterNewsBL();
                var result = newsBL.Search(DateTime.Now.AddDays(-1), DateTime.Now, string.Empty);
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
        public async Task<ActionResult> InsertNews(CreateNews news)
        {
            return await Task.Run(() =>
            {
                if (ModelState.IsValid)
                {
                    var objNews = new InterNews();
                    var objImageDetail = new ImageDetail();
                    var newsBL = new InterNewsBL();

                    objNews.Heading = news.Heading.Trim();
                    objNews.ShortDescription = news.ShortDesc.Trim();
                    objNews.NewsDescription = string.IsNullOrEmpty(news.Description) ? string.Empty : news.Description.Trim();
                    objNews.DisplayOrder = 1;
                    objNews.IsTopNews = news.IsTopTenNews ? 1 : 0;

                    string dirPath = ImagePath.InternationalNewsImage;

                    if (news.Image == null)
                    {
                        ModelState.AddModelError("File", "Please Upload Your file");
                        ViewBag.Message = "Please Upload Your file";
                    }
                    else if (news.Image.ContentLength > 0)
                    {
                        int MaxContentLength = 1024 * 1024 * 10; //Size = 10 MB
                        string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png" };
                        if (!AllowedFileExtensions.Contains(news.Image.FileName.Substring(news.Image.FileName.LastIndexOf('.')).ToLower()))
                        {
                            ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                            ViewBag.Message = "Please file of type: " + string.Join(", ", AllowedFileExtensions);
                        }
                        else if (news.Image.ContentLength > MaxContentLength)
                        {
                            ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                            ViewBag.Message = "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB";
                        }
                        else
                        {
                            var fileName = new Random().Next(1000000000).ToString() + Path.GetFileName(news.Image.FileName);

                            var pathArrey = Server.MapPath("Image").Replace("Admin", "@").Split('@');
                            var serverPath = pathArrey[0] + dirPath;

                            if (Path.IsPathRooted(serverPath))
                            {
                                objImageDetail.ImageUrl = dirPath + "/" + fileName;
                                objImageDetail.Caption = news.ImageCaption;
                                objImageDetail.ImageType = 2;
                                var path = Path.Combine(serverPath, fileName);
                                news.Image.SaveAs(path);
                            }
                        }
                    }

                    var user = (IUsers)this.Session[Constants.UserSessionKey];

                    newsBL.Insert(objNews, objImageDetail, user);

                    news = new CreateNews();
                    ViewBag.Message = "File saved successfully.";
                    ModelState.Clear();
                }
                else
                {
                    //ModelState.AddModelError("INSERT", "Oops ! There is some error.");
                    ViewBag.Message = "Oops ! There is some error.";
                }

                return View(news);
            });
        }

        [Update]
        [HttpGet]
        public async Task<ActionResult> UpdateNews(string NewsID)
        {
            return await Task.Run(() =>
            {
                ViewBag.Message = "Update new news.";
                ViewBag.IsPopup = true;
                UpdateNews newForUpdate = null;
                var news = InterNewsBL.Instance.Select(NewsID);
                if (news != null)
                {
                    var imgList = ImageDetailBL.Instance.SelectInterNewsImageList(NewsID);
                    IImageDetail image = null;
                    if (imgList != null && imgList.Count() > 0)
                    {
                        image = imgList.FirstOrDefault(v => v.IsActive == 1 && v.IsFirst == 1);
                    }

                    newForUpdate = new UpdateNews
                    {
                        NewsID = news.NewsID,
                        Heading = news.Heading,
                        ShortDesc = news.ShortDescription,
                        Description = news.NewsDescription,
                        Image = null,
                        ImageUrl = image.ImageUrl,
                        Caption = news.ImageCaption,
                        IsActiveNews = news.IsActive == 1 ? true : false,
                        IsApprovedNews = news.IsApproved == 1 ? true : false,
                        IsTopTenNews = news.IsTopNews == 1 ? true : false

                    };
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
                    ViewBag.Message = "Update new news.";
                    if (ModelState.IsValid)
                    {
                        var news = new InterNews
                        {
                            NewsID = newForUpdate.NewsID,
                            Heading = newForUpdate.Heading.Trim(),
                            ShortDescription = newForUpdate.ShortDesc.Trim(),
                            NewsDescription = string.IsNullOrEmpty(newForUpdate.Description) ? string.Empty : newForUpdate.Description.Trim(),
                            IsActive = newForUpdate.IsActiveNews ? 1 : 0,
                            IsApproved = newForUpdate.IsApprovedNews ? 1 : 0,
                            IsTopNews = newForUpdate.IsTopTenNews ? 1 : 0
                        };

                        var image = new ImageDetail
                        {
                            ImageType = 2,
                            ImageUrl = newForUpdate.ImageUrl,
                            Caption = newForUpdate.Caption,
                            IsActive = 1,
                            IsFirst = 1
                        };

                        var fileName = string.Empty;
                        if (newForUpdate.Image != null && newForUpdate.Image.ContentLength > 0)
                        {
                            fileName = new Random().Next(1000000000).ToString() + Path.GetFileName(newForUpdate.Image.FileName);
                            image.ImageUrl = ImagePath.InternationalNewsImage + "/" + fileName;
                            image.IsActive = 1;
                            image.IsFirst = 1;
                        }

                        var user = (IUsers)this.Session[Constants.UserSessionKey];
                        InterNewsBL.Instance.UpdateNews(ref dbHelpre, news, image, user);

                        if (!string.IsNullOrEmpty(fileName))
                        {

                            if (SaveImage(ImagePath.InternationalNewsImage, fileName, newForUpdate.Image))
                            {
                                if (DeleteImage(ImagePath.InternationalNewsImage, newForUpdate.ImageUrl))
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
