using System.IO;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace ImageViewer
{
    class ContentViewModel : IContentViewModel
    {
        private IContentModel m_contentModel;
        private ObservableCollection<Content> m_contentList;
        private Content m_selectedItem;

        private readonly ICommand m_openCommand;

        public ContentViewModel(IContentModel contentModel)
        {
            m_contentModel = contentModel;
            m_openCommand = new OpenDirectoryCommand(this);
        }

        public ObservableCollection<Content> ContentList
        {
            get => m_contentList;
            set
            {
                m_contentList = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ContentList"));
            }
        }

        public Content SelectedItem
        {
            get => m_selectedItem;
            set
            {
                m_selectedItem = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
            }
        }

        public ICommand OpenCommand
        {
            get => m_openCommand;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateItems()
        {
            if (m_contentModel == null)
                return;

            string dirPath = FileManager.OpenDirectoryDialog();
            if (dirPath == null)
                return;

            m_contentModel.SetContentList(FileManager.GetFiles(dirPath, SearchOption.AllDirectories));
            ContentList = m_contentModel.GetContentList();

            if (m_contentModel.GetContentList().Count > 0)
                SelectedItem = m_contentModel.GetContentList()[0];
            else
                SelectedItem = null;
        }

        public void SortContentByKey(string propertyHeaderName)
        {
            if (m_contentModel == null)
                return;

            var sortableModel = m_contentModel as ISortableModel;
            if (sortableModel == null)
                return;

            if (sortableModel.SortMap.Keys.Contains(propertyHeaderName))
            {
                // TODO: restore selected item
                (m_contentModel as ISortableModel).SortMap[propertyHeaderName].Invoke();
                ContentList = m_contentModel.GetContentList();
            }
        }
    }
}
