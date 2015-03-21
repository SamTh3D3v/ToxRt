using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using ToxRt.Model;
using ToxRt.NavigationService;

namespace ToxRt.ViewModel
{

    public class MainViewModel : ViewModelBase
    {
        #region Fields
        private IMessagesNavigationService _navigationService;
        private ObservableCollection<Friend> _listFriends;
        #endregion
        #region Properties
        public ObservableCollection<Friend> ListFriends
        {
            get
            {
                return _listFriends;
            }

            set
            {
                if (_listFriends == value)
                {
                    return;
                }

                _listFriends = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region Commands

        #endregion
        #region Ctors and Methods
        public MainViewModel(IMessagesNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        #endregion       
    }
}