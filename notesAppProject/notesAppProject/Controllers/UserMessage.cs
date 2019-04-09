using StaticHttpContextAccessor.Helpers;

namespace notesAppProject.Controllers
{
    public class UserMessage
    {
        private readonly SessionHandler _sessionHandler;

        public UserMessage(SessionHandler sessionHandler)
        {
            _sessionHandler = sessionHandler;
        }
        
        private string FirstMessage = "Sign in or register a new account to proceed.";
        private string RegisterMessage = "Please enter your personal details and preferences";
        private string RegisterSuccessMessage = "Your details have been save successfully, please sign in to continue.";
        private string UserAlreadyExists = "Username already exists, please select a different Username.";
        private string SignInMessage = "Enter your Username and Password to sign in.";
        private string WrongUsernameMessage = "Incorrect Username";
        private string WrongPasswordMessage = "Incorrect Password";

        public void UserIndexMessage()
        {
            string Message = _sessionHandler.GetTempMessage();

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

            SetVisibleMessage(Message);
        }

        public void UserNewMessage()
        {
            string Message = _sessionHandler.GetTempMessage();
            if (Message != UserAlreadyExists)
            {
                Message = RegisterMessage;
            }

            SetVisibleMessage(Message);
        }

        public void UserCreateMessage(bool UserExists)
        {
            string Message = !UserExists ? RegisterSuccessMessage : UserAlreadyExists;
            SetVisibleMessage(Message);
        }

        public void SetVisibleMessage(string message)
        {
            _sessionHandler.SetTempMessage(message);
        }
    }
}