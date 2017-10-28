using System;

namespace ImageViewer
{
    class ContentViewModelFactory
    {
        public IContentViewModel Create(IContentModel model)
        {
            return new ContentViewModel(model);
        }
    }
}
