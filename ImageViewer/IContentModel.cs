using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ImageViewer
{
    interface IContentModel
    {
        void SetContentList(List<FileInfo> items);
        ObservableCollection<Content> GetContentList();
    }
}
