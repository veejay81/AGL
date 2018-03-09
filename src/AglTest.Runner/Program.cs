using System;
using System.Configuration;
using AglTest.DataSource;
using AglTest.Business;

namespace AglTest.Runner
{
    class Program
    {
        static void Main(string[] args)
        {
            var webApiUrl = ConfigurationManager.AppSettings["webApi"];

            IDataService dataService = new WebApiDataService(webApiUrl);
            IFilterService filterService = new FilterService();

            var owners = dataService.FetchOwnersAsync().Result;

            var maleOwnerCats = filterService.FilterPets(owners, "Male", "Cat");
            var femaleOwnerCats = filterService.FilterPets(owners, "Female", "Cat");

            Console.WriteLine("Male:");
            foreach(var pet in maleOwnerCats)
            {
                Console.WriteLine($"\t{pet.Name}");
            }

            Console.WriteLine("Female:");
            foreach (var pet in femaleOwnerCats)
            {
                Console.WriteLine($"\t{pet.Name}");
            }

            Console.ReadLine();
        }
    }
}
