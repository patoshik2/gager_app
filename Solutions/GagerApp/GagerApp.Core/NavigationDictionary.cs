using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calcium.Reflection;
using GagerApp.Core.ViewModel;

namespace GagerApp.Core
{
    public class NavigationDictionary
    {
        private static readonly Dictionary<Type, string> Dictionary = new Dictionary<Type, string>();

        internal static string Register(Type type)
        {
            var key = type.AssemblyQualifiedName;
            Dictionary[type] = key;
            return key;
        }

        public static Type ResolveType(string key)
        {
            return Dictionary.FirstOrDefault((kvp) => kvp.Value == key).Key;
        }
    }
}
