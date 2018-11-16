using PrismAppV7Sample.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace PrismAppV7Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            //モジュールの登録
            moduleCatalog.AddModule<ListExplorerModule.ListExplorerModule>();
            moduleCatalog.AddModule<TreeExplorerModule.TreeExplorerModule>();
        }
    }
}
