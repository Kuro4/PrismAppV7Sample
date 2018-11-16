using Prism.Events;
using PrismAppV7Sample.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismAppV7Sample.Core.EventAggregators
{
    public class SelectedDirectoryChangedEvent : PubSubEvent<DirectoryNode>
    {
    }
}
