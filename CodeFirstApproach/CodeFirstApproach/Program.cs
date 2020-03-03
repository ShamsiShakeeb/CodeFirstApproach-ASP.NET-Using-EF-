using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstApproach
{
    class Program
    {

        public class Information
        {
            public int id { set; get; }
            public String Name { set; get; }
            public String Email { set; get; }

            public String Password { set; get; }
        }

        public class DB: DbContext
        {
            public DbSet<Information> InfoTable { set; get; }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter ID: ");
            int ID = Int32.Parse(Console.ReadLine().ToString());
            Console.WriteLine("Enter Name: ");
            String NAME = Console.ReadLine();
            Console.WriteLine("Enter Email: ");
            String EMAIL = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            String PASSWORD = Console.ReadLine();

            DB context = new DB();
            var post = new Information()
            {
                id = ID,
                Name = NAME,
                Email = EMAIL,
                Password = PASSWORD,

            };
            context.InfoTable.Add(post);
            context.SaveChanges();

            var select = context.InfoTable.Select(x => new { x.id, x.Name, x.Email }).ToList();
            for(int i = 0; i < select.Count; i++)
            {
                Console.WriteLine(select[i]);
            }
            Console.ReadLine();

        }
    }
}
