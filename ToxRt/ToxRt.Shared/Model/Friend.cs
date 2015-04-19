using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ToxRt.Annotations;
using ToxRt.ViewModel;

namespace ToxRt.Model
{
    //IsPanding represent a sent friend request from the current profile
    public class Friend:INotifyPropertyChanged
    {
        #region Fields
        private string _realName;
        private string _screenName;
        private string _picSource;
        private string _statusMessage;
        private string _toxId;      
        private int _profileId;
        private int _friendNumber;
        private bool _isPanding;
        private Status _currentStatus = Status.Offline;
        #endregion
        #region Properties  
        public int FriendId { get; set; }
        public string RealName
        {
            get
            {
                return _realName;
            }

            set
            {
                if (_realName == value)
                {
                    return;
                }

                _realName = value;
                OnPropertyChanged();
            }
        }
        public int FriendNumber
        {
            get
            {
                return _friendNumber;
            }

            set
            {
                if (_friendNumber == value)
                {
                    return;
                }

                _friendNumber = value;
                OnPropertyChanged();
            }
        }
        public string ScreenName
        {
            get
            {
                return _screenName;
            }

            set
            {
                if (_screenName == value)
                {
                    return;
                }

                _screenName = value;
                OnPropertyChanged();
            }
        }
        public string PicSource
        {
            get
            {
                return _picSource;
            }

            set
            {
                if (_picSource == value)
                {
                    return;
                }

                _picSource = value;
                OnPropertyChanged();
            }
        } 
        public string StatusMessage
        {
            get
            {
                return _statusMessage;
            }

            set
            {
                if (_statusMessage == value)
                {
                    return;
                }

                _statusMessage = value;
                OnPropertyChanged();
            }
        }      
        public string ToxId
        {
            get
            {
                return _toxId;
            }

            set
            {
                if (_toxId == value)
                {
                    return;
                }

                _toxId = value;
                OnPropertyChanged();
            }
        }
        public int ProfileId
        {
            get
            {
                return _profileId;
            }

            set
            {
                if (_profileId == value)
                {
                    return;
                }

                _profileId = value;
                OnPropertyChanged();
            }
        }       
        public bool IsPanding
        {
            get
            {
                return _isPanding;
            }

            set
            {
                if (_isPanding == value)
                {
                    return;
                }

                _isPanding = value;
                OnPropertyChanged();
            }
        }        
        public Status CurrentStatus
        {
            get
            {
                return _currentStatus;
            }

            set
            {
                if (_currentStatus == value)
                {
                    return;
                }

                _currentStatus = value;
                OnPropertyChanged();
            }
        }
        //Navigation properties
        public ObservableCollection<Message> Messages { get; set; }
        public Profile Profile { get; set; }
        #endregion
        #region Commands        
        #endregion
        #region Ctors and Methods
        public Friend()
        {
            Messages=new ObservableCollection<Message>();
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion      
    }
}
