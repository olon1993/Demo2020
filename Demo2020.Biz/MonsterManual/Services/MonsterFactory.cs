using Autofac;
using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.MonsterManual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Services
{
    public class MonsterFactory : IMonsterFactory
    {
        private ILifetimeScope _scope;
        private ISpeedFactory _speedFactory;

        public MonsterFactory(ILifetimeScope scope, ISpeedFactory speedFactory)
        {
            _scope = scope;
            _speedFactory = speedFactory;
        }

        public IMonster GetMonster()
        {
            IMonster monster = _scope.Resolve<IMonster>();

            // Replace hard coded data assignments with API call 
            monster.Name = "Test";
            monster.Size = "Medium";
            monster.MonsterType = "Bug";
            monster.MonsterSubtype = "(Software Bug)";
            monster.Alignment = "Lawful Evil";
            monster.ArmorClass = 15;
            monster.HitPoints = 58;
            monster.HitPointsCalculation = "(10 d12 + 5)";
            monster.Strength = 8;
            monster.StrengthModifier = -1;
            monster.Dexterity = 10;
            monster.DexterityModifier = 0;
            monster.Constitution = 13;
            monster.ConstitutionModifier = 1;
            monster.Intellect = 9;
            monster.IntellectModifier = -1;
            monster.Wisdom = 11;
            monster.WisdomModifier = 0;
            monster.Charisma = 10;
            monster.CharismaModifier = 0;

            monster.Speed = new List<ISpeed>();

            ISpeed speed = _speedFactory.GetSpeed();
            speed.Type = "";
            speed.Value = 30;
            monster.Speed.Add(speed);

            return monster;
        }
    }
}
