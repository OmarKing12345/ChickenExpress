using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems;
using ChickenExpress.Application.Interfaces;
using ChickenExpress.Infrastructure.Services;
using ChickenExpress.Persistence.ApplictionDbContext; // ������ �� ���� namespace ����� (����� .Context)
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

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var cs = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseSqlServer(cs)); // ��������� �� ���Persistence (���������)


            // MediatR
            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetMenuItemsQuery).Assembly));

            // Services
            builder.Services.AddScoped<IMenuItemService, MenuItemService>();
            builder.Services.AddScoped<IItemVariantService, ItemVariantServicecs>();

            // Repositories
            builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
            builder.Services.AddScoped<IItemVariantRepository, ItemVariantRepository>();

            builder.Services.AddScoped<IFileStorageService, FileStorageService>();



            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
