using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using ToxRt.Model;
using ToxRt.NavigationService;

namespace ToxRt.ViewModel
{
    public class MessagesViewModel:ViewModelBase
    {
        #region Fields
        private IMessagesNavigationService _navigationService;    
        
        #endregion 
        #region Properties         
        private ObservableCollection<Message> _listOnScreenMessages ;
        private Friend _feriend;
        private String _textMessage;
        public ObservableCollection<Message> ListOnscreenMessages
        {
            get
            {
                return _listOnScreenMessages;
            }

            set
            {
                if (_listOnScreenMessages == value)
                {
                    return;
                }

                _listOnScreenMessages = value;
                RaisePropertyChanged();
            }
        }
        public Friend Friend
        {
            get
            {
                return _feriend;
            }

            set
            {
                if (_feriend == value)
                {
                    return;
                }

                _feriend = value;
                RaisePropertyChanged();
            }
        }
        public String TextMessage
        {
            get
            {
                return _textMessage;
            }

            set
            {
                if (_textMessage == value)
                {
                    return;
                }

                _textMessage = value;
                RaisePropertyChanged();
            }
        }
        #endregion 
        #region Commands    
        private RelayCommand _sendCommand;
        public RelayCommand SendCommand
        {
            get
            {
                return _sendCommand
                    ?? (_sendCommand = new RelayCommand(
                    () => ListOnscreenMessages.Add(new Message()
                    {
                        MessageText = TextMessage,
                        Sender = Friend
                    })));
            }
        }
        #endregion 
        #region Ctors and Methods

        public MessagesViewModel(IMessagesNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        
        #endregion       
    }
}
