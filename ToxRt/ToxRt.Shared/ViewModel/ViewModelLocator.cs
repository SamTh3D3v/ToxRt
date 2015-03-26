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
            SimpleIoc.Default.Register<AddFriendViewModel>();
            SimpleIoc.Default.Register<CreditViewModel>();
            SimpleIoc.Default.Register<AllFriendsViewModel>();
            SimpleIoc.Default.Register<GoupeChatViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<GroupeChatSettingsViewModel>();
            SetupUpNavigationServices();

        }        
        private static void SetupUpNavigationServices()
        {
#if WINDOWS_APP
            var innerNavigationService = CreateInnerNavigationService();
            var navigationservice = CreateGlobalWindowsNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationservice);
            SimpleIoc.Default.Register<IMessagesNavigationService>(() => innerNavigationService);
#endif
#if WINDOWS_PHONE_APP            
            var navigationservice = CreateGlobalWindowsPhoneNavigationService();
            SimpleIoc.Default.Register<INavigationService>(() => navigationservice);            
#endif

        }
        
#if WINDOWS_APP
        //based on which navigation service you use, you can choose to view the page whith the side bar or navigate 
        //en tirelly to it 
        private static INavigationService CreateGlobalWindowsNavigationService()
        {
            //for page navigation 
            var navigationService = new GalaSoft.MvvmLight.Views.NavigationService();
            navigationService.Configure("CreditView", typeof(CreditView));
            navigationService.Configure("GroupeChatView", typeof(GroupeChatView));
            navigationService.Configure("SettingsView", typeof(SettingsView));
            navigationService.Configure("MainPage", typeof(MainPage));
            navigationService.Configure("GroupeChatSettingsView", typeof(GroupeChatSettingsView));

            return navigationService;
        }
        private static IMessagesNavigationService CreateInnerNavigationService()
        {
            //for messages frame navigation 
            var navigationService = new MessagesNavigationService();
            navigationService.Configure("MessagesView", typeof(MessagesView));
            navigationService.Configure("AddFriendView", typeof(AddFriendView));
            navigationService.Configure("CreditView", typeof(CreditView));
            navigationService.Configure("GroupeChatView", typeof(GroupeChatView));
            navigationService.Configure("SettingsView", typeof(SettingsView));
            navigationService.Configure("GroupeChatSettingsView", typeof(GroupeChatSettingsView));
            return navigationService;

        }
#endif
#if WINDOWS_PHONE_APP
        private static INavigationService CreateGlobalWindowsPhoneNavigationService()
        {
        //for page navigation 
            var navigationService = new GalaSoft.MvvmLight.Views.NavigationService();
            navigationService.Configure("CreditView", typeof(CreditView));
            navigationService.Configure("GroupeChatView", typeof(GroupeChatView));
            navigationService.Configure("SettingsView", typeof(SettingsView));
            navigationService.Configure("MainPage", typeof(MainPage));
            navigationService.Configure("AllFriendsView", typeof(AllFriendsView));
            return navigationService;
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public AddFriendViewModel AddFriendViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddFriendViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public CreditViewModel CreditViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CreditViewModel>();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public AllFriendsViewModel AllFriendsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AllFriendsViewModel>();
            }
        }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public GoupeChatViewModel GroupeChatViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GoupeChatViewModel>();
            }
        }
     
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public SettingsViewModel SettingsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SettingsViewModel>();
            }
        }     
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public GroupeChatSettingsViewModel GroupeChatSettingsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<GroupeChatSettingsViewModel>();
            }
        }
        

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}