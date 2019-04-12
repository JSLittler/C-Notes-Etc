using StaticHttpContextAccessor.Helpers;

namespace notesAppProject.Controllers
{
    public class UserContext
    {
        private readonly SessionHandler _sessionHandler;
        private string FirstMessage = "Sign in or register a new account to proceed.";
        private string RegisterMessage = "Please enter your personal details and preferences";
        private string RegisterSuccessMessage = "Your details have been save successfully, please sign in to continue";
        private string UserAlreadyExistsMessage = "Username already exists, please select a different Username.";
        private string SignInMessage = "Enter your Username and Password to sign in.";
        private string WrongUserDetailsMessage = "Incorrect Username or password";
        private string SignInSuccessMessage = "Welcome!";

        internal UserContext()
        {
            _sessionHandler = new SessionHandler();
        }

        internal void UserIndexMessage()
        {
            string Message = _sessionHandler.GetTempMessage();

            if (Message == FirstMessage)
            {
                Message = SignInMessage;
            }

            var SignInMessageCheck = Message == SignInMessage;
            var WrongUserDetailsMessageCheck = Message == WrongUserDetailsMessage;

            if (!SignInMessageCheck && !WrongUserDetailsMessageCheck)
            {
                Message = RegisterMessage;
            }

            SetVisibleMessage(Message);
        }

        internal void UserSignInResultMessage(bool SignInFailed)
        {
            string Message = SignInFailed ? WrongUserDetailsMessage : SignInSuccessMessage;
            SetVisibleMessage(Message);
        }

        internal void UserNewMessage()
        {
            string Message = GetVisibleMessage();

            if (Message != UserAlreadyExistsMessage)
            {
                Message = RegisterMessage;
            }

            SetVisibleMessage(Message);
        }

        internal void UserCreateMessage(bool UserExists)
        {
            string Message = !UserExists ? RegisterSuccessMessage : UserAlreadyExistsMessage;
            SetVisibleMessage(Message);
        }

        internal void SetUserSession(string username)
        {
            _sessionHandler.SetUserSession(username);
        }

        internal void SetVisibleMessage(string message)
        {
            _sessionHandler.SetTempMessage(message);
        }

        internal string GetVisibleMessage()
        {
            return _sessionHandler.GetTempMessage();
        }
    }
}