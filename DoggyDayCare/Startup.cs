using DoggyDayCare.Data;
using DoggyDayCare.Repositories;
using DoggyDayCare.Services;
using DoggyDayCare.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DoggyDayCare
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
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            }));
            services.AddDbContext<DoggyDayCareDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("PortalDataDev")));
            services.AddControllers();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion_3_0);

            services.AddTransient<StudentsRepository>();
            services.AddTransient<IStudentService, StudentsService>();
            services.AddTransient<DogsRepository>();
            services.AddTransient<IDogService, DogsService>();
            //services.AddTransient<StudentsRepository>();
            //services.AddTransient<IStudentService, StudentsService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("MyPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see <https://aka.ms/aspnetcore-hsts.>
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
