﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public static class AppRoles
    {
        public const string DistrictManager = "DistrictManager";
        public const string PropertyManager = "PropertyManager";
        public const string Agent = "Agent";
    }
}