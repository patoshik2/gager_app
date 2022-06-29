using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BindableUI.Droid.Utils
{
    internal static class FontUtil
    {
        private static readonly Dictionary<string, Typeface> Typefaces = new Dictionary<string, Typeface>();

        public static Android.Graphics.TypefaceStyle GetTypefaceStyle(bool isBold, bool isItalic)
        {
            Android.Graphics.TypefaceStyle style = Android.Graphics.TypefaceStyle.Normal;
            if (isBold)
            {
                style |= Android.Graphics.TypefaceStyle.Bold;
            }
            if (isItalic)
            {
                style |= Android.Graphics.TypefaceStyle.Italic;
            }
            return style;
        }

        public static Typeface GetFontFromAsset(string name)
        {
            if (!Typefaces.ContainsKey(name))
            {
                var font = Typeface.CreateFromAsset(Application.Context.Assets, name + ".ttf");
                Typefaces[name] = font;
            }
            return Typefaces[name];
        }
    }
}
