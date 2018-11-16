using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using PrismAppV7Sample.Core.Models;
using System.IO;

namespace PrismAppV7Sample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get => this._title;
            set => this.SetProperty(ref this._title, value);
        }

        private DirectoryNode _rootDirectory = new DirectoryNode(@"C:\");
        public DirectoryNode RootDirectory
        {
            get => this._rootDirectory;
            private set => this.SetProperty(ref this._rootDirectory, value);
        }

        public DelegateCommand<string> ChangeRootDirectoryCommand { get; private set; }

        public InteractionRequest<INotification> DirectoryNotExistNotificationRequest { get; } = new InteractionRequest<INotification>();

        public MainWindowViewModel()
        {
            this.ChangeRootDirectoryCommand = new DelegateCommand<string>(x =>
            {
                if (!Directory.Exists(x))
                {
                    this.DirectoryNotExistNotificationRequest.Raise(new Notification()
                    {
                        Title = "DirectoryNotExist",
                        Content = $"指定したディレクトリ【{x}】は存在しません",
                    });
                    return;
                }
                this.RootDirectory = new DirectoryNode(x);
            });
        }
    }
}
