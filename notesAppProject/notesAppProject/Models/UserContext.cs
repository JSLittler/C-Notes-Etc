using StaticHttpContextAccessor.Helpers;

namespace notesAppProject.Controllers
{
    public class UserContext
    {
        private readonly SessionHandler _sessionHandler;

       internal UserContext()
        {
            _sessionHandler = new SessionHandler();
        }
        
        private string FirstMessage = "Sign in or register a new account to proceed.";
        private string RegisterMessage = "Please enter your personal details and preferences";
        private string RegisterSuccessMessage = "Your details have been save successfully, please sign in to continue.";
        private string UserAlreadyExistsMessage = "Username already exists, please select a different Username.";
        private string SignInMessage = "Enter your Username and Password to sign in.";
        private string WrongUserDetailsMessage = "Incorrect Username or password";
        private string SignInSuccessMessage = "Welcome!";

        internal void HomeIndexMessage()
        {
            string Message = _sessionHandler.GetTempMessage();

            if (Message != RegisterSuccessMessage)
            {
                Message = FirstMessage;
            }

            SetVisibleMessage(Message);
        }

        internal void UserIndexMessage()
        {
            string Message = _sessionHandler.GetTempMessage();

            if (Message == FirstMessage)
            {
                Message = SignInMessage;
            }

            var SignInMessageCheck = Message == SignInMessage;
            var WrongUsernameMessageCheck = Message == WrongUserDetailsMessage;

            if (!SignInMessageCheck && !WrongUsernameMessageCheck)
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

        }

        internal void UserCreateMessage(bool UserExists)
        {
            string Message = !UserExists ? RegisterSuccessMessage : UserAlreadyExistsMessage;
            SetVisibleMessage(Message);
        }


        internal void SetVisibleMessage(string message)
        {
            _sessionHandler.SetTempMessage(message);
        }

        internal void SetUserSession(string username)
        {
            _sessionHandler.SetUserSession(username);
        }

        internal string GetVisibleMessage()
        {
            return _sessionHandler.GetTempMessage();
        }
    }
}