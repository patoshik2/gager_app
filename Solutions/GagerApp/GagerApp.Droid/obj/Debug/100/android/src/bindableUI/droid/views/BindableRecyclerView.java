package bindableUI.droid.views;


public class BindableRecyclerView
	extends androidx.recyclerview.widget.RecyclerView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_dispatchSetSelected:(Z)V:GetDispatchSetSelected_ZHandler\n" +
			"n_setAdapter:(Landroidx/recyclerview/widget/RecyclerView$Adapter;)V:GetSetAdapter_Landroidx_recyclerview_widget_RecyclerView_Adapter_Handler\n" +
			"n_finalize:()V:GetJavaFinalizeHandler\n" +
			"n_onDetachedFromWindow:()V:GetOnDetachedFromWindowHandler\n" +
			"";
		mono.android.Runtime.register ("BindableUI.Droid.Views.BindableRecyclerView, BindableUI.Droid", BindableRecyclerView.class, __md_methods);
	}


	public BindableRecyclerView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == BindableRecyclerView.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Views.BindableRecyclerView, BindableUI.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public BindableRecyclerView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == BindableRecyclerView.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Views.BindableRecyclerView, BindableUI.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public BindableRecyclerView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == BindableRecyclerView.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Views.BindableRecyclerView, BindableUI.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public void dispatchSetSelected (boolean p0)
	{
		n_dispatchSetSelected (p0);
	}

	private native void n_dispatchSetSelected (boolean p0);


	public void setAdapter (androidx.recyclerview.widget.RecyclerView.Adapter p0)
	{
		n_setAdapter (p0);
	}

	private native void n_setAdapter (androidx.recyclerview.widget.RecyclerView.Adapter p0);


	public void finalize ()
	{
		n_finalize ();
	}

	private native void n_finalize ();


	public void onDetachedFromWindow ()
	{
		n_onDetachedFromWindow ();
	}

	private native void n_onDetachedFromWindow ();

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
