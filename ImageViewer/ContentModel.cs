using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ImageViewer
{
    class ContentModel : IContentModel, ISortableModel
    {
        private IContentFactory m_contentFactory;
        private ObservableCollection<Content> m_imageCollection;

        private Dictionary<string, Action> m_sortMap;
        private Dictionary<string, SortExtension.Direction> m_sortDirection;

        public Dictionary<string, Action> SortMap { get => m_sortMap; }

        struct PropertyNames
        {
            public static readonly string Name = "Name";
            public static readonly string Size = "Size";
            public static readonly string Resolution = "Resolution";
        }

        public ContentModel()
        {
            m_contentFactory = new ImageFactory();
            m_imageCollection = new ObservableCollection<Content>();

            m_sortDirection = new Dictionary<string, SortExtension.Direction>
            {
                { PropertyNames.Name, SortExtension.Direction.Ascending },
                { PropertyNames.Size, SortExtension.Direction.Ascending },
                { PropertyNames.Resolution, SortExtension.Direction.Ascending }
            };

            m_sortMap = new Dictionary<string, Action>
            {
                {
                    PropertyNames.Name,
                    delegate
                    {
                        if (m_sortDirection[PropertyNames.Name] == SortExtension.Direction.Ascending)
                        {
                            m_imageCollection.Sort(x => x.Name);
                            m_sortDirection[PropertyNames.Name] = SortExtension.Direction.Descending;
                        }
                        else
                        {
                            m_imageCollection.SortDescending(x => x.Name);
                            m_sortDirection[PropertyNames.Name] = SortExtension.Direction.Ascending;
                        }
                    }
                },
                {
                    PropertyNames.Size,
                    delegate
                    {
                        if (m_sortDirection[PropertyNames.Size] == SortExtension.Direction.Ascending)
                        {
                            m_imageCollection.Sort(x => x.Size);
                            m_sortDirection[PropertyNames.Size] = SortExtension.Direction.Descending;
                        }
                        else
                        {
                            m_imageCollection.SortDescending(x => x.Size);
                            m_sortDirection[PropertyNames.Size] = SortExtension.Direction.Ascending;
                        }
                    }
                },
                {
                    PropertyNames.Resolution,
                    delegate
                    {
                        if (m_sortDirection[PropertyNames.Resolution] == SortExtension.Direction.Ascending)
                        {
                            m_imageCollection.Sort(x => x.Resolution);
                            m_sortDirection[PropertyNames.Resolution] = SortExtension.Direction.Descending;
                        }
                        else
                        {
                            m_imageCollection.SortDescending(x => x.Resolution);
                            m_sortDirection[PropertyNames.Resolution] = SortExtension.Direction.Ascending;
                        }
                    }
                }
            };
        }

        public void SetContentList(List<FileInfo> items)
        {
            m_imageCollection.Clear();
            foreach (var item in items)
            {
                m_imageCollection.Add(m_contentFactory.Create(
                    item.Name,
                    item.Extension,
                    item.FullName,
                    item.Length)
                );
            }
        }

        public ObservableCollection<Content> GetContentList()
        {
            return m_imageCollection;
        }
    }
}
