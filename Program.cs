using ConsoleApp1.Intro;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new BloggingContext())
            {
                if (!db.Roots.Any())
                {
                    var anchor = new Anchor { Name = "Screen1" };
                    var rootNode = new RootNode { Name = "Root" };
                    rootNode.Children.Add(new Node { Name = "Leaf" });
                    anchor.Properties.Add(rootNode);
                }

                db.SaveChanges();
            }
            using (var db = new BloggingContext())
            {
                var anchor = db.Roots.First();
                anchor.Properties.ToList();
                anchor.Properties.
            }

            Console.ReadLine();
        }
    }
}
