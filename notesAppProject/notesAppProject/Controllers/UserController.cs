using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using notesAppProject.Models;
using StaticHttpContextAccessor.Helpers;

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
            var UserAttempt = UserCollection.Find(User => User.Username == username).First();
            var Password = UserAttempt.Password;

            if (User == null || Password != password)
            {
                TempData["FlashMessage"] = "Incorrect username or password, do you need to register?";
                return Redirect("./Index");
            }

            _sessionHandler.SetUserSession(UserAttempt.Username);

            return Redirect("../NotesApp/Index");
        }

        public IActionResult New()
        {

            return View();
        }

        public async Task<IActionResult> Create(string username, string emailAddress, string password, string firstName, string lastName, string streetAddress, string postalTown, string postcode, bool permissionWeatherApp, bool permisssionNewsApp, bool permissionRadioApp)
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var NotesAppDb = client.GetDatabase("NotesAppDb");
            var UserCollection = NotesAppDb.GetCollection<User>("UserCollection");
            var CheckUserName = UserCollection.Find(U => U.Username == username);

            if (CheckUserName != null)
            {
                TempData["FlashMessage"] = "Username already in use";
                return Redirect("./New");
            }

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

            return Redirect("../");



        }

        //            string encryptedPassword = Encryption.EncryptPassword(password);
        //            User newUser = Models.User.CreateNewUser(NotesAppContext, username, encryptedPassword);
        //            _sessionHandler.SetUserSession(newUser.username, newUser.id);
    }
}