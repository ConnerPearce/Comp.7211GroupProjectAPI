using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comp._7211GroupProjectAPI.Models
{
    public class UserModel
    {
        [PrimaryKey, AutoIncrement]
        public Int64 id { get; set; }

        [NotNull]
        public Int64 UId { get; set; }

        [NotNull]
        public String FirstName { get; set; }

        [NotNull]
        public String LastName { get; set; }

        [NotNull]
        public String Dob { get; set; }

        [NotNull]
        public String Email { get; set; }

        [NotNull]
        public String Address { get; set; }

        public String Nickname { get; set; }

        [NotNull]
        public String Password { get; set; }
    }
}
