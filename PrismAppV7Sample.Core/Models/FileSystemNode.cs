using Prism.Mvvm;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace PrismAppV7Sample.Core.Models
{
    public class FileSystemNode : Node<FileSystemInfo>
    {
        private FileSystemInfo _value;
        public new FileSystemInfo Value
        {
            get => this._value;
            protected set
            {
                this.SetProperty(ref this._value, value);
                this.Name = value.Name;
                this.FullName = value.FullName;

            }
        }

        private string _fullName;
        public string FullName
        {
            get => this._fullName;
            protected set => this.SetProperty(ref this._fullName, value);
        }

        private FileSystemNode _parent;
        public new FileSystemNode Parent
        {
            get => this._parent;
            protected set => this.SetProperty(ref _parent, value);
        }

        protected readonly ObservableCollection<FileSystemNode> _children = new ObservableCollection<FileSystemNode>();
        public new ReadOnlyObservableCollection<FileSystemNode> Children { get; protected set; }
        

        public FileSystemNode()
        {
            this.Children = new ReadOnlyObservableCollection<FileSystemNode>(this._children);
        }

        public FileSystemNode(FileSystemNode parent)
        {
            this.Parent = parent;
        }

        public override void OnCollapsed()
        {
        }

        public override void OnExpanded()
        {
        }

        public override string ToString()
        {
            return this.FullName;
        }
    }
}
