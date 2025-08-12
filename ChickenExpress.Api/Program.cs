using ChickenExpress.Persistence.ApplictionDbContext; // €Ì¯—Â« ·Ê ⁄‰œﬂ namespace „Œ ·› („À·« .Context)
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
