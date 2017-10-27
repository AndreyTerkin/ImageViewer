using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    class ImageFactory : IContentFactory
    {
        public Content Create(string name, string extension, string fullName, long size)
        {
            return new Image(name, extension, fullName, size);
        }
    }
}
