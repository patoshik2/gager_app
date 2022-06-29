package crc64c846e0706f903298;


public class CommonDialogFragment
	extends crc64c846e0706f903298.BaseDialogFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onResume:()V:GetOnResumeHandler\n" +
			"n_onPause:()V:GetOnPauseHandler\n" +
			"";
		mono.android.Runtime.register ("GagerApp.Droid.Activities.CommonDialogFragment, GagerApp.Droid", CommonDialogFragment.class, __md_methods);
	}


	public CommonDialogFragment ()
	{
		super ();
		if (getClass () == CommonDialogFragment.class)
			mono.android.TypeManager.Activate ("GagerApp.Droid.Activities.CommonDialogFragment, GagerApp.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();


	public void onPause ()
	{
		n_onPause ();
	}

	private native void n_onPause ();

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
