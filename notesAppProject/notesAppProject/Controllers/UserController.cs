using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using notesAppProject.Models;
using StaticHttpContextAccessor.Helpers;
using MongoDB.Driver;
using MongoDB.Driver.Core.Authentication;
using Newtonsoft.Json;

namespace notesAppProject.Controllers
{
    public class UserController : Controller
    {

//    private readonly notesAppProject _context;
    private readonly SessionHandler _sessionHandler;
    
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {

            return View();
        }

        public IActionResult Create(string username, string emailAddress, string password, string firstName, string lastName, string streetAddress, string postalTown, string postcode, bool permissionWeatherApp, bool permisssionNewsApp, bool permissionRadioApp)
        {
            var connectionString = "mongodb://localhost:27017";

            var client = new MongoClient(connectionString);

            var NotesAppDB = client.GetDatabase("NotesAppDB");
            var UserCollection = NotesAppDB.GetCollection<User>("UserCollection");

            var Collection = UserCollection
                .Find(U => U.Username == Username);

            if (Collection != null)
            {
                TempData["FlashMessage"] = "Username already in use";
                return Redirect("./New");
            }

            //            string encryptedPassword = Encryption.EncryptPassword(password);
            //            User newUser = Models.User.CreateNewUser(NotesAppContext, username, encryptedPassword);
            //            _sessionHandler.SetUserSession(newUser.username, newUser.id);

            //var NewUser = "user": {
            //    "username": "",
            //    "emailAddress": "" ,
            //    "password": "" ,
            //    "firstName": "" ,
            //    "lastName": "" ,
            //    "streetAddress": "",
            //    "postalTown": "",
            //    "postcode": "",
            //    "permissssionWeatherApp": false,
            //    "permissionNewsApp": false,
            //    "permissionRadioApp": false
            //};

            //var NewUserJson = JsonConvert.serialize(NewUser);

            //var UserJson = NewUser["user"];
            //UserJson["username"] = Username;
            //UserJson["emailAddress"] = EmailAddress;
            //UserJson["password"] = Password;
            //UserJson["FirstName"] = FirstName;
            //UserJson["LastName"] = LastName;
            //UserJson["StreetAddress"] = StreetAddress;
            //UserJson["PostalTown"] = PostalTown;
            //UserJson["Postcode"] = Postcode;
            //UserJson["PermissionWeatherApp"] = PermissionWeatherApp;
            //UserJson["PermissionNewsApp"] = PermisssionNewsApp;
            //UserJson["PermissionRadioApp"] = PermisssionNewsApp;

            //var NewUserJson = JsonConvert.serialize(NewUser);

            var NewUser = new User();

            NewUser.Username = username;
            NewUser.EmailAddress = emailAddress;
            NewUser.Password = password;
            NewUser.FirstName = firstName;
            NewUser.LastName = lastName;
            NewUser.StreetAddress = streetAddress;
            NewUser.PostalTown = postalTown;
            NewUser.Postcode = postcode;
            NewUser.PermissionWeatherApp = permissionWeatherApp;
            NewUser.PermissionNewsApp = permisssionNewsApp;
            NewUser.PermissionRadioApp = permissionRadioApp;

            UserCollection.Upsert(NewUser);

            return Redirect("../NotesAppPage");

        }

        private object JsonConvert(User newUser)
        {
            throw new NotImplementedException();
        }
    }
}