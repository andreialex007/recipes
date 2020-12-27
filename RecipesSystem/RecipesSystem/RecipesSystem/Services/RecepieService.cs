using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipesSystem.Code;

namespace RecipesSystem.Services
{
    public class RecepieService
    {
        private AppDbContext _appDbContext;

        public RecepieService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


    }
}
