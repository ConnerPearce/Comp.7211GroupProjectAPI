using System;
using System.Collections.Generic;

namespace Comp._7211GroupProjectAPI.Models
{
    public partial class Posts
    {
        public Posts()
        {
            Comments = new HashSet<Comments>();
        }

        public int Id { get; set; }
        public int Uid { get; set; }
        public string Post { get; set; }
        public int UpVote { get; set; }
        public int DownVote { get; set; }

        public virtual Users U { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
