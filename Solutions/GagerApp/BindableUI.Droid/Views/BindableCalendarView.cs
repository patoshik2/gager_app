using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace BindableUI.Droid.Views
{
    [Register("bindableUI.droid.views.BindableCalendarView")]
    public class BindableCalendarView : CalendarView
    {
        public BindableCalendarView(Context context, IAttributeSet attrs) :
            base(context, attrs)
        {
            Initialize();
        }

        public BindableCalendarView(Context context, IAttributeSet attrs, int defStyle) :
            base(context, attrs, defStyle)
        {
            Initialize();
        }

        private void Initialize()
        {
            DateChange -= Self_DateChange;
            DateChange += Self_DateChange;
        }

        private void Self_DateChange(object sender, DateChangeEventArgs e)
        {
            var date = new DateTime(e.Year, e.Month+1, e.DayOfMonth, 0, 0, 0, DateTimeKind.Utc);
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var time = date - origin;
            Date = (long)time.TotalMilliseconds;
        }
    }
}