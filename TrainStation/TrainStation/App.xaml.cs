
using BL.Impl;
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
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            
            var UoW = new UnitOfWork();
            
            var seatService = new SeatService(UoW);
            var data = seatService.GetAll();

            var vanService = new VanService(UoW);
            var data1 = vanService.GetAll();
            var dataSimple = UoW.Vans.Get();

            var trainService = new TrainService(UoW);
            var data3 = trainService.GetAll();

            var stationService = new StationService(UoW);
            var data4 = stationService.GetAll();

            var passangerService = new PassangerService(UoW);
            var data5 = passangerService.GetAll();

            var ticketService = new TicketService(UoW);
            var data6 = ticketService.GetAll();

            var routePropService = new RouteProperetiesService(UoW);
            var data7 = routePropService.GetAll();
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
