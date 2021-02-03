using Autofac;
using Demo2020.Biz;
using Demo2020.Biz.Commons.Interfaces;
using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Commons.Services;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Demo2020
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SplashScreen splash = new SplashScreen("Resources/Images/Splash.jpg");
            splash.Show(true, true);

            base.OnStartup(e);

            var container = ProgramConfig.Configure();
            //var contractResolver = new AutofacContractResolver(container);

            using (var scope = container.BeginLifetimeScope())
            {
                var vm = scope.Resolve<IMainViewModel>();
                //vm.ContractResolver = contractResolver;
                MainWindow window = new MainWindow(vm);
                window.Show();
            }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Application.Current.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(AppDispatcherUnhandledException);
        }

        void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            Messenger.Default.Send(new MessageWindowConfiguration { Message = e.Exception.Message });
        }
    }
}
