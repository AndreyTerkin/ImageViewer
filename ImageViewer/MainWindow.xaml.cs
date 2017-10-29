using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ImageViewer.Model;
using ImageViewer.ViewModel;

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
            m_contentViewModel = m_viewModelFactory.Create(m_contentModel, new CloseCommand(this));

            this.DataContext = m_contentViewModel;
        }

        private void ListViewHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
            var sortableViewModel = m_contentViewModel as ISortableViewModel;
            sortableViewModel?.SortContentByKey(headerClicked.Content as string);
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filterableViewModel = m_contentViewModel as IFilterableViewModel;
            if(filterableViewModel != null)
                filterableViewModel.FilterString = (e.Source as TextBox).Text;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string helpText = "In order to start images viewing open directory with images you want to watch:\n" +
                              "File->Open Directory\n" +
                              "Wait for images loading.\n\n" +
                              "Image list provides sorting functionality. In order to sort list by one of the attribute " +
                              "click on table header of interested attribute.\n" +
                              "Also you can search image by its name. Just start to write name and list will be filtered automatically.";

            MessageBox.Show(helpText, "Help", MessageBoxButton.OK);
        }
    }
}
