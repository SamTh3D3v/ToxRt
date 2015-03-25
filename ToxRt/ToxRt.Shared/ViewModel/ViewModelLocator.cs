using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
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

            SetupMessagesNavigation();

        }

        private static void SetupMessagesNavigation()
        {
            var navigationService = new MessagesNavigationService();
#if WINDOWS_APP
            navigationService.Configure("MessagesView",typeof(MessagesView));
#endif
#if WINDOWS_PHONE_APP
            navigationService.Configure("MessagesView", typeof(FriendChatView));     
#endif             
            SimpleIoc.Default.Register<IMessagesNavigationService>(() => navigationService);
        }


        


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