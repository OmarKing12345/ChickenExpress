using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems;
using ChickenExpress.Application.Interfaces;
using ChickenExpress.Infrastructure.Services;
using ChickenExpress.Persistence.ApplictionDbContext;
using ChickenExpress.Persistence.Repositories.IRepository;
using ChickenExpress.Persistence.Repositories.Repository;
using Microsoft.EntityFrameworkCore;

namespace ChickenExpress.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ≈÷«›… CORS ··”„«Õ ·‹ Angular »«·Ê’Ê·
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:4200") // Angular URL
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials();
                    });
            });

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var cs = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(cs));

            // MediatR
            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetMenuItemsQuery).Assembly));

            // Services
            builder.Services.AddScoped<IMenuItemService, MenuItemService>();
            builder.Services.AddScoped<IItemVariantService, ItemVariantServicecs>();

            builder.Services.AddScoped<IMenuCategoriesService, MenuCategoryService>();


            // Repositories
            builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            builder.Services.AddScoped<IItemVariantRepository, ItemVariantRepository>();
            builder.Services.AddScoped<IMenuCategoryRepository, MenuCategoryRepository>();

            builder.Services.AddScoped<IFileStorageService, FileStorageService>();



            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            // ≈÷«›… CORS middleware
            app.UseCors("AllowAngular");

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}