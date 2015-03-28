using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ToxRt.Annotations;

namespace ToxRt.Model
{
    public class Friend:INotifyPropertyChanged
    {
        #region Fields
        private string _realName;
        private string _screenName;
        private string _picSource;
        private string _statusMessage;
        private string _toxId;

        #endregion
        #region Properties        
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
        #endregion
        #region Commands        
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
