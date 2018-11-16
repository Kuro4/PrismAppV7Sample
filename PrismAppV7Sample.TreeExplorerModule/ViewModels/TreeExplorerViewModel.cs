using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismAppV7Sample.Core.EventAggregators;
using PrismAppV7Sample.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismAppV7Sample.TreeExplorerModule.ViewModels
{
    public class TreeExplorerViewModel : BindableBase
    {
        private ObservableCollection<DirectoryNode> _rootDirectories = new ObservableCollection<DirectoryNode>();
        public ObservableCollection<DirectoryNode> RootDirectories
        {
            get => this._rootDirectories;
            set => this.SetProperty(ref this._rootDirectories, value);
        }

        private FileSystemNode _selectedNode;
        public FileSystemNode SelectedNode
        {
            get => this._selectedNode;
            set
            {
                this.SetProperty(ref this._selectedNode, value);
                switch (value)
                {
                    case DirectoryNode dir:
                        this.SelectedDirectoryNode = dir;
                        break;
                    case FileNode file:
                        this.SelectedFileNode = file;
                        break;
                    default:
                        break;
                }                
            }
        }

        private DirectoryNode _selectedDirectoryNode;
        public DirectoryNode SelectedDirectoryNode
        {
            get => this._selectedDirectoryNode;
            private set
            {
                if(this._selectedDirectoryNode?.FullName != value.FullName) this._eventAggregator.GetEvent<SelectedDirectoryChangedEvent>().Publish(value);
                this.SetProperty(ref this._selectedDirectoryNode, value);
            }
        }

        private FileNode _selectedFileNode;
        public FileNode SelectedFileNode
        {
            get => this._selectedFileNode;
            private set
            {
                this.SetProperty(ref this._selectedFileNode, value);
            }
        }

        public DelegateCommand<FileSystemNode> SelectedItemChangedCommand { get; private set; }

        private readonly IEventAggregator _eventAggregator;
        
        public TreeExplorerViewModel(IEventAggregator eventAggregator)
        {
            this._eventAggregator = eventAggregator;
            this.SelectedItemChangedCommand = new DelegateCommand<FileSystemNode>(x => this.SelectedNode = x);
        }
    }
}
