using Autofac;
using Demo2020.Biz.Commons.Interfaces;
using Demo2020.Biz.Commons.Services;
using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.Equipment.Models;
using Demo2020.Biz.Equipment.Services;
using Demo2020.Biz.Equipment.ViewModels;
using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.MonsterManual.Models;
using Demo2020.Biz.MonsterManual.Services;
using Demo2020.Biz.MonsterManual.ViewModels;

namespace Demo2020.Biz
{
    public class ProgramConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            
            // View Models
            builder.RegisterType<MainViewModel>().As<IMainViewModel>();
            builder.RegisterType<MonsterManualViewModel>().As<IMonsterManualViewModel>();
            builder.RegisterType<EquipmentViewModel>().As<IEquipmentViewModel>();

            // Models
            builder.RegisterType<Monster>().As<IMonster>();
            builder.RegisterType<Speed>().As<ISpeed>();
            builder.RegisterType<Equipment.Models.Equipment>().As<IEquipment>();
            builder.RegisterType<ArmorClass>().As<IArmorClass>();
            builder.RegisterType<Category>().As<ICategory>();
            builder.RegisterType<Cost>().As<ICost>();
            builder.RegisterType<Damage>().As<IDamage>();
            builder.RegisterType<EquipmentProperty>().As<IEquipmentProperty>();
            builder.RegisterType<Range>().As<IRange>();

            // Services
            builder.RegisterType<SqlDataAccessService>().As<IDataAccessService>();
            builder.RegisterType<MonsterFactory>().As<IMonsterFactory>();
            builder.RegisterType<SpeedFactory>().As<ISpeedFactory>();
            builder.RegisterType<DnD5eMonsterDataAccessObject>().As<IMonsterDataAccessObject>();
            builder.RegisterType<EquipmentFactory>().As<IEquipmentFactory>();
            //builder.RegisterType<CategoryFactory>().As<ICategoryFactory>();
            //builder.RegisterType<CostFactory>().As<ICostFactory>();
            builder.RegisterType<DnD5eEquipmentApi>().As<IEquipmentApi>();

            return builder.Build();
        }
    }
}
