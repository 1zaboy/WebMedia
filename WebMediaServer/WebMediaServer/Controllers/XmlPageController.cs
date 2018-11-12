using System;
using System.Text;
using System.Web.Mvc;
using WebMediaServer.AllSource.XmlControl.Generation;

namespace WebMediaServer.Controllers
{
    public class XmlPageController : Controller
    {
        Generator sitemapGenerator = new Generator();
        [Authorize]
        public ActionResult Sitemap(string typevideo = "", string NameVideo = "", UInt32 SkipCount = 0, UInt32 AllCount = 0)
        {
            
            return this.Content(sitemapGenerator.con_view(this.Url, typevideo, NameVideo, SkipCount, AllCount), "text/xml", Encoding.UTF8);
        }

        [Authorize]
        public ActionResult ViewUser(string name = "", string email = "", UInt32 SkipCount = 0, UInt32 AllCount = 10)
        {
            return this.Content(sitemapGenerator.user_view(this.Url, name, email, SkipCount, AllCount), "text/xml",
                Encoding.UTF8);
        }
    }
}