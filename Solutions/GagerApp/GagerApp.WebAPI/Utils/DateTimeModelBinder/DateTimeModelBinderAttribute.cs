using Microsoft.AspNetCore.Mvc;

namespace GagerApp.WebApi.Utils.DateTimeModelBinder
{
    public class DateTimeModelBinderAttribute : ModelBinderAttribute
    {
        public string DateFormat { get; set; }

        public DateTimeModelBinderAttribute()
            : base(typeof(DateTimeModelBinder))
        {
        }
    }
}
