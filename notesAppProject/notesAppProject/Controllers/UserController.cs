using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using notesAppProject.Models;
using StaticHttpContextAccessor.Helpers;

namespace notesAppProject.Controllers
{
    public class UserController : Controller
    {

        private readonly SessionHandler _sessionHandler;
        private readonly DbConnection _dbConnection;
        private readonly UserMessage _userMessage;

        public UserController(SessionHandler sessionHandler)
        {
            _sessionHandler = sessionHandler;
            _dbConnection = new DbConnection();
            _userMessage = new UserMessage(_sessionHandler);
        }

        public IActionResult Index()
        {
            _userMessage.UserIndexMessage();
            ViewBag.message = _sessionHandler.GetTempMessage();
            return View();
        }

        public async Task<IActionResult> SignIn(string username, string password)
        {
            if (!_dbConnection.UserExists(username))
            {
                _sessionHandler.SetTempMessage("Incorrect Username");
                return Redirect("./Index");
            }

            var AttemptedUser = _dbConnection.FindExistingUser(username);
            var EncryptedPassword = Encryption.EncryptPassword(password);

            if (AttemptedUser.Password != EncryptedPassword)
            {
                return Redirect("./Index");
            }

            _sessionHandler.SetUserSession(AttemptedUser.Username);
            return Redirect("../NotesApp/Index");
        }

        public IActionResult New()
        {
            ViewBag.message = _sessionHandler.GetTempMessage();
            return View();
        }

        public async Task<IActionResult> Create(string username, string emailAddress, string password, string firstName, string lastName, string streetAddress, string postalTown, string postcode)
        {
            var EncryptedPassword = Encryption.EncryptPassword(password);
            bool UserExists = _dbConnection.UserExists(username);

            if (!UserExists)
            {
                var NewUser = new User().CreateUser(username, emailAddress, EncryptedPassword, firstName, lastName, streetAddress, postalTown, postcode);
                _dbConnection.AddUser(NewUser);
                _userMessage.UserCreateMessage(false);
                return Redirect("../");
            }

            _userMessage.UserCreateMessage(true);
            return Redirect("./New");
        }
    }
}