using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;

namespace ToxRt.NavigationService
{

//No need to implement this service in the windows phone project...
//i will use the default navigation service 
    public interface IMessagesNavigationService : INavigationService
    {
        //parameter to be passed between pages 
        object Parameter { get; }
    }

}
