using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipesSystem.Code;
using RecipesSystem.Code.Entities;
using RecipesSystem.Common;
using RecipesSystem.Models;

namespace RecipesSystem.Services
{
    public interface IRecepieService
    {
        List<RecipeDto> All();
        RecipeDto Get(int id);
        void Save(RecipeDto recipeDto);
    }

    public class RecepieService : IRecepieService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IRecepieHistoryService _recepieHistoryService;

        public RecepieService(AppDbContext appDbContext, IRecepieHistoryService recepieHistoryService)
        {
            _appDbContext = appDbContext;
            _recepieHistoryService = recepieHistoryService;
        }

        public List<RecipeDto> All()
        {
            return this.RecipesQuery().ToList();
        }

        public RecipeDto Get(int id)
        {
            return RecipesQuery().Single(x => x.Id == id);
        }

        public void Save(RecipeDto recipeDto)
        {
            Recipe recipe;
            if (recipeDto.Id == 0)
            {
                recipe = new Recipe();
                _appDbContext.Add(recipe);
            }
            else
            {
                recipe = this._appDbContext.Recipes.Find(recipeDto.Id);
            }

            recipe.Calories = recipeDto.Calories;
            recipe.Country = recipeDto.Country;
            recipe.Description = recipeDto.Description;
            recipe.Ingredients = recipeDto.Ingredients;
            recipe.Name = recipeDto.Name;
            recipe.Year = recipeDto.Year;

            _appDbContext.Entry(recipe).OriginalValues["RowVersion"] = recipeDto.RowVersion;

            try
            {
                _appDbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new WebApiException("Item already updated by someone, please refresh entity");
            }
            

            _recepieHistoryService.AddRecord(recipe);
        }

        private IQueryable<RecipeDto> RecipesQuery()
        {
            return _appDbContext
                .Recipes
                .Select(x => new RecipeDto
                {
                    Id = x.Id,
                    Calories = x.Calories,
                    Country = x.Country,
                    Description = x.Description,
                    Ingredients = x.Ingredients,
                    Name = x.Name,
                    Year = x.Year,
                    RowVersion = x.RowVersion
                });
        }

    }
}
