using System;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using AccessControl.DataAccess;
using AccessControl.DataAccess.Context;
using AccessControl.Domain.Entities.ConfigurationData;
using AccessControl.Domain;
using AccessControl.Domain.Common;
using AccessControl.Domain.ValueObjects;
using AccessControl.Domain.Entities.HistoricalData;

namespace AccessControl.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext appcontext = new ApplicationContext("Data Source=AccessControlDB.sqlite");
            if(!appcontext.Database.CanConnect())
                appcontext.Database.Migrate();

            //creando instancias ejemplo
            Operator operator1 = new Operator(null, "Alejandro", "00122967766", School.University, Guid.NewGuid());
            Operator operator2 = new Operator(null, "Camilo", "00112234567", School.University, Guid.NewGuid());
            Supervisor supervisor1 = new Supervisor("Carrion", "11223345678", School.MiddleSchool, Guid.NewGuid());

            //ProductSet SchoolItems = new ProductSet();
            //ProductSet ContrabandItems = new ProductSet();
            //ProductSet GoodFlavors = new ProductSet();
            List<Product> SchoolItems = new List<Product>() { new Product("Lapices", Guid.NewGuid()), new Product("Libretas", Guid.NewGuid()), new Product("Libros", Guid.NewGuid()) };
            List<Product> ContrabandItems = new List<Product>() { new Product("Blancas", Guid.NewGuid()), new Product("Armas", Guid.NewGuid()), new Product("Drogas", Guid.NewGuid()) };
            List<Product> GoodFlavors = new List<Product>() { new Product("Chocolate Amargo", Guid.NewGuid()), new Product("Chocolate Blanco", Guid.NewGuid()), new Product("Chocolate", Guid.NewGuid()) };

            //List<Product> SchoolItems = new List<Product>() { new Product("Lapices"), new Product("Libretas"), new Product("Libros") };
            //List<Product> ContrabandItems = new List<Product>() { new Product("Blancas"), new Product("Armas"), new Product("Drogas") };
            //List<Product> GoodFlavors = new List<Product>() { new Product("Chocolate Amargo"), new Product("Chocolate Blanco"), new Product("Chocolate") };

            //Product Blancas = new Product("Blancas", Guid.NewGuid(), ContrabandItems);
            //Product Armas = new Product("Armas", Guid.NewGuid(), ContrabandItems);
            //Product Drogas = new Product("Drogas", Guid.NewGuid(), ContrabandItems);
            //Product ChocoAmargo = new Product("Chocolate Amargo", Guid.NewGuid(), GoodFlavors);
            //Product ChocoBlanco= new Product("Chocolate Blanco", Guid.NewGuid(), GoodFlavors);
            //Product Chocolate = new Product("Chocolate", Guid.NewGuid(), GoodFlavors);
            //Product Lapices = new Product("Lapices", Guid.NewGuid(), SchoolItems);
            //Product Libretas = new Product("Libretas", Guid.NewGuid(), SchoolItems);
            //Product Libros = new Product("Libros", Guid.NewGuid(), SchoolItems);


            Domain.ValueObjects.Process process1 = new Domain.ValueObjects.Process(Guid.NewGuid(), "Produccion de escuela", SchoolItems);
            Domain.ValueObjects.Process process2 = new Domain.ValueObjects.Process(Guid.NewGuid(), "Produccion de contrabando", ContrabandItems );
            Domain.ValueObjects.Process process3 = new Domain.ValueObjects.Process(Guid.NewGuid(), "Produccion de buenos sabores", GoodFlavors );
            supervisor1.AddOperator(operator1);
            supervisor1.AddOperator(operator2);
            operator1.AddProcess(process1);
            operator2.AddProcess(process2);
            operator1.AddProcess(process3);
            AccessEntry operator1Entry1 = new AccessEntry(Guid.NewGuid(), operator1, DateTime.Now, null);
            AccessEntry operator2Entry1 = new AccessEntry(Guid.NewGuid(), operator2, DateTime.Now, null);
            AccessEntry supervisorEntry1 = new AccessEntry(Guid.NewGuid(), supervisor1, DateTime.Now, null);

            //agregando a tablas
            //appcontext.Products.Add(Blancas);
            //appcontext.Products.Add(Armas);
            //appcontext.Products.Add(Drogas);
            //appcontext.Products.Add(ChocoAmargo);
            //appcontext.Products.Add(ChocoBlanco);
            //appcontext.Products.Add(Chocolate);
            //appcontext.Products.Add(Libros);
            //appcontext.Products.Add(Lapices);
            //appcontext.Products.Add(Libretas);
            appcontext.Persons.Add(operator1);
            appcontext.Persons.Add(operator2);
            appcontext.Persons.Add(supervisor1);
            appcontext.Processes.Add(process1);
            appcontext.Processes.Add(process2);
            appcontext.Processes.Add(process3);
            appcontext.AccessEntries.Add(operator1Entry1);
            appcontext.AccessEntries.Add(operator2Entry1);
            appcontext.AccessEntries.Add(supervisorEntry1);

            //salvando cambios
            appcontext.SaveChanges();

            Operator? operatorFromEntry = appcontext.Set<Operator>()
                .FirstOrDefault(v => v.Id == operator1Entry1.Person.Id);
            Process? processFromSupervisor = appcontext.Set<Process>()
                .FirstOrDefault(v => v.ProcessId == supervisorEntry1.Person.Processes.ElementAt(0).ProcessId);
            Console.WriteLine($"{operatorFromEntry.Name}, {operatorFromEntry.CI}");
            Console.WriteLine($"{processFromSupervisor.Name}, {processFromSupervisor.Products}");

            process1.Name = "Lo que no hay en la escuela";
            appcontext.Processes.Update(process1);
            Process? processFromSupervisor2 = appcontext.Set<Process>()
                .FirstOrDefault(v => v.ProcessId == supervisorEntry1.Person.Processes.ElementAt(0).ProcessId);
            Console.WriteLine($"{processFromSupervisor2.Name}, {processFromSupervisor2.Products}");

            Operator? operatorFromEntry2 = appcontext.Set<Operator>()
                .FirstOrDefault(v => v.Id == operator2Entry1.Person.Id);
            Console.WriteLine($"{operatorFromEntry2.Name}, {operatorFromEntry2.CI}");
            appcontext.Persons.Remove(operator2);
            appcontext.SaveChanges();
            Operator? operatorFromEntry3 = appcontext.Set<Operator>()
                .FirstOrDefault(v => v.Id == operator2Entry1.Person.Id);
            Console.WriteLine($"{operatorFromEntry3.Name}, {operatorFromEntry3.CI}");

        }
    }
}