using PrismAppV7Sample.TreeExplorerModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismAppV7Sample.Core;

namespace PrismAppV7Sample.TreeExplorerModule
{
    public class TreeExplorerModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public TreeExplorerModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {      
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TreeExplorer>();
            this._regionManager.RequestNavigate(RegionNames.TreeExplorerRegion, nameof(TreeExplorer));
        }
    }
}