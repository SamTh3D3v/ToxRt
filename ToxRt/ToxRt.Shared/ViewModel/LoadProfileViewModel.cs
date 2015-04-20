using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Views;
using ToxRt.Helpers;
using ToxRt.Model;
using ToxRt.NavigationService;

namespace ToxRt.ViewModel
{
    public class LoadProfileViewModel : NavigableViewModelBase
    {
        #region Fields
        
        #endregion
        #region Properties
        
        #endregion
        #region Commands
        
        #endregion
        #region Ctors and Methods
        public LoadProfileViewModel(INavigationService navigationService, IDataService dataService, IMessagesNavigationService innerNavigationService)
            : base(navigationService,dataService, innerNavigationService)
        {
        }
        
        #endregion
    }
}
