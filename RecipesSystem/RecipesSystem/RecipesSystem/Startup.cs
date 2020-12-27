using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RecipesSystem.Code;
using RecipesSystem.Code.Entities;
using RecipesSystem.Common;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RecipesSystem
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
           // services.AddScoped<ICatsClient, CatsClient>();

            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();


            services.AddControllers(x =>
            {
                x.Filters.Add(new AuthorizeFilter(policy));
                x.Filters.Add(new WebAppExceptionFilterAttribute());
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Recepies API"
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                AddBarier(c);
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.Issuer,

                        ValidateAudience = true,
                        ValidAudience = AuthOptions.Audience,
                        ValidateLifetime = true,

                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(-1);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Recepies API V1");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            InitializeDatabase(app);
            FillData(db);
        }

        private static void InitializeDatabase(IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.Migrate();
            }
        }

        private static void AddBarier(SwaggerGenOptions c)
        {
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Scheme = "bearer",
                Description = "Please insert JWT token into field"
            });

            c.OperationFilter<AddAuthHeaderOperationFilter>();
        }

        private void FillData(AppDbContext context)
        {
            if (!context.Recipes.Any())
            {
                var recipe = new Recipe
                {
                    Description = "Cook description",
                    Calories = 100,
                    Country = "Germany",
                    Ingredients = "Ingredients description",
                    Name = "Christmas Cookies",
                    Year = 1950
                };
                context.Recipes.Add(recipe);
                context.SaveChanges();


                context.History.Add(new RecipeHistory
                {
                    Name = recipe.Name,
                    Year = recipe.Year,
                    Calories = recipe.Calories,
                    Ingredients = recipe.Ingredients,
                    Country = recipe.Country,
                    Description = "Cook description original",
                    ModifyDate = DateTime.Now,
                    RecipeId = recipe.Id
                });

                context.SaveChanges();
            }
        }

    }
}
