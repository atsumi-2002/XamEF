using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using XamEF.Models;


namespace XamEF.DataContext
{
    public class DBContext : DbContext
    {
        string DbPath = string.Empty;

        public DBContext(string dbPath)
        {
            this.DbPath = dbPath;
        }

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Album> Albumes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");
        }

    }
}
