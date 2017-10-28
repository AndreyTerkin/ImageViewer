using System;
using System.Windows.Input;
using ImageViewer.ViewModel;

namespace ImageViewer.Model
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
