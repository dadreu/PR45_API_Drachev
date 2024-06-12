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
            optionsBuilder.UseMySql("server=localhost;uid=root;database=TaskManager", 
                new MySqlServerVersion(new System.Version(8, 0, 11)));
    }
}

