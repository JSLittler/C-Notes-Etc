using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using notesAppProject.Models;

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

        static async Task MainAsync()
        {
            var connectionString = "mongodb://localhost:27017";

            var client = new MongoClient(connectionString);

            var NotesAppDB = client.GetDatabase("NotesAppDB");
            var UserCollection = NotesAppDB.GetCollection<User>("UserCollection");
            var NotesCollection = NotesAppDB.GetCollection<Note>("NotesCollection");
            var Username = "Dave"

            var User = UserCollection
                .Find(U => U.Username == Username);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

    }
}
