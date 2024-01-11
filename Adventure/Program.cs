using System;
using System.Data;
using System.Drawing.Text;
using System.Reflection;
using System.Reflection.Metadata;
using System.Security.Permissions;
using Adventure.Business.Services;
using Adventure.FactoryMethod;
using BusinessServices;
using Dapper;
using FluentMigrator.Runner;
using LeaningPass.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Z.Dapper.Plus;


namespace Adventure;

public class Program
{

    
    public static void Main(string[] args)
    {
        Rectangle r = new Rectangle();
        r.SetHeight(10);
        r.SetWidth(20);
        r.CalculateArea();

        Square s = new Square();
        r.Width = 10;
        r.CalculateArea();

        IShapeLSP obj = r;
        obj = s;

        IPrinter p = new Printer();
        p.Print();

        AlarmPrinterDecorator d = new AlarmPrinterDecorator(p);
        d.Print();


        /*Customer c = new Customer();
        c.SetRouteStrategy(new PublicTransportStrategy());

        c._routeStrategy.CalculateRoute();

        c.SetRouteStrategy(new CarStrategy());
        c._routeStrategy.CalculateRoute();

        c.SetRouteStrategy(new AirStrategy());
        c._routeStrategy.CalculateRoute();*/

        /*ElectricBike bike = new ElectricBike();
        bike.Drive();

        ElectricBikeDecorator electricBike = new ElectricBikeDecorator(bike);
        electricBike.Drive();

        //Customer customer = new Customer();
        //customer._routeStrategy = new CarStrategy();
        //customer._routeStrategy.CalculateRoute();*/

        //Customer customer2 = new Customer();
        //customer2._routeStrategy = new PublicTransportStrategy();
        //customer2._routeStrategy.CalculateRoute();


        var serviceCollection = new ServiceCollection();

        serviceCollection.AddScoped<IManager1, Manager1>();
        serviceCollection.AddTransient<IManager2, Manager2>();


        var serviceProvider = serviceCollection.BuildServiceProvider();

        //IManager1 manager2;
        //using (var scope = serviceProvider.CreateScope())
        //{
        //     manager2 = scope.ServiceProvider.GetRequiredService<IManager1>();
        //}

        //IManager1 manager1 = serviceProvider.GetRequiredService<IManager1>();


        //Console.WriteLine(manager1 == manager2);
        


        IAppLoggerCreator creator = new ConsoleAppLogger();


        var loggger = creator.FactoryMethod();
        loggger.Log("Error");
        Console.ReadLine();






        //var serviceCollectio = new ServiceCollection();
        //serviceCollectio.AddScoped<ILoggerProvider, ConsoleLoggerProvider>();
        //var serviceProvider = serviceCollectio.BuildServiceProvider();

        var logger1 = serviceProvider.GetRequiredService<ILoggerProvider>();
        var logger2 = serviceProvider.GetRequiredService<ILoggerProvider>();

        var isEquel = logger1 == logger2;

        var name = Console.ReadLine();
        using (var scope = serviceProvider.CreateScope())
        {
            var logger3 = scope.ServiceProvider.GetRequiredService<ILoggerProvider>();
            var logger4 = scope.ServiceProvider.GetRequiredService<ILoggerProvider>();
            var isEquel2 = logger3 == logger4;
            var isEquel3 = logger1 == logger4;

        }



        ILoggerProvider provider = new ConsoleLoggerProvider();

        var logger = provider.FactoryMethod();


        BusBuilder builder = new BusBuilder();


        CarFactory carFactory = new CarFactory(builder);
        carFactory.BuildFullCar();

        var transport = builder.Build();
        Console.WriteLine(transport.Material + transport.Electronics + transport.MainParts);


        Console.ReadLine();

        /*Print(new ServiceOrderCreator());
        Print(new FoodOrderCreator());
    
        void Print(IOrderCreator c)
        {
            var a = c.Create();
            Console.WriteLine(a.Name);
        }
        CarBuilder builder = new CarBuilder();
        var shop = new Shop(builder);
        shop.BasicConfiguration();
        var car1 = builder.Build();
        Console.WriteLine(car1.Electronics + car1.MainParts+car1.Materials);
    
        shop.FullConfiguration();
    
        var car2 = builder.Build();
    
        Console.WriteLine(car2.Electronics + car2.MainParts + car2.Materials);
    
        */



        /*
        SingltonClass s1 = SingltonClass.GetInstance();
        SingltonClass s2 = SingltonClass.GetInstance();

        Console.WriteLine(s1 == s2);

        IVehicleFactory factory = new SportVehicleFactory();
        var bike = factory.CreateBike();
        Console.WriteLine(bike.GetFullInfo());

        var car = factory.CreateCar();
        Console.WriteLine(car.GetFullInfo());

        IVehicleFactory factory2 = new RegularVehicleFactory();
        var bike2 = factory2.CreateBike();
        Console.WriteLine(bike2.GetFullInfo());

        var car2 = factory2.CreateCar();
        Console.WriteLine(car2.GetFullInfo());
        */
        /*
        InitConfig();

        var dbContext = new DatabaseContext(config);
        var database = new Database(dbContext);

        var dbName = config["DBName"];
        database.CreateDatabase(dbName);

        var serviceProvider = CreateServices();

        using (var scope = serviceProvider.CreateScope())
        {
            RunMigration(scope.ServiceProvider);
        }

        // Sql injection

        var id = Console.ReadLine();
        using (var connection = dbContext.CreateConnection())
        {
            var result = connection.Execute($"select* from Teacher where TeacherId = {id}");
        }
        */

        /*
        static void RunMigration(IServiceProvider serviceProvider)
        {
            var migrationService = serviceProvider.GetRequiredService<IMigrationRunner>();
            migrationService.ListMigrations();
            migrationService.MigrateUp();

        }


        static IServiceProvider CreateServices()
        {

            return new ServiceCollection()
                .AddLogging(c => c.AddFluentMigratorConsole())
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddSqlServer2012()
                    .WithGlobalConnectionString(config.GetConnectionString("LearningPass"))
                    .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
                .BuildServiceProvider(false);
        }

        static void InitConfig()
        {
            var builder = new ConfigurationBuilder();

            var launchSettinsenv = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            builder
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                    optional: false, reloadOnChange: true);

            config = builder.Build();

            var a = config.GetConnectionString("LearningPass");

            var timeout = config["Timeout"];
        }


        void CheckAnonymousTypes()
        {
            dynamic inttype = new { FirstName = "sdf" };
            var firstNamea = inttype.FirstName;
            //inttype.Name = 1;
            //inttype.FirstName = 1;
            inttype = new Course();
            firstNamea = inttype.FirstName;

            dynamic strtype = "sldkfj";
            strtype = 10;
            dynamic obj = new { Name = 1 };

            var anounInt = 1;
            var anonStr = "sdf";
            var objAnon = new { Name = 1, LastName = "soeir" };
            //objAnon.Name = "sdkfj";
            var a = 1;
        }*/
    }
}

