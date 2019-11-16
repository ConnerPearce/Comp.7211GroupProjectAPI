﻿using System;
using System.Collections.Generic;

namespace Comp._7211GroupProjectAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Comments = new HashSet<Comments>();
            MessagesReceiver = new HashSet<Messages>();
            MessagesSender = new HashSet<Messages>();
            Posts = new HashSet<Posts>();
            Settings = new HashSet<Settings>();
        }

        public int Id { get; set; }
        public string Uid { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Nickname { get; set; }
        public string Pword { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
        public string Position { get; set; }

        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Messages> MessagesReceiver { get; set; }
        public virtual ICollection<Messages> MessagesSender { get; set; }
        public virtual ICollection<Posts> Posts { get; set; }
        public virtual ICollection<Settings> Settings { get; set; }
    }
}
