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
        public int Size { get; set; }
        public string Comment { get; set; }

        public Image()
        { }

        public Image(string name, string extension, string fullName)
        {
            Name = name;
            Extension = extension;
            FullName = fullName;
            Uri = new Uri(fullName);
            Bitmap = new BitmapImage(Uri);
        }
    }
}
