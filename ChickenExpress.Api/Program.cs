using ChickenExpress.Application.Features.MenuItems.Queries.GetMenuItems;
using ChickenExpress.Infrastructure.Services;
using ChickenExpress.Persistence.ApplictionDbContext; // €Ì¯—Â« ·Ê ⁄‰œﬂ namespace „Œ ·› („À·« .Context)
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
                opt.UseSqlServer(cs)); // «·„ÌÃ—Ì‘‰ ›Ì «·‹Persistence («·«› —«÷Ì)


            // MediatR
            builder.Services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(GetMenuItemsQuery).Assembly));

            // Services
            builder.Services.AddScoped<IMenuItemService, MenuItemService>();

            // Repositories
            builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
