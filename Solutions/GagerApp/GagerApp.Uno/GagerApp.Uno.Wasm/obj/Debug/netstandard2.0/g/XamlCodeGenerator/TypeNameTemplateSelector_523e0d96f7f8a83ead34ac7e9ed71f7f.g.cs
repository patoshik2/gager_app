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

namespace GagerApp.Uno.Wasm
{
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV0056", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV0058", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV1003", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV0085", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2001", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2003", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2004", Justification="Generated code")]
	[global::System.Diagnostics.CodeAnalysis.SuppressMessage("nventive.Usage", "NV2005", Justification="Generated code")]
	public sealed partial class GlobalStaticResources
	{
		// This non-static inner class is a means of reducing size of AOT compilations by avoiding many accesses to static members from a static callsite, which adds costly class initializer checks each time.
		internal sealed class ResourceDictionarySingleton__6 : global::Uno.UI.IXamlResourceDictionaryProvider
		{
			private static ResourceDictionarySingleton__6 _instance;
			internal static ResourceDictionarySingleton__6 Instance
			{
				get
				{
					if (_instance == null)
					{
						_instance = new ResourceDictionarySingleton__6();
					}

					return _instance;
				}
			}

			internal global::Uno.UI.Xaml.XamlParseContext __ParseContext_ {get; }

			private ResourceDictionarySingleton__6()
			{
				__ParseContext_ = global::GagerApp.Uno.Wasm.GlobalStaticResources.__ParseContext_;
			}

			// Method for resource TypeNameTemplateSelector 
			private object Get_6_1(object __ResourceOwner_4) =>
				new global::GagerApp.Uno.Shared.Utils.TypeNameDataTemplateSelector
				{
					// Source ..\..\..\..\..\..\..\GagerApp.Uno.Shared\Resources\TypeNameTemplateSelector.xaml (Line 11:6)
				}
				.TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7f_XamlApply((TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7fXamlApplyExtensions.XamlApplyHandler0)(c0 => 
				{
					c0.Templates = (global::Uno.UI.ResourceResolverSingleton.Instance.ResolveResourceStatic("LoginPageViewModel", out var staticResourceResolverOutputIndex0, context: this.__ParseContext_) ? ((staticResourceResolverOutputIndex0 as global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.DataTemplate>) ?? default(global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.DataTemplate>)) : default(global::System.Collections.Generic.Dictionary<string, global::Windows.UI.Xaml.DataTemplate>));
					
				}
				))
				;

			private global::Windows.UI.Xaml.ResourceDictionary _TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7f_ResourceDictionary;

			internal global::Windows.UI.Xaml.ResourceDictionary TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7f_ResourceDictionary
			{
				get
				{
					if (_TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7f_ResourceDictionary == null)
					{
						_TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7f_ResourceDictionary = 
						new global::Windows.UI.Xaml.ResourceDictionary
						{
							IsParsing = true
							,
							MergedDictionaries = {
							global::GagerApp.Uno.Wasm.GlobalStaticResources.LoginPageDataTemplate_32f9f78f7e6806d598b3160f8c54eabe_ResourceDictionary
							,
							},
							["TypeNameTemplateSelector"] = 
							new global::Uno.UI.Xaml.WeakResourceInitializer(this, Get_6_1)
							,
						}
						;
						_TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7f_ResourceDictionary.Source = new global::System.Uri("ms-resource:///Files/Resources/TypeNameTemplateSelector.xaml");
						_TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7f_ResourceDictionary.CreationComplete();
					}
					return _TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7f_ResourceDictionary;
				}
			}

			global::Windows.UI.Xaml.ResourceDictionary global::Uno.UI.IXamlResourceDictionaryProvider.GetResourceDictionary() => TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7f_ResourceDictionary;
		}

		internal static global::Windows.UI.Xaml.ResourceDictionary TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7f_ResourceDictionary => ResourceDictionarySingleton__6.Instance.TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7f_ResourceDictionary;
	}
}
namespace GagerApp.Uno.Wasm.__Resources
{
}
namespace GagerApp.Uno.Wasm
{
	static class TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7fXamlApplyExtensions
	{
		public delegate void XamlApplyHandler0(global::GagerApp.Uno.Shared.Utils.TypeNameDataTemplateSelector instance);
		[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
		public static global::GagerApp.Uno.Shared.Utils.TypeNameDataTemplateSelector TypeNameTemplateSelector_523e0d96f7f8a83ead34ac7e9ed71f7f_XamlApply(this global::GagerApp.Uno.Shared.Utils.TypeNameDataTemplateSelector instance, XamlApplyHandler0 handler)
		{
			handler(instance);
			return instance;
		}
	}
}
