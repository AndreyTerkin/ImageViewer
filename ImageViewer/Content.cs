using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    abstract class Content
    {
        public string Name { get; set; }
        public string Extension { get; set; }
        public string FullName { get; set; }
        public long Size { get; set; }

        public Content(string name, string extension, string fullName, long size)
        {
            Name = name;
            Extension = extension;
            FullName = fullName;
            Size = size;
        }
    }
}
