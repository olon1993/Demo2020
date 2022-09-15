using Autofac;
using Demo2020.Biz.ActorCatalog.Interfaces;
using Demo2020.Biz.ActorCatalog.Services;
using Demo2020.Biz.ActorCatalog.ViewModels;
using Demo2020.Biz.Commons.Interfaces;
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
            builder.RegisterType<MagicItemViewModel>().As<IMagicItemViewModel>();
            builder.RegisterType<LootTableViewModel>().As<ILootTableViewModel>();
            builder.RegisterType<ActorCatalogViewModel>().As<IActorCatalogViewModel>();

            // Models
            builder.RegisterType<MonsterModel>().As<IMonsterModel>();
            builder.RegisterType<SpeedModel>().As<ISpeedModel>();
            builder.RegisterType<ArmorClassModel>().As<IArmorClassModel>();
            builder.RegisterType<EquipmentModel>().As<IEquipmentModel>();
            builder.RegisterType<CategoryModel>().As<ICategoryModel>();
            builder.RegisterType<CostModel>().As<ICostModel>();
            builder.RegisterType<DamageModel>().As<IDamageModel>();
            builder.RegisterType<EquipmentPropertyModel>().As<IEquipmentPropertyModel>();
            builder.RegisterType<RangeModel>().As<IRangeModel>();
            builder.RegisterType<MagicItemModel>().As<IMagicItemModel>();
            builder.RegisterType<LootTableModel>().As<ILootTableModel>();
            builder.RegisterType<EquipmentSlotModel>().As<IEquipmentSlotModel>();

            // Services
            builder.RegisterType<MonsterFactoryService>().As<IMonsterFactoryService>();
            builder.RegisterType<MonsterDataAccessService>().As<IMonsterDataAccessService>();
            builder.RegisterType<MonsterSearchAndFilterService>().As<IMonsterSearchAndFilterService>();
            builder.RegisterType<SpeedFactoryService>().As<ISpeedFactoryService>();

            builder.RegisterType<EquipmentFactoryService>().As<IEquipmentFactoryService>();
            builder.RegisterType<EquipmentSlotFactoryService>().As<IEquipmentSlotFactoryService>();
            builder.RegisterType<EquipmentDataAccessService>().As<IEquipmentDataAccessService>();
            builder.RegisterType<EquipmentSearchAndFilterService>().As<IEquipmentSearchAndFilterService>();

            builder.RegisterType<MagicItemFactoryService>().As<IMagicItemFactoryService>();
            builder.RegisterType<MagicItemDataAccessService>().As<IMagicItemDataAccessService>();
            builder.RegisterType<MagicItemSearchAndFilterService>().As<IMagicItemSearchAndFilterService>();

            builder.RegisterType<LootTableFactoryService>().As<ILootTableFactoryService>();
            builder.RegisterType<LootTableDataAccessService>().As<ILootTableDataAccessService>();
            builder.RegisterType<LootTableSearchAndFilterService>().As<ILootTableSearchAndFilterService>();

            builder.RegisterType<ActorFactoryService>().As<IActorFactoryService>();
            builder.RegisterType<ActorSearchAndFilterService>().As<IActorSearchAndFilterService>();

            return builder.Build();
        }
    }
}
