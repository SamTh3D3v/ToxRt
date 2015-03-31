using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using ToxRt.Helpers;
using ToxRt.Model;
using ToxRt.NavigationService;

namespace ToxRt.ViewModel
{
    public class CreditViewModel:NavigableViewModelBase
    {
        #region Fields        
        
        #endregion
        #region Properties

        #endregion
        #region Commands
        private RelayCommand _goBackCommand;
        public RelayCommand GoBackCommand
        {
            get
            {
                return _goBackCommand
                    ?? (_goBackCommand = new RelayCommand(
                    () =>
                    {
                        NavigationService.NavigateTo("MainPage");
                    }));
            }
        }
        #endregion
        #region Ctors and Methods

        public CreditViewModel(INavigationService navigationService, IDataService dataService, IMessagesNavigationService innerNavigationService)
            : base(navigationService,dataService, innerNavigationService)
        {
        }      
        #endregion 
    }
}
