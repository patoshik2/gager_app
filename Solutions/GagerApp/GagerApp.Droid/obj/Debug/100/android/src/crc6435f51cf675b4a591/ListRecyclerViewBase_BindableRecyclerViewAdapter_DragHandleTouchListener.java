package crc6435f51cf675b4a591;


public class ListRecyclerViewBase_BindableRecyclerViewAdapter_DragHandleTouchListener
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnTouchListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouch:(Landroid/view/View;Landroid/view/MotionEvent;)Z:GetOnTouch_Landroid_view_View_Landroid_view_MotionEvent_Handler:Android.Views.View/IOnTouchListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("BindableUI.Droid.Views.ListRecyclerViewBase+BindableRecyclerViewAdapter+DragHandleTouchListener, BindableUI.Droid", ListRecyclerViewBase_BindableRecyclerViewAdapter_DragHandleTouchListener.class, __md_methods);
	}


	public ListRecyclerViewBase_BindableRecyclerViewAdapter_DragHandleTouchListener ()
	{
		super ();
		if (getClass () == ListRecyclerViewBase_BindableRecyclerViewAdapter_DragHandleTouchListener.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Views.ListRecyclerViewBase+BindableRecyclerViewAdapter+DragHandleTouchListener, BindableUI.Droid", "", this, new java.lang.Object[] {  });
	}

	public ListRecyclerViewBase_BindableRecyclerViewAdapter_DragHandleTouchListener (crc64939f38f4a8d262b7.BindableViewHolder_1 p0, crc6435f51cf675b4a591.ListRecyclerViewBase_BindableRecyclerViewAdapter p1)
	{
		super ();
		if (getClass () == ListRecyclerViewBase_BindableRecyclerViewAdapter_DragHandleTouchListener.class)
			mono.android.TypeManager.Activate ("BindableUI.Droid.Views.ListRecyclerViewBase+BindableRecyclerViewAdapter+DragHandleTouchListener, BindableUI.Droid", "BindableUI.Droid.Adapters.BindableViewHolder`1<System.Object>, BindableUI.Droid:BindableUI.Droid.Views.ListRecyclerViewBase+BindableRecyclerViewAdapter, BindableUI.Droid", this, new java.lang.Object[] { p0, p1 });
	}


	public boolean onTouch (android.view.View p0, android.view.MotionEvent p1)
	{
		return n_onTouch (p0, p1);
	}

	private native boolean n_onTouch (android.view.View p0, android.view.MotionEvent p1);

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
