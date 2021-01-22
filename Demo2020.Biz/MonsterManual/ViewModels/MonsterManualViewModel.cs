using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.MonsterManual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.ViewModels
{
    public class MonsterManualViewModel : ObservableObject
    {
        public MonsterManualViewModel()
        {
            CurrentMonster = new Monster 
            {
                Name = "Test",
                Size = "Medium",
                MonsterType = "Bug",
                MonsterSubtype = "(Software Bug)",
                Alignment = "Lawful Evil",
                ArmorClass = 15,
                ArmorType = "Natural Armor",
                HitPoints = 58,
                HitPointsCalculation = "(10 d12 + 5)",
                GroundSpeed = 30,
                Strength = 8,
                StrengthModifier = -1,
                Dexterity = 10,
                DexterityModifier = 0,
                Constitution = 13,
                ConstitutionModifier = 1,
                Intellect = 9,
                IntellectModifier = -1,
                Wisdom = 11,
                WisdomModifier = 0,
                Charisma = 10,
                CharismaModifier = 0
            };
        }

        private Monster _currentMonster;
        public Monster CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                if (_currentMonster != value)
                {
                    _currentMonster = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
