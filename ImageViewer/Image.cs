using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageViewer
{
    class Image : Content
    {
        public Uri Uri { get; set; }
        public BitmapImage Bitmap { get; set; }
        public string SizeString { get; set; }
        public string ResolutionString { get; set; }
        public string Comment { get; set; }

        public Image(string name, string extension, string fullName, long size)
            : base(name, extension, fullName, size)
        {
            Uri = new Uri(fullName);
            Bitmap = new BitmapImage(Uri);
            SizeString = Size / 1024 + " KB";
            Resolution = Bitmap.PixelWidth * Bitmap.PixelHeight;
            ResolutionString = Bitmap.PixelWidth + "x" + Bitmap.PixelHeight;
        }
    }
}
