using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using GagerApp.Core.Services;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;

namespace GagerApp.Core.ViewModel.Pages
{
    public class RoomPageViewModel : PageViewModel<int>
    {
        #region Fields

        private readonly int _roomNumber;
        private readonly IRoomPageService _roomPageService;
        private readonly IRoomService _roomService;
        private ObservableCollection<DopUslugaDTO> _dopUslugas;
        private bool _isBusy = false;
        private double _sum;

        #endregion Fields

        #region Constructors/Finalizers

        public RoomPageViewModel(int roomNumber, IRoomPageService roomPageService, IRoomService roomService) : base(roomNumber)
        {
            _roomNumber = roomNumber;
            _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
            _roomPageService = roomPageService ?? throw new ArgumentNullException(nameof(roomPageService));
            _ = GetRoomPageModel();
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public ObservableCollection<DopUslugaDTO> DopUslugas
        {
            get => _dopUslugas; private set => Set(ref _dopUslugas, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            private set => Set(ref _isBusy, value);
        }

        public FullRoomDTO Room
        {
            get;
            private set;
        }

        public double Sum
        {
            get => _sum;
            private set => Set(ref _sum, value);
        }

        #endregion Properties/Indexers

        #region Methods/Events

        private async Task GetRoomPageModel()
        {
            IsBusy = true;

            Room = await _roomService.GetFullRoomAsync(_roomNumber);
            _dopUslugas = new ObservableCollection<DopUslugaDTO>(Room.DopUsluga);
            IsBusy = false;
            OnPropertyChanged(nameof(Room));
            OnPropertyChanged(nameof(DopUslugas));

        }

        #endregion Methods/Events
    }
}
