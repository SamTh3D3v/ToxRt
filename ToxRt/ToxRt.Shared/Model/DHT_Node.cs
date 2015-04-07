using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ToxRt.Annotations;

namespace ToxRt.Model
{
    public class DHT_Node:INotifyPropertyChanged
    {
        #region Fields       
        private int _nodeId  ;
        private String _IpV4;
        private String _IpV6;
        private int _port;
        private String _clientId;
        private String _mainTainer;
        private String _location;
        private String _status;
        #endregion
        #region Properties
        public int NodeId
        {
            get
            {
                return _nodeId;
            }

            set
            {
                if (_nodeId == value)
                {
                    return;
                }

                _nodeId = value;
                OnPropertyChanged();
            }
        }
        public String Ipv4
        {
            get
            {
                return _IpV4;
            }

            set
            {
                if (_IpV4 == value)
                {
                    return;
                }

                _IpV4 = value;
                OnPropertyChanged();
            }
        }
        public String IpV6
        {
            get
            {
                return _IpV6;
            }

            set
            {
                if (_IpV6 == value)
                {
                    return;
                }

                _IpV6 = value;
                OnPropertyChanged();
            }
        }
        public int Port
        {
            get
            {
                return _port;
            }

            set
            {
                if (_port == value)
                {
                    return;
                }

                _port = value;
                OnPropertyChanged();
            }
        }
        public String ClientId
        {
            get
            {
                return _clientId;
            }

            set
            {
                if (_clientId == value)
                {
                    return;
                }

                _clientId = value;
                OnPropertyChanged();
            }
        }
        public String Maintainer
        {
            get
            {
                return _mainTainer;
            }

            set
            {
                if (_mainTainer == value)
                {
                    return;
                }

                _mainTainer = value;
                OnPropertyChanged();
            }
        }
        public String Location
        {
            get
            {
                return _location;
            }

            set
            {
                if (_location == value)
                {
                    return;
                }

                _location = value;
                OnPropertyChanged();
            }
        }
        public String Status
        {
            get
            {
                return _status;
            }

            set
            {
                if (_status == value)
                {
                    return;
                }

                _status = value;
                OnPropertyChanged();
            }
        }                      
        #endregion
        #region Ctor and Methods
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
