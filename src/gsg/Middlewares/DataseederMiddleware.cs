using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using gsg.Data;

namespace gsg.Middlewares
{
    public class DataseederMiddleware
    {
        private readonly RequestDelegate _next;

        public DataseederMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,
                                      ApplicationDbContext db,
                                      RoleManager<IdentityRole> roleManager,
                                      UserManager<IdentityUser> userManager)
        {
            //var roleManager = provider.GetService<RoleManager<IdentityRole>>();
            var adminRoleExists = roleManager.RoleExistsAsync("Admin").Result;
            var userRoleExists = roleManager.RoleExistsAsync("User").Result;

            db.Database.Migrate();

            if (!adminRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("Admin")).GetAwaiter().GetResult();
            }
            if (!userRoleExists)
            {
                roleManager.CreateAsync(new IdentityRole("User")).GetAwaiter().GetResult();
            }
            
            var userName = userManager.FindByNameAsync("dydimitrov86@gmail.com").GetAwaiter().GetResult();
            if (userName != null && !userManager.IsInRoleAsync(userName,"Admin").GetAwaiter().GetResult())
            {
                await userManager.AddToRoleAsync(userName, "Admin");
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
