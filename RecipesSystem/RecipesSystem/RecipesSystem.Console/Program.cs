using System;
using System.Linq;
using RecipesSystem.Client.Api;
using RecipesSystem.Client.Model;

namespace RecipesSystem.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var basePath = "http://localhost:60540/";
            var tokenApi = new TokenApi(basePath);
            var token = tokenApi.TokenPost(new AuthenticateRequest
            {
                Email = "admin@admin.com",
                Password = "123"
            });

            var recipesApi = new RecipesApi(basePath, token.Trim('"'));
            var itemsList = recipesApi.RecipesGet();
            var item = recipesApi.RecipesRecepieIdGet(itemsList.First().Id);
        }
    }
}
