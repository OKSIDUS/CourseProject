using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using UserCollection.Services.Interfaces;
using UserCollection.Services.WebAPI;
using UserCollection.WebAPP.Data;
using UserCollection.WebAPP.Hubs;

namespace UserCollection.WebAPP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI();

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRole", policy => policy.RequireRole("admin"));
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ICategoryService, CategoryWebApiService>();
            builder.Services.AddScoped<ICollectionService, CollectionWebApiService>();
            builder.Services.AddScoped<ICollectionItemService, ItemWebApiService>();
            builder.Services.AddScoped<ICommentService, CommentWebApiService>();

            builder.Services.AddSignalR();

            builder.Services.AddRazorPages();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Collection}/{action=Index}/{id?}");
            app.MapRazorPages();

            //app.MapHub<CommentHub>("/commentHub");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<CommentHub>("/commentHub");
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}