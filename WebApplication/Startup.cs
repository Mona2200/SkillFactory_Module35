using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FluentValidation.AspNetCore;
using WebApplication.Models;

namespace WebApplication
{
    public class Startup
    {
        /// <summary>
        /// Загрузка конфигурации из файла Json
        /// </summary>
        private IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json")
            .Build();

        public void ConfigureServices(IServiceCollection services)
        {
            // Подключаем автомаппинг
            //var assembly = Assembly.GetAssembly(typeof(MappingProfile));
            //services.AddAutoMapper(assembly);

            //// регистрация сервиса репозитория для взаимодействия с базой данных
            //services.AddSingleton<IDeviceRepository, DeviceRepository>();
            //services.AddSingleton<IRoomRepository, RoomRepository>();

            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection), ServiceLifetime.Singleton);

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.Password.RequiredLength = 5;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            })
                    .AddEntityFrameworkStores<ApplicationDbContext>();

            //// Подключаем валидацию
            //services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddDeviceRequestValidator>());

            //// Добавляем новый сервис
            //services.Configure<HomeOptions>(Configuration);

            //// Загружаем только адресс (вложенный Json-объект))
            //services.Configure<Address>(Configuration.GetSection("Address"));

            // Нам не нужны представления, но в MVC бы здесь стояло AddControllersWithViews()
            services.AddControllersWithViews();
            // поддерживает автоматическую генерацию документации WebApi с использованием Swagger
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "HomeApi", Version = "v1" }); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //// Проставляем специфичные для запуска при разработке свойства
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //    app.UseSwagger();
            //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeApi v1"));
            //}

            //app.UseHttpsRedirection();
            //app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();

            //// Сопоставляем маршруты с контроллерами
            //app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeApi v1"));
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //app.MapRazorPages();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

        }
    }
}