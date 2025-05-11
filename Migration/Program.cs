using Microsoft.EntityFrameworkCore;
using MigrationComp.Entities;
using System.Linq;

namespace MigrationComp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CompanyDB context = new CompanyDB();
            //context.Workers.Add(new Entities.Worker()
            //{
            //    Name = "Taras",
            //    Surname = "Melnuk",
            //    Birthday = new DateTime(2005, 05, 15),
            //    Salary = 4700,
            //    DepartmentID = 1
            //});
            //context.Workers.FirstOrDefault(x => x.Name == "Taras").CountryId = 1;
            //context.SaveChanges();

            /*context.Workers.FirstOrDefault(n => n.Name == "Emma").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "Tetris"));
            context.Workers.FirstOrDefault(n => n.Name == "Tomm").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "Tetris"));
            context.Workers.FirstOrDefault(n => n.Name == "Taras").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "Tetris"));


            context.Workers.FirstOrDefault(n => n.Name == "Emma").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "PacMan"));
            context.Workers.FirstOrDefault(n => n.Name == "Taras").Projects.Add(context.Projects.FirstOrDefault(n => n.Name == "PacMan"));

            context.SaveChanges();*/


            #region Laze Loading
            // Завантаження зв'язаних об'єктів відбувається лише в момент доступу до них
            // Required:
            // 1 - property must be public
            // 2 - class must be not sealed
            // 3 - property must be virtual
            // 4 - context.Configuration.LazyLoadingEnabled = True (default);

            //foreach (var w in context.Workers)
            //{
            //    Console.WriteLine($"--------- Worker [{w.Id}] {w.Name}");
            //    Console.WriteLine($"Department :: {w.Department?.Name}"); // load department
            //    if(w.CountryId != null)
            //    {
            //        Console.WriteLine($"Country :: {w.Country?.Name}");
            //    }
            //    foreach (var pr in w.Projects) // loading projects
            //    {
            //        Console.WriteLine($"\t Project :: {pr.Name}");
            //    }
            //}
            #endregion

            #region Eager Loading
            // Завантаження зв'язаних об'єктів відбувається відразу при виконанні основного запиту
            // застосовується оператор JOIN
            //context.Workers.Include(proprtyName)
            // proprtyName - ім'я навігаційної властивості для не відкладеного завантаження

            //var workerQuery = context.Workers.Include(nameof(Worker.Department))
            //    .Include(nameof(Worker.Country))
            //    .Include(nameof(Worker.Projects));

            //foreach (var w in workerQuery)
            //{
            //    Console.WriteLine($"--------- Worker [{w.Id}] {w.Name}");
            //    Console.WriteLine($"Department :: {w.Department?.Name}"); // load department
            //    if (w.CountryId != null)
            //    {
            //        Console.WriteLine($"Country :: {w.Country?.Name}");
            //    }
            //    foreach (var pr in w.Projects) // loading projects
            //    {
            //        Console.WriteLine($"\t Project :: {pr.Name}");
            //    }
            //}
            #endregion

            #region Explicit loading
            // Завантаження звязаних обєктів відбувається явним викликом методів
            //context.Entry(entity).Reference(propName).Load() // для завантаження одного обєкта
            //context.Entry(entity).Collection(CollectionName).Load() // для завантаження колекції обєктів

            //Console.WriteLine("Enter worker Id");
            // int workerId;
            // while (!int.TryParse(Console.ReadLine(), out workerId))
            // {
            //     Console.WriteLine("Incorrect value. Try Again!");
            // }
            // // Find by id
            // Worker worker = context.Workers.Find(workerId);
            // if (worker == null)
            // {
            //     Console.WriteLine("Worker not found");
            //     return;
            // }
            // // Load Reference
            // context.Entry(worker).Reference(nameof(Worker.Department)).Load();
            // Console.WriteLine($"---- Worker [{worker.Id}] {worker.Name}");
            // Console.WriteLine($"Department :: {worker.Department?.Name}"); // department reference

            // // load Collection
            // context.Entry(worker).Collection(nameof(Worker.Projects)).Load();
            // foreach (var item in worker.Projects)
            // {
            //     Console.WriteLine($"\t Project :: {item.Name}");
            // }
            #endregion
            var res = from i in context.Workers
                      where i.Salary > 1000
                      orderby i.Salary descending
                      select i;
            foreach (var item in res.Take(2))
            {
                Console.WriteLine($"{item.Name}  --  {item.Salary}");
            }
                      
        }

    }
}
