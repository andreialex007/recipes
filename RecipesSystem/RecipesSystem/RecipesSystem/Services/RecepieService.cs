using System;
using RecipesSystem.Code;
using RecipesSystem.Code.Entities;

namespace RecipesSystem.Services
{
    public interface IRecepieHistoryService
    {
        void AddRecord(Recipe dto);
    }

    public class RecepieHistoryService : IRecepieHistoryService
    {
        private readonly AppDbContext _appDbContext;

        public RecepieHistoryService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddRecord(Recipe dto)
        {
            _appDbContext.History.Add(new RecipeHistory
            {
                Calories = dto.Calories,
                Country = dto.Country,
                Description = dto.Description,
                Ingredients = dto.Ingredients,
                Name = dto.Name,
                Year = dto.Year,
                ModifyDate = DateTime.Now,
                RecipeId = dto.Id
            });
            _appDbContext.SaveChanges();
        }

    }
}
