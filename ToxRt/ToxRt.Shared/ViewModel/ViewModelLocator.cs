using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using ToxRt.NavigationService;
using ToxRt.View;

namespace ToxRt.ViewModel
{    
    public class ViewModelLocator
    {
 
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MessagesViewModel>();
#if WINDOWS_APP
            SetupMessagesNavigation();
#endif
        }
#if WINDOWS_APP
        private static void SetupMessagesNavigation()
        {
            var navigationService = new MessagesNavigationService();
            navigationService.Configure("MessagesView",typeof(MessagesView));           
            SimpleIoc.Default.Register<IMessagesNavigationService>(() => navigationService);
        }
#endif


        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MessagesViewModel MessagesViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MessagesViewModel>();
            }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}