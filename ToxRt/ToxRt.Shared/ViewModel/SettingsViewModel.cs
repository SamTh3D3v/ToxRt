using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ToxRt.Helpers;
using ToxRt.Model;
using ToxRt.NavigationService;

namespace ToxRt.ViewModel
{
    public enum SettingsType
    {
        UserDetails,
        UserSettings,
        DevicesAndDisplay,
        Networking
    }

    public class SettingTypeItem
    {
        public SettingsType SettingsType { get; set; }
        public String SettingsDisplayName { get; set; }
    }
    public class SettingsViewModel : NavigableViewModelBase
    {
        #region Fields
        private Profile _currentProfile;
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
        private Proxy _currentProxy;
        private ObservableCollection<String> _proxyState;
        private String _selectedProxyState;
        private Visibility _userSettingsVisibility = Visibility.Collapsed;
        private Visibility _userDetailsVisibility = Visibility.Collapsed;
        private Visibility _networkingVisibility = Visibility.Collapsed;
        private Visibility _devicesAndDisplay = Visibility.Collapsed;
        private ObservableCollection<SettingTypeItem> _settingItems;
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
        public Visibility UserSettingsVisibility
        {
            get
            {
                return _userSettingsVisibility;
            }

            set
            {
                if (_userSettingsVisibility == value)
                {
                    return;
                }

                _userSettingsVisibility = value;
                RaisePropertyChanged();
            }
        }
        public Visibility UserDetailsVisibility
        {
            get
            {
                return _userDetailsVisibility;
            }

            set
            {
                if (_userDetailsVisibility == value)
                {
                    return;
                }

                _userDetailsVisibility = value;
                RaisePropertyChanged();
            }
        }
        public Visibility NeworkingVisibility
        {
            get
            {
                return _networkingVisibility;
            }

            set
            {
                if (_networkingVisibility == value)
                {
                    return;
                }

                _networkingVisibility = value;
                RaisePropertyChanged();
            }
        }
        public Visibility DevicesAndDisplay
        {
            get
            {
                return _devicesAndDisplay;
            }

            set
            {
                if (_devicesAndDisplay == value)
                {
                    return;
                }

                _devicesAndDisplay = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<SettingTypeItem> SettingItems
        {
            get
            {
                return _settingItems;
            }

            set
            {
                if (_settingItems == value)
                {
                    return;
                }

                _settingItems = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region Commands
        private RelayCommand _settingsViewLoadedCommand;
        public RelayCommand SettingsViewLoadedCommand
        {
            get
            {
                return _settingsViewLoadedCommand
                    ?? (_settingsViewLoadedCommand = new RelayCommand(
                    () =>
                    {
                        UserDetailsVisibility = Visibility.Visible;
                    }));
            }
        }
        private RelayCommand _copyToClipboardCommand;
        public RelayCommand CopyToClipboardCommand
        {
            get
            {
                return _copyToClipboardCommand
                    ?? (_copyToClipboardCommand = new RelayCommand(
                    () =>
                    {

                        var dataPackage = new DataPackage();
                        dataPackage.SetText(CurrentProfile.ToxId);
                        Clipboard.SetContent(dataPackage);                        
                    }));
            }
        }
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
        private RelayCommand _goBackCommand;
        public RelayCommand GoBackCommand
        {
            get
            {
                return _goBackCommand
                    ?? (_goBackCommand = new RelayCommand(
                    () =>
                    {
                        NavigationService.NavigateTo("MainPage",CurrentProfile);  //Pass the updated profile
                    }));
            }
        }
        private RelayCommand<SettingsType> _changeSetingsTypeCommand;
        public RelayCommand<SettingsType> ChangeSetingsTypeCommand
        {
            get
            {
                return _changeSetingsTypeCommand
                    ?? (_changeSetingsTypeCommand = new RelayCommand<SettingsType>(
                    (settingsType) =>
                    {
                        NeworkingVisibility = Visibility.Collapsed;
                        UserDetailsVisibility = Visibility.Collapsed;
                        UserSettingsVisibility = Visibility.Collapsed;
                        DevicesAndDisplay = Visibility.Collapsed;
                        switch (settingsType)
                        {
                            case SettingsType.UserDetails:
                                UserDetailsVisibility = Visibility.Visible;
                                break;
                            case SettingsType.UserSettings:
                                UserSettingsVisibility = Visibility.Visible;
                                break;
                            case SettingsType.Networking:
                                NeworkingVisibility = Visibility.Visible;
                                break;
                            case SettingsType.DevicesAndDisplay:
                                DevicesAndDisplay = Visibility.Visible;
                                break;

                        }

                    }));
            }
        }


        #endregion
        #region Ctors and Methods

        public SettingsViewModel(INavigationService navigationService, IDataService dataService, IMessagesNavigationService innerNavigationService)
            : base(navigationService, dataService, innerNavigationService)
        {
            SettingItems = new ObservableCollection<SettingTypeItem>()
            {
                new SettingTypeItem()
                {
                    SettingsType = SettingsType.DevicesAndDisplay,
                    SettingsDisplayName ="Devices And Display"
                }, 
                new SettingTypeItem()
                {
                    SettingsType = SettingsType.UserDetails,
                    SettingsDisplayName ="User Details"
                }, 
                new SettingTypeItem()
                {
                    SettingsType = SettingsType.UserSettings,
                    SettingsDisplayName ="User Settings"
                }, 
                new SettingTypeItem()
                {
                    SettingsType = SettingsType.Networking,
                    SettingsDisplayName ="Networking"
                },
            };
            Themes=new ObservableCollection<string>()
            {
                "light theme",
                "dark theme"
            };
        }
        public override void Activate(object parameter)
        {
            if (parameter != null)
            {
                CurrentProfile = (Profile)parameter;
            }
        }

        public override void Deactivate(object parameter)
        {
        }

        public override void GoBack()
        {
        }
        #endregion
    }
}
