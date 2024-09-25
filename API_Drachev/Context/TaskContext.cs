using Microsoft.EntityFrameworkCore;
using System;
using API_Drachev.Model;

namespace API_Drachev.Context
{
    public class TaskContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public TaskContext()
        {
            Database.EnsureCreated();
            Tasks.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;uid=root;database=TaskManagers", 
                new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
