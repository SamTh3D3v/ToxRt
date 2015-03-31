using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ToxRt.Helpers;
using ToxRt.Model;
using ToxRt.NavigationService;

namespace ToxRt.ViewModel
{
    public class SettingsViewModel:NavigableViewModelBase
    {
       #region Fields  
        private Profile _currentProfile   ;
        private ObservableCollection<String> _themes = new ObservableCollection<string>()
        {
            "Default" //tmp
        };
        private ObservableCollection<string> _languages = new ObservableCollection<string>()
        {
            "English" //tmp
        };
        private ObservableCollection<String> _audioInput;
        private ObservableCollection<String> _audioOutput;
        private ObservableCollection<String> _videoOutput;
        private ObservableCollection<String> _dpi;
        private bool _udpEnabled;
        private bool _ipv6Enabled = false;
        private String _selectedAudioInput;
        private String _selectedAudioOutput;
        private String _selectedVideoInput;
        private String _selectedDpi;      
        private Proxy _currentProxy  ;
        private ObservableCollection<String> _proxyState;
        private String _selectedProxyState;
        #endregion
        #region Properties
        public Profile CurrentProfile
        {
            get
            {
                return _currentProfile;
            }

            set
            {
                if (_currentProfile == value)
                {
                    return;
                }

                _currentProfile = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<String> Themes
        {
            get
            {
                return _themes;
            }

            set
            {
                if (_themes == value)
                {
                    return;
                }

                _themes = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<string> Languages
        {
            get
            {
                return _languages;
            }

            set
            {
                if (_languages == value)
                {
                    return;
                }

                _languages = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<String> AudioInput
        {
            get
            {
                return _audioInput;
            }

            set
            {
                if (_audioInput == value)
                {
                    return;
                }

                _audioInput = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<String> AudioOutput
        {
            get
            {
                return _audioOutput;
            }

            set
            {
                if (_audioOutput == value)
                {
                    return;
                }

                _audioOutput = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<String> VideoOutput
        {
            get
            {
                return _videoOutput;
            }

            set
            {
                if (_videoOutput == value)
                {
                    return;
                }

                _videoOutput = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<String> Dpi
        {
            get
            {
                return _dpi;
            }

            set
            {
                if (_dpi == value)
                {
                    return;
                }

                _dpi = value;
                RaisePropertyChanged();
            }
        }
        public String SelectedAudioInput
        {
            get
            {
                return _selectedAudioInput;
            }

            set
            {
                if (_selectedAudioInput == value)
                {
                    return;
                }

                _selectedAudioInput = value;
                RaisePropertyChanged();
            }
        }
        public String SelectedAudioOutput
        {
            get
            {
                return _selectedAudioOutput;
            }

            set
            {
                if (_selectedAudioOutput == value)
                {
                    return;
                }

                _selectedAudioOutput = value;
                RaisePropertyChanged();
            }
        }
        public String SelectedVideoInput
        {
            get
            {
                return _selectedVideoInput;
            }

            set
            {
                if (_selectedVideoInput == value)
                {
                    return;
                }

                _selectedVideoInput = value;
                RaisePropertyChanged();
            }
        }    
        public String SelectedDpi
        {
            get
            {
                return _selectedDpi;
            }

            set
            {
                if (_selectedDpi == value)
                {
                    return;
                }

                _selectedDpi = value;
                RaisePropertyChanged();
            }
        }
        public bool UpdEnabled
        {
            get
            {
                return _udpEnabled;
            }

            set
            {
                if (_udpEnabled == value)
                {
                    return;
                }

                _udpEnabled = value;
                RaisePropertyChanged();
            }
        }
        public bool Ipv6Enabled
        {
            get
            {
                return _ipv6Enabled;
            }

            set
            {
                if (_ipv6Enabled == value)
                {
                    return;
                }

                _ipv6Enabled = value;
                RaisePropertyChanged();
            }
        }
        public Proxy CurrentProxy
        {
            get
            {
                return _currentProxy;
            }

            set
            {
                if (_currentProxy == value)
                {
                    return;
                }

                _currentProxy = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<String> ProxyState
        {
            get
            {
                return _proxyState;
            }

            set
            {
                if (_proxyState == value)
                {
                    return;
                }

                _proxyState = value;
                RaisePropertyChanged();
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
                RaisePropertyChanged();
            }
        }
        #endregion
        #region Commands
        private RelayCommand _audioPreviewCommand;
        public RelayCommand AudioPreviewCommand
        {
            get
            {
                return _audioPreviewCommand
                    ?? (_audioPreviewCommand = new RelayCommand(
                    () =>
                    {
                        
                    }));
            }
        }
        private RelayCommand _videoPreviewCommand;

        public RelayCommand VideoPreviewCommand
        {
            get
            {
                return _videoPreviewCommand
                    ?? (_videoPreviewCommand = new RelayCommand(
                    () =>
                    {
                        
                    }));
            }
        }
      
        
        #endregion
        #region Ctors and Methods

        public SettingsViewModel(INavigationService navigationService, IDataService dataService, IMessagesNavigationService innerNavigationService)
            : base(navigationService,dataService, innerNavigationService)
        {
        }      
        #endregion 
    }
}
