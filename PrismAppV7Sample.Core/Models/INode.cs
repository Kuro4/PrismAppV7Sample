using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;

namespace PrismAppV7Sample.Core.Models
{
    public interface INode<T>
    {
        T Value { get; }
        string Name { get; }
        INode<T> Parent { get; }
        IEnumerable<INode<T>> Children { get; }
        bool IsExpanded { get; set; }

        void OnExpanded();
        void OnCollapsed();
    }
}
