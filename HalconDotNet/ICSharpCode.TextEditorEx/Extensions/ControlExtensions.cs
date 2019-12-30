using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace ICSharpCode.TextEditor.Extensions
{
    public static class ControlExtensions
    {
        public static EventHandlerList GetEventHandlerList(this Control c)
        {
            return GetEventHandlerListInternal(c);
        }

        public static EventHandlerList GetEventHandlerList(this Component c)
        {
            return GetEventHandlerListInternal(c);
        }

        private static EventHandlerList GetEventHandlerListInternal(object obj)
        {
            Type type = obj.GetType();
            PropertyInfo pi = type.GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            return (EventHandlerList)pi.GetValue(obj, null);
        }
    }
}