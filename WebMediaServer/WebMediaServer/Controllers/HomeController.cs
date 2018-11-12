using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using WebMediaServer.Models;
using WebMediaServer.ModelsDB;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI;

namespace WebMediaServer.Controllers
{
    public class HomeController : Controller
    {
        private Mod_DB modelDB = new Mod_DB();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            //
            List<ViewInfoOnCard> SV = modelDB.Database.SqlQuery<ViewInfoOnCard>("SELECT Content.id, NameVideo, AspNetUsers.UserName, UserId, DateAddVideo, Url2 FROM Content JOIN AspNetUsers ON AspNetUsers.Id = Content.UserId JOIN TypeContent ON TypeContent.id = Content.TypeContent where TypeContent.NameType = 'video'").ToList();
            //
            return View(SV);
        }

        public ActionResult PlayVideo(int id)
        {
            modelDB.Views_Con.Add(new Views_Con() { UserId = User.Identity.GetUserId(), ContentId = id, DeteView = DateTime.Now });
            modelDB.SaveChanges();
            string str = "SELECT Content.id, NameVideo, AspNetUsers.UserName, " +
                         "UserId, DateAddVideo, Url1, Url2 FROM Content " +
                         "JOIN AspNetUsers ON AspNetUsers.Id = Content.UserId" +
                         " WHERE Content.id = " + id.ToString();
            ViewInfoOnPlayVideo table = modelDB.Database.SqlQuery<ViewInfoOnPlayVideo>(str).First();
            return View(table);
        }
        
        //function of receiving and verifying information
        public string addFile(string file, string folderName)
        {   
            string OnePath = "~/UserMediaFile/Media/" + folderName + "/";
            string fileName = Path.GetFileName(file);
            string path = Path.Combine(OnePath, fileName);
            return path;
        }
        public string addFile1(string file, string folderName)
        {
            string OnePath = "~/UserMediaFile/Media/" + folderName + "/";
            string fileName = Path.GetFileName(file);
            string path = Path.Combine(Server.MapPath(OnePath), fileName);
            return path;
        }

        public string GetTypeStr(string str, int pos)
        {
            return str.Split('/')[pos];
        }
        [HttpPost]
        public ActionResult Upload(UploadVideoContent files)
        {
            int TC_id;
            var tyCon = GetTypeStr(files.typeF1, 0);
            var ListType = modelDB.TypeContent.Where(t => t.NameType == tyCon).ToList();
            if (ListType.Count == 0)
            {
                modelDB.TypeContent.Add(new TypeContent() {NameType = tyCon});
                modelDB.SaveChanges();
                TC_id = modelDB.TypeContent.Where(t => t.NameType == tyCon).First().id;
            }
            else
            {
                TC_id = ListType[0].id;
            }

            var u1 = "";
            if (files.filename2 != null)
            {
                u1 = addFile(files.filename2, GetTypeStr(files.typeF2, 0));
            }
            else
            {
                u1 = "";
            }
            modelDB.Content.Add(new Content
            {
                TypeContent = TC_id,
                LengthVideo = new TimeSpan(0, 10, 0),
                NameVideo = files.Name,
                Text_Description = files.TextDescription,
                DateAddVideo = DateTime.Now,
                UserId = User.Identity.GetUserId(),
                Url1 = addFile(files.filename1, GetTypeStr(files.typeF1, 0)),
                Url2 = u1
            });
            modelDB.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public string MultiUpload(System.Web.HttpPostedFileWrapper FileBytes, string ConType, string NameFile, int pos)
        {
            
            int len = FileBytes.ContentLength;
            var buf = new byte[len];
            FileBytes.InputStream.Read(buf, 0, len);
            string newpath = addFile1(NameFile, ConType);
            using (FileStream fs = System.IO.File.Open(newpath,FileMode.OpenOrCreate,FileAccess.Write,FileShare.Write))
            {
                fs.Position = pos;
                fs.Write(buf,0,len);
            }

            return "test";
        }
    }
}