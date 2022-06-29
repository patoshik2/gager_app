package crc64c846e0706f903298;


public class ContainerViewModel
	extends androidx.lifecycle.ViewModel
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("GagerApp.Droid.Activities.ContainerViewModel, GagerApp.Droid", ContainerViewModel.class, __md_methods);
	}


	public ContainerViewModel ()
	{
		super ();
		if (getClass () == ContainerViewModel.class)
			mono.android.TypeManager.Activate ("GagerApp.Droid.Activities.ContainerViewModel, GagerApp.Droid", "", this, new java.lang.Object[] {  });
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
