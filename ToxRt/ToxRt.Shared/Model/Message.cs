using System;
using System.Collections.Generic;
using System.Text;

namespace ToxRt.Model
{
    public class Message
    {
        #region Properties

        public Friend Sender { get; set; }    
        public String MessageText { get; set; }    
        #endregion
    }
}
