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
        private readonly DbConnection _dbConnection;

        public UserController(SessionHandler sessionHandler)
        {
            _sessionHandler = sessionHandler;
            _dbConnection = new DbConnection();
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
            var AttemptedUser = _dbConnection.FindExistingUser(username);
            var EncryptedPassword = Encryption.EncryptPassword(password);

            if (!_dbConnection.UserExists(username))
            {
                _sessionHandler.SetTempMessage("Incorrect Username");
                return Redirect("./Index");
            }

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

        public async Task<IActionResult> Create(string username, string emailAddress, string password, string firstName, string lastName, string streetAddress, string postalTown, string postcode)
        {
            string Message = "";
            var EncryptedPassword = Encryption.EncryptPassword(password);

            if (!_dbConnection.UserExists(username))
            {
                var NewUser = new User().CreateUser(username, emailAddress, EncryptedPassword, firstName, lastName, streetAddress, postalTown, postcode);
                _dbConnection.AddUser(NewUser);
                Message = "Your details have been save successfully, please sign in to continue.";
                _sessionHandler.SetTempMessage(Message);
                return Redirect("../");
            }

            Message = "Username already exists, please select a different Username.";
            _sessionHandler.SetTempMessage(Message);
            return Redirect("./New");
        }
    }
}