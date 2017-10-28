using System;

namespace ImageViewer
{
    interface ISortableViewModel
    {
        void SortContentByKey(string propertyHeaderName);
    }
}
