using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ImageViewer
{
    interface IContentViewModel : INotifyPropertyChanged
    {
        Image SelectedItem { get; set; }
        void UpdateItems();
    }
}
