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
    public class LoadProfileViewModel : NavigableViewModelBase
    {
        #region Fields
        private ObservableCollection<Profile> _listProfiles;
        private Profile _selectedProfile;
        private ObservableCollection<String> _listSupportedLanguages = new ObservableCollection<string>()  //To Be Changed 
        {
            "English",
            "French"
        };
        private ObservableCollection<String> _lisSupportedThems = new ObservableCollection<string>()
        {
            "Dark","Light"
        };
        #endregion
        #region Properties              
        public ObservableCollection<Profile> ListProfiles
        {
            get
            {
                return _listProfiles;
            }

            set
            {
                if (_listProfiles == value)
                {
                    return;
                }

                _listProfiles = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<String> ListSupportedLangauges
        {
            get
            {
                return _listSupportedLanguages;
            }

            set
            {
                if (_listSupportedLanguages == value)
                {
                    return;
                }

                _listSupportedLanguages = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<String> ListSupportedThems
        {
            get
            {
                return _lisSupportedThems;
            }

            set
            {
                if (_lisSupportedThems == value)
                {
                    return;
                }

                _lisSupportedThems = value;
                RaisePropertyChanged();
            }
        }
        public Profile SelectedProfile
        {
            get
            {
                return _selectedProfile;
            }

            set
            {
                if (_selectedProfile == value)
                {
                    return;
                }

                _selectedProfile = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region Commands
        private RelayCommand _loadProfielCommand;
        public RelayCommand LoadProfileCommand
        {
            get
            {
                return _loadProfielCommand
                    ?? (_loadProfielCommand = new RelayCommand(
                    () =>
                    {
                        
                    }));
            }
        }
        private RelayCommand _setDefaultProfileCommand;
        public RelayCommand SetDefaultProfileCommand
        {
            get
            {
                return _setDefaultProfileCommand
                    ?? (_setDefaultProfileCommand = new RelayCommand(
                    () =>
                    {
                        
                    }));
            }
        }
        private RelayCommand _saveProfileCommand;
        public RelayCommand SaveProfileCommand
        {
            get
            {
                return _saveProfileCommand
                    ?? (_saveProfileCommand = new RelayCommand(
                    () =>
                    {
                        
                    }));
            }
        }
        private RelayCommand _deleteProfileCommand;
        public RelayCommand DeleteProfileCommand
        {
            get
            {
                return _deleteProfileCommand
                    ?? (_deleteProfileCommand = new RelayCommand(
                    () =>
                    {
                        
                    }));
            }
        }
        private RelayCommand _profilePageLoadedCommand;
        public RelayCommand ProfilePageLoadedCommand
        {
            get
            {
                return _profilePageLoadedCommand
                    ?? (_profilePageLoadedCommand = new RelayCommand(
                    () =>
                    {
                        //Load profile from the sqlite DB
                    }));
            }
        }
        #endregion
        #region Ctors and Methods
        public LoadProfileViewModel(INavigationService navigationService, IDataService dataService, IMessagesNavigationService innerNavigationService)
            : base(navigationService,dataService, innerNavigationService)
        {
        }

        public override void Activate(object parameter)
        {
            base.Activate(parameter);
        }

        public override void Deactivate(object parameter)
        {
            base.Deactivate(parameter);
        }

        #endregion
    }
}
