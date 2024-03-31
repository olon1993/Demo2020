using Demo2020.Biz.ActorCatalog.Interfaces;
using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.MonsterManual.Interfaces;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo2020.Biz.ActorCatalog.Models
{
    public class ActorModel : ObservableObject, IActorModel
    {
        private bool _isEditStatBlockEnabled;
        private bool _isEditLootTableEnabled;
        private string _editLootTableIconSource;
        private string _editStatBlockIconSource;

        private const string UNLOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/UnlockIcon.png";
        private const string LOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/LockIcon.png";

        public ActorModel()
		{
            ToggleEditLootTableCommand = new RelayCommand<string>(ToggleEdit);
            ToggleEditStatBlockCommand = new RelayCommand<string>(ToggleEdit);
            EditLootTableIconSource = LOCKED_IMAGE_PATH;
            EditStatBlockIconSource = LOCKED_IMAGE_PATH;
        }

        private void ToggleEdit(string sender)
        {
            if (sender == "EditStatBlock")
            {
                ToggleEditStatBlock();
            }
            else
            {
                ToggleEditLootTable();
            }
        }

        private void ToggleEditStatBlock()
        {
            if (_isEditStatBlockEnabled)
            {
                IsEditStatBlockEnabled = false;
            }
            else
            {
                IsEditStatBlockEnabled = true;
            }
        }

        private void ToggleEditLootTable()
        {
            if (_isEditLootTableEnabled)
            {
                IsEditLootTableEnabled = false;
            }
            else
            {
                IsEditLootTableEnabled = true;
                foreach (IEquipmentSlotModel slot in LootTable.EquipmentSlots)
                {
                    slot.Name = slot.Equipment.Name;
                }
            }
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public IMonsterModel StatBlock { get; set; }
        public int LootTableId { get; set; }
		public ILootTableModel LootTable { get; set; }

        public bool IsEditLootTableEnabled
        {
            get { return _isEditLootTableEnabled; }
            set
            {
                if (_isEditLootTableEnabled != value)
                {
                    _isEditLootTableEnabled = value;
                    if (_isEditLootTableEnabled)
                    {
                        LootTable.LootTableSize = LootTable.EquipmentSlots.Count;
                        EditLootTableIconSource = UNLOCKED_IMAGE_PATH;
                    }
                    else
                    {
                        EditLootTableIconSource = LOCKED_IMAGE_PATH;
                    }
                    OnPropertyChanged();
                }
            }
        }

        public string EditLootTableIconSource
        {
            get { return _editLootTableIconSource; }
            set
            {
                if (_editLootTableIconSource != value)
                {
                    _editLootTableIconSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsEditStatBlockEnabled
        {
            get { return _isEditStatBlockEnabled; }
            set
            {
                if (_isEditStatBlockEnabled != value)
                {
                    _isEditStatBlockEnabled = value;
                    if (_isEditStatBlockEnabled)
                    {
                        EditStatBlockIconSource = UNLOCKED_IMAGE_PATH;
                    }
                    else
                    {
                        EditStatBlockIconSource = LOCKED_IMAGE_PATH;
                    }
                    OnPropertyChanged();
                }
            }
        }

        public string EditStatBlockIconSource
        {
            get { return _editStatBlockIconSource; }
            set
            {
                if (_editStatBlockIconSource != value)
                {
                    _editStatBlockIconSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ToggleEditLootTableCommand { get; set; }

        public ICommand ToggleEditStatBlockCommand { get; set; }
    }
}
