package crc64939f38f4a8d262b7;


public class BindableViewHolder_1
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("BindableUI.Droid.Adapters.BindableViewHolder`1, BindableUI.Droid", BindableViewHolder_1.class, __md_methods);
	}


	public BindableViewHolder_1 (android.view.View p0)
	{
		super (p0);
		if (getClass () == BindableViewHolder_1.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Adapters.BindableViewHolder`1, BindableUI.Droid", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
