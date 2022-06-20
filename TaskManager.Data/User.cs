﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TaskManager.Data
{
    public partial class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

    }
}


