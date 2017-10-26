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
        private ContentViewModel m_contentViewModel;

        private ContentModel m_contentModel;

        public MainWindow()
        {
            InitializeComponent();
            m_contentModel = new ContentModel();
            m_contentViewModel = new ContentViewModel(m_contentModel);

            this.DataContext = m_contentViewModel;
        }

        private void ImageList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var listBox = sender as ListBox;
            //ImageView.Source = m_contentModel.GetContentList()[listBox.SelectedIndex].Bitmap;
        }
    }
}
