using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ImageViewer.Model
{
    class ErrorHandler
    {
        public static void HandleOpenDirectoryError(string path)
        {
            MessageBox.Show("It's not impossible to open directory " + path +
                            " or any files from it.",
                "Opening Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}
