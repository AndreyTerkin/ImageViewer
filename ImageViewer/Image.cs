using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ImageViewer
{
    class Image : IContent
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string FullName { get; set; }
        public Uri Uri { get; set; }
        public BitmapImage Bitmap { get; set; }
        public long Size { get; set; }
        public string SizeString { get; set; }
        public int Resolution { get; set; }
        public string ResolutionString { get; set; }
        public string Comment { get; set; }

        public Image()
        { }

        public Image(string name, string extension, string fullName, long size)
        {
            Name = name;
            Extension = extension;
            FullName = fullName;
            Uri = new Uri(fullName);
            Bitmap = new BitmapImage(Uri);
            Size = size;
            SizeString = Size / 1024 + " KB";
            Resolution = Bitmap.PixelWidth * Bitmap.PixelHeight;
            ResolutionString = Bitmap.PixelWidth + "x" + Bitmap.PixelHeight;
        }
    }
}
