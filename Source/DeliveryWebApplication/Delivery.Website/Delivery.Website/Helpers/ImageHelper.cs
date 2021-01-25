using System.Web;
using System.Web.Mvc;

namespace Delivery.Website.Helpers
{
    public static class ImageHelper
    {
        private const string PATH_TO_PHOTOS = "/Images/Photos/";
        private const string DEFAULT_EXTENSIONS = ".jpg";
        private const string DEFAULT_IMG = "/Images/Photos/unknown.jpg";
        public static MvcHtmlString Image(this HtmlHelper helper, int id, string height, string width)
        {
            var src = DEFAULT_IMG;
            var file = string.Format("{0}{1}{2}", PATH_TO_PHOTOS, id, DEFAULT_EXTENSIONS);
            var absolutePath = HttpContext.Current.Server.MapPath(file);
            if (System.IO.File.Exists(absolutePath))
            {
                src = file;
            }

            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("style", string.Format("height:{0};width:{1};", height, width));

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}