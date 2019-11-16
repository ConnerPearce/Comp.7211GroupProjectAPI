using System;
using System.Collections.Generic;

namespace Comp._7211GroupProjectAPI.Models
{
    public partial class Comments
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }

        public virtual Posts Post { get; set; }
        public virtual Users U { get; set; }
    }
}
