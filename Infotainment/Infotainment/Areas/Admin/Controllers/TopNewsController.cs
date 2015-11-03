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

namespace Infotainment.Areas.Admin.Controllers
{
    public class TopNewsController : Controller
    {
        public async Task<ActionResult> NeedApproval()
        {
            return await Task.Run(() =>
            {
                var list = new TopNewsApprovalList();
                list.Message = "Select news and click on submit tp approve.";

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

                    objTopNews.Heading = news.Heading;
                    objTopNews.ShortDescription = news.ShortDesc;
                    objTopNews.NewsDescription = news.Description;

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
                            var fileName = new Random(1000000000).ToString() + Path.GetFileName(news.Image.FileName);
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

                var newForUpdate = new UpdateNews
                {
                    NewsID = ""
                };

                return View(newForUpdate);
            });
        }

        //[HttpPost]
        //public ActionResult UploadImage(HttpPostedFileBase file)
        //{

        //    //return await Task.Run(() =>
        //    //{
        //    if (ModelState.IsValid)
        //    {
        //        if (file == null)
        //        {
        //            ModelState.AddModelError("File", "Please Upload Your file");
        //        }
        //        else if (file.ContentLength > 0)
        //        {
        //            int MaxContentLength = 1024 * 1024 * 10; //Size = 10 MB
        //            string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png" };
        //            if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
        //            {
        //                ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
        //            }
        //            else if (file.ContentLength > MaxContentLength)
        //            {
        //                ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
        //            }
        //            else
        //            {
        //                var fileName = Path.GetFileName(file.FileName);
        //                var path = Path.Combine(Server.MapPath("~/Images/Top-ten"), fileName);
        //                file.SaveAs(path);
        //                ModelState.Clear();
        //                ViewBag.Message = "File uploaded successfully. File path :   ~/Upload/" + fileName;
        //            }
        //        }
        //    }

        //    return View();
        //    //});
        //}
    }
}