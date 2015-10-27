﻿using System;
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
            int selectedItemCount = selectedNewsList.ApprovalList.Where(t => t.Selected).Count();

            if (selectedItemCount > 0)
                selectedNewsList.Message = selectedItemCount.ToString() + " news selected for approval!";
            else
                selectedNewsList.Message = "Please select atleast one news to approve!";

            return View(selectedNewsList);
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
            int selectedItemCount = selectedNewsList.ActivationlList.Where(t => t.Selected).Count();

            if (selectedItemCount > 0)
                selectedNewsList.Message = selectedItemCount.ToString() + " news selected for approval!";
            else
                selectedNewsList.Message = "Please select atleast one news to approve!";

            return View(selectedNewsList);
        }

        public async Task<ActionResult> NewsList()
        {
            return await Task.Run(() =>
            {
                var topNewsBL = new TopNewsBL();
                var result = topNewsBL.SelectAll(DateTime.Now.AddDays(-1), DateTime.Now, 0, 0, string.Empty);
                return View(result);
            });
        }

        [HttpGet]
        public async Task<ActionResult> InsertNews()
        {
            return await Task.Run(() =>
            {
                return View();
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
                    }
                    else if (news.Image.ContentLength > 0)
                    {
                        int MaxContentLength = 1024 * 1024 * 10; //Size = 10 MB
                        string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png" };
                        if (!AllowedFileExtensions.Contains(news.Image.FileName.Substring(news.Image.FileName.LastIndexOf('.'))))
                        {
                            ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                        }
                        else if (news.Image.ContentLength > MaxContentLength)
                        {
                            ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
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
                                ModelState.Clear();
                                ViewBag.Message = "File uploaded successfully. File path :   ~/Upload/" + fileName;
                            }
                        }
                    }

                    topNewsBL.Insert(objTopNews, objImageDetail);
                }

                return View(news);
            });
        }

        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {

            //return await Task.Run(() =>
            //{
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    ModelState.AddModelError("File", "Please Upload Your file");
                }
                else if (file.ContentLength > 0)
                {
                    int MaxContentLength = 1024 * 1024 * 10; //Size = 10 MB
                    string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png" };
                    if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
                    {
                        ModelState.AddModelError("File", "Please file of type: " + string.Join(", ", AllowedFileExtensions));
                    }
                    else if (file.ContentLength > MaxContentLength)
                    {
                        ModelState.AddModelError("File", "Your file is too large, maximum allowed size is: " + MaxContentLength + " MB");
                    }
                    else
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Images/Top-ten"), fileName);
                        file.SaveAs(path);
                        ModelState.Clear();
                        ViewBag.Message = "File uploaded successfully. File path :   ~/Upload/" + fileName;
                    }
                }
            }

            return View();
            //});
        }
    }
}