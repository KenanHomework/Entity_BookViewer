using Entity_BookViewer.MVVM.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Entity_BookViewer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Members

        public static string ConnectionString { get; set; }
        public static SimpleInjector.Container Container = new();
        public static DbContextOptions<LibraryContext> Options = new();


        #endregion

        #region Methods

        void ReadConnectionString()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appconfig.json");
            var config = builder.Build();
            ConnectionString = config.GetConnectionString("SqlServerConnection");
        }

        void Register()
        {
            Container.RegisterSingleton<AppViewVM>();

            Container.Verify();
        }

        void InitOptions()
        {
            ConfigurationBuilder buider = new();
            buider.AddJsonFile("appconfig.json");
            IConfigurationRoot config = buider.Build();
            string cs = config.GetConnectionString("SqlServerConnection");
            DbContextOptionsBuilder<LibraryContext> optionsBuilder = new ();
            Options = optionsBuilder.UseSqlServer(cs).Options;
        }

        #endregion

        public App()
        {
            Register();
            InitOptions();
            ReadConnectionString();



        }
    }
}
