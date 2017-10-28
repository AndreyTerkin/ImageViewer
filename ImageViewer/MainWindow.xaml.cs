using System.Windows;
using System.Windows.Controls;

namespace ImageViewer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IContentViewModel m_contentViewModel;
        private IContentModel m_contentModel;

        private ContentModelFactory m_modelFactory;
        private ContentViewModelFactory m_viewModelFactory;

        public MainWindow()
        {
            InitializeComponent();

            m_modelFactory = new ContentModelFactory();
            m_viewModelFactory = new ContentViewModelFactory();

            m_contentModel = m_modelFactory.Create();
            m_contentViewModel = m_viewModelFactory.Create(m_contentModel);

            this.DataContext = m_contentViewModel;
        }

        private void ListViewHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            var sortableViewModel = m_contentViewModel as ISortableViewModel;
            if(sortableViewModel != null)
                sortableViewModel.SortContentByKey(headerClicked.Content as string);
        }
    }
}
