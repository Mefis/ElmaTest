using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ORMConfig.Managers;
using ORMConfig.Models;
using System;
using System.Collections.Generic;
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

        // GET: File
        public ActionResult Index()
        {
            var enumerable = FileManager.List();
            return View(enumerable);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public void Create(FileCreateORMModel model)
        {

            var author = UserManager.FindById(User.Identity.GetUserId());
            model.CreationDate = DateTime.Now;
            model.AuthorId = author.Id;
            model.AuthorName = author.Email;
            FileManager.Add(model);
            RedirectToAction("Index");
        }
        
        public void Delete(Guid fileId)
        {
            FileManager.Delete(fileId);
            RedirectToAction("Index");
        }
    }
}