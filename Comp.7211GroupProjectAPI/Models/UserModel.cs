﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp._7211GroupProjectAPI.Models
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int UId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Dob { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Nickname { get; set; }
        public string Password { get; set; }
    }
}