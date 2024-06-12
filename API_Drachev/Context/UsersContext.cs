using API_Drachev.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_Drachev.Context
{
    public class UsersContext : DbContext
    {
        public DbSet<Users> Users {  get; set; }
        UsersContext() 
        {
            Database.EnsureCreated();
            Users.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseMySql("server=127.0.0.1; " +
                "uid=root;" +
                "pwd=;" +
                "database=TaskManagers",
                new MySqlServerVersion(new Version(8, 0, 11)));

    }
}
}
