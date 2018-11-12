using System;
using System.Drawing;
using System.Web;

namespace WebMediaServer.Models
{
    public class ScrolVideo
    {
        public string NameVideo;
        public string NameAutor;
        public Image MainImage;
        public string DateAdd;
    }

    public class UploadVideoContent
    {
        public string Name { get; set; }
        public string TextDescription { get; set; }
        public string filename1 { get; set; }
        public string typeF1 { get; set; }
        public string filename2 { get; set; }
        public string typeF2 { get; set; }
    }

    public class ViewInfoOnCard
    {
        public int id { get; set; }
        public string NameVideo { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public DateTime DateAddVideo { get; set; }
        private string _Url2 { get; set; }

        public string Url2
        {
            get { return _Url2; }
            set
            {
                if (value == null)
                {
                    _Url2 = "";
                }
                else
                {
                    _Url2 = value;
                }
            }
        }
    }

    public class ViewInfoOnPlayVideo
    {
        public int id { get; set; }
        public string NameVideo { get; set; }
        public string UserName { get; set; }
        public string UserID { get; set; }
        public DateTime DateAddVideo { get; set; }
        private string _Url1 { get; set; }
        public string Url1
        {
            get { return _Url1; }
            set
            {
                if (value == null)
                {
                    _Url1 = "";
                }
                else
                {
                    _Url1 = value;
                }
            }
        }
        private string _Url2 { get; set; }
        public string Url2
        {
            get { return _Url2; }
            set
            {
                if (value == null)
                {
                    _Url2 = "";
                }
                else
                {
                    _Url2 = value;
                }
            }
        }
    }
}