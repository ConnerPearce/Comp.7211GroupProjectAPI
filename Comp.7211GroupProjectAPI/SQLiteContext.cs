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

        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<PostModel> Posts { get; set; }      
        public DbSet<SettingsModel> Settings { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}