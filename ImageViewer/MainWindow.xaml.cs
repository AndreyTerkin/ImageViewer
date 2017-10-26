using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Resources;

namespace ImageViewer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private FileManager m_fileManager;
        private ContentManager m_contentManager;

        public MainWindow()
        {
            InitializeComponent();
            m_fileManager = new FileManager();
            m_contentManager = new ContentManager();
        }

        private void OpenDirectory(object sender, RoutedEventArgs e)
        {
            string dirPath = m_fileManager.OpenDirectoryDialog();
            if (dirPath == null)
                return;

            m_contentManager.SetContentList(m_fileManager.GetFiles(dirPath, SearchOption.AllDirectories));

            if (m_contentManager.GetContentList().Count > 0)
                ImageView.Source = m_contentManager.GetContentList()[0].Bitmap;
            else
                ImageView.Source = null;

            ImageList.ItemsSource = from contentItem in m_contentManager.GetContentList()
                                    select contentItem.Name;

            if (m_contentManager.GetContentList().Count > 0)
                ImageList.SelectedIndex = 0;
        }

        private void ImageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            ImageView.Source = m_contentManager.GetContentList()[listBox.SelectedIndex].Bitmap;
        }
    }
}
