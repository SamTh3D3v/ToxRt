﻿using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Views;
using ToxRt.Helpers;
using ToxRt.NavigationService;

namespace ToxRt.ViewModel
{
    public class SettingsViewModel:NavigableViewModelBase
    {
       #region Fields        
        
        #endregion
        #region Properties

        #endregion
        #region Commands

        #endregion
        #region Ctors and Methods

        public SettingsViewModel(INavigationService navigationService, IMessagesNavigationService innerNavigationService)
            : base(navigationService, innerNavigationService)
        {
        }      
        #endregion 
    }
}
