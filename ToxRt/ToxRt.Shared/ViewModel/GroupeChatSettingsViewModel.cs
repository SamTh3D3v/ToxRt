using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Views;
using ToxRt.Helpers;
using ToxRt.Model;
using ToxRt.NavigationService;

namespace ToxRt.ViewModel
{
    public class GroupeChatSettingsViewModel:NavigableViewModelBase
    {
         #region Fields        
        
        #endregion
        #region Properties

        #endregion
        #region Commands

        #endregion
        #region Ctors and Methods

        public GroupeChatSettingsViewModel(INavigationService navigationService, IDataService dataService, IMessagesNavigationService innerNavigationService)
            : base(navigationService,dataService, innerNavigationService)
        {
        }      
        #endregion    
    }
}
