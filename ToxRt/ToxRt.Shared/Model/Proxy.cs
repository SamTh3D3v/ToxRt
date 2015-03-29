using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using ToxRt.Annotations;

namespace ToxRt.Model
{
    public class Proxy:INotifyPropertyChanged
    {
        #region Fields
        private String _ipAdress;
        private String _portNumber;
 
        #endregion
        #region Properties
        public String IpAdress
        {
            get
            {
                return _ipAdress;
            }

            set
            {
                if (_ipAdress == value)
                {
                    return;
                }

                _ipAdress = value;
                OnPropertyChanged();
            }
        }     
        public String PortNumber
        {
            get
            {
                return _portNumber;
            }

            set
            {
                if (_portNumber == value)
                {
                    return;
                }

                _portNumber = value;
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
