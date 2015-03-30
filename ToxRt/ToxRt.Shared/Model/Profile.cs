using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ToxRt.Model
{
    public class Profile : Friend
    {
        #region Fields
        private bool _loggin = false;
        private bool _audioNotifications = false;
        private bool _closeToTray = false;
        private ObservableCollection<Friend> _friends;
        private String _profileTheme = "Mytheme"; //tmp
        private String _profileLanguage = "English"; //tmp
        #endregion
        #region Properties
        public bool Loggin
        {
            get
            {
                return _loggin;
            }

            set
            {
                if (_loggin == value)
                {
                    return;
                }

                _loggin = value;
                OnPropertyChanged();
            }
        }
        public bool AudioNotifications
        {
            get
            {
                return _audioNotifications;
            }

            set
            {
                if (_audioNotifications == value)
                {
                    return;
                }

                _audioNotifications = value;
                OnPropertyChanged();
            }
        }
        public bool CloseToTray
        {
            get
            {
                return _closeToTray;
            }

            set
            {
                if (_closeToTray == value)
                {
                    return;
                }

                _closeToTray = value;
                OnPropertyChanged();
            }
        }
        public String ProfileTheme
        {
            get
            {
                return _profileTheme;
            }

            set
            {
                if (_profileTheme == value)
                {
                    return;
                }

                _profileTheme = value;
                OnPropertyChanged();
            }
        }
        public String ProfileLanguage
        {
            get
            {
                return _profileLanguage;
            }

            set
            {
                if (_profileLanguage == value)
                {
                    return;
                }

                _profileLanguage = value;
                OnPropertyChanged();
            }
        }        
        public ObservableCollection<Friend> Friends
        {
            get
            {
                return _friends;
            }

            set
            {
                if (_friends == value)
                {
                    return;
                }

                _friends = value;
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
