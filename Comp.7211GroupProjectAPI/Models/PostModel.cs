using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Comp._7211GroupProjectAPI.Models
{
    public class PostModel
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [NotNull]
        public int UId { get; set; }
        [NotNull]
        public string PostDescription { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }
    }
}