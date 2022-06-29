package crc64f23614019d391eb1;


public class ActionDialog
	extends android.app.Dialog
	implements
		mono.android.IGCUserPeer,
		android.view.View.OnClickListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_cancel:()V:GetCancelHandler\n" +
			"n_dismiss:()V:GetDismissHandler\n" +
			"n_onAttachedToWindow:()V:GetOnAttachedToWindowHandler\n" +
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onClick:(Landroid/view/View;)V:GetOnClick_Landroid_view_View_Handler:Android.Views.View/IOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("Calcium.UI.Elements.ActionDialog, Calcium.Extras.Platform", ActionDialog.class, __md_methods);
	}


	public ActionDialog (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ActionDialog.class)
			mono.android.TypeManager.Activate ("Calcium.UI.Elements.ActionDialog, Calcium.Extras.Platform", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public ActionDialog (android.content.Context p0, boolean p1, android.content.DialogInterface.OnCancelListener p2)
	{
		super (p0, p1, p2);
		if (getClass () == ActionDialog.class)
			mono.android.TypeManager.Activate ("Calcium.UI.Elements.ActionDialog, Calcium.Extras.Platform", "Android.Content.Context, Mono.Android:System.Boolean, mscorlib:Android.Content.IDialogInterfaceOnCancelListener, Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ActionDialog (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == ActionDialog.class)
			mono.android.TypeManager.Activate ("Calcium.UI.Elements.ActionDialog, Calcium.Extras.Platform", "Android.Content.Context, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public void cancel ()
	{
		n_cancel ();
	}

	private native void n_cancel ();


	public void dismiss ()
	{
		n_dismiss ();
	}

	private native void n_dismiss ();


	public void onAttachedToWindow ()
	{
		n_onAttachedToWindow ();
	}

	private native void n_onAttachedToWindow ();


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onClick (android.view.View p0)
	{
		n_onClick (p0);
	}

	private native void n_onClick (android.view.View p0);

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
