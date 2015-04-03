using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ToxRt.Helpers;
using ToxRt.Model;
using ToxRt.NavigationService;

namespace ToxRt.ViewModel
{
    public class AddFriendViewModel:NavigableViewModelBase
    {
        #region Fields   
        private FriendRequest _newFriendRequest;       
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
                        
                    }));
            }
        }

        #endregion
        #region Ctors and Methods

        public AddFriendViewModel(INavigationService navigationService,IDataService dataService, IMessagesNavigationService innerNavigationService) : base(navigationService,dataService, innerNavigationService)
        {
        }      
        #endregion              
    }
}
