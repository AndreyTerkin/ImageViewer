using System.IO;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;
using ImageViewer.Model;

namespace ImageViewer.ViewModel
{
    class ContentViewModel : IContentViewModel, ISortableViewModel, IFilterableViewModel
    {
        private IContentModel m_contentModel;
        private ObservableCollection<Content> m_contentList;
        private Content m_selectedItem;

        private string m_filterString;

        private readonly ICommand m_openCommand;
        private readonly ICommand m_closeCommand;

        public ContentViewModel(IContentModel contentModel, ICommand closeCommand)
        {
            m_contentModel = contentModel;
            m_filterString = "";

            m_openCommand = new OpenDirectoryCommand(this);
            m_closeCommand = closeCommand;
        }

        public ObservableCollection<Content> ContentList
        {
            get
            {
                if (m_contentList == null)
                    return null;

                return new ObservableCollection<Content>(
                            from item in m_contentList
                            where item.Name.ToLower().StartsWith(FilterString)
                            select item);
            }
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

        public ICommand CloseCommand
        {
            get => m_closeCommand;
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
                (m_contentModel as ISortableModel).SortMap[propertyHeaderName].Invoke();
                ContentList = m_contentModel.GetContentList();
            }
        }

        // IFilterableViewModel
        public string FilterString
        {
            get => m_filterString;
            set
            {
                m_filterString = value.ToLower();
                PropertyChanged(this, new PropertyChangedEventArgs("ContentList"));
            }
        }
    }
}
