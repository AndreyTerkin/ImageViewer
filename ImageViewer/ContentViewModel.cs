﻿using System;
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
        private List<Content> m_contentList;
        private Content m_selectedItem;

        private readonly ICommand m_openCommand;

        public ContentViewModel(ContentModel contentModel)
        {
            m_contentModel = contentModel;
            m_openCommand = new OpenDirectoryCommand(this);
        }

        public List<Content> ContentList
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
