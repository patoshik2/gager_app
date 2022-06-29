package crc6435f51cf675b4a591;


public abstract class ListRecyclerViewBase
	extends android.widget.FrameLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getLayoutParams:()Landroid/view/ViewGroup$LayoutParams;:GetGetLayoutParametersHandler\n" +
			"n_setLayoutParams:(Landroid/view/ViewGroup$LayoutParams;)V:GetSetLayoutParameters_Landroid_view_ViewGroup_LayoutParams_Handler\n" +
			"n_setClipToPadding:(Z)V:GetSetClipToPadding_ZHandler\n" +
			"n_onAttachedToWindow:()V:GetOnAttachedToWindowHandler\n" +
			"n_onDetachedFromWindow:()V:GetOnDetachedFromWindowHandler\n" +
			"";
		mono.android.Runtime.register ("BindableUI.Droid.Views.ListRecyclerViewBase, BindableUI.Droid", ListRecyclerViewBase.class, __md_methods);
	}


	public ListRecyclerViewBase (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ListRecyclerViewBase.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Views.ListRecyclerViewBase, BindableUI.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ListRecyclerViewBase (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ListRecyclerViewBase.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Views.ListRecyclerViewBase, BindableUI.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ListRecyclerViewBase (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ListRecyclerViewBase.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Views.ListRecyclerViewBase, BindableUI.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ListRecyclerViewBase (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == ListRecyclerViewBase.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Views.ListRecyclerViewBase, BindableUI.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public android.view.ViewGroup.LayoutParams getLayoutParams ()
	{
		return n_getLayoutParams ();
	}

	private native android.view.ViewGroup.LayoutParams n_getLayoutParams ();


	public void setLayoutParams (android.view.ViewGroup.LayoutParams p0)
	{
		n_setLayoutParams (p0);
	}

	private native void n_setLayoutParams (android.view.ViewGroup.LayoutParams p0);


	public void setClipToPadding (boolean p0)
	{
		n_setClipToPadding (p0);
	}

	private native void n_setClipToPadding (boolean p0);


	public void onAttachedToWindow ()
	{
		n_onAttachedToWindow ();
	}

	private native void n_onAttachedToWindow ();


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
