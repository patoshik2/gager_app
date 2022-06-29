using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GagerApp.Core.Services;
using GagerApp.Core.ViewModel.Messages;

namespace GagerApp.Core.ViewModel.Dialogs
{
    public class AddNewRoomDialogViewModel : SingleTextInputDialogViewModel
    {
        #region Fields

        private readonly int _orderNumber;
        private readonly IRoomService _roomService;

        private bool _isBusy;

        private IEnumerable<string> _roomNames;

        #endregion Fields

        #region Constructors/Finalizers

        public AddNewRoomDialogViewModel(int orderNumber, IRoomService roomService, DialogController dialogController)
            : base("Новая комната", "Введите название", string.Empty, dialogController)
        {
            _orderNumber = orderNumber;
            _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));
            _ = LoadRoomNamesAsync();
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public bool IsBusy
        {
            get => _isBusy;
            private set => Set(ref _isBusy, value);
        }

        #endregion Properties/Indexers

        #region Methods/Events

        /// <summary>
        /// Show text input dialog to user.
        /// </summary>
        /// <param name="orderNumber">number of order to create new room in</param>
        public static void Show(int orderNumber)
        {
            ShowDialog<AddNewRoomDialogViewModel>(orderNumber);
        }

        protected override void NegativeCallback()
        {
            //Do nothing
        }

        protected override async void PositiveCallback(string inputText)
        {
            var result =  await _roomService.AddNewRoomAsync(_orderNumber, inputText);

            if (result == null)
            {
                //Room was not added, nedd to inform
                return;
            }

            _ = Messenger.PublishAsync(new RoomAddedMessage(this, _orderNumber, result));
        }

        protected override string ValidateInput(string inputText)
        {
            if (IsBusy)
            {
                return "Идёт проверка...";
            }

            if (_roomNames is null)
            {
                return "Идёт загрузка...";
            }

            if (string.IsNullOrEmpty(inputText))
            {
                return ("Название не может быть пустым");
            }

            return _roomNames.Any((roomName) => roomName.Equals(inputText)) ? "Комната с таким именем уже существует" : string.Empty;
        }

        private async Task LoadRoomNamesAsync()
        {
            IsBusy = true;
            _roomNames = (await _roomService.GetRoomsAsync(_orderNumber)).Select((room) => room.NameRoom);            
            IsBusy = false;
            InvalidateErrorText();
        }

        #endregion Methods/Events
    }
}
