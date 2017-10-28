using System;
using ImageViewer.Model;

namespace ImageViewer.ViewModel
{
    class ContentViewModelFactory
    {
        public IContentViewModel Create(IContentModel model)
        {
            return new ContentViewModel(model);
        }
    }
}
