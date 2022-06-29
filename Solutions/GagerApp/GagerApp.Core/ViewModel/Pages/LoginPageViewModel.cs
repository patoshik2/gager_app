using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Calcium;
using Calcium.Navigation;
using Calcium.Services;
using Calcium.UIModel;
using Calcium.UIModel.Input;
using GagerApp.Core.Services;

namespace GagerApp.Core.ViewModel.Pages
{
    public class LoginPageViewModel : PageViewModel
    {
        #region Fields

        private readonly AsyncActionCommand _loginCommand;
        private readonly ILoginService _loginService;
        private bool _isBusy = false;
        private string _message = string.Empty;
        private string _password;
        private string _username;

        #endregion Fields

        #region Constructors/Finalizers

        public LoginPageViewModel(ILoginService loginService)
        {
            _loginCommand = new AsyncActionCommand(LoginAsync, CanLoginAsync);
            _loginService = loginService ?? throw new ArgumentNullException(nameof(loginService));
            PropertyChanged += LoginPageViewModel_PropertyChanged;
        }

        #endregion Constructors/Finalizers

        #region Properties/Indexers

        public bool IsBusy
        {
            get => _isBusy;
            private set => Set(ref _isBusy, value);
        }

        public ICommand LoginCommand => _loginCommand;

        public string Message
        {
            get => _message;
            set => Set(ref _message, value);
        }

        public string Password
        {
            get => _password;
            set => Set(ref _password, value);
        }

        public string Username
        {
            get => _username;
            set => Set(ref _username, value);
        }

        #endregion Properties/Indexers

        #region Methods/Events


        private Task<bool> CanLoginAsync(object arg)
        {
            return Task.FromResult(
                !string.IsNullOrEmpty(_username)
                && !string.IsNullOrEmpty(_password)
                && !_isBusy
                );
        }

        private async Task LoginAsync(object arg)
        {
            IsBusy = true;

            var loginResult = await _loginService.LoginAsync(_username,_password);

            Message = loginResult.Translate();

            IsBusy = false;

            if (loginResult == LoginResult.Success)
            {
                GetNavigationTokenFor<RootPageViewModel>().NavigateToDestination();
            }
        }

        private void LoginPageViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == nameof(Username)) || (e.PropertyName == nameof(Password)) || (e.PropertyName == nameof(IsBusy)))
            {
                _loginCommand.RaiseCanExecuteChanged();
            }
        }


        #endregion Methods/Events
    }
}
