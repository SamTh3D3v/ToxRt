using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using ToxRt.NavigationService;

namespace ToxRt.Helpers
{
    public class NavigableViewModelBase:ViewModelBase,INavigable
    {
        #region Fields
        protected IMessagesNavigationService InnerNavigationService;
        protected INavigationService NavigationService;
        #endregion
        #region Ctors and Methods

        public NavigableViewModelBase(INavigationService navigationService, IMessagesNavigationService innerNavigationService = null)
        {
            InnerNavigationService = innerNavigationService;
            NavigationService = navigationService;
        }
        #endregion
        virtual public void Activate(object parameter)
        {            
        }

        virtual public void Deactivate(object parameter)
        {            
        }

        virtual public void GoBack()
        {            
        }
    }
}
