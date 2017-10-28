using System;

namespace ImageViewer.Model
{
    interface IContentFactory
    {
        Content Create(string name, string extension, string fullName, long size);
    }
}
