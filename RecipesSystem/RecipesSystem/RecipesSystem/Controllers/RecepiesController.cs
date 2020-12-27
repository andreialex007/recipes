using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using RecipesSystem.Code;
using RecipesSystem.Code.Entities;

namespace RecipesSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecepiesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public RecepiesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        /// <summary>
        /// Get All recepies
        /// </summary>
        /// <returns>List of recepies</returns>
        [HttpGet]
        public IEnumerable<Recipe> Get()
        {
            return _appDbContext.Recipes.ToList();
        }

        /// <summary>
        /// Get recepie by id
        /// </summary>
        /// <param name="recepieId">Unique Id of Recepie</param>
        /// <returns>recepie item</returns>
        [HttpGet]
        [Route("{recepieId:int}")]
        public Recipe Get(int recepieId)
        {
            return _appDbContext.Recipes.Single(x=>x.Id == recepieId);
        }
    }
}
