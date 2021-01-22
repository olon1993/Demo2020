using Demo2020.Biz.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Models
{
    public class Monster : ObservableObject
    {

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _size;
        public string Size
        {
            get { return _size; }
            set
            {
                if (_size != value)
                {
                    _size = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _monsterType;
        public string MonsterType
        {
            get { return _monsterType; }
            set
            {
                if (_monsterType != value)
                {
                    _monsterType = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _monsterSubtype;
        public string MonsterSubtype
        {
            get { return _monsterSubtype; }
            set
            {
                if (_monsterSubtype != value)
                {
                    _monsterSubtype = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _alignment;
        public string Alignment
        {
            get { return _alignment; }
            set
            {
                if (_alignment != value)
                {
                    _alignment = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _armorClass;
        public int ArmorClass
        {
            get { return _armorClass; }
            set
            {
                if (_armorClass != value)
                {
                    _armorClass = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _armorType;
        public string ArmorType
        {
            get { return _armorType; }
            set
            {
                if (_armorType != value)
                {
                    _armorType = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _hitPoints;
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                if (_hitPoints != value)
                {
                    _hitPoints = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _hitPointsCalculation;
        public string HitPointsCalculation
        {
            get { return _hitPointsCalculation; }
            set
            {
                if (_hitPointsCalculation != value)
                {
                    _hitPointsCalculation = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _groundSpeed;
        public int GroundSpeed
        {
            get { return _groundSpeed; }
            set
            {
                if (_groundSpeed != value)
                {
                    _groundSpeed = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _swimSpeed;
        public int SwimSpeed
        {
            get { return _swimSpeed; }
            set
            {
                if (_swimSpeed != value)
                {
                    _swimSpeed = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _climbSpeed;
        public int ClimbSpeed
        {
            get { return _climbSpeed; }
            set
            {
                if (_climbSpeed != value)
                {
                    _climbSpeed = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _flySpeed;
        public int FlySpeed
        {
            get { return _flySpeed; }
            set
            {
                if (_flySpeed != value)
                {
                    _flySpeed = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _strength;
        public int Strength
        {
            get { return _strength; }
            set
            {
                if (_strength != value)
                {
                    _strength = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _strengthModifier;
        public int StrengthModifier
        {
            get { return _strengthModifier; }
            set
            {
                if (_strengthModifier != value)
                {
                    _strengthModifier = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _dexterity;
        public int Dexterity
        {
            get { return _dexterity; }
            set
            {
                if (_dexterity != value)
                {
                    _dexterity = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _dexterityModifier;
        public int DexterityModifier
        {
            get { return _dexterityModifier; }
            set
            {
                if (_dexterityModifier != value)
                {
                    _dexterityModifier = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _constitution;
        public int Constitution
        {
            get { return _constitution; }
            set
            {
                if (_constitution != value)
                {
                    _constitution = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _constitutionModifier;
        public int ConstitutionModifier
        {
            get { return _constitutionModifier; }
            set
            {
                if (_constitutionModifier != value)
                {
                    _constitutionModifier = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _intellect;
        public int Intellect
        {
            get { return _intellect; }
            set
            {
                if (_intellect != value)
                {
                    _intellect = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _intellectModifier;
        public int IntellectModifier
        {
            get { return _intellectModifier; }
            set
            {
                if (_intellectModifier != value)
                {
                    _intellectModifier = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _wisdom;
        public int Wisdom
        {
            get { return _wisdom; }
            set
            {
                if (_wisdom != value)
                {
                    _wisdom = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _wisdomModifier;
        public int WisdomModifier
        {
            get { return _wisdomModifier; }
            set
            {
                if (_wisdomModifier != value)
                {
                    _wisdomModifier = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _charisma;
        public int Charisma
        {
            get { return _charisma; }
            set
            {
                if (_charisma != value)
                {
                    _charisma = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _charismaModifier;
        public int CharismaModifier
        {
            get { return _charismaModifier; }
            set
            {
                if (_charismaModifier != value)
                {
                    _charismaModifier = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
