using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GagerApp.Core.ViewModel;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;
using TomsToolbox.ObservableCollections;

namespace GagerApp.Core.Services
{
    public interface IDiscountService
    {
        Task<IEnumerable<DiscountModel>> GetDiscountsAsync();
    
        double Recalculate(DiscountModel selectedDiscountModel, IEnumerable<RoomViewModel> roomViewModels);
    }
}
