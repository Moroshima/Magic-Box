using MagicalBox.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalBox.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<User>? Users { get; set; }
        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder) + Path.DirectorySeparatorChar + "MagicalBox";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            DbPath = string.Join(Path.DirectorySeparatorChar, path, "MagicalBox.db");
        }

        public string DbPath { get; }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
