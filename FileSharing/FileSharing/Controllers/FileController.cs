using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ORMConfig.Managers;
using ORMConfig.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileSharing.Controllers
{
    public class FileController : Controller
    {
        private FileManager FileManager { get; set; }
        private ApplicationUserManager _userManager;

        public FileController()
        {
            FileManager = new FileManager();
        }

        public FileController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
            FileManager = new FileManager();
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private bool Authorized()
        {
            return System.Web.HttpContext.Current != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated;
        }
        // GET: File
        public ActionResult Index(String sort, String dir)
        {
            if (Authorized())
            {
                return View(FileManager.List(sort,dir));
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Delete(Guid fileId)
        {
            if (Authorized())
            {
                FileManager.Delete(fileId);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult Download(Guid fileId)
        {
            if (Authorized())
            {
                var file = FileManager.GetFile(fileId);

                FileContentResult result = new FileContentResult(file.Data, "application/octet-stream");
                result.FileDownloadName = file.FileName;

                return result;
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public ActionResult Upload()
        {
            if (Authorized())
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Upload(FileCreateORMModel model)
        {
            if (Authorized())
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var author = UserManager.FindById(User.Identity.GetUserId());
                        model.FileName = Path.GetFileName(file.FileName); ;
                        model.CreationDate = DateTime.Now;
                        model.AuthorId = author.Id;
                        model.AuthorName = author.Email;

                        byte[] fileData = null;
                        using (var binaryReader = new BinaryReader(file.InputStream))
                        {
                            fileData = binaryReader.ReadBytes(file.ContentLength);
                        }

                        model.Data = fileData;
                        FileManager.Add(model);
                    }
                }
                return RedirectToAction("Index");

            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}