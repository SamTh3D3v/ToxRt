using System;
using System.Collections.Generic;
using System.Text;

namespace ToxRt.Model
{
    public class Message
    {
        #region Properties

        //The Sender is used as a navigation property
        public Friend Sender { get; set; }    
        public String MessageText { get; set; }
        public DateTime MessageDate { get; set; }
        #endregion
    }
}
