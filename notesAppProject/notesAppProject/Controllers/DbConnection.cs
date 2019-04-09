using notesAppProject.Models;
using MongoDB.Driver;

namespace notesAppProject.Controllers
{
    public class DbConnection
    {
        public DbConnection()
        {
        }

        public void AddUser(User user)
        {
            UserCollection.InsertOne(user);
        }

        public bool UserExists(string username)
        {
            return UserCollection.CountDocuments(User => User.Username == username) > 0;
        }

        public User FindExistingUser(string username)
        {
            User ExistingUser = UserCollection.Find(User => User.Username == username).First();
            return ExistingUser;
        }

        internal IMongoCollection<User> UserCollection
        {
            get
            {
                var ConectionString = "mongodb://localhost:27017";
                var client = new MongoClient(ConectionString);
                var Db = client.GetDatabase("NotesAppDb");
                var Collection = Db.GetCollection<User>("UserCollection");
                return Collection;
            }
        }
    }
}