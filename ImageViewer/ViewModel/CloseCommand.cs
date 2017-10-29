using System;
using System.Windows;
using System.Windows.Input;

namespace ImageViewer.ViewModel
{
    class CloseCommand : ICommand
    {
        private Window m_window;

        public CloseCommand(Window window)
        {
            m_window = window;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            m_window.Close();
        }
    }
}
