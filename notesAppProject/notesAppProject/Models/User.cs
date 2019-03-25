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
    }
}
