using CodeFirst.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Company IT

            Workers
            Projects
            Contry
            Department
             * */

            CompanyDB db = new CompanyDB();
            //db.Countries.Add(new Country() { Name = "Ukraine" });
            //db.Countries.Add(new Country() { Name = "Poland" });
            //db.Countries.Add(new Country() { Name = "USA" });
            //db.SaveChanges();

            //// Departments
            //db.Departments.Add(new Department() { Name = "Management", Phone = "25-69-85" });
            //db.Departments.Add(new Department() { Name = "Programming", Phone = "48-87-85" });
            //db.Departments.Add(new Department() { Name = "Design", Phone = "25-87-45" });
            //db.SaveChanges();

            ////Workers
            //db.Workers.Add(new Worker()
            // {
            //     Name = "Bill",
            //     Surname = "Gates",
            //     Salary = 2700,
            //     Birthday = new DateTime(2003,2,2),
            //     DepartmentID = (db.Departments.Where(s => s.Name == "Programming")).First().Id,
            //     CountryId = (db.Countries.Where(c => c.Name == "USA")).First().Id
            // });
            //db.Workers.Add(new Worker()
            // {
            //     Name = "Tomm",
            //    Surname = "Page",
            //     Salary = 4300,
            //     Birthday = new DateTime(2002, 3, 12),
            //     DepartmentID = (db.Departments.Where(s => s.Name == "Design")).First().Id,
            //     CountryId = (db.Countries.Where(c => c.Name == "Ukraine")).First().Id
            // });
            // db.Workers.Add(new Worker()
            // {
            //     Name = "Emma",
            //     Surname = "Miller",
            //     Salary = 5500,
            //     Birthday = new DateTime(2000, 12, 12),
            //     DepartmentID = (db.Departments.Where(s => s.Name == "Programming")).First().Id,
            //     CountryId = (db.Countries.Where(c => c.Name == "Poland")).First().Id
            // });
            // db.Workers.Add(new Worker()
            // {
            //     Name = "Oleg",
            //     Surname = "King",
            //     Salary = 3300,
            //     Birthday = new DateTime(2003, 11, 24),
            //     DepartmentID = (db.Departments.FirstOrDefault(s => s.Name == "Management")).Id,
            //     CountryId = (db.Countries.FirstOrDefault(c => c.Name == "Ukraine")).Id
            // });
            // db.SaveChanges();

            ////Projects
            //db.Projects.Add(new Project() { 
            //    Name = "Tetris",LaunchDate = new DateTime(1982,12,12),
            //});
            //db.Projects.Add(new Project()
            //{
            //    Name = "PacMan",
            //    LaunchDate = new DateTime(2003, 12, 12),
            //});
            //db.Projects.Add(new Project()
            //{
            //    Name = "CS",
            //    LaunchDate = new DateTime(2000, 01, 01),
            //});
            //db.SaveChanges();


            //Worker worker1 = db.Workers.FirstOrDefault(w=>w.Name == "Bill" && w.Surname == "Gates");
            //Project pr1 = db.Projects.FirstOrDefault(w => w.Name == "Tetris");
            //Project pr2 = db.Projects.FirstOrDefault(w => w.Name == "PacMan");
            //worker1.Projects.Add(pr1);
            //worker1.Projects.Add(pr2);
            //Worker worker2 = db.Workers.FirstOrDefault(w=>w.Name == "Emma" && w.Surname == "Miller");
            //Project pr3 = db.Projects.FirstOrDefault(w => w.Name == "CS");
            //worker2.Projects.Add(pr3);
            //db.SaveChanges();

            var workers = db.Workers.ToList();

            foreach (var worker in workers)
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine(worker.Name);
                Console.WriteLine(worker.Surname);
                Console.WriteLine(worker.Birthday);
                Console.WriteLine(worker.Salary);
                db.Entry(worker).Reference(nameof(worker.Country)).Load();
                Console.WriteLine(worker.Country.Name);
                db.Entry(worker).Reference(nameof(worker.Department)).Load();
                Console.WriteLine(worker.Department.Name);
                db.Entry(worker).Collection(nameof(worker.Projects)).Load();
                foreach (var item in worker.Projects)
                {
                    Console.WriteLine(item.Name, item.LaunchDate);
                }
            }
        } 
    }
}
