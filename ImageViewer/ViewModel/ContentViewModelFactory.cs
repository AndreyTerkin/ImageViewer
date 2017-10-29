using System;
using System.Windows.Input;
using ImageViewer.Model;

namespace ImageViewer.ViewModel
{
    class ContentViewModelFactory
    {
        public IContentViewModel Create(IContentModel model, ICommand closeCommand)
        {
            return new ContentViewModel(model, closeCommand);
        }
    }
}
