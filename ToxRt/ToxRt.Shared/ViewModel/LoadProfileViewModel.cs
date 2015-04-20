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
        #endregion
        #region Ctors and Methods
        public LoadProfileViewModel(INavigationService navigationService, IDataService dataService, IMessagesNavigationService innerNavigationService)
            : base(navigationService,dataService, innerNavigationService)
        {
        }
        
        #endregion
    }
}
