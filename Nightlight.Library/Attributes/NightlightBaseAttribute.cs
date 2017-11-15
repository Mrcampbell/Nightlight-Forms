using System;
using System.Collections.Generic;
using System.Text;

namespace Nightlight.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public abstract class NightlightBaseAttribute : Attribute, INightlightAttribute
    {
        private string _title;

        public NightlightBaseAttribute(string Title)
        {
            _title = Title;
        }

        public string Title { get { return _title; } }
    }
}
