using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Windows.Input;
using AndroidX.RecyclerView.Widget;
using Calcium.UI.Data;

namespace BindableUI.Droid.Adapters
{
    public class BindableViewHolder<T> : RecyclerView.ViewHolder
    {
        #region Fields

        private readonly int _resourceId;
        private readonly XmlBindingApplicator _bindingApplicator;
        private Action<int, T> _clickCalback;

        #endregion Fields

        #region Constructors/Finalizers

        public BindableViewHolder(int resId, ViewGroup parent)
            : base(LayoutInflater.FromContext(parent.Context).Inflate(resId, parent, false))
        {
            _resourceId = resId;
            _bindingApplicator = new XmlBindingApplicator();
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public T DataContext
        {
            get;
            private set;
        }

        #endregion Properties/Indexers

        #region Methods/Events

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardViewModel"></param>
        /// <param name="clickCallback">
        /// Action to execute on <see cref="RecyclerView.ViewHolder.ItemView"/> click.
        /// Integer parameter will be <see cref="RecyclerView.ViewHolder.AdapterPosition"/>, <typeparamref name="T"/> is <paramref name="cardViewModel"/>
        /// </param>
        public void Bind(T cardViewModel, Action<int, T> clickCallback)
        {
            //Preventive unbinding
            Unbind();

            //Bind data to card
            DataContext = cardViewModel;
            _bindingApplicator.ApplyBindings(ItemView, cardViewModel, _resourceId);

            //Bind additional click handler to invoke callback
            _clickCalback = clickCallback;
            if (_clickCalback != null)
            {
                ItemView.Click += ContentView_Click;
            }
        }

        public void Unbind()
        {
            _bindingApplicator.RemoveBindings();
            //Unbind previous click handler
            ItemView.Click -= ContentView_Click;
        }

        private void ContentView_Click(object sender, EventArgs e)
        {
            _clickCalback?.Invoke(AdapterPosition, DataContext);
        }

        #endregion Methods/Events
    }
}
