using ChatApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApi.DA
{
    public class ChatApiContext : DbContext
    {
        public ChatApiContext(DbContextOptions<ChatApiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Messages)
                .WithOne(m => m.User);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
