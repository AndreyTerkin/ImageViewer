using System;
using System.ComponentModel;
using ImageViewer.Model;

namespace ImageViewer.ViewModel
{
    interface IContentViewModel : INotifyPropertyChanged
    {
        Content SelectedItem { get; set; }
        void UpdateItems();
    }
}
