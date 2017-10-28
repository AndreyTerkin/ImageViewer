using System;

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
