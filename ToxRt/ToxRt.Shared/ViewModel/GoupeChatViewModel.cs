using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Views;
using ToxRt.Helpers;
using ToxRt.NavigationService;

namespace ToxRt.ViewModel
{
    class GoupeChatViewModel:NavigableViewModelBase
    {
        #region Fields        
        
        #endregion
        #region Properties

        #endregion
        #region Commands

        #endregion
        #region Ctors and Methods

        public GoupeChatViewModel(INavigationService navigationService, IMessagesNavigationService innerNavigationService)
            : base(navigationService, innerNavigationService)
        {
        }      
        #endregion 
    }
}
