using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebAppMVC1.Models
{
    public partial class User
    {
        public string UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}