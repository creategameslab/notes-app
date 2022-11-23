using Notes.Code;
using Notes.Code.Repositories;
using System.Text.Json.Serialization;

namespace Notes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<INotesRepository, NotesRepository>();

            builder.Services.AddRouting(config =>
            {
                config.LowercaseUrls = true;
            });
            builder.Services.AddControllersWithViews()
                    .AddJsonOptions(config =>
                    {
                        config.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    });

            builder.Services.AddRazorPages();  

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();
 
            app.UseRouting();

            app.MapRazorPages();
            
            app.MapControllerRoute("Default", "/{controller}/{action}/{id?}",
             new
             {
                 controller = "App",
                 action = "Index"
             });

            app.Run();
        }
    }
}