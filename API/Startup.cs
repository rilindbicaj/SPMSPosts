
using System;
using Application.Commands.Posts;
using Application.Queries.Posts;
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
            services.AddDbContext<PostsDbContext>(opt =>
                  opt.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //opt.UseSqlServer(Configuration.GetConnectionString("SqlServerDemo")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

            //MediatR configuration
            services.AddMediatR(typeof(GetAllPosts.Handler).Assembly);
            services.AddMediatR(typeof(GetPostsByAudience.Handler).Assembly);
            services.AddMediatR(typeof(DeletePost.Handler).Assembly);
            services.AddMediatR(typeof(CreatePost.Handler).Assembly);

            services.AddCors(conf => conf.AddPolicy("CorsPolicy",
            opt => opt.AllowAnyMethod().AllowAnyHeader().AllowCredentials().WithOrigins("http://localhost:3000")));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
