using System;

namespace ImageViewer
{
    interface IContentFactory
    {
        Content Create(string name, string extension, string fullName, long size);
    }
}
