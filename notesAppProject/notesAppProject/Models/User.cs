using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using MongoDB.Driver.Core.Authentication;

namespace notesAppProject.Models
{
    public class User
    {
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
