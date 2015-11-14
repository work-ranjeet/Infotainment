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

namespace Infotainment.Areas.Admin.Controllers
{
    public class TopNewsController : Controller
    {
        public async Task<ActionResult> NeedApproval()
        {
            return await Task.Run(() =>
            {
                var list = new TopNewsApprovalList();
                list.Message = "Select news and click on submit to approve.";

                list.ApprovalList = new List<TopNewsApproval>();

                var topNewsBL = new TopNewsBL();
                var result = topNewsBL.SelectTopeNewsForApproval();
                result.ToList().ForEach(v =>
                {
                    list.ApprovalList.Add(
                        new TopNewsApproval
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

        [HttpPost]
        public ActionResult NeedApproval(TopNewsApprovalList selectedNewsList)
        {
            var activeList = new TopNewsApprovalList();
            activeList.ApprovalList = new List<TopNewsApproval>();
            int selectedItemCount = selectedNewsList.ApprovalList.Where(t => t.Selected).Count();

            if (selectedItemCount > 0)
            {
                var list = new List<ITopNews>();
                selectedNewsList.ApprovalList.ToList().ForEach(item => list.Add(new TopNews()
                {
                    TopNewsID = item.TopNewsID,
                    IsApproved = item.Selected ? 1 : 0
                }));

                TopNewsBL.Instance.GiveApprovalFor(list);

                TopNewsBL.Instance.SelectTopeNewsForApproval().ToList().ForEach(v =>
                {
                    activeList.ApprovalList.Add(
                        new TopNewsApproval
                        {
                            Selected = false,
                            TopNewsID = v.TopNewsID,
                            IsApproved = v.IsApproved,
                            Heading = v.Heading,
                            DttmCreated = v.DttmCreated
                        });
                });

                activeList.Message = selectedItemCount.ToString() + " news has been approves successfuly.";
            }
            else
            {
                activeList.Message = "Please select atleast one news to approve!";
            }

            return View(activeList);
        }

        public async Task<ActionResult> MakeActive()
        {
            return await Task.Run(() =>
            {
                var list = new TopNewsActivationlList();
                list.Message = "Select news and click on submit to make active.";

                list.ActivationlList = new List<TopNewsActivation>();

                var topNewsBL = new TopNewsBL();
                var result = topNewsBL.SelectTopeNewsForActivate();
                result.ToList().ForEach(v =>
                {
                    list.ActivationlList.Add(
                        new TopNewsActivation
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

        [HttpPost]
        public ActionResult MakeActive(TopNewsActivationlList selectedNewsList)
        {
            var activeList = new TopNewsActivationlList();
            activeList.ActivationlList = new List<TopNewsActivation>();
            int selectedItemCount = selectedNewsList.ActivationlList.Where(t => t.Selected).Count();

            if (selectedItemCount > 0)
            {
                var list = new List<ITopNews>();
                selectedNewsList.ActivationlList.ToList().ForEach(item => list.Add(new TopNews()
                {
                    TopNewsID = item.TopNewsID,
                    IsActive = item.Selected ? 1 : 0
                }));

                TopNewsBL.Instance.MakeActiveFor(list);

                TopNewsBL.Instance.SelectTopeNewsForActivate().ToList().ForEach(v =>
                {
                    activeList.ActivationlList.Add(
                        new TopNewsActivation
                        {
                            Selected = false,
                            TopNewsID = v.TopNewsID,
                            IsActive = v.IsActive,
                            Heading = v.Heading,
                            DttmCreated = v.DttmCreated
                        });
                });

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

        [HttpGet]
        public async Task<ActionResult> InsertNews()
        {
            return await Task.Run(() =>
            {
                ViewBag.Message = "Inser new news.";
                return View(new CreateTopTenNews());
            });
        }

        [HttpPost]
        public async Task<ActionResult> InsertNews(CreateTopTenNews news)
        {
            return await Task.Run(() =>
            {
                if (ModelState.IsValid)
                {
                    var objTopNews = new TopNews();
                    var objImageDetail = new ImageDetail();
                    var topNewsBL = new TopNewsBL();

                    objTopNews.Heading = news.Heading.Trim();
                    objTopNews.ShortDescription = news.ShortDesc.Trim();
                    objTopNews.NewsDescription = string.IsNullOrEmpty(news.Description) ? string.Empty : news.Description.Trim();
                    objTopNews.DisplayOrder = 1;

                    string dirPath = "~/Images/Top-ten";

                    if (news.Image == null)
                    {
                        ModelState.AddModelError("File", "Please Upload Your file");
                        ViewBag.Message = "Please Upload Your file";
                    }
                    else if (news.Image.ContentLength > 0)
                    {
                        int MaxContentLength = 1024 * 1024 * 10; //Size = 10 MB
                        string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png" };
                        if (!AllowedFileExtensions.Contains(news.Image.FileName.Substring(news.Image.FileName.LastIndexOf('.'))))
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
                            var serverPath = Server.MapPath(dirPath);
                            if (Path.IsPathRooted(serverPath))
                            {
                                objImageDetail.ImageUrl = dirPath + "/" + fileName;
                                var path = Path.Combine(serverPath, fileName);
                                news.Image.SaveAs(path);
                            }
                        }
                    }

                    topNewsBL.Insert(objTopNews, objImageDetail);

                    news = new CreateTopTenNews();
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

        [HttpGet]
        public async Task<ActionResult> UpdateNews(string NewsID)
        {
            return await Task.Run(() =>
            {
                ViewBag.Message = "Update new news.";

                var news = TopNewsBL.Instance.Select(NewsID);
                var imgList = ImageDetailBL.Instance.SelectImageList(NewsID);
                IImageDetail image = null;
                if (imgList != null && imgList.Count() > 0)
                {
                    image = imgList.FirstOrDefault(v => v.IsActive == 1 && v.IsFirst == 1);
                }

                var newForUpdate = new UpdateNews
                {
                    NewsID = news.TopNewsID,
                    Heading = news.Heading,
                    ShortDesc = news.ShortDescription,
                    Description = news.NewsDescription,
                    Image = null,
                    ImageUrl = image.ImageUrl,
                    IsActiveNews = news.IsActive == 1 ? true : false,
                    IsApprovedNews = news.IsApproved == 1 ? true : false

                };

                return View(newForUpdate);
            });
        }
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
                            //ImageType = ImageType.TopNewsImage
                            ImageUrl = newForUpdate.ImageUrl,
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

                        TopNewsBL.Instance.UpdateNews(ref dbHelpre, news, image);

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