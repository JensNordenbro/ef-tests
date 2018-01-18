using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace ConsoleApp1
{
    namespace Intro
    {
        public class BloggingContext : DbContext
        {
            public DbSet<Anchor> Anchors { get; set; }
            public DbSet<Node> Nodes { get; set; }
            
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase3;Trusted_Connection=True;");
            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Anchor>()
                    .HasKey(a => a.Id);
                modelBuilder.Entity<Node>()
                    .HasKey(a => a.Id);
            }

        }

        public class Anchor
        {
            public int Id{get;set;}
          
            public string Name { get; set; }
            public ICollection<RootNode> Properties { get; } = new List<RootNode>();
        }

        public class RootNode : Node { }

        public class Node
        {
            public int Id{get;set;}
            public string Name { get; set; }
            public Anchor Root { get; set; }
            public ICollection<Node> Children { get; } = new List<Node>();
        }

       
    }
}
