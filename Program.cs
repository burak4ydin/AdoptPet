

using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata;
using AdoptPetProject.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

internal class Program
{
    private static void Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);
        //builder.Services.AddDbContext<AdoptPetContext>(options => options.UseSqlServer("Server=localhost,1433;Database=AdoptPetDB;User Id=SA;Password:root159963;"));

        try
        {
            SqlConnectionStringBuilder builders = new SqlConnectionStringBuilder();
            builders.DataSource = "localhost,1433";
            builders.UserID = "SA";
            builders.Password = "root159963";
            builders.InitialCatalog = "master";

            using (SqlConnection connection = new SqlConnection(builders.ConnectionString))
            {
                Console.WriteLine("\nQuery data example:");
                Console.WriteLine("=========================================\n");

                String sql = "SELECT name, collation_name FROM sys.databases";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                        }
                    }
                }
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.ToString());
        }

        builder.Services.AddSingleton<LanguageService>();
        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

        builder.Services.AddMvc()
            .AddViewLocalization()
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = ((type, factory) =>
                {
                    var assemblyName = new AssemblyName(typeof(ShareResource).GetTypeInfo().Assembly.FullName);
                    return factory.Create("ShareResource", assemblyName.Name);
                });
            });

        builder.Services.AddHttpContextAccessor();

        builder.Services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new List<CultureInfo>
            {
                    new CultureInfo("tr-TR"),
                    new CultureInfo("en-US")
            };
            options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;
            
            options.RequestCultureProviders.Insert(0,new QueryStringRequestCultureProvider());
        });
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(120);
           
        });
        // Add services to the container.
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        var locOptions = ((IApplicationBuilder)app).ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
        app.UseRequestLocalization(locOptions.Value);
        app.UseAuthorization();
        app.UseSession();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}