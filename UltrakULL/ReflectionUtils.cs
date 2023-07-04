using System;
using System.Reflection;

namespace UltrakULL.Flazhik
{
    public class ReflectionUtils
    {
        private static readonly BindingFlags BindingFlagsFields =
            BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

        public static void SetPrivate<T, V>(T instance, Type classType, string field, V value)
        {
            FieldInfo privateField = classType.GetField(field, BindingFlagsFields);
            privateField.SetValue(instance, value);
        }
    }
}