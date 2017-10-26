using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageViewer
{
    class ContentManager
    {
        private List<Image> m_imageCollection;

        public ContentManager()
        {
            m_imageCollection = new List<Image>();
        }

        public void SetContentList(List<FileInfo> items)
        {
            m_imageCollection.Clear();
            foreach (var item in items)
            {
                m_imageCollection.Add(new Image(item.Name, item.Extension, item.FullName));
            }
        }

        public List<Image> GetContentList()
        {
            return m_imageCollection;
        }
    }
}
