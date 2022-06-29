package bindableUI.droid.views;


public class BindableButton
	extends com.google.android.material.button.MaterialButton
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_requestRectangleOnScreen:(Landroid/graphics/Rect;Z)Z:GetRequestRectangleOnScreen_Landroid_graphics_Rect_ZHandler\n" +
			"n_finalize:()V:GetJavaFinalizeHandler\n" +
			"";
		mono.android.Runtime.register ("BindableUI.Droid.Views.BindableButton, BindableUI.Droid", BindableButton.class, __md_methods);
	}


	public BindableButton (android.content.Context p0)
	{
		super (p0);
		if (getClass () == BindableButton.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Views.BindableButton, BindableUI.Droid", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public BindableButton (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == BindableButton.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Views.BindableButton, BindableUI.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public BindableButton (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == BindableButton.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Views.BindableButton, BindableUI.Droid", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public boolean requestRectangleOnScreen (android.graphics.Rect p0, boolean p1)
	{
		return n_requestRectangleOnScreen (p0, p1);
	}

	private native boolean n_requestRectangleOnScreen (android.graphics.Rect p0, boolean p1);


	public void finalize ()
	{
		n_finalize ();
	}

	private native void n_finalize ();

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
