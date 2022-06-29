using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Calcium.UIModel;
using Calcium.UIModel.Input;
using GagerApp.Core.Services;
using GagerApp.Core.ViewModel.Dialogs;
using GagerApp.Model.DTO;

namespace GagerApp.Core.ViewModel
{
    public class RoomViewModel : ViewModelBase
    {
        #region Fields

        private readonly RoomDTO _roomDTO;
        private readonly IRoomService _roomService;
        private double? _cost;

        #endregion Fields

        #region Constructors/Finalizers

        public RoomViewModel(RoomDTO roomDTO, IRoomService roomService)
        {
            _roomDTO = roomDTO ?? throw new ArgumentNullException(nameof(roomDTO));
            _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
            _ = GetCostAsync();
            DeleteCommand = new ActionCommand(DeleteRoom);
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public double Cost
        {
            get => _cost ?? 0;
            private set => Set(ref _cost, value);
        }

        public ICommand DeleteCommand
        {
            get;
        }

        public int IdRoom => _roomDTO.IdRoom;

        public string NameRoom => _roomDTO.NameRoom;

        #endregion Properties/Indexers

        #region Methods/Events

        private void DeleteRoom(object obj)
        {
            DeleteRoomDialogViewModel.Show(_roomDTO);
        }

        private async Task GetCostAsync()
        {
            Cost = (double)await _roomService.GetRoomCostAsync(_roomDTO.IdRoom);
        }

        #endregion Methods/Events
    }
}
