using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using RecipesSystem.Models;
using RecipesSystem.Services;

namespace RecipesSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecipesController : ControllerBase
    {
        private readonly IRecepieService _recepieService;

        public RecipesController(IRecepieService recepieService)
        {
            _recepieService = recepieService;
        }

        /// <summary>
        /// Get All recepies
        /// </summary>
        /// <returns>List of recepies</returns>
        [HttpGet]
        public IEnumerable<RecipeDto> Get()
        {
            return _recepieService.All();
        }

        /// <summary>
        /// Get recepie by id
        /// </summary>
        /// <param name="recepieId">Unique Id of Recepie</param>
        /// <returns>recepie item</returns>
        [HttpGet]
        [Route("{recepieId:int}")]
        public RecipeDto Get(int recepieId)
        {
            return _recepieService.Get(recepieId);
        }

        /// <summary>
        /// Updates or Creates recipe
        /// </summary>
        /// <param name="recipeDto">Recipe to update</param>
        [HttpPost]
        [Route("{recepieId:int}")]
        public void Update([FromBody] RecipeDto recipeDto)
        {
            _recepieService.Save(recipeDto);
        }
    }
}
