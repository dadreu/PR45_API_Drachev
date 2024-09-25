using API_Drachev.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_Drachev.Context
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public UsersContext()
        {
            Database.EnsureCreated();
            Users.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;" +
                "uid=root;" +
                "port=3306;" +
                "pwd=;" +
                "database=TaskManagers", new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}

