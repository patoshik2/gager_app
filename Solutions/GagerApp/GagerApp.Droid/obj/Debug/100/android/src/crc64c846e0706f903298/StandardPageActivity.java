package crc64c846e0706f903298;


public class StandardPageActivity
	extends crc64c846e0706f903298.BaseActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onOptionsItemSelected:(Landroid/view/MenuItem;)Z:GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler\n" +
			"n_setContentView:(Landroid/view/View;)V:GetSetContentView_Landroid_view_View_Handler\n" +
			"";
		mono.android.Runtime.register ("GagerApp.Droid.Activities.StandardPageActivity, GagerApp.Droid", StandardPageActivity.class, __md_methods);
	}


	public StandardPageActivity ()
	{
		super ();
		if (getClass () == StandardPageActivity.class)
			mono.android.TypeManager.Activate ("GagerApp.Droid.Activities.StandardPageActivity, GagerApp.Droid", "", this, new java.lang.Object[] {  });
	}


	public StandardPageActivity (int p0)
	{
		super (p0);
		if (getClass () == StandardPageActivity.class)
			mono.android.TypeManager.Activate ("GagerApp.Droid.Activities.StandardPageActivity, GagerApp.Droid", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public boolean onOptionsItemSelected (android.view.MenuItem p0)
	{
		return n_onOptionsItemSelected (p0);
	}

	private native boolean n_onOptionsItemSelected (android.view.MenuItem p0);


	public void setContentView (android.view.View p0)
	{
		n_setContentView (p0);
	}

	private native void n_setContentView (android.view.View p0);

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
