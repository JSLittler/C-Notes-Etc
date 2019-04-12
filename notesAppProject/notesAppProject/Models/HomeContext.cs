using StaticHttpContextAccessor.Helpers;

namespace notesAppProject.Controllers
{
    public class HomeContext
    {
        private readonly SessionHandler _sessionHandler;
        private string FirstMessage = "Sign in or register a new account to proceed.";
        private string RegisterSuccessMessage = "Your details have been save successfully, please sign in to continue";

        internal HomeContext()
        {
            _sessionHandler = new SessionHandler();
        }

        internal void HomeIndexMessage()
        {
            string Message = GetVisibleMessage();

            if (Message != RegisterSuccessMessage)
            {
                Message = FirstMessage;
            }

            SetVisibleMessage(Message);
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