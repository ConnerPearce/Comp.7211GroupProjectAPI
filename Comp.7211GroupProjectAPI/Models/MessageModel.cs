using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp._7211GroupProjectAPI.Models
{
    public class MessageModel
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Message { get; set; }
        public int SenderID { get; set; }
        public int DestinationID { get; set; }
    }
}