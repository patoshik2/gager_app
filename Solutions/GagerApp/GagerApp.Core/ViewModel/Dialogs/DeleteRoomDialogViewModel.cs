using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GagerApp.Core.Services;
using GagerApp.Core.ViewModel.Messages;
using GagerApp.Model.DTO;

namespace GagerApp.Core.ViewModel.Dialogs
{
    public class DeleteRoomDialogViewModel: TextDeleteDialogViewModel
    {
        #region Fields

        
        private readonly IRoomService _roomService;

        private bool _isBusy;

        private readonly RoomDTO _roomDTO;

        #endregion Fields

        public DeleteRoomDialogViewModel(RoomDTO roomDTO, IRoomService roomService, DialogController dialogController)
          : base("Удалить комнату " + roomDTO.NameRoom + "?", dialogController)
        {
            _roomDTO = roomDTO ?? throw new ArgumentNullException(nameof(roomDTO));
            _roomService = roomService ?? throw new ArgumentNullException(nameof(roomService));            
        }

        #region Properties/Indexers

        public bool IsBusy
        {
            get => _isBusy;
            private set => Set(ref _isBusy, value);
        }

        #endregion Properties/Indexers

        #region Methods/Events

        /// <summary>
        /// Show text delete  dialog to user.
        /// </summary>
        /// <param name="roomNumber">number of room to delete</param>
        public static void Show(RoomDTO roomDTO)
        {
            ShowDialog<DeleteRoomDialogViewModel>(roomDTO);
        }
       
        protected sealed override bool CanExecuteThirdButtonAction()
        {
            return false;
        }

        protected override async Task<bool> OnAcceptAsync()
        {
            var result = await _roomService.DeleteRoomAsync(_roomDTO.IdRoom);

            if (result)
            {
                
                _ = Messenger.PublishAsync(new RoomDeletedMessage(this, _roomDTO));
            }

            
            return result;
        }

        #endregion Methods/Events
    }
}
