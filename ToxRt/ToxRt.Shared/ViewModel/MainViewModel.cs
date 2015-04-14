using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq.Expressions;
using Windows.Devices.Geolocation;
using Windows.Networking.NetworkOperators;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SharpTox.Core;
using ToxRt.Helpers;
using ToxRt.Model;
using ToxRt.NavigationService;

namespace ToxRt.ViewModel
{

    public enum Status
    {
        Online,
        Offline,
        Away
    }
    public class MainViewModel : NavigableViewModelBase
    {
        #region Fields        
        private String _localId;       
        private ObservableCollection<Friend> _listFriends;
        private Profile _defaultProfile;
        private Tox _tox;
        private Status _userStatus = Status.Online;
        // for testing purpuse only
        private ObservableCollection<DHT_Node> _nodes;
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
        public String LocalId
        {
            get
            {
                return _localId;
            }

            set
            {
                if (_localId == value)
                {
                    return;
                }

                _localId = value;
                RaisePropertyChanged();
            }
        }
        public Profile DefaultProfile
        {
            get
            {
                return _defaultProfile;
            }

            set
            {
                if (_defaultProfile == value)
                {
                    return;
                }

                _defaultProfile = value;
                RaisePropertyChanged();
            }
        }              
        public Status UserStatus
        {
            get
            {
                return _userStatus;
            }

            set
            {
                if (_userStatus == value)
                {
                    return;
                }

                _userStatus = value;
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
                    (friend) => InnerNavigationService.NavigateTo("MessagesView", friend)));
            }
        }
        private RelayCommand _loadedCommand;
        public RelayCommand LoadedCommand
        {
            get
            {
                return  _loadedCommand
                    ?? ( _loadedCommand = new RelayCommand(async () =>
                    {
                        //Load the default profile from the database
                        DefaultProfile = DataService.GetDefaultProfile();
                        if (DefaultProfile==null)
                        {
                            //Create a default profile before starting
                            DefaultProfile=new Profile()
                            {
                                ScreenName = "Tmp",
                                StatusMessage = "Tmp",
                                ToxId = "",
                                ProfileLanguage = "English",
                                ProfileTheme = "Default",
                                AudioNotifications = 1,
                                CloseToTray = 1,
                                IsDefault = 1,
                                ProfileName = Guid.NewGuid().ToString()                                
                            };
                            DataService.InsertNewProfile(DefaultProfile);
                        }

                        //initiate tox       --get those option parameter from the db                 
                        var options = new ToxOptions(true, false);

                        _tox = new Tox(options); 
                        _tox.OnFriendRequest += tox_OnFriendRequest;
                        _tox.OnFriendMessage += tox_OnFriendMessage;
                        
                        //Load the nodes from the local db                            
                        _nodes=new ObservableCollection<DHT_Node>(await DataService.LoadAllDhtNodes());
                        //try to bootstap from those node                         
                        if(!Boostraping())
                        {
                            //update the nodes from the wiki [At least for now] page and reboostraping  
                            UpdateNodes();
                            if (!Boostraping())
                            {
                                Debug.WriteLine("Can't boostrap from the current nodes !");
                            }                            
                        }
                        
                        





                        

                        _tox.Name = DefaultProfile.ScreenName;    //Everything is loadede from the Sqlite database, no .tox files or anything 
                        _tox.StatusMessage = DefaultProfile.StatusMessage;
                        _tox.Start();

                        LocalId= _tox.Id.ToString();
                        Debug.WriteLine("ID: {0}", LocalId);                        
                    }));
            }
        }

        private bool Boostraping()
        {
            bool success = false;
            foreach (DHT_Node node in _nodes)
                success=success || _tox.BootstrapFromNode(new ToxNode(node.Ipv4, node.Port, new ToxKey(ToxKeyType.Public, node.ClientId)));
            return success;   //make sure that at least one node is bootstraped succesfully
        }
        private void UpdateNodes()
        {
            
        }
        private RelayCommand _addFriendCommand;
        public RelayCommand AddFriendCommand
        {
            get
            {
                return _addFriendCommand
                    ?? (_addFriendCommand = new RelayCommand(
                    () =>
                    {
                        InnerNavigationService.NavigateTo("AddFriendView");
                    }));
            }
        }
        private RelayCommand _searchFriendCommand;
        public RelayCommand SearchFriendCommand
        {
            get
            {
                return _searchFriendCommand
                    ?? (_searchFriendCommand = new RelayCommand(
                    () =>
                    {
                        
                    }));
            }
        }
        private RelayCommand _changeStatusCommand;  
        public RelayCommand ChangeStatusCommand
        {
            get
            {
                return _changeStatusCommand
                    ?? (_changeStatusCommand = new RelayCommand(
                    () =>
                    {
                        //Use a flyout here                        
                    }));
            }
        }
        private RelayCommand _addGroupeCommand;
        public RelayCommand AddGroupeCommand
        {
            get
            {
                return _addGroupeCommand
                    ?? (_addGroupeCommand = new RelayCommand(
                    () =>
                    {
                        InnerNavigationService.NavigateTo("GroupeChatSettingsView");                        
                    }));
            }
        }
        private RelayCommand _removeSelectedFriendsCommand;
        public RelayCommand RemoveSelectedFriendsCommand
        {
            get
            {
                return _removeSelectedFriendsCommand
                    ?? (_removeSelectedFriendsCommand = new RelayCommand(
                    () =>
                    {
                        
                    }));
            }
        }
        private RelayCommand _loadProfileCommand;
        public RelayCommand LoadProfileCommand
        {
            get
            {
                return _loadProfileCommand
                    ?? (_loadProfileCommand = new RelayCommand(
                    () =>
                    {
                        
                    }));
            }
        }
        private RelayCommand _settingsCommand;
        public RelayCommand SettingsCommand
        {
            get
            {
                return _settingsCommand
                    ?? (_settingsCommand = new RelayCommand(
                    () =>
                    {
                        NavigationService.NavigateTo("SettingsView");                        
                    }));
            }
        }
        private RelayCommand _creditCommand;
        public RelayCommand CreditCommand
        {
            get
            {
                return _creditCommand
                    ?? (_creditCommand = new RelayCommand(
                    () =>
                    {
                        NavigationService.NavigateTo("CreditView");    
                    }));
            }
        }

        #endregion
        #region Ctors and Methods
        public MainViewModel(INavigationService navigationService, IDataService dataService, IMessagesNavigationService innerNavigationService)
            :base(navigationService,dataService,innerNavigationService)
        {
            
            //for test purpuse only
            DefaultProfile=new Profile()
            {
                RealName = "Elhamer Oussama",
                StatusMessage = "Life is Good",
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
        private void tox_OnFriendMessage(object sender, ToxEventArgs.FriendMessageEventArgs e)
        {
            //get the name associated with the friendnumber
            string name = _tox.GetName(e.FriendNumber);


            //print the message to the console
            Debug.WriteLine("<{0}> {1}", name, e.Message);
        }
        private void tox_OnFriendRequest(object sender, ToxEventArgs.FriendRequestEventArgs e)
        {
            //automatically accept every friend request we receive
            _tox.AddFriendNoRequest(new ToxKey(ToxKeyType.Public, e.Id));
        }
        public void Activate(object parameter)
        {
        }

        public void Deactivate(object parameter)
        {
        }

        public void GoBack()
        {
        }
        #endregion

       
    }
}