using Autofac;
using Demo2020.Biz.Commons.Interfaces;
using Demo2020.Biz.Commons.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz
{
    public class ProgramConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // Windows
            builder.RegisterType<MainWindow>().As<IMainWindow>();
            
            // View Models
            builder.RegisterType<MainViewModel>().As<IMainViewModel>();

            // Services
            builder.RegisterType<SqlDataAccessService>().As<IDataAccessService>();

            return builder.Build();
        }
    }
}
