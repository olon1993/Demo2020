using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
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
        private bool _isEditEnabled = false;
        private string _editIconSource;

        private const string UNLOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/UnlockIcon.png";
        private const string LOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/LockIcon.png";

        public LootTableViewModel(ILootTableFactory lootTableFactory, ILootTableDataAccessObject lootTableDataAccessObject)
        {
            _lootTableFactory = lootTableFactory;
            _lootTableDataAccessObject = lootTableDataAccessObject;

            ToggleEditCommand = new RelayCommand(ToggleEdit);
            IsEditEnabled = true;

            GetLootTables();
        }

        //**************************************************\\
        //******************** Methods *********************\\
        //**************************************************\\
        private async void GetLootTables()
        {

        }

        private async void GetLootTableDetails() 
        { 
        
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
    }
}
