using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Calcium;
using Calcium.Collections;
using Calcium.Messaging;
using Calcium.Services;
using Calcium.Text;
using Calcium.UIModel;
using Calcium.UIModel.Input;
using GagerApp.Core.Commands;
using GagerApp.Core.Services;
using GagerApp.Core.ViewModel.Messages;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;

namespace GagerApp.Core.ViewModel.Pages
{
    public class OrderPageViewModel :
        PageViewModel<int>,
        IMessageSubscriber<RoomAddedMessage>,
        IMessageSubscriber<RoomDeletedMessage>
    {
        #region Fields

        private readonly ActionCommand _callPhoneCommand;
        private readonly UICommand _closeOrderCommand;
        private readonly ActionCommand _mapCommand;
        private readonly int _orderNumber;
        private readonly IOrderPageService _orderPageService;
        private readonly IPlatformService _platformService;
        private readonly UICommand _reopenOrderCommand;
        private readonly UICommand _reportRefusalCommand;
        private readonly ObservableList<IUICommand> _currentCommands;
        private FullOrderDTO _fullOrder;
        private bool _isBusy = false;

        #endregion Fields

        #region Constructors/Finalizers

        public OrderPageViewModel(int orderNumber, IOrderPageService orderPageService, IPlatformService platformService)
            : base(orderNumber)
        {
            _orderNumber = orderNumber;
            _orderPageService = orderPageService ?? throw new ArgumentNullException(nameof(orderPageService));
            _platformService = platformService ?? throw new ArgumentNullException(nameof(platformService));
            _callPhoneCommand = new ActionCommand(CallPhone);
            _mapCommand = new ActionCommand(OpenMap);
            _closeOrderCommand = new UICommand(CloseOrder, CanCloseOrder) { IconUrl = IconURL.Accept, Text = "Закрыть заявку" };
            _reportRefusalCommand = new UICommand(ReportRefusal) { IconUrl = IconURL.Error, Text = "Отказ" };
            _reopenOrderCommand = new UICommand(ReopenOrder) { IconUrl = IconURL.Undo, Text= "Открыть заявку" };
            ZamerCommand = new ActionCommand(LaunchZamerOrderPage);
            _currentCommands = new ObservableList<IUICommand>();
            _ = GetOrderPageModelAsync();
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public IEnumerable<IUICommand> CurrentCommands => _currentCommands;

        public AdressDTO Adress => _fullOrder?.Adress;

        public ICommand CallPhoneCommand => _callPhoneCommand;

        public ClientDTO Client => _fullOrder?.Client;

        public bool IsBusy
        {
            get => _isBusy;
            private set => Set(ref _isBusy, value);
        }

        public ICommand MapCommand => _mapCommand;

        public string Notes => _fullOrder?.Notes;

        public int? Number => _fullOrder?.Number;

        public IEnumerable<string> Phones => _fullOrder?.TelefonNumber;

        public OrderStatus? Status => _fullOrder?.Status;

        public ICommand ZamerCommand
        {
            get;
        }

        public DateTime ZamerDate => _fullOrder == null ? DateTime.MinValue : _fullOrder.Date;

        public DateTime ZamerFinishTime => _fullOrder == null ? DateTime.MinValue : _fullOrder.FinishTime;

        public int? ZamerRoomCount => _fullOrder?.Rooms?.Count;

        public DateTime ZamerStartTime => _fullOrder == null ? DateTime.MinValue : _fullOrder.StartTime;

        #endregion Properties/Indexers

        #region Methods/Events

        private void CallPhone(object obj)
        {
            //TODO: show phone selection dialog
        }

        private bool CanCloseOrder(object arg)
        {
            return ZamerRoomCount.HasValue && ZamerRoomCount > 0;
        }

        private async void CloseOrder(object obj)
        {
            if (await _orderPageService.UpdateZamerStatusAsync(_orderNumber, OrderStatus.Confirmed))
            {
                _fullOrder.Status = OrderStatus.Confirmed;
                OnOrderStatusChanged();
            }
            //TODO: handle else
        }

        private async Task GetOrderPageModelAsync()
        {
            IsBusy = true;
            _fullOrder = await _orderPageService.GetFullOrderAsync(_orderNumber);
            IsBusy = false;

            OnPropertyChanged(nameof(Number));
            OnPropertyChanged(nameof(Notes));
            OnPropertyChanged(nameof(Client));
            OnPropertyChanged(nameof(Adress));
            OnPropertyChanged(nameof(ZamerDate));
            OnPropertyChanged(nameof(ZamerStartTime));
            OnPropertyChanged(nameof(ZamerFinishTime));
            OnPropertyChanged(nameof(ZamerRoomCount));

            OnOrderStatusChanged();
        }

        private void OnOrderStatusChanged()
        {
            _currentCommands.Clear();
            if (Status == null || !Status.HasValue)
            {
                return;
            }

            switch (Status.Value)
            {
                case OrderStatus.Pending:
                    if (_fullOrder.Rooms == null || _fullOrder.Rooms.Count == 0)
                    {
                        _currentCommands.Add(_reportRefusalCommand);
                    }
                    _currentCommands.Add(_closeOrderCommand);
                    break;
                case OrderStatus.Rejected:
                    _currentCommands.Add(_reopenOrderCommand);
                    break;
                case OrderStatus.Confirmed:
                    _currentCommands.Add(_reopenOrderCommand);

                    //TODO: Add montage command
                    //TODO: Add payment command
                    break;
                default:
                    break;
            }

            NotifyStatusDependentProperties();
        }

        private void NotifyStatusDependentProperties()
        {
            OnPropertyChanged(nameof(Status));
            _closeOrderCommand.RaiseCanExecuteChanged();
        }

        private void OpenMap(object obj)
        {
            //TODO: Реализовать метод
        }

        private async void ReopenOrder(object obj)
        {
            if (await _orderPageService.UpdateZamerStatusAsync(_orderNumber, OrderStatus.Pending))
            {
                _fullOrder.Status = OrderStatus.Pending;
                OnOrderStatusChanged();
            }
        }

        private async void ReportRefusal(object obj)
        {
            if (await _orderPageService.UpdateZamerStatusAsync(_orderNumber, OrderStatus.Rejected))
            {
                _fullOrder.Status = OrderStatus.Rejected;
                OnOrderStatusChanged();
            }
        }

        private void LaunchZamerOrderPage(object obj)
        {
            ZamerPageViewModel.GetNavigationTokenFor<ZamerPageViewModel>().NavigateToDestinationWith(_orderNumber);
        }

        async Task IMessageSubscriber<RoomAddedMessage>.ReceiveMessageAsync(RoomAddedMessage message)
        {
            //TODO: Consider just adding the room to _fullOrder.Rooms
            if (message.OrderNumber == _orderNumber)
            {
                await GetOrderPageModelAsync();
            }
        }

        async Task IMessageSubscriber<RoomDeletedMessage>.ReceiveMessageAsync(RoomDeletedMessage message)
        {
            //TODO: Consider just adding the room to _fullOrder.Rooms
            if (_fullOrder.Rooms.Any((room) => room.IdRoom == message.Payload.IdRoom))
            {
                await GetOrderPageModelAsync();
            }
        }

        #endregion Methods/Events
    }
}
