using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using SharpTox.Core;
using ToxRt.Helpers;
using ToxRt.Model;
using ToxRt.NavigationService;

namespace ToxRt.ViewModel
{
    public class AddFriendViewModel : NavigableViewModelBase
    {
        #region Fields
        private FriendRequest _newFriendRequest;
        private ObservableCollection<FriendRequest> _listPendingRequests;
        private Tox _tox;
        #endregion
        #region Properties
        public FriendRequest NewFriendRequest
        {
            get
            {
                return _newFriendRequest;
            }

            set
            {
                if (_newFriendRequest == value)
                {
                    return;
                }

                _newFriendRequest = value;
                RaisePropertyChanged();
            }
        }             
        public ObservableCollection<FriendRequest> ListPendingRequests
        {
            get
            {
                return _listPendingRequests;
            }

            set
            {
                if (_listPendingRequests == value)
                {
                    return;
                }

                _listPendingRequests = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region Commands
        private RelayCommand _sendRequestCommand;
        public RelayCommand SendRequestCommand
        {
            get
            {
                return _sendRequestCommand
                    ?? (_sendRequestCommand = new RelayCommand(
                    () =>
                    {
                        try
                        {
                            var friendNumber = _tox.AddFriend(new ToxId(NewFriendRequest.ToxId), NewFriendRequest.RequestMessage);
                            var friendStatus = "";
                            if (_tox.IsOnline(friendNumber))
                            {
                                friendStatus = getFriendStatusMessage(friendNumber);
                            }
                            else
                            {
                                var lastOnline = TimeZoneInfo.ConvertTime(_tox.GetLastOnline(friendNumber), TimeZoneInfo.Local);

                                if (lastOnline.Year == 1970)
                                {                                    
                                    friendStatus = "Friend request sent";
                                }
                                else
                                    friendStatus = string.Format("Last seen: {0}", lastOnline.Date);
                            }

                            var friendName = getFriendName(friendNumber);
                            if (string.IsNullOrEmpty(friendName))
                            {
                                friendName = _tox.GetClientId(friendNumber).GetString();
                            }







                        }
                        catch (ToxAFException ex)
                        {
                            if (ex.Error != ToxAFError.SetNewNospam)
                                Debug.WriteLine("An error occurred Code [0]");

                            return;
                        }
                        catch
                        {
                            Debug.WriteLine("An error occurred, The ID you entered is not valid.");
                            return;
                        }
 
                    }));
            }
        }


        private RelayCommand _acceptRequestCommand; 
        public RelayCommand AcceptRequestCommand
        {
            get
            {
                return _acceptRequestCommand
                    ?? (_acceptRequestCommand = new RelayCommand(
                    () =>
                    {
                        
                    }));
            }
        }
        private RelayCommand _refuseRequestCommand;
        public RelayCommand RefuseRequestCommand
        {
            get
            {
                return _refuseRequestCommand
                    ?? (_refuseRequestCommand = new RelayCommand(
                    () =>
                    {
                        
                    }));
            }
        }
        private RelayCommand _selectPandingRequestCommand;
        public RelayCommand SelectPandingRequestCommand
        {
            get
            {
                return  _selectPandingRequestCommand
                    ?? ( _selectPandingRequestCommand = new RelayCommand(
                    () =>
                    {
                        
                    }));
            }
        }
        #endregion
        #region Ctors and Methods

        public AddFriendViewModel(INavigationService navigationService, IDataService dataService, IMessagesNavigationService innerNavigationService)
            : base(navigationService, dataService, innerNavigationService)
        {
           
        }
         private string getFriendStatusMessage(int friendnumber)
        {
            return _tox.GetStatusMessage(friendnumber).Replace("\n", "").Replace("\r", "");
        }
        private string getFriendName(int friendnumber)
        {
            return _tox.GetName(friendnumber).Replace("\n", "").Replace("\r", "");
        }
        public override async void Activate(object parameter)
        {
            if (parameter is Tox)
            {
                _tox = (Tox) parameter;
            } 
            NewFriendRequest=new FriendRequest();
            ListPendingRequests=new ObservableCollection<FriendRequest>(await DataService.GetAllFriendRequest());
        }
        #endregion
    }
}
