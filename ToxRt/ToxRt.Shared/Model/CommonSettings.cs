using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ToxRt.Annotations;

namespace ToxRt.Model
{
    public class CommonSettings:INotifyPropertyChanged
    {
        #region Fields
        private Proxy _proxySettings;
        private ObservableCollection<String> _proxyStateCollection;    
        private String _selectedProxyState;
        private bool _isUdpEnabled;
        private bool _isIpv6Enabled;
        #endregion
        #region Properties             
        public Proxy ProxySettins
        {
            get
            {
                return _proxySettings;
            }

            set
            {
                if (_proxySettings == value)
                {
                    return;
                }

                _proxySettings = value;
                OnPropertyChanged();
            }
        }                
        public ObservableCollection<String> ProxyStateCollection
        {
            get
            {
                return _proxyStateCollection;
            }

            set
            {
                if (_proxyStateCollection == value)
                {
                    return;
                }

                _proxyStateCollection = value;
                OnPropertyChanged();
            }
        }          
        public String SelectedProxyState
        {
            get
            {
                return _selectedProxyState;
            }

            set
            {
                if (_selectedProxyState == value)
                {
                    return;
                }

                _selectedProxyState = value;
                OnPropertyChanged();
            }
        }         
        public bool IsUdpEnabled
        {
            get
            {
                return _isUdpEnabled;
            }

            set
            {
                if (_isUdpEnabled == value)
                {
                    return;
                }

                _isUdpEnabled = value;
                OnPropertyChanged();
            }
        }       
        public bool IsIpv6Enabled
        {
            get
            {
                return _isIpv6Enabled;
            }

            set
            {
                if (_isIpv6Enabled == value)
                {
                    return;
                }

                _isIpv6Enabled = value;
                OnPropertyChanged();
            }
        }      
        #endregion
        #region Ctors and Methods

        public CommonSettings()
        {
            ProxyStateCollection=new ObservableCollection<string>()
            {
                "Disabled",
                "Always",
                "FallBack"
            };
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
