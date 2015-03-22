﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ToxRt.Helpers
{
    public  class BindablePage:Page
    {
        public BindablePage()
            : base()
        {
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var navigableViewModel = this.DataContext as INavigable;
            if (navigableViewModel != null)
                navigableViewModel.Activate(e.Parameter);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            var navigableViewModel = this.DataContext as INavigable;
            if (navigableViewModel != null)
                navigableViewModel.Deactivate(e.Parameter);
        }


      



    }
}
