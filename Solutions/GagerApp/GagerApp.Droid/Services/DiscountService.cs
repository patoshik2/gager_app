using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GagerApp.Core.Services;
using GagerApp.Core.ViewModel;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;
using TomsToolbox.ObservableCollections;

namespace GagerApp.Droid.Services
{
    public class DiscountService : IDiscountService
    {
        public async Task<IEnumerable<DiscountModel>> GetDiscountsAsync()
        {
            var discountModels = new List<DiscountModel>();

            for (int i = 0; i <= 25; i++)
            {

                discountModels.Add(new DiscountModel { ID = i, DiscountAmount = i }); 
            }

            return await Task.FromResult(discountModels);
        }
        
        public double Recalculate(DiscountModel selectedDiscountModel, IEnumerable<RoomViewModel> roomViewModels)
        {
            double discount;
            if (selectedDiscountModel == null)
            {
                discount = 0;
            }
            else
            {
                discount = selectedDiscountModel.DiscountAmount;
            }

            return  roomViewModels.Sum(x => x.Cost) * ((100 - discount) / 100);
        }
    }
}
