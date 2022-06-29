using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Calcium;
using Calcium.Messaging;
using Calcium.Services;
using Calcium.UIModel;
using Calcium.UIModel.Input;
using GagerApp.Core.Services;
using GagerApp.Core.ViewModel.Messages;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;

namespace GagerApp.Core.ViewModel.Pages
{
    public class RootPageViewModel : PageViewModel,
        IMessageSubscriber<OrderStatusUpdatedMessage>
    {

        #region Fields

        private readonly ActionCommand _exitCommand;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private ObservableCollection<OrderDTO> _orders;
        private bool _isBusy;
        private string _username;

        #endregion Fields

        #region Constructors/Finalizers

        public RootPageViewModel(IUserService userService, IOrderService orderService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _exitCommand = new ActionCommand(Logout);
            _ = InitAsync();
            OrderClickCommand = new ActionCommand<OrderDTO>(OpenOrderPage);
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public bool IsBusy
        {
            get => _isBusy;
            private set => Set(ref _isBusy, value);
        }

        public ICommand ExitCommand => _exitCommand;

        public ObservableCollection<OrderDTO> Orders
        {
            get => _orders;
            private set => Set(ref _orders, value);
        }

        public string Username
        {
            get => _username;
            private set => Set(ref _username, value);
        }

        public ICommand OrderClickCommand
        {
            get;
        }

        #endregion Properties/Indexers

        #region Methods/Events

        private void OpenOrderPage(OrderDTO viewModel)
        {
            OrderPageViewModel.GetNavigationTokenFor<OrderPageViewModel>().NavigateToDestinationWith(viewModel.Number);
        }

        private void Logout(object obj)
        {
            _userService.Logout();
        }

        private async Task InitAsync()
        {
            IsBusy = true;

            await UpdateOrdersAsync();
            await UpdateUserAsync();

            IsBusy = false;
        }

        private async Task UpdateUserAsync()
        {
            Username = await _userService.GetUserFIOAsync();
        }

        private async Task UpdateOrdersAsync()
        {
            IEnumerable<OrderDTO> ordersModel = await _orderService.GetOrdersAsync();
            Orders = new ObservableCollection<OrderDTO>(ordersModel);
        }

        Task IMessageSubscriber<OrderStatusUpdatedMessage>.ReceiveMessageAsync(OrderStatusUpdatedMessage message)
        {
            var order = Orders?.FirstOrDefault((o) => o.Number == message.OrderNumber);
            if (order != default)
            {
                order.Status = message.OrderStatus;
            }

            return Task.FromResult<object>(null);
        }

        #endregion Methods/Events
    }
}
