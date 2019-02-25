using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using MongoDB.Driver.Core.Authentication;

namespace notesAppProject.Models
{
    public class Note
    {
        public string Username { get; set; }
        public string CreationDate { get; set; }
        public string CompletedByDate { get; set; }
        public string CompletedByTime { get; set; }
        public bool Comnpleted { get; set; }
        public bool WhenCompletedDate { get; set; }
        public bool WhenCompletedTime { get; set; }
        public string CompletionComments { get; set; }
    }


}
