using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.MonsterManual.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Demo2020.Biz.MonsterManual.Models
{
    public class Monster : ObservableObject, IMonster
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private string _name;
        private string _size;
        private string _monsterType;
        private string _monsterSubtype;
        private string _alignment;
        private int _armorClass;
        private string _armorType;
        private int _hitPoints;
        private string _hitPointsCalculation;
        private Speed _speed;
        private int _strength;
        private int _strengthModifier;
        private int _dexterity;
        private int _dexterityModifier;
        private int _constitution;
        private int _constitutionModifier;
        private int _intelligence;
        private int _intelligenceModifier;
        private int _wisdom;
        private int _wisdomModifier;
        private int _charisma;
        private int _charismaModifier;
        private bool _isDataComplete;
        private List<Proficiency> _proficiencies;

        public Monster()
        {
            Speed = new Speed();
        }

        private int CalculateModifier(int score)
        {
            int modifier = (score - 10) / 2;
            if (score < 10 && score % 2 == 1)
            {
                modifier--;
            }
            return modifier;
        }

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\

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

        [JsonProperty("type")]
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

        [JsonProperty("subtype")]
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

        [JsonProperty("armor_class")]
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

        [JsonProperty("armor_type")]
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

        [JsonProperty("hit_points")]
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

        [JsonProperty("hit_dice")]
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

        public Speed Speed
        {
            get { return _speed; }
            set
            {
                if (_speed != value)
                {
                    _speed = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Strength
        {
            get { return _strength; }
            set
            {
                if (_strength != value)
                {
                    _strength = value;
                    StrengthModifier = CalculateModifier(_strength);
                    OnPropertyChanged();
                }
            }
        }

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

        public int Dexterity
        {
            get { return _dexterity; }
            set
            {
                if (_dexterity != value)
                {
                    _dexterity = value;
                    DexterityModifier = CalculateModifier(_dexterity);
                    OnPropertyChanged();
                }
            }
        }

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

        public int Constitution
        {
            get { return _constitution; }
            set
            {
                if (_constitution != value)
                {
                    _constitution = value;
                    ConstitutionModifier = CalculateModifier(_constitution);
                    OnPropertyChanged();
                }
            }
        }

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

        public int Intelligence
        {
            get { return _intelligence; }
            set
            {
                if (_intelligence != value)
                {
                    _intelligence = value;
                    IntelligenceModifier = CalculateModifier(_intelligence);
                    OnPropertyChanged();
                }
            }
        }

        public int IntelligenceModifier
        {
            get { return _intelligenceModifier; }
            set
            {
                if (_intelligenceModifier != value)
                {
                    _intelligenceModifier = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Wisdom
        {
            get { return _wisdom; }
            set
            {
                if (_wisdom != value)
                {
                    _wisdom = value;
                    WisdomModifier = CalculateModifier(_wisdom);
                    OnPropertyChanged();
                }
            }
        }

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

        public int Charisma
        {
            get { return _charisma; }
            set
            {
                if (_charisma != value)
                {
                    _charisma = value;
                    CharismaModifier = CalculateModifier(_charisma);
                    OnPropertyChanged();
                }
            }
        }

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

        public bool IsDataComplete
        {
            get { return _isDataComplete; }
            set { _isDataComplete = value; }
        }

        public List<Proficiency> Proficiencies
        {
            get { return _proficiencies; }
            set 
            {
                if(_proficiencies != value)
                {
                    _proficiencies = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
