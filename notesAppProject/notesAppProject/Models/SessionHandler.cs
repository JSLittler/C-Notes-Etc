using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace StaticHttpContextAccessor.Helpers
{
    public class SessionHandler
    {
        public bool UserIsSignedIn()
        {
            return AppContext.Current.Session.GetS("username") != "null";
        }
        
        public void SetUserSession(string username)
        {
            AppContext.Current.Session.SetS("username", username);
        }

        public string GetSignedInUsername()
        {
            return AppContext.Current.Session.GetS("username");
        }

        public void SetTempMessage(string message)
        {
            AppContext.Current.Session.SetS("message", message);
        }

        public string GetTempMessage()
        {
            return AppContext.Current.Session.GetS("message");
        }
    }
}