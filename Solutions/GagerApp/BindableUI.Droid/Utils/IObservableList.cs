using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BindableUI.Droid.Utils
{
    /// <summary>
    /// An essential parts of <see cref="System.Collections.ObjectModel.ObservableCollection{T}"/> interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObservableList<T> :
        IList<T>,
        INotifyPropertyChanged,
        INotifyCollectionChanged
    {
    }

    /// <summary>
    /// A lightweight wrapper over a class that conforms to <see cref="IList"/>, <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/>
    /// </summary>
    public class ObservableList : IObservableList<object>
    {
        private readonly IList _itemsList;
        private readonly INotifyPropertyChanged _itemsINPC;
        private readonly INotifyCollectionChanged _itemsINCC;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                _itemsINPC.PropertyChanged += value;
            }
            remove
            {
                _itemsINPC.PropertyChanged -= value;
            }
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add
            {
                _itemsINCC.CollectionChanged += value;
            }
            remove
            {
                _itemsINCC.CollectionChanged -= value;
            }
        }

        public int Count => _itemsList.Count;

        public bool IsReadOnly => _itemsList.IsReadOnly;

        public object this[int index]
        {
            get => _itemsList[index];

            set => _itemsList[index] = value;
        }

        /// <summary>
        /// Attempt to adapt given <see cref="IEnumerable"/> to the <see cref="IObservable{Object}"/> interface.
        /// <para>
        /// If "<paramref name="items"/>" complies to <see cref="IList"/>, <see cref="INotifyPropertyChanged"/> and <see cref="INotifyCollectionChanged"/> then it will be wrapped.
        /// </para>
        /// </summary>
        /// <param name="items"></param>
        /// <param name="wrapped"></param>
        /// <returns></returns>
        public static bool TryWrap(IEnumerable items, out IObservableList<object> wrapped)
        {
            wrapped = null;
            if ((items is IList) && (items is INotifyCollectionChanged) && (items is INotifyPropertyChanged))
            {
                wrapped = new ObservableList(items);
                return true;
            }
            return false;
        }

        public int IndexOf(object item)
        {
            return _itemsList.IndexOf(item);
        }

        public void Insert(int index, object item)
        {
            _itemsList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _itemsList.RemoveAt(index);
        }

        public void Add(object item)
        {
            _itemsList.Add(item);
        }

        public void Clear()
        {
            _itemsList.Clear();
        }

        public bool Contains(object item)
        {
            return _itemsList.Contains(item);
        }

        public void CopyTo(object[] array, int arrayIndex)
        {
            _itemsList.CopyTo(array, arrayIndex);
        }

        public bool Remove(object item)
        {
            if (_itemsList.Contains(item))
            {
                _itemsList.Remove(item);
                return true;
            }
            return false;
        }

        public IEnumerator<object> GetEnumerator()
        {
            return new WrapEnumerator(_itemsList.GetEnumerator());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _itemsList.GetEnumerator();
        }

        private ObservableList(IEnumerable items)
        {
            _itemsList = items as IList;
            _itemsINPC = items as INotifyPropertyChanged;
            _itemsINCC = items as INotifyCollectionChanged;
        }

        private class WrapEnumerator : IEnumerator<object>
        {
            private readonly IEnumerator _enumerator;

            public WrapEnumerator(IEnumerator enumerator)
            {
                _enumerator = enumerator;
            }

            public object Current => _enumerator.Current;

            public bool MoveNext()
            {
                return _enumerator.MoveNext();
            }

            public void Reset()
            {
                _enumerator.Reset();
            }

            #region IDisposable Support

            private bool _disposedValue = false; // To detect redundant calls

            protected virtual void Dispose(bool disposing)
            {
                if (!_disposedValue)
                {
                    if (disposing)
                    {
                        // TODO: dispose managed state (managed objects).
                    }

                    // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                    // TODO: set large fields to null.

                    _disposedValue = true;
                }
            }

            // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
            // ~WrapEnumerator() {
            //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            //   Dispose(false);
            // }

            // This code added to correctly implement the disposable pattern.
            public void Dispose()
            {
                // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                Dispose(true);
                // TODO: uncomment the following line if the finalizer is overridden above.
                // GC.SuppressFinalize(this);
            }
            #endregion
        }
    }
}
