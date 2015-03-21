using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;

namespace ToxRt.NavigationService
{


    interface IMessagesNavigationService : INavigationService
    {
        //parameter to be passed between pages 
        object Parameter { get; }
    }

}
