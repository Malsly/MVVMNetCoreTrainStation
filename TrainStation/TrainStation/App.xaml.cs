using DAL.Impl;
using DAL.Impl.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TrainStation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<TrainStationContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("NewTrainStationDatabase")));

            services.AddScoped<EfCoreSeatRepository>();
            //services.AddScoped<EfCoreEmployeeRepository>();
            //services.AddScoped<EfCoreEmployeeDepartmentRepository>();
            //services.AddScoped<EfCoreItCompanyRepository>();
            //services.AddScoped<EfCoreDepartmentRepository>();

            //services.AddTransient<IDepartmentService, DepartmentService>();
            //services.AddTransient<IEmployeeDepartmentService, EmployeeDepartmentService>();
            //services.AddTransient<IEmployeeService, EmployeeService>();
            //services.AddTransient<IItCompanyService, ItCompanyService>();
            //services.AddTransient<ITaskService, TaskService>();

            services.AddTransient(typeof(MainWindow));
        }
    }
}
