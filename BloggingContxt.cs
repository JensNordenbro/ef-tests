using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConsoleApp1
{
    namespace Intro
    {
        public class BloggingContext : DbContext
        {
            public DbSet<Anchor> Roots { get; set; }
            public DbSet<Node> Nodes { get; set; }
            

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
            }
        }

        public class Anchor
        {
            public string Name { get; set }
            public ICollection<RootNode> Properties { get; set; }
        }

        public class RootNode : Node { }

        public class Node
        {
            public string Name { get; set; }
            public Anchor Root { get; set; }
            public ICollection<Node> Children { get; set; }
        }

       
    }
}
