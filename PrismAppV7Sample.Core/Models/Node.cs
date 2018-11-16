using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismAppV7Sample.Core.Models
{
    public abstract class Node<T> : BindableBase, INode<T>
    {
        private T _value;
        public T Value
        {
            get => this._value;
            protected set => this.SetProperty(ref this._value, value);
        }

        private string _name;
        public string Name
        {
            get => this._name;
            protected set => this.SetProperty(ref this._name, value);
        }

        private INode<T> _parent;
        public INode<T> Parent
        {
            get => this._parent;
            protected set => this.SetProperty(ref this._parent, value);
        }

        private IEnumerable<INode<T>> _children;
        public IEnumerable<INode<T>> Children
        {
            get => this._children;
            protected set => this.SetProperty(ref this._children, value);
        }

        private bool _isExpanded;
        public bool IsExpanded
        {
            get => this._isExpanded;
            set
            {
                if (!this._isExpanded && value) this.OnExpanded();
                else if (this._isExpanded && !value) this.OnCollapsed();
                this.SetProperty(ref this._isExpanded, value);
            }
        }

        public abstract void OnCollapsed();
        public abstract void OnExpanded();
    }
}
