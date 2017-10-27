using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    class ContentModel
    {
        private IContentFactory m_contentFactory;
        private ObservableCollection<Content> m_imageCollection;

        public ContentModel()
        {
            m_contentFactory = new ImageFactory();
            m_imageCollection = new ObservableCollection<Content>();
        }

        public void SetContentList(List<FileInfo> items)
        {
            m_imageCollection.Clear();
            foreach (var item in items)
            {
                m_imageCollection.Add(m_contentFactory.Create(item.Name, item.Extension, item.FullName, item.Length));
            }
        }

        public ObservableCollection<Content> GetContentList()
        {
            return m_imageCollection;
        }

    }
}
