using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using ToxRt.NavigationService;

namespace ToxRt.ViewModel
{
    class MessagesViewModel:ViewModelBase
    {
        #region Fields

        private IMessagesNavigationService _navigationService;
        
        #endregion 
        #region Properties
        
        #endregion 
        #region Commands    
        
        #endregion 
        #region Ctors and Methods

        public MessagesViewModel(IMessagesNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        
        #endregion       
    }
}
