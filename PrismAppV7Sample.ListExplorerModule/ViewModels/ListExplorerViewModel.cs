using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using PrismAppV7Sample.Core.EventAggregators;
using PrismAppV7Sample.Core.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismAppV7Sample.ListExplorerModule.ViewModels
{
    public class ListExplorerViewModel : BindableBase
    {
        private ObservableCollection<FileSystemNode> _fileSystemNodes = new ObservableCollection<FileSystemNode>();
        public ReadOnlyObservableCollection<FileSystemNode> FileSystemNodes { get; private set; }

        private readonly IEventAggregator _eventAggregator;

        public ListExplorerViewModel(IEventAggregator eventAggregator)
        {
            this.FileSystemNodes = new ReadOnlyObservableCollection<FileSystemNode>(this._fileSystemNodes);

            this._eventAggregator = eventAggregator;
            this._eventAggregator.GetEvent<SelectedDirectoryChangedEvent>().Subscribe(x =>
            {
                this._fileSystemNodes.Clear();
                x.IsExpanded = true;
                this._fileSystemNodes.AddRange(x.Children);
            });
        }
    }
}
