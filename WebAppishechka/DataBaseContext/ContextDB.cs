﻿using Microsoft.EntityFrameworkCore;
using WebAppishechka.Model;


namespace WebAppishechka.DataBaseContext
{
    public class ContextDB : DbContext
    {
        public ContextDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> User { get; set; }
    }
}
