using MAUIDemo.Services;
using MAUIDemo.ViewModels;
using Microsoft.Extensions.Logging;

namespace MAUIDemo
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

    		builder.Logging.AddDebug();

            //Services
            builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
            //Views
            builder.Services.AddSingleton<EmployeesList>();
            builder.Services.AddTransient<AddEmployee>();

            //ViewModels
            builder.Services.AddSingleton<EmployeesViewModel>();
            builder.Services.AddTransient<AddEmployeeViewModel>();

            return builder.Build();
        }
    }
}
