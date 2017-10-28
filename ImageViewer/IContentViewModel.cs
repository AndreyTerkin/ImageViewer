using System;
using System.ComponentModel;

namespace ImageViewer
{
    interface IContentViewModel : INotifyPropertyChanged
    {
        Content SelectedItem { get; set; }
        void UpdateItems();
    }
}
