using Prism.Common;
using Prism.Regions;
using PrismAppV7Sample.Core.Models;
using PrismAppV7Sample.TreeExplorerModule.ViewModels;
using System.Windows.Controls;

namespace PrismAppV7Sample.TreeExplorerModule.Views
{
    /// <summary>
    /// Interaction logic for TreeExplorer
    /// </summary>
    public partial class TreeExplorer : UserControl
    {
        public TreeExplorer()
        {
            InitializeComponent();
            RegionContext.GetObservableContext(this).PropertyChanged += (sender, e) =>
            {
                var context = (ObservableObject<object>)sender;
                var root = (DirectoryNode)context.Value;
                var rootDirs = (DataContext as TreeExplorerViewModel).RootDirectories;
                rootDirs.Clear();
                rootDirs.Add(root);
            };
        }
    }
}
