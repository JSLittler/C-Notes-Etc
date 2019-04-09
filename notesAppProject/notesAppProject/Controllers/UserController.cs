using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using notesAppProject.Models;
using StaticHttpContextAccessor.Helpers;
using MongoDB.Driver;

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
            string Message = _sessionHandler.GetTempMessage();

            string FirstMessage = "Sign in or register a new account to proceed.";
            string RegisterMessage = "Please enter your personal details and preferences";
            string SignInMessage = "Enter your Username and Password to sign in.";
            string WrongUsernameMessage = "Incorrect Username";
            string WrongPasswordMessage = "Incorrect Password";

            if (Message == FirstMessage)
            {
                Message = SignInMessage;
            }

            var SignInMessageCheck = Message == SignInMessage;
            var WrongUsernameMessageCheck = Message == WrongUsernameMessage;
            var WrongPasswordMessageCheck = Message == WrongPasswordMessage;

            if (!SignInMessageCheck && !WrongUsernameMessageCheck && !WrongPasswordMessageCheck)
            {
                Message = RegisterMessage;
            }

            ViewBag.message = Message;

            return View();
        }

        public async Task<IActionResult> SignIn(string username, string password)
        { 
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var NotesAppDb = client.GetDatabase("NotesAppDb");
            var UserCollection = NotesAppDb.GetCollection<User>("UserCollection");

            var AttemptedUserCount = UserCollection.CountDocuments(User => User.Username == username);

            if (AttemptedUserCount < 1)
            {
                _sessionHandler.SetTempMessage("Incorrect Username");

                return Redirect("./Index");
            }
            
            var AttemptedUser = UserCollection.Find(User => User.Username == username).First();
            var EncryptedPassword = Encryption.EncryptPassword(password);

            if (AttemptedUser.Password != EncryptedPassword)
            {
                _sessionHandler.SetTempMessage("Incorrect Password");

                return Redirect("./Index");
            }
            
            _sessionHandler.SetUserSession(AttemptedUser.Username);
            return Redirect("../NotesApp/Index");
        }

        public IActionResult New()
        {
            string Message = _sessionHandler.GetTempMessage();
            if (Message != "Username already exists, please select a different Username.")
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
            var EncryptedPassword = Encryption.EncryptPassword(password);

            if (AttemptedUserName < 1)
            {
                UserCollection.InsertOne(new User
                {
                    Username = username,
                    EmailAddress = emailAddress,
                    Password = EncryptedPassword,
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
                _sessionHandler.SetTempMessage(message);
                return Redirect("../");
            }
            else
            {
                message = "Username already exists, please select a different Username."; //set session variable to this and take viewbag from session variable
                _sessionHandler.SetTempMessage(message);
                return Redirect("./New");
            }
        }
    }
}