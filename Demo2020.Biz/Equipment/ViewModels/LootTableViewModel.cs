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
        private bool _isDebugOn = false;

        private ILootTableFactoryService _lootTableFactoryService;
        private IEquipmentSlotFactoryService _equipmentSlotFactoryService;
        private IEquipmentFactoryService _equipmentModelService;
        private ILootTableDataAccessService _lootTableDataAccessService;
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

        public LootTableViewModel(ILootTableFactoryService lootTableFactory, IEquipmentSlotFactoryService equipmentSlotFactoryService, IEquipmentFactoryService equipmentModelService, 
            ILootTableDataAccessService lootTableDataAccessService, ILootTableSearchAndFilterService lootTableSearchAndFilter)
        {
            _lootTableFactoryService = lootTableFactory;
            _equipmentSlotFactoryService = equipmentSlotFactoryService;
            _equipmentModelService = equipmentModelService;
            _lootTableDataAccessService = lootTableDataAccessService;
            _lootTableSearchAndFilter = lootTableSearchAndFilter;

            ToggleEditCommand = new RelayCommand(ToggleEdit);
            AddLootSlotCommand = new RelayCommand(AddLootSlot);
            AddLootTableCommand = new RelayCommand(AddLootTable);
            EditIconSource = LOCKED_IMAGE_PATH;

            GetLootTables();
        }

        //**************************************************\\
        //******************** Methods *********************\\
        //**************************************************\\
        private async void GetLootTables()
        {
            //_lootTablesRaw = LootTables = _lootTableDataAccessService.GetLootTables();

            //IList<ILootTableModel> lootTables = new List<ILootTableModel>();
            //lootTables.Add(_lootTableFactoryService.GetLootTable());
            //_lootTablesRaw = LootTables = lootTables;

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
                            Multiplier = 12,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 12,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
            //if (CurrentLootTable.IsDataComplete == false)
            //{
            //    LootTables[SelectedLootTableIndex] = (_lootTableDataAccessService.GetLootTable(LootTables[SelectedLootTableIndex].Name)) as ILootTableModel;
            //}

            //if (_isDebugOn)
            //{
            //    Console.Write(CurrentLootTable.Name);
            //}
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
            IEquipmentSlotModel equipmentSlot = new EquipmentSlotModel();
            IEquipmentModel equipmentModel = new EquipmentModel();
            equipmentSlot.Equipment = equipmentModel;
            IList<IEquipmentSlotModel> equipmentSlots = new List<IEquipmentSlotModel>();
            
            foreach(IEquipmentSlotModel equipmentSlotModel in CurrentLootTable.EquipmentSlots)
            {
                equipmentSlots.Add(equipmentSlotModel);
            }

            IEquipmentSlotModel newSlot = new EquipmentSlotModel();
            equipmentSlots.Add(newSlot);

            IList<ILootTableModel> lootTables = new List<ILootTableModel>();
            foreach (ILootTableModel model in LootTables)
            {
                lootTables.Add(model);
            }

            lootTables[_selectedLootTableIndex].EquipmentSlots = equipmentSlots;

            _lootTablesRaw = LootTables = lootTables;
            CurrentLootTable = LootTables[SelectedLootTableIndex];
        }

        private void RemoveLootSlot()
        {
        }

        private void AddLootTable()
        {
            IList<ILootTableModel> lootTables = new List<ILootTableModel>();
            foreach (ILootTableModel model in _lootTablesRaw)
            {
                lootTables.Add(model);
            }

            ILootTableModel newTable = new LootTableModel()
            {
                Name = "I Loot the... Cultist!",
                Description = "This is the description",
                ImageSource = "/Demo2020;component/Resources/Images/SwordIcon.png",
                EquipmentSlots = new System.Collections.ObjectModel.ObservableCollection<IEquipmentSlotModel>()
                    {
                        new EquipmentSlotModel()
                        {
                            Index = 1,
                            Multiplier = 12,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
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
                            Multiplier = 0,
                            Equipment = new EquipmentModel()
                            {
                                Name = "Ceremonial Dagger",
                                Description = new List<DescriptionModel>()
                                {
                                    new DescriptionModel("This dagger works exceptionally well on human flesh, it deals 2d4 piercing damage to humans.")
                                }
                            }
                        }
                    }
            };
            lootTables.Add(newTable);

            _lootTablesRaw = LootTables = lootTables;
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
            get 
            {
                if (_currentLootTable == null)
                {
                    _currentLootTable = _lootTableFactoryService.GetLootTable();
                }

                return _currentLootTable; 
            }
            set
            {
                //if (_currentLootTable != value)
                //{
                    _currentLootTable = value;
                    OnPropertyChanged();
                //}
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

        public ICommand AddLootTableCommand { get; set; }
    }
}
