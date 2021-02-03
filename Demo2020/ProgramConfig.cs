using Autofac;
using Demo2020.Biz.Commons.Interfaces;
using Demo2020.Biz.Commons.Services;
using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.MonsterManual.Models;
using Demo2020.Biz.MonsterManual.Services;
using Newtonsoft.Json.Serialization;
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

            builder.RegisterType<AutofacContractResolver>().As<IContractResolver>();

            // Windows
            //builder.RegisterType<MainWindow>().As<IMainWindow>();
            
            // View Models
            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            // builder.RegisterType<MonsterManualViewModel>().As<IMonsterManualViewModel>();

            // Models
            builder.RegisterType<Monster>().As<IMonster>();
            builder.RegisterType<Speed>().As<ISpeed>();

            // Services
            builder.RegisterType<SqlDataAccessService>().As<IDataAccessService>();
            builder.RegisterType<MonsterFactory>().As<IMonsterFactory>();
            builder.RegisterType<SpeedFactory>().As<ISpeedFactory>();
            builder.RegisterType<DnD5eMonsterApi>().As<IMonsterApi>();

            return builder.Build();
        }
    }
}
