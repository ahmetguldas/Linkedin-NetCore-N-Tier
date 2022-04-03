using Business.IServices;
using Business.Services;
using Data.Context;
using DataAccess.Repository;
using DataAccess.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

namespace PresentationLayer
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApp", Version = "v1" });
            });
            services.AddDbContext<DataContext>(x => x.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCors(option => option.AddPolicy
            ("Cors", builder => {
                builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
            }));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitofWork, UnitofWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILicenseOfCertificationService, LicenseOfCertificationService>();
            services.AddScoped<IExperienceService, ExperienceService>();
            services.AddScoped<IEducationService, EducationService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WepApp v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Cors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot")),
                RequestPath = new PathString("/wwwroot")
            });
        }
    }
}
