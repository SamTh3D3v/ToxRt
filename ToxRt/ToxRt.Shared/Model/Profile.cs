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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
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
                OnPropertyChanged();
            }
        }
        #endregion
    }
}
