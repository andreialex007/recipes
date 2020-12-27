﻿using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace RecipesSystem.Common
{
    public static class AuthOptions
    {
        public const string Issuer = "MyAuthServer";
        public const string Audience = "MyAuthClient";
        private const string Key = "mysupersecret_secretkey!123"; 
        public const int Lifetime = 5; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}