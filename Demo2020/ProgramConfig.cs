﻿using Autofac;
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
            builder.RegisterType<LootTableViewModel>().As<ILootTableViewModel>();

            // Models
            builder.RegisterType<Monster>().As<IMonster>();
            builder.RegisterType<Speed>().As<ISpeed>();
            builder.RegisterType<ArmorClass>().As<IArmorClass>();
            builder.RegisterType<Equipment.Models.Equipment>().As<IEquipment>();
            builder.RegisterType<Category>().As<ICategory>();
            builder.RegisterType<Cost>().As<ICost>();
            builder.RegisterType<Damage>().As<IDamage>();
            builder.RegisterType<EquipmentProperty>().As<IEquipmentProperty>();
            builder.RegisterType<Range>().As<IRange>();
            builder.RegisterType<LootTable>().As<ILootTable>();

            // Services
            builder.RegisterType<SqlDataAccessService>().As<IDataAccessService>();

            builder.RegisterType<MonsterFactory>().As<IMonsterFactory>();
            builder.RegisterType<MonsterDataAccessObject>().As<IMonsterDataAccessObject>();
            builder.RegisterType<MonsterSearchAndFilterService>().As<ISearchAndFilterService>();
            builder.RegisterType<SpeedFactory>().As<ISpeedFactory>();

            builder.RegisterType<EquipmentFactory>().As<IEquipmentFactory>();
            builder.RegisterType<EquipmentDataAccessObject>().As<IEquipmentDataAccessObject>();
            builder.RegisterType<EquipmentSearchAndFilterService>().As<IEquipmentSearchAndFilter>();

            builder.RegisterType<LootTableFactory>().As<ILootTableFactory>();
            builder.RegisterType<LootTableDataAccessObject>().As<ILootTableDataAccessObject>();
            builder.RegisterType<LootTableSearchAndFilterService>().As<ILootTableSearchAndFilter>();

            return builder.Build();
        }
    }
}
