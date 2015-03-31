using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using ToxRt.Model;
using ToxRt.NavigationService;

namespace ToxRt.Helpers
{
    public class NavigableViewModelBase:ViewModelBase,INavigable
    {
        #region Fields
        protected IMessagesNavigationService InnerNavigationService;
        protected INavigationService NavigationService;
        protected IDataService DataService;
        #endregion
        #region Ctors and Methods

        public NavigableViewModelBase(INavigationService navigationService,IDataService dataService, IMessagesNavigationService innerNavigationService = null)
        {
            InnerNavigationService = innerNavigationService;
            NavigationService = navigationService;
            DataService = dataService;
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
