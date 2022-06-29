using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using BindableUI.Droid.Utils;
using Google.Android.Material.Button;

namespace BindableUI.Droid.Views
{
    /// <summary>
    /// A button that allows setting fonts via xml layout
    /// Also has a tooltip
    /// </summary>
    [Register("bindableUI.droid.views.BindableButton")]
    public class BindableButton : MaterialButton
    {
        #region Fields

        //private IPopupMenu _attachedPopup;
        //private IBehavior _behavior;
        //private string _behaviorString;
        private bool _bold;
        private ICommand _command;
        private object _commandParameter;
        private bool _italic;
        //private bool _popupShown = false;
        //private AndroidX.AppCompat.Widget.PopupMenu _popupWindow;
        private string _tooltipText;
        private bool _underline;

        #endregion

        #region Properties/Indexers
/*
        public IPopupMenu AttachedPopup
        {
            get => _attachedPopup;
            set
            {
                if (_attachedPopup != value)
                {
                    AttachPopup(value);
                }
            }
        }
*/
/*
        public string BehaviorString
        {
            get => _behaviorString;
            set
            {
                if (_behaviorString != value)
                {
                    _behavior?.Detach();
                    _behaviorString = value;
                    _behavior = Behavior.CreateBehavior(this, _behaviorString);
                }
            }
        }
*/
        public bool Bold
        {
            get => _bold;
            set
            {
                if (_bold != value)
                {
                    _bold = value;
                    UpdateTypeface(Typeface);
                }
            }
        }

        public ICommand Command
        {
            get => _command;
            set
            {
                if (_command != value)
                {
                    UnsubscribeCommand(_command);

                    _command = value;
                    Command_CanExecuteChanged(this, EventArgs.Empty);

                    SubscribeCommand(_command);
                }
            }
        }

        public object CommandParameter
        {
            get => _commandParameter;
            set
            {
                if (_commandParameter != value)
                {
                    _commandParameter = value;
                    Command_CanExecuteChanged(this, EventArgs.Empty);
                }
            }
        }

        public Typeface Font
        {
            get => Typeface;
            set => UpdateTypeface(value);
        }

        public bool Italic
        {
            get => _italic;
            set
            {
                if (_italic != value)
                {
                    _italic = value;
                    UpdateTypeface(Typeface);
                }
            }
        }
/*
        public bool PopupShown
        {
            get => _popupShown;
            set
            {
                if (_popupShown != value)
                {
                    _popupShown = value;
                    OnPopupStateChanged(_popupShown);
                }
            }
        }
*/
        //Since TooltipText is alredy taken and can't be overridden, introduce new property
        //TooltipText does nothing when API < 26, so we need our own.
        public string Tooltip
        {
            get => _tooltipText;
            set
            {
                if (_tooltipText != value)
                {
                    _tooltipText = value;
                    if ((int)Build.VERSION.SdkInt >= (int)Android.OS.BuildVersionCodes.O)
                    {
                        TooltipText = _tooltipText;
                    }
                    else
                    {
                        AndroidX.AppCompat.Widget.TooltipCompat.SetTooltipText(this, _tooltipText);
                    }
                }
            }
        }

        public bool Underline
        {
            get => _underline;
            set
            {
                if (_underline != value)
                {
                    _underline = value;
                    UpdateUnderline();
                }
            }
        }

        #endregion

        #region Methods/Events

        public event EventHandler PopupStateChanged;

        public override bool RequestRectangleOnScreen(Rect rectangle, bool immediate)
        {
            //a fix for AndroidX PopupMenu bug when presenting over RecyclerView
            //see thread: https://stackoverflow.com/questions/29473977/popupmenu-click-causing-recyclerview-to-scroll
            return false;
        }

        protected override void JavaFinalize()
        {
            //On Android 9+ Java finalization occurs separately of .NET finalization.
            //There are oten cases when Java part is already finalized, and .NET is not.
            //So we're forced to track Java finalization.
            UnsubscribeCommand(Command);
            base.JavaFinalize();
        }
/*
        private void AttachPopup(IPopupMenu value)
        {
            //TODO: consider subscribing to IPopupMenu.PopupCommands.CollectionChanged event
            PopupShown = false;
            if (_popupWindow != null)
            {
                _popupWindow.DismissEvent -= PopupWindow_DismissEvent;
                _popupWindow = null;
            }

            _attachedPopup = value;
        }
*/
/*
        private void BindableButton_Click(object sender, EventArgs e)
        {
            PopupShown = true;
        }
*/
        [WeakEventHandler.MakeWeak]
        private void Command_CanExecuteChanged(object sender, EventArgs e)
        {
            Enabled = (Command == null) ? true : Command.CanExecute(CommandParameter); 
        }

        private void OnClicked(object sender, EventArgs e)
        {
            if (Command == null || !Command.CanExecute(CommandParameter))
            {
                return;
            }
            Command.Execute(CommandParameter);
        }
/*
        private void OnPopupStateChanged(bool isShowing)
        {
            //Close and free popup window, if there is one.
            //This is will work as expected if isShowing is false.
            //If there is a popupwindow already present and isShowing is true, we still need to hide and dispose popupwindow, 'cause it's probably invalid.
            if (_popupWindow != null)
            {
                _popupWindow.DismissEvent -= PopupWindow_DismissEvent;
                _popupWindow.Dismiss();
                _popupWindow = null;
            }
            if (isShowing)
            {
                //Create and show popup window
                if (
                    _attachedPopup != null &&
                    _attachedPopup.PopupCommands != null &&
                    _attachedPopup.PopupCommands.Any()
                    )
                {
                    _popupWindow = PopupHelper.GetMenuPopup(
                        Context,
                        this,
                        _attachedPopup.PopupCommands);
                    _popupWindow.DismissEvent += PopupWindow_DismissEvent;
                    _popupWindow.Show();
                }
            }

            PopupStateChanged?.Invoke(this, EventArgs.Empty);
        }
*/
/*
        private void PopupWindow_DismissEvent(object sender, AndroidX.AppCompat.Widget.PopupMenu.DismissEventArgs e)
        {
            //If the popup window is dismised by tapping outside, we need to set property
            PopupShown = false;
        }
*/
        private void ReadXmlAttributes(Context context, IAttributeSet attrs, int defStyleAttr)
        {
            if (IsInEditMode)
            {
                return;
            }

            TypedArray typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.TextFont, defStyleAttr, Resource.Style.Widget_MaterialComponents_Button);
            if (typedArray != null)
            {
                string fontName = typedArray.GetString(Resource.Styleable.TextFont_FontName);
                if (!string.IsNullOrEmpty(fontName))
                {
                    Typeface typeface = FontUtil.GetFontFromAsset(fontName);
                    TypefaceStyle textStyle = Typeface == null ? TypefaceStyle.Normal : Typeface.Style;

                    if (typeface != null)
                    {
                        SetTypeface(typeface, textStyle);
                    }
                }
            }
            typedArray?.Recycle();
/*
            typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.BindableButton, defStyleAttr, Resource.Style.Widget_MaterialComponents_Button);
            if (typedArray != null)
            {
                bool autoOpenMenu = typedArray.GetBoolean(Resource.Styleable.BindableButton_autoOpenMenu, false);
                if (autoOpenMenu)
                {
                    Click -= BindableButton_Click;
                    Click += BindableButton_Click;
                }
            }
            typedArray?.Recycle();
*/
/*
            typedArray = context.ObtainStyledAttributes(attrs, Resource.Styleable.BehaviorExpression);
            if (typedArray != null)
            {
                BehaviorString = typedArray.GetString(Resource.Styleable.BehaviorExpression_Behavior);
            }
            typedArray?.Recycle();
*/
        }

        private void SubscribeCommand(ICommand command)
        {
            Click += OnClicked;
            if (command != null)
            {
                command.CanExecuteChanged += Command_CanExecuteChanged;
            }
            //Applying the current command state
            Command_CanExecuteChanged(this, EventArgs.Empty);
        }

        private void UnsubscribeCommand(ICommand command)
        {
            Click -= OnClicked;
            if (command != null)
            {
                command.CanExecuteChanged -= Command_CanExecuteChanged; 
            }
        }

        private void UpdateTypeface(Typeface typeface)
        {
            TypefaceStyle typefaceStyle = TypefaceStyle.Normal;
            typefaceStyle = _bold ? typefaceStyle | TypefaceStyle.Bold : typefaceStyle;
            typefaceStyle = _italic ? typefaceStyle | TypefaceStyle.Italic : typefaceStyle;

            base.SetTypeface(typeface, typefaceStyle);
        }

        private void UpdateUnderline()
        {
            if (Underline)
            {
                PaintFlags |= PaintFlags.UnderlineText;
            }
            else
            {
                PaintFlags &= ~PaintFlags.UnderlineText;
            }
        }

        #endregion

        #region Constructors/Finalizers

        public BindableButton(Context context)
            : this(context, null)
        {
        }

        public BindableButton(Context context, IAttributeSet attrs)
            : this(context, attrs, Resource.Style.Widget_MaterialComponents_Button)
        {
        }

        public BindableButton(Context context, IAttributeSet attrs, int defStyleAttr)
            : base(context, attrs, defStyleAttr)
        {
            ReadXmlAttributes(Context, attrs, defStyleAttr);
        }

        protected BindableButton(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        #endregion
    }
}
