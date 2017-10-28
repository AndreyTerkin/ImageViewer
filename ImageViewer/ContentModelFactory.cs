﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    class ContentModelFactory
    {
        public IContentModel Create()
        {
            return new ContentModel();
        }
    }
}
