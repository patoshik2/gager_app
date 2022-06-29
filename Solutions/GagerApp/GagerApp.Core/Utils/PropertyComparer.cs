using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GagerApp.Core.Utils
{
    internal class PropertyComparer<T> : IComparer<T>
    {
        private readonly PropertyInfo _property;
        private readonly string _propertyName;
        private readonly bool _descending;

        public PropertyComparer(string sortProperty, bool descending)
        {
            _propertyName = sortProperty;

            _property = GetPropertyInfo(typeof(T), sortProperty);

            if (_property == null)
            {
                throw new ArgumentException(string.Format("Property {0} is not found in type {1}. Nested properties are not supported yet.", sortProperty, typeof(T).Name));
            }
            _descending = descending;
        }

        private object GetPropertyValue(object src, string propName)
        {
            string[] nameParts = propName.Split('.');

            if (nameParts.Length == 1)
            {
                return src.GetType().GetRuntimeProperty(propName).GetValue(src, null);
            }
            nameParts = nameParts.Skip(1).ToArray();
            foreach (string part in nameParts)
            {
                if (src == null)
                {
                    return null;
                }

                Type type = src.GetType();

                PropertyInfo info = type.GetRuntimeProperty(part);

                if (info == null)
                {
                    return null;
                }

                src = info.GetValue(src, null);
            }
            return src;
        }

        private PropertyInfo GetPropertyInfo(Type baseType, string propertyName)
        {
            string[] parts = propertyName.Split('.');

            return (parts.Length > 1)
                ? null
                : baseType.GetRuntimeProperty(propertyName);

            //TODO: Extend type to work with nested properties - catch PropertyChanged, subscribe and unsubscribe properly
            /*
                            return (parts.Length > 1)
                                ? GetProp(baseType.GetRuntimeProperty(parts[0]).PropertyType, parts.Skip(1).Aggregate((a, i) => a + "." + i))
                                : baseType.GetRuntimeProperty(propertyName);
            */
        }

        public int Compare(T x, T y)
        {
            object valueX;
            object valueY;
            //TODO: Extend type to work with nested properties - catch PropertyChanged, subscribe and unsubscribe properly
            if (_property != null)
            {
                valueX = _property.GetValue(x, null);
                valueY = _property.GetValue(y, null);
            }
            else
            {
                valueX = GetPropertyValue(x, _propertyName);
                valueY = GetPropertyValue(y, _propertyName);
            }

            if (!_descending)
            {
                return Comparer<object>.Default.Compare(valueX, valueY);
            }
            else
            {
                return Comparer<object>.Default.Compare(valueY, valueX);
            }
        }
    }
}
