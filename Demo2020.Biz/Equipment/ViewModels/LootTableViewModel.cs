using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.Equipment.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo2020.Biz.Equipment.ViewModels
{

    public class LootTableViewModel : ObservableObject, ILootTableViewModel
    {
        private ILootTableFactory _lootTableFactory;
        private ILootTableDataAccessObject _lootTableDataAccessObject;
        private ILootTable _currentLootTable;
        private IList<ILootTable> _lootTables;
        private int _selectedLootTableIndex = -1;
        private bool _isEditEnabled;
        private string _editIconSource;

        private const string UNLOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/UnlockIcon.png";
        private const string LOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/LockIcon.png";

        public LootTableViewModel(ILootTableFactory lootTableFactory, ILootTableDataAccessObject lootTableDataAccessObject)
        {
            _lootTableFactory = lootTableFactory;
            _lootTableDataAccessObject = lootTableDataAccessObject;

            ToggleEditCommand = new RelayCommand(ToggleEdit);
            AddLootSlotCommand = new RelayCommand(AddLootSlot);
            EditIconSource = LOCKED_IMAGE_PATH;

            GetLootTables();
        }

        //**************************************************\\
        //******************** Methods *********************\\
        //**************************************************\\
        private async void GetLootTables()
        {
            LootTables = new List<ILootTable>() 
            { 
                new LootTable() 
                { 
                    Name = "I Loot the... Cultist!", 
                    Description = "This is the description", 
                    ImageSource = "/Demo2020;component/Resources/Images/SwordIcon.png",
                    EquipmentSlots = new System.Collections.ObjectModel.ObservableCollection<IEquipmentSlot>() 
                    {
                        new EquipmentSlot()
                        {
                            Index = 1,
                            Multiplier = "1d12",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Bronze Hourglass",
                                Description = new List<Description>()
                                {
                                    new Description("Beautifully designed, the sand inside is black.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 2,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Tattered Letter",
                                Description = new List<Description>()
                                {
                                    new Description("From a mother, pleas for them to come home.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 3,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Manacles",
                                Description = new List<Description>()
                                {
                                    new Description("For fastening someones hands or legs together")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 4,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Jar of Dirt",
                                Description = new List<Description>()
                                {
                                    new Description("There is a faintly beating heart inside it.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 5,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Carved Skull",
                                Description = new List<Description>()
                                {
                                    new Description("Covered in runes, the teeth chatter on a full moon.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 6,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Handbell",
                                Description = new List<Description>()
                                {
                                    new Description("Can be used to catch someones attention.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 7,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "White Chalk",
                                Description = new List<Description>()
                                {
                                    new Description("For writing and marking various surfaces.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 8,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Signet Ring",
                                Description = new List<Description>()
                                {
                                    new Description("Has a distinctively abnormal design carved into it.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 9,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Crystal Pendant",
                                Description = new List<Description>()
                                {
                                    new Description("Begins to glow if completely submerged in water.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 10,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Black Candle",
                                Description = new List<Description>()
                                {
                                    new Description("When lit, it emenates an eerie purple light.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 11,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Unholy Symbol",
                                Description = new List<Description>()
                                {
                                    new Description("This symbol is always cold to the touch.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 12,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Ceremonial Dagger",
                                Description = new List<Description>()
                                {
                                    new Description("This dagger works exceptionally well on human flesh, it deals 2d4 piercing damage to humans.")
                                }
                            }
                        }
                    } 
                },
                new LootTable()
                {
                    Name = "I Loot the... Bandit!",
                    Description = "This is the description",
                    ImageSource = "/Demo2020;component/Resources/Images/SwordIcon.png",
                    EquipmentSlots = new System.Collections.ObjectModel.ObservableCollection<IEquipmentSlot>()
                    {
                        new EquipmentSlot()
                        {
                            Index = 1,
                            Multiplier = "1d12",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Red Bandana",
                                Description = new List<Description>()
                                {
                                    new Description("Don't have to worry about blood stains!")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 2,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Steel Lock",
                                Description = new List<Description>()
                                {
                                    new Description("There's no key.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 3,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Playing Card Set",
                                Description = new List<Description>()
                                {
                                    new Description("Some of the corners are bent.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 4,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Rusted Scimitar",
                                Description = new List<Description>()
                                {
                                    new Description("It's in bad shape, -1 damage rolls.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 5,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Fingerless Gloves",
                                Description = new List<Description>()
                                {
                                    new Description("Makes it easier to snag things")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 6,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Six Sided Die",
                                Description = new List<Description>()
                                {
                                    new Description("Weighs much more than it should")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 7,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Gold Earrings",
                                Description = new List<Description>()
                                {
                                    new Description("A set of very beautiful golden earrings.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 8,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Double-Headed Coin",
                                Description = new List<Description>()
                                {
                                    new Description("The coin has two faces.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 9,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Vial of Acid",
                                Description = new List<Description>()
                                {
                                    new Description("On a hit, the target takes 2d6 acid damage.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 10,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Wooden Box of Coins",
                                Description = new List<Description>()
                                {
                                    new Description("Contains 2d5 GP, 3d8 SP, 4d12 CP.")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 11,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "A Fine, Leather Gem Pouch",
                                Description = new List<Description>()
                                {
                                    new Description("100 GP worth of shiny gemstones")
                                }
                            }
                        },
                        new EquipmentSlot()
                        {
                            Index = 12,
                            Multiplier = "",
                            Equipment = new Equipment.Models.Equipment()
                            {
                                Name = "Poison Bolt",
                                Description = new List<Description>()
                                {
                                    new Description("Poison vial stuck to a bolt. CON save or take an additional 1d4 poison damage.")
                                }
                            }
                        }
                    }
                }
            };
        }

        private async void GetLootTableDetails() 
        {
            CurrentLootTable = LootTables[SelectedLootTableIndex];
        }

        private void ToggleEdit()
        {
            if (_isEditEnabled)
            {
                IsEditEnabled = false;
            }
            else
            {
                IsEditEnabled = true;
            }
        }

        private void AddLootSlot()
        {
            CurrentLootTable.EquipmentSlots.Add(new EquipmentSlot
            {
                Index = CurrentLootTable.EquipmentSlots.Count + 1,
                Equipment = new Equipment.Models.Equipment { Name = "{{Name}}", Description = new List<Description> { new Description("{{Description}}") } }
            });
        }

        private void RemoveLootSlot()
        {

        }

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\
        public int SelectedLootTableIndex
        {
            get { return _selectedLootTableIndex; }
            set
            {
                if (_selectedLootTableIndex != value)
                {
                    _selectedLootTableIndex = value;
                    if (_selectedLootTableIndex > -1)
                    {
                        GetLootTableDetails();
                    }
                    OnPropertyChanged();
                }
            }
        }

        public ILootTable CurrentLootTable
        {
            get { return _currentLootTable; }
            set
            {
                if (_currentLootTable != value)
                {
                    _currentLootTable = value;
                    OnPropertyChanged();
                }
            }
        }

        public IList<ILootTable> LootTables
        {
            get { return _lootTables; }
            set
            {
                if (_lootTables != value)
                {
                    _lootTables = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsEditEnabled
        {
            get { return _isEditEnabled; }
            set 
            {
                if(_isEditEnabled != value)
                {
                    _isEditEnabled = value;
                    if (_isEditEnabled)
                    {
                        CurrentLootTable.LootTableSize = CurrentLootTable.EquipmentSlots.Count;
                        EditIconSource = UNLOCKED_IMAGE_PATH;
                    }
                    else
                    {
                        EditIconSource = LOCKED_IMAGE_PATH;
                    }
                    OnPropertyChanged();
                }
            }
        }

        public string EditIconSource
        {
            get { return _editIconSource; }
            set
            {
                if(_editIconSource != value)
                {
                    _editIconSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ToggleEditCommand { get; set; }

        public ICommand AddLootSlotCommand { get; set; }
    }
}
