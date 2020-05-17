using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _LeahyHealthProject.Controllers
{
        [Authorize]
        public class UploadController : Controller
        {
            // GET: Upload
            public ActionResult Index()
            {
                return View();
            }
            [HttpGet]
            public ActionResult UofSuccessForm()
            {
                ViewBag.Message = "This is only for those who wish to participate in the program.";

                return View();
            }
            [HttpPost]
            public ActionResult UofSuccessForm(HttpPostedFileBase file)
            {
                try
                {
                    if (file.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(file.FileName);
                        string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                        file.SaveAs(_path);
                    }
                    ViewBag.Message = "File Uploaded Successfully!!";
                    return View();
                }
                catch
                {
                    ViewBag.Message = "File Upload failed!!";
                    return View();
                }
            }
        }
    }