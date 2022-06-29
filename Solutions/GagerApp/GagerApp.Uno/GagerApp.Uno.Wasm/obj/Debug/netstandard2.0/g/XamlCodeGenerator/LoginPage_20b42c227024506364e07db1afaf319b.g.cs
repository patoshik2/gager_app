// <autogenerated />
#pragma warning disable 618  // Ignore obsolete members warnings
#pragma warning disable 105  // Ignore duplicate namespaces
#pragma warning disable 1591 // Ignore missing XML comment warnings
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Uno.UI;
using Uno.UI.Xaml;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Text;
using Uno.Extensions;
using Uno;
using Uno.UI.Helpers.Xaml;
using GagerApp.Uno.Wasm;

#if __ANDROID__
using _View = Android.Views.View;
#elif __IOS__
using _View = UIKit.UIView;
#elif __MACOS__
using _View = AppKit.NSView;
#elif UNO_REFERENCE_API
using _View = Windows.UI.Xaml.UIElement;
#elif NET461
using _View = Windows.UI.Xaml.UIElement;
#endif

namespace GagerApp.Uno.Shared.Pages
{
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV0056", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV0058", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV1003", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV0085", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2001", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2003", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2004", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2005", Justification="Generated code")]
	public partial class LoginPage : GagerApp.Uno.Shared.Pages.BasePage
	{
		private void InitializeComponent()
		{
			var nameScope = new global::Windows.UI.Xaml.NameScope();
			NameScope.SetNameScope(this, nameScope);
			IsParsing = true
			;
			Resources["CollapsedConverter"] = 
			new global::GagerApp.Uno.Shared.Converters.EmptyStringToCollapsedConverter
			{
				// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 15:14)
			}
			;
			// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 1:2)
			Content = 
			new global::Windows.UI.Xaml.Controls.Grid
			{
				IsParsing = true
				,
				ColumnDefinitions = 
				{
					new global::Windows.UI.Xaml.Controls.ColumnDefinition
					{
						Width = new Windows.UI.Xaml.GridLength(1f, Windows.UI.Xaml.GridUnitType.Star)/* Windows.UI.Xaml.GridLength/, *, ColumnDefinition/Width */,
						// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 21:14)
					}
					,
					new global::Windows.UI.Xaml.Controls.ColumnDefinition
					{
						Width = new Windows.UI.Xaml.GridLength(1f, Windows.UI.Xaml.GridUnitType.Auto)/* Windows.UI.Xaml.GridLength/, auto, ColumnDefinition/Width */,
						// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 22:14)
					}
					,
					new global::Windows.UI.Xaml.Controls.ColumnDefinition
					{
						Width = new Windows.UI.Xaml.GridLength(1f, Windows.UI.Xaml.GridUnitType.Star)/* Windows.UI.Xaml.GridLength/, *, ColumnDefinition/Width */,
						// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 23:14)
					}
					,
				}
				,
				RowDefinitions = 
				{
					new global::Windows.UI.Xaml.Controls.RowDefinition
					{
						Height = new Windows.UI.Xaml.GridLength(1f, Windows.UI.Xaml.GridUnitType.Star)/* Windows.UI.Xaml.GridLength/, *, RowDefinition/Height */,
						// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 26:14)
					}
					,
					new global::Windows.UI.Xaml.Controls.RowDefinition
					{
						Height = new Windows.UI.Xaml.GridLength(1f, Windows.UI.Xaml.GridUnitType.Auto)/* Windows.UI.Xaml.GridLength/, auto, RowDefinition/Height */,
						// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 27:14)
					}
					,
					new global::Windows.UI.Xaml.Controls.RowDefinition
					{
						Height = new Windows.UI.Xaml.GridLength(1f, Windows.UI.Xaml.GridUnitType.Star)/* Windows.UI.Xaml.GridLength/, *, RowDefinition/Height */,
						// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 28:14)
					}
					,
				}
				,
				// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 19:6)
				Children = 
				{
					new global::Windows.UI.Xaml.Controls.Grid
					{
						IsParsing = true
						,
						Width = 320d/* double/, 320, Grid/Width */,
						RowDefinitions = 
						{
							new global::Windows.UI.Xaml.Controls.RowDefinition
							{
								Height = new Windows.UI.Xaml.GridLength(1f, Windows.UI.Xaml.GridUnitType.Auto)/* Windows.UI.Xaml.GridLength/, auto, RowDefinition/Height */,
								// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 38:18)
							}
							,
							new global::Windows.UI.Xaml.Controls.RowDefinition
							{
								Height = new Windows.UI.Xaml.GridLength(1f, Windows.UI.Xaml.GridUnitType.Auto)/* Windows.UI.Xaml.GridLength/, auto, RowDefinition/Height */,
								// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 39:18)
							}
							,
							new global::Windows.UI.Xaml.Controls.RowDefinition
							{
								Height = new Windows.UI.Xaml.GridLength(1f, Windows.UI.Xaml.GridUnitType.Auto)/* Windows.UI.Xaml.GridLength/, auto, RowDefinition/Height */,
								// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 40:18)
							}
							,
							new global::Windows.UI.Xaml.Controls.RowDefinition
							{
								Height = new Windows.UI.Xaml.GridLength(1f, Windows.UI.Xaml.GridUnitType.Auto)/* Windows.UI.Xaml.GridLength/, auto, RowDefinition/Height */,
								// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 41:18)
							}
							,
							new global::Windows.UI.Xaml.Controls.RowDefinition
							{
								Height = new Windows.UI.Xaml.GridLength(1f, Windows.UI.Xaml.GridUnitType.Auto)/* Windows.UI.Xaml.GridLength/, auto, RowDefinition/Height */,
								// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 42:18)
							}
							,
						}
						,
						// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 31:10)
						Children = 
						{
							new global::Windows.UI.Xaml.Controls.Image
							{
								IsParsing = true
								,
								HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Center/* Windows.UI.Xaml.HorizontalAlignment/, Center, Image/HorizontalAlignment */,
								Width = 200d/* double/, 200, Image/Width */,
								Height = 200d/* double/, 200, Image/Height */,
								Source = @"/Source/house_plan.png"/* Windows.UI.Xaml.Media.ImageSource/, /Source/house_plan.png, Image/Source */,
								Margin = new global::Windows.UI.Xaml.Thickness(8)/* Windows.UI.Xaml.Thickness/, 8, Image/Margin */,
								// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 44:14)
							}
							.LoginPage_20b42c227024506364e07db1afaf319b_XamlApply((LoginPage_20b42c227024506364e07db1afaf319bXamlApplyExtensions.XamlApplyHandler2)(c11 => 
							{
								global::Windows.UI.Xaml.Controls.Grid.SetRow(c11, 0/* int/, 0, Grid/Row */);
								global::Uno.UI.FrameworkElementHelper.SetBaseUri(c11, "file:///D:/vs/gager_app/Gager App/Solutions/GagerApp/GagerApp.Uno/GagerApp.Uno.Shared/Pages/LoginPage.xaml");
								c11.CreationComplete();
							}
							))
							,
							new global::Windows.UI.Xaml.Controls.TextBox
							{
								IsParsing = true
								,
								PlaceholderText = "Пользователь"/* string/, Пользователь, TextBox/PlaceholderText */,
								Margin = new global::Windows.UI.Xaml.Thickness(8)/* Windows.UI.Xaml.Thickness/, 8, TextBox/Margin */,
								// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 53:14)
							}
							.LoginPage_20b42c227024506364e07db1afaf319b_XamlApply((LoginPage_20b42c227024506364e07db1afaf319bXamlApplyExtensions.XamlApplyHandler3)(c12 => 
							{
								global::Windows.UI.Xaml.Controls.Grid.SetRow(c12, 1/* int/, 1, Grid/Row */);
								c12.SetBinding(global::Windows.UI.Xaml.Controls.TextBox.TextProperty, new Windows.UI.Xaml.Data.Binding{ Path = @"Username"/* Windows.UI.Xaml.PropertyPath/Windows.UI.Xaml.PropertyPath, Username, Binding/Path */, Mode = global::Windows.UI.Xaml.Data.BindingMode.TwoWay/* Windows.UI.Xaml.Data.BindingMode/Windows.UI.Xaml.Data.BindingMode, TwoWay, Binding/Mode */, UpdateSourceTrigger = global::Windows.UI.Xaml.Data.UpdateSourceTrigger.PropertyChanged/* Windows.UI.Xaml.Data.UpdateSourceTrigger/Windows.UI.Xaml.Data.UpdateSourceTrigger, PropertyChanged, Binding/UpdateSourceTrigger */ });
																global::Uno.UI.FrameworkElementHelper.SetBaseUri(c12, "file:///D:/vs/gager_app/Gager App/Solutions/GagerApp/GagerApp.Uno/GagerApp.Uno.Shared/Pages/LoginPage.xaml");
								c12.CreationComplete();
							}
							))
							,
							new global::Windows.UI.Xaml.Controls.PasswordBox
							{
								IsParsing = true
								,
								PlaceholderText = "Пароль"/* string/, Пароль, PasswordBox/PlaceholderText */,
								InputScope = new global::Windows.UI.Xaml.Input.InputScope { Names = { new global::Windows.UI.Xaml.Input.InputScopeName { NameValue = global::Windows.UI.Xaml.Input.InputScopeNameValue.Password} } }/* Windows.UI.Xaml.Input.InputScope/, Password, PasswordBox/InputScope */,
								Margin = new global::Windows.UI.Xaml.Thickness(8)/* Windows.UI.Xaml.Thickness/, 8, PasswordBox/Margin */,
								// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 59:14)
							}
							.LoginPage_20b42c227024506364e07db1afaf319b_XamlApply((LoginPage_20b42c227024506364e07db1afaf319bXamlApplyExtensions.XamlApplyHandler4)(c13 => 
							{
								global::Windows.UI.Xaml.Controls.Grid.SetRow(c13, 2/* int/, 2, Grid/Row */);
								c13.SetBinding(global::Windows.UI.Xaml.Controls.PasswordBox.PasswordProperty, new Windows.UI.Xaml.Data.Binding{ Path = @"Password"/* Windows.UI.Xaml.PropertyPath/Windows.UI.Xaml.PropertyPath, Password, /_PositionalParameters */, Mode = global::Windows.UI.Xaml.Data.BindingMode.TwoWay/* Windows.UI.Xaml.Data.BindingMode/Windows.UI.Xaml.Data.BindingMode, TwoWay, Binding/Mode */, UpdateSourceTrigger = global::Windows.UI.Xaml.Data.UpdateSourceTrigger.PropertyChanged/* Windows.UI.Xaml.Data.UpdateSourceTrigger/Windows.UI.Xaml.Data.UpdateSourceTrigger, PropertyChanged, Binding/UpdateSourceTrigger */ });
																global::Uno.UI.FrameworkElementHelper.SetBaseUri(c13, "file:///D:/vs/gager_app/Gager App/Solutions/GagerApp/GagerApp.Uno/GagerApp.Uno.Shared/Pages/LoginPage.xaml");
								c13.CreationComplete();
							}
							))
							,
							new global::Windows.UI.Xaml.Controls.TextBlock
							{
								IsParsing = true
								,
								Margin = new global::Windows.UI.Xaml.Thickness(8)/* Windows.UI.Xaml.Thickness/, 8, TextBlock/Margin */,
								// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 66:14)
							}
							.LoginPage_20b42c227024506364e07db1afaf319b_XamlApply((LoginPage_20b42c227024506364e07db1afaf319bXamlApplyExtensions.XamlApplyHandler5)(c14 => 
							{
								global::Windows.UI.Xaml.Controls.Grid.SetRow(c14, 3/* int/, 3, Grid/Row */);
								c14.SetBinding(global::Windows.UI.Xaml.Controls.TextBlock.TextProperty, new Windows.UI.Xaml.Data.Binding{ Path = @"Message"/* Windows.UI.Xaml.PropertyPath/Windows.UI.Xaml.PropertyPath, Message, Binding/Path */, Mode = global::Windows.UI.Xaml.Data.BindingMode.OneWay/* Windows.UI.Xaml.Data.BindingMode/Windows.UI.Xaml.Data.BindingMode, OneWay, Binding/Mode */ });
																c14.SetBinding(global::Windows.UI.Xaml.Controls.TextBlock.VisibilityProperty, new Windows.UI.Xaml.Data.Binding{ Path = @"Message"/* Windows.UI.Xaml.PropertyPath/Windows.UI.Xaml.PropertyPath, Message, Binding/Path */, Mode = global::Windows.UI.Xaml.Data.BindingMode.OneWay/* Windows.UI.Xaml.Data.BindingMode/Windows.UI.Xaml.Data.BindingMode, OneWay, Binding/Mode */, Converter = (global::Uno.UI.ResourceResolverSingleton.Instance.ResolveResourceStatic("CollapsedConverter", out var staticResourceResolverOutputIndex0, context: global::GagerApp.Uno.Wasm.GlobalStaticResources.__ParseContext_) ? ((staticResourceResolverOutputIndex0 as global::Windows.UI.Xaml.Data.IValueConverter) ?? default(global::Windows.UI.Xaml.Data.IValueConverter)) : default(global::Windows.UI.Xaml.Data.IValueConverter)) });
																global::Uno.UI.FrameworkElementHelper.SetBaseUri(c14, "file:///D:/vs/gager_app/Gager App/Solutions/GagerApp/GagerApp.Uno/GagerApp.Uno.Shared/Pages/LoginPage.xaml");
								c14.CreationComplete();
							}
							))
							,
							new global::Windows.UI.Xaml.Controls.Button
							{
								IsParsing = true
								,
								Content = @"Вход"/* object/, Вход, Button/Content */,
								HorizontalAlignment = global::Windows.UI.Xaml.HorizontalAlignment.Stretch/* Windows.UI.Xaml.HorizontalAlignment/, Stretch, Button/HorizontalAlignment */,
								Margin = new global::Windows.UI.Xaml.Thickness(8)/* Windows.UI.Xaml.Thickness/, 8, Button/Margin */,
								// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 72:14)
							}
							.LoginPage_20b42c227024506364e07db1afaf319b_XamlApply((LoginPage_20b42c227024506364e07db1afaf319bXamlApplyExtensions.XamlApplyHandler6)(c15 => 
							{
								global::Windows.UI.Xaml.Controls.Grid.SetRow(c15, 4/* int/, 4, Grid/Row */);
								c15.SetBinding(global::Windows.UI.Xaml.Controls.Button.CommandProperty, new Windows.UI.Xaml.Data.Binding{ Path = @"LoginCommand"/* Windows.UI.Xaml.PropertyPath/Windows.UI.Xaml.PropertyPath, LoginCommand, /_PositionalParameters */, Mode = global::Windows.UI.Xaml.Data.BindingMode.OneWay/* Windows.UI.Xaml.Data.BindingMode/Windows.UI.Xaml.Data.BindingMode, OneWay, Binding/Mode */ });
																global::Uno.UI.FrameworkElementHelper.SetBaseUri(c15, "file:///D:/vs/gager_app/Gager App/Solutions/GagerApp/GagerApp.Uno/GagerApp.Uno.Shared/Pages/LoginPage.xaml");
								c15.CreationComplete();
							}
							))
							,
						}
					}
					.LoginPage_20b42c227024506364e07db1afaf319b_XamlApply((LoginPage_20b42c227024506364e07db1afaf319bXamlApplyExtensions.XamlApplyHandler7)(c16 => 
					{
						global::Windows.UI.Xaml.Controls.Grid.SetColumn(c16, 1/* int/, 1, Grid/Column */);
						global::Windows.UI.Xaml.Controls.Grid.SetRow(c16, 1/* int/, 1, Grid/Row */);
						global::Uno.UI.FrameworkElementHelper.SetBaseUri(c16, "file:///D:/vs/gager_app/Gager App/Solutions/GagerApp/GagerApp.Uno/GagerApp.Uno.Shared/Pages/LoginPage.xaml");
						c16.CreationComplete();
					}
					))
					,
				}
			}
			.LoginPage_20b42c227024506364e07db1afaf319b_XamlApply((LoginPage_20b42c227024506364e07db1afaf319bXamlApplyExtensions.XamlApplyHandler7)(c17 => 
			{
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(c17, "file:///D:/vs/gager_app/Gager App/Solutions/GagerApp/GagerApp.Uno/GagerApp.Uno.Shared/Pages/LoginPage.xaml");
				c17.CreationComplete();
			}
			))
			;
			
			this
			.Apply((c18 => 
			{
				// Source D:\vs\gager_app\Gager App\Solutions\GagerApp\GagerApp.Uno\GagerApp.Uno.Shared\Pages\LoginPage.xaml (Line 1:2)
				
				// WARNING Property c18.base does not exist on {using:GagerApp.Uno.Shared.Pages}BasePage, the namespace is http://www.w3.org/XML/1998/namespace. This error was considered irrelevant by the XamlFileGenerator
			}
			))
			.Apply((c19 => 
			{
				// Class GagerApp.Uno.Shared.Pages.LoginPage
				global::Uno.UI.ResourceResolverSingleton.Instance.ApplyResource(c19, global::GagerApp.Uno.Shared.Pages.BasePage.BackgroundProperty, "ApplicationPageBackgroundThemeBrush", isThemeResourceExtension: true, context: global::GagerApp.Uno.Wasm.GlobalStaticResources.__ParseContext_);
				this._component_0 = c19;
				global::Uno.UI.FrameworkElementHelper.SetBaseUri(c19, "file:///D:/vs/gager_app/Gager App/Solutions/GagerApp/GagerApp.Uno/GagerApp.Uno.Shared/Pages/LoginPage.xaml");
				c19.CreationComplete();
			}
			))
			;
			OnInitializeCompleted();

			Bindings = new LoginPage_Bindings(this);
			Loading += delegate
			{
				_component_0.UpdateResourceBindings();
			}
			;
		}
		partial void OnInitializeCompleted();
		private global::GagerApp.Uno.Shared.Pages.BasePage _component_0;
		private interface ILoginPage_Bindings
		{
			void Initialize();
			void Update();
			void StopTracking();
		}
		#pragma warning disable 0169 //  Suppress unused field warning in case Bindings is not used.
		private ILoginPage_Bindings Bindings;
		#pragma warning restore 0169
		[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
		private class LoginPage_Bindings : ILoginPage_Bindings
		{
			#if UNO_HAS_UIELEMENT_IMPLICIT_PINNING
			private global::System.WeakReference _ownerReference;
			private LoginPage Owner { get => (LoginPage)_ownerReference?.Target; set => _ownerReference = new global::System.WeakReference(value); }
			#else
			private LoginPage Owner { get; set; }
			#endif
			public LoginPage_Bindings(LoginPage owner)
			{
				Owner = owner;
			}
			void ILoginPage_Bindings.Initialize()
			{
			}
			void ILoginPage_Bindings.Update()
			{
				var owner = Owner;
			}
			void ILoginPage_Bindings.StopTracking()
			{
			}
		}
	}
}
namespace GagerApp.Uno.Wasm
{
	static class LoginPage_20b42c227024506364e07db1afaf319bXamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::Windows.UI.Xaml.Controls.ColumnDefinition instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.ColumnDefinition LoginPage_20b42c227024506364e07db1afaf319b_XamlApply(this global::Windows.UI.Xaml.Controls.ColumnDefinition instance, XamlApplyHandler0 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler1(global::Windows.UI.Xaml.Controls.RowDefinition instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.RowDefinition LoginPage_20b42c227024506364e07db1afaf319b_XamlApply(this global::Windows.UI.Xaml.Controls.RowDefinition instance, XamlApplyHandler1 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler2(global::Windows.UI.Xaml.Controls.Image instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.Image LoginPage_20b42c227024506364e07db1afaf319b_XamlApply(this global::Windows.UI.Xaml.Controls.Image instance, XamlApplyHandler2 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler3(global::Windows.UI.Xaml.Controls.TextBox instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.TextBox LoginPage_20b42c227024506364e07db1afaf319b_XamlApply(this global::Windows.UI.Xaml.Controls.TextBox instance, XamlApplyHandler3 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler4(global::Windows.UI.Xaml.Controls.PasswordBox instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.PasswordBox LoginPage_20b42c227024506364e07db1afaf319b_XamlApply(this global::Windows.UI.Xaml.Controls.PasswordBox instance, XamlApplyHandler4 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler5(global::Windows.UI.Xaml.Controls.TextBlock instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.TextBlock LoginPage_20b42c227024506364e07db1afaf319b_XamlApply(this global::Windows.UI.Xaml.Controls.TextBlock instance, XamlApplyHandler5 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler6(global::Windows.UI.Xaml.Controls.Button instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.Button LoginPage_20b42c227024506364e07db1afaf319b_XamlApply(this global::Windows.UI.Xaml.Controls.Button instance, XamlApplyHandler6 handler)
		{
			handler(instance);
			return instance;
		}
		public delegate void XamlApplyHandler7(global::Windows.UI.Xaml.Controls.Grid instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::Windows.UI.Xaml.Controls.Grid LoginPage_20b42c227024506364e07db1afaf319b_XamlApply(this global::Windows.UI.Xaml.Controls.Grid instance, XamlApplyHandler7 handler)
		{
			handler(instance);
			return instance;
		}
	}
}
