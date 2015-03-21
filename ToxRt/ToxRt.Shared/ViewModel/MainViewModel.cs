using System.Collections.ObjectModel;
using Windows.Networking.NetworkOperators;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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


        private Profile _currentProfile  ;


        public Profile CurrentProfile
        {
            get
            {
                return _currentProfile;
            }

            set
            {
                if (_currentProfile == value)
                {
                    return;
                }

                _currentProfile = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region Commands
        private RelayCommand<Friend> _friendSelectedCommand;
        public RelayCommand<Friend> FriendSelectedCommand
        {
            get
            {
                return _friendSelectedCommand
                    ?? (_friendSelectedCommand = new RelayCommand<Friend>(
                    (friend) =>
                    {
                        _navigationService.NavigateTo("MessagesView",friend);
                    }));
            }
        }

        #endregion
        #region Ctors and Methods
        public MainViewModel(IMessagesNavigationService navigationService)
        {
            _navigationService = navigationService;
            //for test purpuse only
            CurrentProfile=new Profile()
            {
                RealName = "Elhamer Oussama",
                ScreenName = "SamTheDev",
                PicSource = "../Images/user.png"
            };
            ListFriends=new ObservableCollection<Friend>()
            {
                new Friend()
                {
                    PicSource = "../Images/user.png",
                    RealName = "Joseph Walsh",
                    ScreenName = "Josheph"
                },
                new Friend()
                {
                    PicSource = "../Images/user.png",
                    RealName = "Alan Deep",
                    ScreenName = "Dii34"
                }
            };

        }
        #endregion       
    }
}