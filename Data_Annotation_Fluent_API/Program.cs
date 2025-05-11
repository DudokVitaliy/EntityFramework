namespace Data_Annotation_Fluent_API
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CompanyDB context = new CompanyDB();

            context.Workers.FirstOrDefault(n => n.Name == "Emma").Projects.Add
                (context.Projects.FirstOrDefault(n => n.Name == "Tetris"));
            context.Workers.FirstOrDefault(n => n.Name == "Tomm").Projects.Add
                (context.Projects.FirstOrDefault(n => n.Name == "Tetris"));
            context.Workers.FirstOrDefault(n => n.Name == "Bill").Projects.Add
                (context.Projects.FirstOrDefault(n => n.Name == "Tetris"));

            context.Workers.FirstOrDefault(n => n.Name == "Emma").Projects.Add
                (context.Projects.FirstOrDefault(n => n.Name == "PacMan"));
            context.Workers.FirstOrDefault(n => n.Name == "Oleg").Projects.Add
                (context.Projects.FirstOrDefault(n => n.Name == "PacMan"));
            context.SaveChanges();

            var workers = context.Workers.ToList();

            foreach (var worker in workers)
            {
                Console.WriteLine(new string('-', 50));
                Console.WriteLine(worker.Name);
                Console.WriteLine(worker.Surname);
                Console.WriteLine(worker.Birthday);
                Console.WriteLine(worker.Salary);
                context.Entry(worker).Reference(nameof(worker.Country)).Load();
                Console.WriteLine(worker.Country.Name);
                context.Entry(worker).Reference(nameof(worker.Department)).Load();
                Console.WriteLine(worker.Department.Name);
                context.Entry(worker).Collection(nameof(worker.Projects)).Load();
                foreach (var item in worker.Projects)
                {
                    Console.WriteLine(item.Name, item.LaunchDate);
                }
            }
        }
    }
}
