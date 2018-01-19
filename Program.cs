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
            string newName = Guid.NewGuid().ToString();

            using (var db = new BloggingContext())
            {
                var anchor = new Anchor { Name =newName };
                var rootNode = new RootNode { Name = "Root" };
                var middle = new Node {Name = "middle"};
                middle.Children.Add(new Node{Name="DeepestLeaf"});
                rootNode.Children.Add(middle);
                rootNode.Children.Add(new Node { Name = "Leaf1" });
                rootNode.Children.Add(new Node { Name = "Leaf2" });

                
                anchor.Properties.Add(rootNode);
                db.Anchors.Add(anchor);
                db.SaveChanges();
            }
            using (var db = new BloggingContext())
            {
                var anchor = db.Anchors.First(a => a.Name==newName);
                db.Entry(anchor).Collection(a=>a.Properties).Load();
            }

            Console.ReadLine();
        }
    }
}
