package crc6435f51cf675b4a591;


public class ListRecyclerViewBase_BindableRecyclerViewAdapter
	extends crc64939f38f4a8d262b7.SingleSelectionAdapterCore_1
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getItemCount:()I:GetGetItemCountHandler\n" +
			"";
		mono.android.Runtime.register ("BindableUI.Droid.Views.ListRecyclerViewBase+BindableRecyclerViewAdapter, BindableUI.Droid", ListRecyclerViewBase_BindableRecyclerViewAdapter.class, __md_methods);
	}


	public ListRecyclerViewBase_BindableRecyclerViewAdapter ()
	{
		super ();
		if (getClass () == ListRecyclerViewBase_BindableRecyclerViewAdapter.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Views.ListRecyclerViewBase+BindableRecyclerViewAdapter, BindableUI.Droid", "", this, new java.lang.Object[] {  });
	}


	public int getItemCount ()
	{
		return n_getItemCount ();
	}

	private native int n_getItemCount ();

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
