using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ToxRt.Annotations;

namespace ToxRt.Model
{
    public class FriendRequest:INotifyPropertyChanged
    {
        #region Fields
        private int _friendRequestId;
        private String _requestMessage;
        private String _toxId;
        #endregion
        #region Properties 
        public int FriendRequestId
        {
            get
            {
                return _friendRequestId;
            }

            set
            {
                if (_friendRequestId == value)
                {
                    return;
                }

                _friendRequestId = value;
                OnPropertyChanged();
            }
        }
        public String RequestMessage
        {
            get
            {
                return _requestMessage;
            }

            set
            {
                if (_requestMessage == value)
                {
                    return;
                }

                _requestMessage = value;
                OnPropertyChanged();
            }
        }
        public String ToxId
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
        #endregion
        #region Ctors and Methods
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
