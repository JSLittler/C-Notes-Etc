using System.Runtime.InteropServices.ComTypes;
using MongoDB.Bson;

namespace notesAppProject.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Username { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string PostalTown { get; set; }
        public string Postcode { get; set; }
        public bool PermissionWeatherApp { get; set; }
        public bool PermissionNewsApp { get; set; }
        public bool PermissionRadioApp { get; set; }


        public User CreateUser(string username, string emailAddress, string password, string firstName, string lastName, string streetAddress, string postalTown, string postcode)
        {
            var User = new User
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
            };
            return User;
        }
    }
}
