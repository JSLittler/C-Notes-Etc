using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace notesAppProject
{
    class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            MainAsync().Wait();

            Console.ReadLine();
        }

        public static async Task MainAsync()
        {
//            var connectionString = "mongodb://localhost:27017";
//
//            var client = new MongoClient(connectionString);

//            var NotesAppDB = client.GetDatabase("NotesAppDB");
//            var UserCollection = NotesAppDB.GetCollection<User>("UserCollection");
//            var NotesCollection = NotesAppDB.GetCollection<Note>("NotesCollection");
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }
}
