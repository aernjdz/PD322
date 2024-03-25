using ClassWork_20_03.DBContext;
using ClassWork_20_03.Model;
using System.Diagnostics;

internal class Program
    {
        static Stat TestProvider(ICarRepository repos) { 
        var stat = new Stat();
        Stopwatch sw;

        //Read
        sw = Stopwatch.StartNew();
        repos.GetCar(86);
        sw.Stop();
        stat.ReadByIdTime = sw.ElapsedMilliseconds;
        
        // ReadAll
        sw = Stopwatch.StartNew();
        repos.GetCars();
        sw.Stop();
        stat.ReadAllTime = sw.ElapsedMilliseconds;

        // Create
        sw = Stopwatch.StartNew();
        Car car = repos.Create(new Car() { 
        Make="Lada",
        Model="Semirka",
        ModelYear=2005
        });
        sw.Stop();
        stat.CreateTime = sw.ElapsedMilliseconds;

        // Update
        sw = Stopwatch.StartNew();
        repos.Delete(car.Id);
        sw.Stop();
        stat.UpdateTime = sw.ElapsedMilliseconds;

        // Delate

        sw = Stopwatch.StartNew();
        repos.Delete(car.Id);
        sw.Stop();
        stat.DeleteTime = sw.ElapsedMilliseconds;

        foreach ( var prop in stat.GetType().GetProperties() ) {
            Console.WriteLine($"{prop.Name} : {prop.GetValue(stat)}ms");
        }
        sw.Stop();

        return stat;

    }
        private static void Main(string[] args)
        {
        string connStr = "Data Source=LAPTOP-SME2AMSS\\SQLEXPRESS;Initial Catalog = CarSalon; Integrated Security=True;Connect Timeout=2";
        Console.WriteLine("\n----------- Entity Framework Core ------------");
        TestProvider(new CarRepositoryEF(connStr));
        Console.WriteLine("\n----------- ADO.NET ------------");
        TestProvider(new CarRepositoryADO_NET(connStr));
        Console.WriteLine("\n----------- Dapper ------------");
        TestProvider(new CarRepositoryDapper(connStr));
    }
    }
