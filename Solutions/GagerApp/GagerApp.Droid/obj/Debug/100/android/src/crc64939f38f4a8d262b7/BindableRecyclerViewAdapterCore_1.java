package crc64939f38f4a8d262b7;


public abstract class BindableRecyclerViewAdapterCore_1
	extends androidx.recyclerview.widget.RecyclerView.Adapter
	implements
		mono.android.IGCUserPeer,
		androidx.recyclerview.widget.RecyclerView.RecyclerListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getItemViewType:(I)I:GetGetItemViewType_IHandler\n" +
			"n_onAttachedToRecyclerView:(Landroidx/recyclerview/widget/RecyclerView;)V:GetOnAttachedToRecyclerView_Landroidx_recyclerview_widget_RecyclerView_Handler\n" +
			"n_onBindViewHolder:(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;I)V:GetOnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_IHandler\n" +
			"n_onBindViewHolder:(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;ILjava/util/List;)V:GetOnBindViewHolder_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_ILjava_util_List_Handler\n" +
			"n_onCreateViewHolder:(Landroid/view/ViewGroup;I)Landroidx/recyclerview/widget/RecyclerView$ViewHolder;:GetOnCreateViewHolder_Landroid_view_ViewGroup_IHandler\n" +
			"n_onDetachedFromRecyclerView:(Landroidx/recyclerview/widget/RecyclerView;)V:GetOnDetachedFromRecyclerView_Landroidx_recyclerview_widget_RecyclerView_Handler\n" +
			"n_onViewRecycled:(Landroidx/recyclerview/widget/RecyclerView$ViewHolder;)V:GetOnViewRecycled_Landroidx_recyclerview_widget_RecyclerView_ViewHolder_Handler:AndroidX.RecyclerView.Widget.RecyclerView/IRecyclerListenerInvoker, Xamarin.AndroidX.RecyclerView\n" +
			"";
		mono.android.Runtime.register ("BindableUI.Droid.Adapters.BindableRecyclerViewAdapterCore`1, BindableUI.Droid", BindableRecyclerViewAdapterCore_1.class, __md_methods);
	}


	public BindableRecyclerViewAdapterCore_1 ()
	{
		super ();
		if (getClass () == BindableRecyclerViewAdapterCore_1.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Adapters.BindableRecyclerViewAdapterCore`1, BindableUI.Droid", "", this, new java.lang.Object[] {  });
	}


	public int getItemViewType (int p0)
	{
		return n_getItemViewType (p0);
	}

	private native int n_getItemViewType (int p0);


	public void onAttachedToRecyclerView (androidx.recyclerview.widget.RecyclerView p0)
	{
		n_onAttachedToRecyclerView (p0);
	}

	private native void n_onAttachedToRecyclerView (androidx.recyclerview.widget.RecyclerView p0);


	public void onBindViewHolder (androidx.recyclerview.widget.RecyclerView.ViewHolder p0, int p1)
	{
		n_onBindViewHolder (p0, p1);
	}

	private native void n_onBindViewHolder (androidx.recyclerview.widget.RecyclerView.ViewHolder p0, int p1);


	public void onBindViewHolder (androidx.recyclerview.widget.RecyclerView.ViewHolder p0, int p1, java.util.List p2)
	{
		n_onBindViewHolder (p0, p1, p2);
	}

	private native void n_onBindViewHolder (androidx.recyclerview.widget.RecyclerView.ViewHolder p0, int p1, java.util.List p2);


	public androidx.recyclerview.widget.RecyclerView.ViewHolder onCreateViewHolder (android.view.ViewGroup p0, int p1)
	{
		return n_onCreateViewHolder (p0, p1);
	}

	private native androidx.recyclerview.widget.RecyclerView.ViewHolder n_onCreateViewHolder (android.view.ViewGroup p0, int p1);


	public void onDetachedFromRecyclerView (androidx.recyclerview.widget.RecyclerView p0)
	{
		n_onDetachedFromRecyclerView (p0);
	}

	private native void n_onDetachedFromRecyclerView (androidx.recyclerview.widget.RecyclerView p0);


	public void onViewRecycled (androidx.recyclerview.widget.RecyclerView.ViewHolder p0)
	{
		n_onViewRecycled (p0);
	}

	private native void n_onViewRecycled (androidx.recyclerview.widget.RecyclerView.ViewHolder p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
