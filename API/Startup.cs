using System.Reflection;
using Application;
using Application.Create;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence;

namespace API
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
            services.AddControllers();
            services.AddDbContext<QuizApplikasjonContext>
               (options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMediatR(typeof(CreateQuestionCommandHandler).GetTypeInfo().Assembly);

            services.AddCors();

            services.AddHealthChecks();

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddAutoMapper(typeof(LogProfile));

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Quiz Application API",
                    Version = "v1",
                    Description = ""
                });
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/Swagger/v1/swagger.json", "Quiz Application API");
                s.RoutePrefix = "";
            });

            app.UseCors(
                 options => options.WithOrigins("http://localhost:3000").AllowAnyMethod()
            );

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseMvc();
        }
    }
}
