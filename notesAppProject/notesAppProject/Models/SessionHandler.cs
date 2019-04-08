using Microsoft.AspNetCore.Http;
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

        public static void SetTempMessage(string message)
        {
            AppContext.Current.Session.SetString("message", message);
        }

        public static string GetTempMessage()
        {
            return AppContext.Current.Session.GetS("message");
        }

        //        public int GetSignedInUserID()
        //        {
        //            return AppContext.Current.Session.GetInt("userID") ?? default(int);
        //        }
    }
}