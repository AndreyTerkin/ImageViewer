using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    class ContentModel
    {
        private IContentFactory m_contentFactory;
        private List<Content> m_imageCollection;

        public ContentModel()
        {
            m_contentFactory = new ImageFactory();
            m_imageCollection = new List<Content>();
        }

        public void SetContentList(List<FileInfo> items)
        {
            m_imageCollection.Clear();
            foreach (var item in items)
            {
                m_imageCollection.Add(m_contentFactory.Create(item.Name, item.Extension, item.FullName, item.Length));
            }
        }

        public List<Content> GetContentList()
        {
            return m_imageCollection;
        }

    }
}
