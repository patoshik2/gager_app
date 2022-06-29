using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Calcium.Messaging;
using Calcium.UIModel;
using Calcium.UIModel.Input;
using GagerApp.Core.Services;
using GagerApp.Core.Utils;
using GagerApp.Core.ViewModel.Dialogs;
using GagerApp.Core.ViewModel.Messages;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;
using TomsToolbox.ObservableCollections;

namespace GagerApp.Core.ViewModel.Pages
{
    public class ZamerPageViewModel :
        PageViewModel<int>,
        IMessageSubscriber<RoomAddedMessage>,
        IMessageSubscriber<RoomDeletedMessage>
    {
        #region Fields

        private readonly ActionCommand _addRoom;
        private readonly IDiscountService _discountService;
        private readonly int _orderNumber;
        private readonly IRoomService _roomService;
        private ObservableCollection<DiscountModel> _discounts;
        private bool _isBusy = false;
        private ObservableCollection<RoomDTO> _rooms;
        private ObservableWrappedCollection<RoomDTO, RoomViewModel> _roomViewModels;
        private DiscountModel _selectedDiscountModel;
        private ObservableSortedCollection<RoomViewModel> _sortedRooms;
        private double _sum;

        #endregion Fields

        #region Constructors/Finalizers

        public ZamerPageViewModel(int orderNumber, IRoomService roomService, IDiscountService discountService) : base(orderNumber)
        {
            _orderNumber = orderNumber;
            _discountService = discountService ?? throw new ArgumentNullException(nameof(discountService));
            _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));

            _addRoom = new ActionCommand(AddNewRoom);
            RoomClickCommand = new ActionCommand<RoomViewModel>(OpenRoomPage);
           
            _ = UpdateRooms();
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public ICommand AddRoom => _addRoom;

        public DiscountModel Discount
        {
            get => _selectedDiscountModel;
            set
            {

                if (Set(ref _selectedDiscountModel, value) == Calcium.ComponentModel.AssignmentResult.Success)
                {
                    Sum = _discountService.Recalculate(_selectedDiscountModel, _roomViewModels);
                }
            }
        }

        public ObservableCollection<DiscountModel> Discounts
        {
            get => _discounts; private set => Set(ref _discounts, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            private set => Set(ref _isBusy, value);
        }

        public int? Number => _orderNumber;

        public ICommand RoomClickCommand
        {
            get;
        }

        public IEnumerable<RoomViewModel> Rooms => _sortedRooms;

        public double Sum
        {
            get => _sum;
            private set => Set(ref _sum, value);
        }

        #endregion Properties/Indexers

        #region Methods/Events

        private void AddNewRoom(object obj)
        {
            AddNewRoomDialogViewModel.Show(_orderNumber);
        }

        private RoomViewModel CreateRoomViewModel(RoomDTO arg)
        {
            return new RoomViewModel(arg, _roomService);
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RoomViewModel.Cost))
            {
                Sum = _discountService.Recalculate(_selectedDiscountModel, _roomViewModels);
            }
        }

        private void OpenRoomPage(RoomViewModel room)
        {
            RoomPageViewModel.GetNavigationTokenFor<RoomPageViewModel>().NavigateToDestinationWith(room.IdRoom);
        }

        Task IMessageSubscriber<RoomAddedMessage>.ReceiveMessageAsync(RoomAddedMessage message)
        {
            _ = UpdateRooms();

            return Task.FromResult<object>(null);
        }

        Task IMessageSubscriber<RoomDeletedMessage>.ReceiveMessageAsync(RoomDeletedMessage message)
        {
            _ = UpdateRooms();
            return Task.FromResult<object>(null);
        }

        private void RoomViewModels_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems.Cast<RoomViewModel>())
                    {
                        item.PropertyChanged += Item_PropertyChanged;
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems.Cast<RoomViewModel>())
                    {
                        item.PropertyChanged -= Item_PropertyChanged;
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    foreach (var item in e.NewItems.Cast<RoomViewModel>())
                    {
                        item.PropertyChanged += Item_PropertyChanged;
                    }
                    foreach (var item in e.OldItems.Cast<RoomViewModel>())
                    {
                        item.PropertyChanged -= Item_PropertyChanged;
                    }
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    SubscribeAllItems(_sortedRooms);
                    break;
                default:
                    break;
            }
        }

        private void SubscribeAllItems(IEnumerable<RoomViewModel> roomViewModels)
        {
            foreach (var item in roomViewModels)
            {
                item.PropertyChanged -= Item_PropertyChanged;
                item.PropertyChanged += Item_PropertyChanged;
            }
        }

        private async Task UpdateRooms()
        {
            IsBusy = true;
            var discountsModel = await _discountService.GetDiscountsAsync();
            var roomsModel = await _roomService.GetRoomsAsync(_orderNumber);

            _rooms = new ObservableCollection<RoomDTO>(roomsModel);

            _roomViewModels = new ObservableWrappedCollection<RoomDTO, RoomViewModel>(_rooms, CreateRoomViewModel);

            _sortedRooms = new ObservableSortedCollection<RoomViewModel>(_roomViewModels);
            _sortedRooms.SortByPropertyName(nameof(RoomViewModel.NameRoom), false);
            _sortedRooms.CollectionChanged += RoomViewModels_CollectionChanged;
            SubscribeAllItems(_sortedRooms);

            Discounts = new ObservableCollection<DiscountModel>(discountsModel);
            IsBusy = false;
            OnPropertyChanged(nameof(Rooms));
            OnPropertyChanged(nameof(Number));
            OnPropertyChanged(nameof(Discount));
        }

        #endregion Methods/Events
    }
}
