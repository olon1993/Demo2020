using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.Equipment.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
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

            Messenger.Default.Register<MessageWindowResponse>(this, "GetLootTableDetails", msg =>
            {
                if (msg.Response)
                {
                    GetLootTableDetails();
                }
            });

            GetLootTables();
        }

        //**************************************************\\
        //******************** Methods *********************\\
        //**************************************************\\
        private void GetLootTables()
        {
            _lootTablesRaw = LootTables = _lootTableDataAccessService.GetLootTables();
        }

        private void GetLootTableDetails() 
        {
            CurrentLootTable = LootTables[SelectedLootTableIndex];
            if (CurrentLootTable.IsDataComplete == false)
            {
                LootTables[SelectedLootTableIndex] = (_lootTableDataAccessService.GetLootTable(LootTables[SelectedLootTableIndex].Name)) as ILootTableModel;

                // The monster api failed and returned null
                if (LootTables[SelectedLootTableIndex] == null)
                {
                    LootTables[SelectedLootTableIndex] = CurrentLootTable;
                    Messenger.Default.Send(new MessageWindowConfiguration
                    {
                        Message = "An error occurred while getting " + CurrentLootTable.Name + " data. Would you like to try again? " +
                        "Check you internet connection if you continue to see this message.",
                        IsOkVisible = false,
                        IsTrueFalseVisible = true,
                        Token = "ReloadLootTable"
                    });
                }
                else
                {
                    LootTables[SelectedLootTableIndex].IsDataComplete = true;
                    CurrentLootTable = LootTables[SelectedLootTableIndex];
                }
            }

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
            int selectedLootTableIndexBuffer = SelectedLootTableIndex;
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
            SelectedLootTableIndex = selectedLootTableIndexBuffer;
            CurrentLootTable = LootTables[SelectedLootTableIndex];
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
                Name = "{{Name}}",
                Description = "{{Description}}",
                ImageSource = "/Demo2020;component/Resources/Images/SwordIcon.png",
                EquipmentSlots = new List<IEquipmentSlotModel>()
                    //{
                    //    new EquipmentSlotModel()
                    //    {
                    //        Index = 1,
                    //        Multiplier = 12,
                    //        Equipment = new EquipmentModel()
                    //        {
                    //            Name = "Bronze Hourglass",
                    //            Description = new List<DescriptionModel>()
                    //            {
                    //                new DescriptionModel("Beautifully designed, the sand inside is black.")
                    //            }
                    //        }
                    //    },
                    //    new EquipmentSlotModel()
                    //    {
                    //        Index = 2,
                    //        Multiplier = 0,
                    //        Equipment = new EquipmentModel()
                    //        {
                    //            Name = "Tattered Letter",
                    //            Description = new List<DescriptionModel>()
                    //            {
                    //                new DescriptionModel("From a mother, pleas for them to come home.")
                    //            }
                    //        }
                    //    },
                    //    new EquipmentSlotModel()
                    //    {
                    //        Index = 3,
                    //        Multiplier = 0,
                    //        Equipment = new EquipmentModel()
                    //        {
                    //            Name = "Manacles",
                    //            Description = new List<DescriptionModel>()
                    //            {
                    //                new DescriptionModel("For fastening someones hands or legs together")
                    //            }
                    //        }
                    //    },
                    //    new EquipmentSlotModel()
                    //    {
                    //        Index = 4,
                    //        Multiplier = 0,
                    //        Equipment = new EquipmentModel()
                    //        {
                    //            Name = "Jar of Dirt",
                    //            Description = new List<DescriptionModel>()
                    //            {
                    //                new DescriptionModel("There is a faintly beating heart inside it.")
                    //            }
                    //        }
                    //    },
                    //    new EquipmentSlotModel()
                    //    {
                    //        Index = 5,
                    //        Multiplier = 0,
                    //        Equipment = new EquipmentModel()
                    //        {
                    //            Name = "Carved Skull",
                    //            Description = new List<DescriptionModel>()
                    //            {
                    //                new DescriptionModel("Covered in runes, the teeth chatter on a full moon.")
                    //            }
                    //        }
                    //    },
                    //    new EquipmentSlotModel()
                    //    {
                    //        Index = 6,
                    //        Multiplier = 0,
                    //        Equipment = new EquipmentModel()
                    //        {
                    //            Name = "Handbell",
                    //            Description = new List<DescriptionModel>()
                    //            {
                    //                new DescriptionModel("Can be used to catch someones attention.")
                    //            }
                    //        }
                    //    },
                    //    new EquipmentSlotModel()
                    //    {
                    //        Index = 7,
                    //        Multiplier = 0,
                    //        Equipment = new EquipmentModel()
                    //        {
                    //            Name = "White Chalk",
                    //            Description = new List<DescriptionModel>()
                    //            {
                    //                new DescriptionModel("For writing and marking various surfaces.")
                    //            }
                    //        }
                    //    },
                    //    new EquipmentSlotModel()
                    //    {
                    //        Index = 8,
                    //        Multiplier = 0,
                    //        Equipment = new EquipmentModel()
                    //        {
                    //            Name = "Signet Ring",
                    //            Description = new List<DescriptionModel>()
                    //            {
                    //                new DescriptionModel("Has a distinctively abnormal design carved into it.")
                    //            }
                    //        }
                    //    },
                    //    new EquipmentSlotModel()
                    //    {
                    //        Index = 9,
                    //        Multiplier = 0,
                    //        Equipment = new EquipmentModel()
                    //        {
                    //            Name = "Crystal Pendant",
                    //            Description = new List<DescriptionModel>()
                    //            {
                    //                new DescriptionModel("Begins to glow if completely submerged in water.")
                    //            }
                    //        }
                    //    },
                    //    new EquipmentSlotModel()
                    //    {
                    //        Index = 10,
                    //        Multiplier = 0,
                    //        Equipment = new EquipmentModel()
                    //        {
                    //            Name = "Black Candle",
                    //            Description = new List<DescriptionModel>()
                    //            {
                    //                new DescriptionModel("When lit, it emenates an eerie purple light.")
                    //            }
                    //        }
                    //    },
                    //    new EquipmentSlotModel()
                    //    {
                    //        Index = 11,
                    //        Multiplier = 0,
                    //        Equipment = new EquipmentModel()
                    //        {
                    //            Name = "Unholy Symbol",
                    //            Description = new List<DescriptionModel>()
                    //            {
                    //                new DescriptionModel("This symbol is always cold to the touch.")
                    //            }
                    //        }
                    //    },
                    //    new EquipmentSlotModel()
                    //    {
                    //        Index = 12,
                    //        Multiplier = 0,
                    //        Equipment = new EquipmentModel()
                    //        {
                    //            Name = "Ceremonial Dagger",
                    //            Description = new List<DescriptionModel>()
                    //            {
                    //                new DescriptionModel("This dagger works exceptionally well on human flesh, it deals 2d4 piercing damage to humans.")
                    //            }
                    //        }
                    //    }
                    //}
            };
            lootTables.Add(newTable);

            IEnumerable<ILootTableModel> sortedLootTables = lootTables.OrderBy(x => x.Name);
            lootTables = sortedLootTables.ToList();
            _lootTablesRaw = LootTables = lootTables;
            SelectedLootTableIndex = lootTables.IndexOf(newTable);
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

        public ICommand AddLootTableCommand { get; set; }
    }
}
