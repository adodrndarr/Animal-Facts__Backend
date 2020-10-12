using AnimalFacts.DataAccess.Database;
using AnimalFacts.DataAccess.Repositories;
using AnimalFacts.DataAccess.Repositories.Implementations;
using AnimalFacts.Domain.Entities;
using AnimalFacts.Services.Services.Implementations;
using AnimalFacts.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace AnimalFacts.Services.Helpers.InjectionHelpers
{
    public static class InjectionModule
    {
        public static void InjectDbContext(this IServiceCollection services, string connection)
        {
            services.AddDbContext<AnimalsContext>(options => options.UseSqlServer(connection));            
        }

        public static void InjectRepositories(this IServiceCollection services, string connection)
        {
            services.AddTransient<IRepository<Dog>>(provider => new DogADORepository(connection));
            services.AddTransient<IRepository<Cat>>(provider => new CatDapperRepository(connection));
            services.AddTransient<IRepository<Rabbit>, RabbitEFRepository>();
        }

        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IDogService, DogService>();
            services.AddTransient<ICatService, CatService>();
            services.AddTransient<IRabbitService, RabbitService>();
        }
    }
}