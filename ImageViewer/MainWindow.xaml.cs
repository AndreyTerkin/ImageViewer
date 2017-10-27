using System.Windows;
using System.Windows.Controls;

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

        private void ListViewHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            m_contentViewModel.SortContentByKey(headerClicked.Content as string);
        }
    }
}
