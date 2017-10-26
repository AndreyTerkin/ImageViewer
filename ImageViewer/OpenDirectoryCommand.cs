using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImageViewer
{
    class OpenDirectoryCommand : ICommand
    {
        private IContentViewModel m_viewModel;

        public OpenDirectoryCommand(IContentViewModel viewModel)
        {
            m_viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            m_viewModel.UpdateItems();
        }
    }
}
