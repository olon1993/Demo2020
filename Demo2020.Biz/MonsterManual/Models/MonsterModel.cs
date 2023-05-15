using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.MonsterManual.Interfaces;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace Demo2020.Biz.MonsterManual.Models
{
    public class MonsterModel : ObservableObject, IMonsterModel
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private string _name;
        private string _size;
        private string _monsterType;
        private string _monsterSubtype;
        private string _alignment;
        private List<ArmorClassModel> _armorClass;
        private int _hitPoints;
        private string _hitPointsCalculation;
        private int _hitPointBase;
        private List<int> _hitDice = new List<int>
        {
            4, 6, 8, 10, 12, 20
        };
        private int _hitDie;
        private int _hitDiceQuantity;
        private string _hitDieImageSource = "/Demo2020;component/Resources/Images/d20Icon.png";
        private List<string> _hitDiceImageSources = new List<string>
        {
            "/Demo2020;component/Resources/Images/d04Icon.png",
            "/Demo2020;component/Resources/Images/d06Icon.png",
            "/Demo2020;component/Resources/Images/d08Icon.png",
            "/Demo2020;component/Resources/Images/d10Icon.png",
            "/Demo2020;component/Resources/Images/d12Icon.png",
            "/Demo2020;component/Resources/Images/d20Icon.png",
        };
        private SpeedModel _speed;
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
        private List<ProficiencyModel> _proficiencies;
        private double _challengeRating;
        private int _xp;
        private List<string> _creatureSizes = new List<string>
        {
            "Tiny", "Small", "Medium", "Large", "Huge", "Gargantuan"
        };
        private List<string> _creatureAlignments = new List<string>
        {
            "lawful good", "neutral good", "chaotic good",
            "lawful neutral", "neutral", "chaotic neutral",
            "lawful evil", "neutral evil", "chaotic evil",
            "any lawful alignment", "any chaotic alignment",
            "any good alignment", "any evil alignment", "any neutral alignment",
            "any non-lawful alignment", "any non-chaotic alignment",
            "any non-good alignment", "any non-evil alignment", "any non-neutral alignment",
            "any alignment", "unaligned",
        };

        public MonsterModel()
        {
            Speed = new SpeedModel();
            ArmorClass = new List<ArmorClassModel>();

            AddCommand = new RelayCommand<string>(x => Add(x));
            SubtractCommand = new RelayCommand<string>(x => Subtract(x));
        }

        //**************************************************\\
        //******************** Methods *********************\\
        //**************************************************\\

        private int CalculateModifier(int score)
        {
            int modifier = (score - 10) / 2;
            if (score < 10 && score % 2 == 1)
            {
                modifier--;
            }
            return modifier;
        }

        private void ExtractHitPointValues()
        {
            if(HitPointsCalculation != null && HitPointsCalculation != string.Empty)
            {
                int length = HitPointsCalculation.Length;
                int dIndex = HitPointsCalculation.IndexOf("d");
                int pIndex = HitPointsCalculation.IndexOf("+");
                int eIndex = pIndex > 0 ? pIndex : length;

                if(dIndex > 0)
                {
                    HitDiceQuantity = Convert.ToInt32(HitPointsCalculation.Substring(0, dIndex));
                    HitDie = Convert.ToInt32(HitPointsCalculation.Substring(dIndex + 1, eIndex - dIndex - 1));
                }
                else
                {
                    HitDiceQuantity = 0;
                    HitDie = HitDice[5];
                }

                if(pIndex > 0)
                {
                    HitPointBase = Convert.ToInt32(HitPointsCalculation.Substring(pIndex + 1, length - pIndex - 1));
                }
                else
                {
                    HitPointBase = 0;
                }
            }
        }

        private void UpdateHitPointCalculation()
        {
            if (HitPointBase > 0 && HitDiceQuantity > 0 && HitDie > 0)
            {
                HitPointsCalculation = HitDiceQuantity + "d" + HitDie + "+" + HitPointBase;
            }
            else if(HitDiceQuantity > 0 && HitDie > 0)
            {
                HitPointsCalculation = HitDiceQuantity + "d" + HitDie;
            }

            if (HitDiceQuantity > 0 && HitDie > 0)
            {
                HitPoints = HitPointBase + HitDiceQuantity * ((HitDie / 2) + 1);
            }
        }

        private void Add(string ability)
        {
            switch (ability)
            {
                case "STR":
                    Strength++;
                    break;
                case "DEX":
                    Dexterity++;
                    break;
                case "CON":
                    Constitution++;
                    break;
                case "INT":
                    Intelligence++;
                    break;
                case "WIS":
                    Wisdom++;
                    break;
                case "CHA":
                    Charisma++;
                    break;
            }
        }

        private void Subtract(string ability)
        {
            switch (ability)
            {
                case "STR":
                    Strength--;
                    break;
                case "DEX":
                    Dexterity--;
                    break;
                case "CON":
                    Constitution--;
                    break;
                case "INT":
                    Intelligence--;
                    break;
                case "WIS":
                    Wisdom--;
                    break;
                case "CHA":
                    Charisma--;
                    break;
            }
        }

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\

        public Guid Id { get; set; }

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
        public List<ArmorClassModel> ArmorClass
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
                    ExtractHitPointValues();
                    OnPropertyChanged();
                }
            }
        }

        public int HitPointBase
        {
            get { return _hitPointBase; }
            set
            {
                if (_hitPointBase != value)
                {
                    _hitPointBase = value;
                    UpdateHitPointCalculation();
                    OnPropertyChanged();
                }
            }
        }


        public List<int> HitDice
        {
            get { return _hitDice; }
            set
            {
                if (_hitDice != value)
                {
                    _hitDice = value;
                    OnPropertyChanged();
                }
            }
        }

        public int HitDie
        {
            get { return _hitDie; }
            set
            {
                if (_hitDie != value)
                {
                    _hitDie = value;
                    switch (_hitDie)
                    {
                        case 4:
                            HitDieImageSource = _hitDiceImageSources[0];
                            break;
                        case 6:
                            HitDieImageSource = _hitDiceImageSources[1];
                            break;
                        case 8:
                            HitDieImageSource = _hitDiceImageSources[2];
                            break;
                        case 10:
                            HitDieImageSource = _hitDiceImageSources[3];
                            break;
                        case 12:
                            HitDieImageSource = _hitDiceImageSources[4];
                            break;
                        default:
                            HitDieImageSource = _hitDiceImageSources[5];
                            break;
                    }
                    UpdateHitPointCalculation();
                    OnPropertyChanged();
                }
            }
        }

        public int HitDiceQuantity
        {
            get { return _hitDiceQuantity; }
            set
            {
                if (_hitDiceQuantity != value)
                {
                    _hitDiceQuantity = value;
                    UpdateHitPointCalculation();
                    OnPropertyChanged();
                }
            }
        }

        public string HitDieImageSource
        {
            get { return _hitDieImageSource; }
            set
            {
                if (_hitDieImageSource != value)
                {
                    _hitDieImageSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public SpeedModel Speed
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

        public List<ProficiencyModel> Proficiencies
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

        [JsonProperty("challenge_rating")]
        public double ChallengeRating
        {
            get { return _challengeRating; }
            set
            {
                if (_challengeRating != value)
                {
                    _challengeRating = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("xp")]
        public int Xp
        {
            get { return _xp; }
            set
            {
                if (_xp != value)
                {
                    _xp = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<string> CreatureSizes
        {
            get { return _creatureSizes; }
            set
            {
                if (_creatureSizes != value)
                {
                    _creatureSizes = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<string> CreatureAlignments
        {
            get { return _creatureAlignments; }
            set
            {
                if (_creatureAlignments != value)
                {
                    _creatureAlignments = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddCommand { get; set; }

        public ICommand SubtractCommand { get; set; }

    }
}
