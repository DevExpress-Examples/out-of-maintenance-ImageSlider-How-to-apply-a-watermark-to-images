using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace ImageSliderWithWatermark.Code
{
    public class ImageHelper
    {
        private static Image GetImageFromUrl(string url)
        {
            var image = Image.FromFile(HttpContext.Current.Server.MapPath(url));
            return image;
        }

        private static byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        public static byte[] GetImageWithWatermark(string url, string text, string fontName)
        {
            var image = GetImageFromUrl(url);
            PhotoUtils.DrawWatermarkText(image, text, fontName);
            return ImageToByteArray(image);
        }
    }
}