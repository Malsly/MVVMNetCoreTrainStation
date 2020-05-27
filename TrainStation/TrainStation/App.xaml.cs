
using DAl.Impl.EFCore;
using DAl.Impl.UnitOfWork;
using DAL.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using ReposirotyAPI.Data;
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
        private readonly IHost host;
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public App()
        {
            host = Host.CreateDefaultBuilder()
                   .ConfigureServices((context, services) =>
                   {
                       ConfigureServices(services);
                   }).Build();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // services for DI...

            services.AddDbContext<ReposirotyAPIContext>
                (options => options.UseSqlServer(Configuration.GetConnectionString("NewTrainStationDatabase")));

            services.AddScoped<SeatRepository>();
            services.AddScoped<ClassProperetiesRepository>();
            services.AddScoped<PassangerRepository>();
            services.AddScoped<RouteProperetiesRepository>();
            services.AddScoped<StationRepository>();
            services.AddScoped<TicketRepository>();
            services.AddScoped<TrainRepository>();
            services.AddScoped<VanRepository>();

            services.AddScoped<UnitOfWork>();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var SeatRepo = ServiceProvider.GetRequiredService<SeatRepository>();
            var secondData = SeatRepo.GetAll();

            var StationRepo = ServiceProvider.GetRequiredService<StationRepository>();
            var staionData = StationRepo.GetAll();

            var TrainRepo = ServiceProvider.GetRequiredService<TrainRepository>();
            var traisOfStation = TrainRepo.GetAll();

            var RoutesRepo = ServiceProvider.GetRequiredService<RouteProperetiesRepository>();
            var routeWhatNeded = RoutesRepo.GetAll();

            var UoW = ServiceProvider.GetRequiredService<UnitOfWork>();
            var aaa = UoW.SeatRepository.Get().ToList();

        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }

            base.OnExit(e);
        }
    }
}
