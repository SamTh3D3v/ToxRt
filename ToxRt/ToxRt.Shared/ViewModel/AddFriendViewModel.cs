using System;
using System.Collections.Generic;
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
                            int friendnumber = _tox.AddFriend(new ToxId(NewFriendRequest.ToxId), NewFriendRequest.RequestMessage);                                                        
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
        #endregion
        #region Ctors and Methods

        public AddFriendViewModel(INavigationService navigationService, IDataService dataService, IMessagesNavigationService innerNavigationService)
            : base(navigationService, dataService, innerNavigationService)
        {
        }
        public override void Activate(object parameter)
        {
            if (parameter is Tox)
            {
                _tox = (Tox) parameter;
            }            
        }
        #endregion
    }
}
