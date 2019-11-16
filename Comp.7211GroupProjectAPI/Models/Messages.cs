using System;
using System.Collections.Generic;

namespace Comp._7211GroupProjectAPI.Models
{
    public partial class Messages
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Msg { get; set; }

        public virtual Users Receiver { get; set; }
        public virtual Users Sender { get; set; }
    }
}
