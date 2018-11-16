using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace PrismAppV7Sample.Core.Models
{
    public class DirectoryNode : FileSystemNode
    {
        private DirectoryInfo _value;
        new public DirectoryInfo Value
        {
            get => this._value;
            private set
            {
                this.SetProperty(ref this._value, value);
                this.Name = value.Name;
                this.FullName = value.FullName;
                if (value.GetFileSystemInfos().Any())
                {
                    this._children.Add(new FileSystemNode());
                }
            }
        }

        public DirectoryNode(string path)
        {
            this.Children = new ReadOnlyObservableCollection<FileSystemNode>(this._children);
            this.Value = new DirectoryInfo(path);
        }

        public DirectoryNode(DirectoryInfo directory)
        {
            this.Children = new ReadOnlyObservableCollection<FileSystemNode>(this._children);
            this.Value = directory;
        }

        public DirectoryNode(string path, DirectoryNode parent)
        {
            this.Children = new ReadOnlyObservableCollection<FileSystemNode>(this._children);
            this.Value = new DirectoryInfo(path);
            this.Parent = parent;
        }

        public DirectoryNode(DirectoryInfo directory, DirectoryNode parent)
        {
            this.Children = new ReadOnlyObservableCollection<FileSystemNode>(this._children);
            this.Value = directory;
            this.Parent = parent;
        }

        public override void OnExpanded()
        {
            this._children.Clear();
            foreach (var item in this.Value.GetFileSystemInfos().OrderBy(x => (x.Attributes & FileAttributes.Directory) != FileAttributes.Directory))
            {
                try
                {
                    if (item is DirectoryInfo dir) this._children.Add(new DirectoryNode(dir, this));
                    else if (item is FileInfo file) this._children.Add(new FileNode(file, this));
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
