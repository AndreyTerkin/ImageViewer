using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ImageViewer
{
    class ContentViewModel : IContentViewModel
    {
        private ContentModel m_contentModel;
        private List<Image> m_contentList;
        private Image m_selectedImage;

        private readonly ICommand m_openCommand;

        public ContentViewModel(ContentModel contentModel)
        {
            m_contentModel = contentModel;
            m_openCommand = new OpenDirectoryCommand(this);
        }

        public List<Image> ContentList
        {
            get => m_contentList;
            set
            {
                m_contentList = value;
                PropertyChanged(this, new PropertyChangedEventArgs("ContentList"));
            }
        }

        public Image SelectedItem
        {
            get => m_selectedImage;
            set
            {
                m_selectedImage = value;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
            }
        }

        public ICommand OpenCommand
        {
            get => m_openCommand;
        }

        public int ItemCount
        {
            get => m_contentList.Count;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateItems()
        {
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
    }
}
