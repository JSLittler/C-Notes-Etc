using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using notesAppProject.Models;

namespace notesAppProject.Controllers
{
    public class UserController : Controller
    {
        private readonly DbConnection _dbConnection;
        private readonly UserContext _userContext;

        public UserController()
        {
            _dbConnection = new DbConnection();
            _userContext = new UserContext();
        }

        public IActionResult Index()
        {
            _userContext.UserIndexMessage();
            ViewBag.message = _userContext.GetVisibleMessage();
            return View();
        }

        public async Task<IActionResult> SignIn(string username, string password)
        {
            if (!_dbConnection.UserExists(username))
            {
                _userContext.UserSignInResultMessage(true);
                return Redirect("./Index");
            }

            var AttemptedUser = _dbConnection.FindExistingUser(username);
            var EncryptedPassword = Encryption.EncryptPassword(password);

            if (AttemptedUser.Password != EncryptedPassword)
            {
                _userContext.UserSignInResultMessage(true);
                return Redirect("./Index");
            }

            _userContext.UserSignInResultMessage(false);
            _userContext.SetUserSession(AttemptedUser.Username);
            return Redirect("../NotesApp/Index");
        }

        public IActionResult New()
        {
            _userContext.UserNewMessage();
            ViewBag.message = _userContext.GetVisibleMessage();
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
                _userContext.UserCreateMessage(false);
                return Redirect("../");
            }

            _userContext.UserCreateMessage(true);
            return Redirect("./New");
        }
    }
}