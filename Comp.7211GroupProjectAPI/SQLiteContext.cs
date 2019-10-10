using Comp._7211GroupProjectAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Comp._7211GroupProjectAPI
{
    public class SQLiteContext : DbContext
    {
        public SQLiteContext(DbContextOptions<SQLiteContext> options)
            : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
    }
}
