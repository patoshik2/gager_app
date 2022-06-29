using System;
using System.Collections.Generic;
using System.Text;

namespace GagerApp.Model.Entities
{
    public enum OrderPageStatusZamer
    {
        NotDone,
        Done
    }

    public static class OrderPageStatusZamerExtensions
    {
        public static string Translate(this OrderPageStatusZamer orderPageStatusZamer)
        {
            switch (orderPageStatusZamer)
            {
                case OrderPageStatusZamer.NotDone:
                    return "Не выполнено";
                case OrderPageStatusZamer.Done:
                    return "Выполнено";
                default:
                    return "Не выполнено";
            }
        }
    }
}
