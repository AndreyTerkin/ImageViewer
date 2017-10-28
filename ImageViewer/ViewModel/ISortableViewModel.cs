using System;

namespace ImageViewer.ViewModel
{
    interface ISortableViewModel
    {
        void SortContentByKey(string propertyHeaderName);
    }
}
