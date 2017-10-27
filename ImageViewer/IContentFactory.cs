using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    interface IContentFactory
    {
        Content Create(string name, string extension, string fullName, long size);
    }
}
