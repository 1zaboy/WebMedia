using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using WebMediaServer.AllSource.XmlControl.Models;
using WebMediaServer.Controllers;
using WebMediaServer.ModelsDB;

namespace WebMediaServer.AllSource.XmlControl.Generation
{
    public class Generator
    {
        private Mod_DB modelDB = new Mod_DB();
        public Generator()
        {

        }
        
        public string con_view(UrlHelper urlHelper, string typevideo, string namevideo, UInt32 CountCardHeve, UInt32 CountCard)
        {
            var ttt =
                "select Content.id, NameVideo, AspNetUsers.UserName, UserId, Url1, Url2," +
                " DateAddVideo, LengthVideo, TypeContent.NameType, Text_Description " +
                "from Content join TypeContent on TypeContent.id = TypeContent " +
                "JOIN AspNetUsers ON AspNetUsers.Id = Content.UserId " +
                "where NameVideo like '"+namevideo+"%' and TypeContent.NameType like '"+typevideo+"%'" +
                "order by Content.id offset "+CountCardHeve+" rows fetch next "+CountCard+" rows only";

            List<Content_All> nodes = new List<Content_All>();
            nodes = modelDB.Database.SqlQuery<Content_All>(ttt).ToList();
            return xmlfileon(nodes);
        }
        public string user_view(UrlHelper urlHelper, string name, string email, UInt32 CountCardHeve, UInt32 CountCard)
        {
            var ttt =
                "select Id, Email, UserName, PhoneNumber "+
                "from AspNetUsers "+
                "where Email like '"+email+"%' and UserName like '"+name+"%' "+
                "order by Id offset " + CountCardHeve + " rows fetch next " + CountCard + " rows only";

            List<user_all> nodes = new List<user_all>();
            nodes = modelDB.Database.SqlQuery<user_all>(ttt).ToList();
            return xmlfileon(nodes);
        }

        public string xmlfileon<T>(List<T> TEntity1) where T : new()
        {
            XmlSerializer formatter = new XmlSerializer(TEntity1.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                formatter.Serialize(textWriter, TEntity1);
                return textWriter.ToString();
            }
        }
    }
}
