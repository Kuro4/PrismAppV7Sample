using PrismAppV7Sample.ListExplorerModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using PrismAppV7Sample.Core;

namespace PrismAppV7Sample.ListExplorerModule
{
    public class ListExplorerModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public ListExplorerModule(IRegionManager regionManager)
        {
            this._regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ListExplorer>();
            this._regionManager.RequestNavigate(RegionNames.ListExplorerRegion, nameof(ListExplorer));
        }
    }
}