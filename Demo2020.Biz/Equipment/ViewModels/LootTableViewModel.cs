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
        private ILootTableFactoryService _lootTableFactory;
        private ILootTableDataAccessService _lootTableDataAccessObject;
        private ILootTableSearchAndFilterService _lootTableSearchAndFilter;
        private ILootTableModel _currentLootTable;
        private IList<ILootTableModel> _lootTables;
        private IList<ILootTableModel> _lootTablesRaw;
        private int _selectedLootTableIndex = -1;
        private string _filter = "";
        private bool _isEditEnabled;
        private string _editIconSource;

        private const string UNLOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/UnlockIcon.png";
        private const string LOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/LockIcon.png";

        public LootTableViewModel(ILootTableFactoryService lootTableFactory, ILootTableDataAccessService lootTableDataAccessObject, ILootTableSearchAndFilterService lootTableSearchAndFilter)
        {
            _lootTableFactory = lootTableFactory;
            _lootTableDataAccessObject = lootTableDataAccessObject;
            _lootTableSearchAndFilter = lootTableSearchAndFilter;

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
            _lootTablesRaw = LootTables = new List<ILootTableModel>() 
            { 
                new LootTableModel() 
                { 
                    Name = "I Loot the... Cultist!", 
                    Description = "This is the description", 
                    ImageSource = "/Demo2020;component/Resources/Images/SwordIcon.png",
                    EquipmentSlots = new System.Collections.ObjectModel.ObservableCollection<IEquipmentSlotModel>() 
                    {
                        new EquipmentSlotModel()
                        {
                            Index = 1,
                            Multiplier = "1d12",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Bronze Hourglass",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("Beautifully designed, the sand inside is black.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 2,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Tattered Letter",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("From a mother, pleas for them to come home.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 3,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Manacles",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("For fastening someones hands or legs together")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 4,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Jar of Dirt",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("There is a faintly beating heart inside it.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 5,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Carved Skull",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("Covered in runes, the teeth chatter on a full moon.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 6,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Handbell",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("Can be used to catch someones attention.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 7,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "White Chalk",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("For writing and marking various surfaces.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 8,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Signet Ring",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("Has a distinctively abnormal design carved into it.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 9,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Crystal Pendant",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("Begins to glow if completely submerged in water.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 10,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Black Candle",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("When lit, it emenates an eerie purple light.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 11,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Unholy Symbol",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("This symbol is always cold to the touch.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 12,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Ceremonial Dagger",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("This dagger works exceptionally well on human flesh, it deals 2d4 piercing damage to humans.")
                                }
                            }
                        }
                    } 
                },
                new LootTableModel()
                {
                    Name = "I Loot the... Bandit!",
                    Description = "This is the description",
                    ImageSource = "/Demo2020;component/Resources/Images/SwordIcon.png",
                    EquipmentSlots = new System.Collections.ObjectModel.ObservableCollection<IEquipmentSlotModel>()
                    {
                        new EquipmentSlotModel()
                        {
                            Index = 1,
                            Multiplier = "1d12",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Red Bandana",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("Don't have to worry about blood stains!")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 2,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Steel Lock",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("There's no key.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 3,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Playing Card Set",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("Some of the corners are bent.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 4,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Rusted Scimitar",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("It's in bad shape, -1 damage rolls.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 5,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Fingerless Gloves",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("Makes it easier to snag things")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 6,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Six Sided Die",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("Weighs much more than it should")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 7,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Gold Earrings",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("A set of very beautiful golden earrings.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 8,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Double-Headed Coin",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("The coin has two faces.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 9,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Vial of Acid",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("On a hit, the target takes 2d6 acid damage.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 10,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Wooden Box of Coins",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("Contains 2d5 GP, 3d8 SP, 4d12 CP.")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 11,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "A Fine, Leather Gem Pouch",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("100 GP worth of shiny gemstones")
                                }
                            }
                        },
                        new EquipmentSlotModel()
                        {
                            Index = 12,
                            Multiplier = "",
                            Equipment = new Equipment.Models.EquipmentModel()
                            {
                                Name = "Poison Bolt",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("Poison vial stuck to a bolt. CON save or take an additional 1d4 poison damage.")
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
            CurrentLootTable.EquipmentSlots.Add(new EquipmentSlotModel
            {
                Index = CurrentLootTable.EquipmentSlots.Count + 1,
                Equipment = new Equipment.Models.EquipmentModel { Name = "{{Name}}", Description = new List<DescriptionModel> { new DescriptionModel("{{Description}}") } }
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

        public ILootTableModel CurrentLootTable
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

        public IList<ILootTableModel> LootTables
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

        public string Filter 
        { 
            get { return _filter; }
            set
            {
                if(_filter != value)
                {
                    _filter = value;
                    LootTables = _lootTableSearchAndFilter.Filter(_lootTablesRaw, _filter);
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ToggleEditCommand { get; set; }

        public ICommand AddLootSlotCommand { get; set; }
    }
}
