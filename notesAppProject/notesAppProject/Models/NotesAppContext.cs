using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Core.Authentication;

namespace notesAppProject.Models
{
    public class NotesAppContext
    {
        public static User User { get; set; }
        public Note Note  { get; set; }

        public static void Set(User user)
        {
            NotesAppContext.User = user;
        }
    }
}