using System.IO;

namespace PrismAppV7Sample.Core.Models
{
    public class FileNode : FileSystemNode
    {
        private FileInfo _value;
        new public FileInfo Value
        {
            get => this._value;
            protected set
            {
                this.SetProperty(ref this._value, value);
                this.Name = value.Name;
                this.FullName = value.FullName;
            }
        }

        public FileNode(string path)
        {
            this.Value = new FileInfo(path);
        }

        public FileNode(FileInfo file)
        {
            this.Value = file;
        }

        public FileNode(string path, FileSystemNode parent)
        {
            this.Value = new FileInfo(path);
            this.Parent = parent;
        }

        public FileNode(FileInfo file, FileSystemNode parent)
        {
            this.Value = file;
            this.Parent = parent;
        }
    }
}
