using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageViewer.Model
{
    class FileManager
    {
        private static string[] m_extensions = { ".png", ".jpg", ".jpeg" };

        /// <summary>
        /// Open dialog to choose directory
        /// </summary>
        /// <returns>Directory path</returns>
        public static string OpenDirectoryDialog()
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog().ToString() == "OK")
            {
                return dlg.SelectedPath;
            }
            return null;
        }

        /// <summary>
        /// Receive list of files in directory according path
        /// </summary>
        /// <param name="path">Path to directory</param>
        /// <param name="mode">Search mode</param>
        /// <returns>List of file information</returns>
        public static List<FileInfo> GetFiles(string path, SearchOption mode = SearchOption.TopDirectoryOnly)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            List<FileInfo> fileList = new List<FileInfo>();

            try
            {
                var files = dirInfo.EnumerateFiles("*.*", SearchOption.AllDirectories)
                    .Where(file => m_extensions.Any(ex => ex == file.Extension.ToLower()));

                foreach (var file in files)
                {
                    fileList.Add(file);
                }
            }
            catch (Exception e)
            {
                ErrorHandler.HandleOpenDirectoryError(path);
            }

            return fileList;
        }
    }
}
