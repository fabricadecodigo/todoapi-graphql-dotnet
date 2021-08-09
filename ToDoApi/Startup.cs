using ToDoApi.src.Database.Repositories;
using ToDoApi.src.Database;
using ToDoApi.src.BusinessRules.Validators;
using ToDoApi.src.BusinessRules.Handlers;
using ToDoApi.src.Api;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

namespace ToDoApi
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
            services
                .AddDbContext<TodoContext>(option => option.UseInMemoryDatabase("TodoDatabase"));

            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

            services
                // Validators
                .AddScoped<ITaskValidator, TaskValidator>()
                
                // Repositories
                .AddScoped<ITaskRepository, TaskRepository>()
                
                // Business rules
                .AddScoped<IUpsertTaskHandler, UpsertTaskHandler>()
                .AddScoped<IGetAllTasksHandler, GetAllTasksHandler>()
                .AddScoped<IGetByIdTaskHandler, GetByIdTaskHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app
                .UseRouting()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapGraphQL();
                });
        }
    }
}
