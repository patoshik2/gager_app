using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using TomsToolbox.Essentials;
using TomsToolbox.ObservableCollections;

namespace GagerApp.Core.Utils
{
    public static class ObservableSortedCollectionExtensions
    {
        #region Methods/Events

        public static void SortByPropertyName<T>(this ObservableSortedCollection<T> collection, string propertyName, bool descending)
        {
            collection.Comparer = new PropertyComparer<T>(propertyName, descending);
        }

        #endregion Methods/Events
    }

    /// <summary>
    /// The collection is read-only, though it does implement <see cref="IList{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ObservableSortedCollection<T> : ReadOnlyObservableCollectionAdapter<T, ObservableCollection<T>>
    {
        #region Fields

        private IComparer<T> _comparer = null;

        #endregion Fields

        #region Constructors/Finalizers

        public ObservableSortedCollection(IEnumerable<T> sourceCollection)
            : base(new ObservableCollection<T>(sourceCollection))
        {
            if (sourceCollection == null)
            {
                throw new ArgumentNullException(nameof(sourceCollection));
            }

            var eventSource = sourceCollection as INotifyCollectionChanged;
            if (eventSource != null)
            {
                eventSource.CollectionChanged += SourceCollection_CollectionChanged;
            }
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public IComparer<T> Comparer
        {
            get => _comparer;
            set
            {
                if (_comparer != value)
                {
                    _comparer = value;
                    ReorderCollection();
                }
            }
        }

        #endregion Properties/Indexers

        #region Methods/Events

        protected virtual void InsertItem(int index, T item)
        {
            AttachPropertyChangedHandler(item);
            if (_comparer == null)
            {
                Items.Insert(index, item);
                return;
            }

            //TODO: consider a faster algorythm
            for (int i = 0; i < Count; i++)
            {
                if (_comparer.Compare(item, Items[i]) <= 0)
                {
                    Items.Insert(i, item);
                    return;
                }
            }

            Items.Insert(Count, item);
        }

        protected virtual void RemoveItem(int index)
        {
            T item = Items[index];
            DetachPropertyChangedHandler(item);
            Items.RemoveAt(index);
        }

        protected virtual void SetItem(int index, T item)
        {
            RemoveItem(index);
            InsertItem(index, item);
        }

        private void AttachPropertyChangedHandler(T item)
        {
            INotifyPropertyChanged castedItem = item as INotifyPropertyChanged;
            if (castedItem != null)
            {
                castedItem.PropertyChanged -= Item_PropertyChanged;
                castedItem.PropertyChanged += Item_PropertyChanged;
            }
        }

        private void DetachPropertyChangedHandler(T item)
        {
            INotifyPropertyChanged castedItem = item as INotifyPropertyChanged;
            if (castedItem != null)
            {
                castedItem.PropertyChanged -= Item_PropertyChanged;
            }
        }

        [WeakEventHandler.MakeWeak]
        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (_comparer != null)
            {
                T item = (T)sender;
                int itemIndex = Items.IndexOf(item);

                bool previousItemIsSmaller = (itemIndex == 0) || (_comparer.Compare(item, Items[itemIndex - 1]) >= 0);
                bool nextItemIsBigger = (itemIndex == Count - 1) || (_comparer.Compare(item, Items[itemIndex + 1]) <= 0);

                if (!(nextItemIsBigger && previousItemIsSmaller))
                {
                    SetItem(itemIndex, item);
                }
            }
        }

        private void ReorderCollection()
        {
            //TODO: try to reorder without clearing
            var orderedCollection = this.OrderBy((x) => x, _comparer ?? Comparer<T>.Default).ToList();

            Items.Clear();

            foreach (var item in orderedCollection)
            {
                AttachPropertyChangedHandler(item);
                Items.Add(item);
            }
        }

        [WeakEventHandler.MakeWeak]
        private void SourceCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            int newIndex = e.NewStartingIndex;
            int oldIndex = e.OldStartingIndex;
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems?.Cast<T>())
                    {
                        InsertItem(newIndex, item);
                        newIndex++;
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems?.Cast<T>())
                    {
                        RemoveItem(Items.IndexOf(item));
                    }
                    break;

                case NotifyCollectionChangedAction.Reset:
                    foreach (var item in Items)
                    {
                        DetachPropertyChangedHandler(item);
                    }
                    Items.Clear();
                    foreach (var item in ((IEnumerable)sender).Cast<T>())
                    {
                        InsertItem(Count, item);
                    }
                    break;

                case NotifyCollectionChangedAction.Replace:
                    foreach (var item in e.OldItems?.Cast<T>())
                    {
                        RemoveItem(Items.IndexOf(item));
                    }
                    foreach (var item in e.NewItems?.Cast<T>())
                    {
                        InsertItem(newIndex, item);
                        newIndex++;
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    //TODO: check correctness
                    foreach (var item in e.OldItems?.Cast<T>())
                    {
                        RemoveItem(Items.IndexOf(item));
                    }
                    foreach (var item in e.NewItems?.Cast<T>())
                    {
                        InsertItem(newIndex, item);
                        newIndex++;
                    }
                    break;

                default:
                    throw new NotImplementedException("Source action not supported");
            }
        }

        #endregion Methods/Events
    }
}
