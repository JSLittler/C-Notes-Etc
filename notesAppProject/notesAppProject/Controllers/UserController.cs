using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using notesAppProject.Models;
using StaticHttpContextAccessor.Helpers;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Core.Authentication;
using Newtonsoft.Json;

namespace notesAppProject.Controllers
{
    public class UserController : Controller
    {

        private readonly SessionHandler _sessionHandler;

        public UserController(SessionHandler sessionHandler)
        {
            _sessionHandler = sessionHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn(string username, string password)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var NotesAppDb = client.GetDatabase("NotesAppDb");
            var UserCollection = NotesAppDb.GetCollection<User>("UserCollection");
            if (UserCollection.Find(User => User.Username == username) == null)
            {
                return (IActionResult)(TempData["FlashMessage"] = "Incorrect username"); // this won't work
            }

            var UserAttempt = UserCollection.Find(User => User.Username == username).First();
            var Password = UserAttempt.Password;

            if (Password != password)
            {
                return (IActionResult)(TempData["FlashMessage"] = "Incorrect password");
            }
            
            _sessionHandler.SetUserSession(UserAttempt.Username);
            return Redirect("../NotesApp/Index");
        }

        public IActionResult New()
        {
            string Message = SessionHandler.GetTempMessage(); //not working, need to debug the get and set functions
            if (!string.IsNullOrEmpty(Message))
            {
                Message = "Please enter your personal details and preferences";
            }

            ViewBag.message = Message;
            return View();
        }

        public async Task<IActionResult> Create(string username, string emailAddress, string password, string firstName, string lastName, string streetAddress, string postalTown, string postcode, bool permissionWeatherApp, bool permisssionNewsApp, bool permissionRadioApp)
        {
            string message = "";
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var NotesAppDb = client.GetDatabase("NotesAppDb");
            var UserCollection = NotesAppDb.GetCollection<User>("UserCollection");
            
            var AttemptedUserName = UserCollection.CountDocuments(User => User.Username == username);

            if (AttemptedUserName < 1)
            {
                UserCollection.InsertOne(new User
                {
                    Username = username,
                    EmailAddress = emailAddress,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    StreetAddress = streetAddress,
                    PostalTown = postalTown,
                    Postcode = postcode,
                    PermissionWeatherApp = true,
                    PermissionNewsApp = true,
                    PermissionRadioApp = true
                });

                message = "Your details have been save successfully, please sign in to continue."; // //set session variable to this and take viewbag from session variable
                SessionHandler.SetTempMessage(message);
                return Redirect("../");
            }
            else
            {
                message = "Username already exists, please select a different Username."; //set session variable to this and take viewbag from session variable
                SessionHandler.SetTempMessage(message);
                return Redirect("./New");
            }
        }

        //            string encryptedPassword = Encryption.EncryptPassword(password);
        //            User newUser = Models.User.CreateNewUser(NotesAppContext, username, encryptedPassword);
        //            _sessionHandler.SetUserSession(newUser.username, newUser.id);
    }
}