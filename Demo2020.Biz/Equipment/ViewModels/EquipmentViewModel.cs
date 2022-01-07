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
    public class EquipmentViewModel : ObservableObject, IEquipmentViewModel
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private bool _isDebugOn = false;

        private IEquipmentFactoryService _equipmentFactory;
        private IEquipmentDataAccessService _equipmentDataAccessObject;
        private IEquipmentSearchAndFilterService _equipmentSearchAndFilter;
        private IEquipmentModel _currentEquipment;
        private IList<IEquipmentModel> _equipment;
        private IList<IEquipmentModel> _equipmentRaw;
        private string _filter = "";
        private int _selectedEquipmentIndex = -1;
        private bool _isEditEnabled;
        private string _editIconSource;

        private const string UNLOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/UnlockIcon.png";
        private const string LOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/LockIcon.png";

        public EquipmentViewModel(IEquipmentFactoryService equipmentFactory, IEquipmentDataAccessService equipmentDataAccessObject, IEquipmentSearchAndFilterService equipmentSearchAndFilter)
        {
            _equipmentFactory = equipmentFactory;
            _equipmentDataAccessObject = equipmentDataAccessObject;
            _equipmentSearchAndFilter = equipmentSearchAndFilter;

            Messenger.Default.Register<MessageWindowResponse>(this, "ReloadMonster", msg =>
            {
                if (msg.Response)
                {
                    GetEquipmentDetails();
                }
            });

            GetEquipment();
        }

        //**************************************************\\
        //******************** Methods *********************\\
        //**************************************************\\
        private async void GetEquipment()
        {
            _equipmentRaw = Equipment = (await _equipmentDataAccessObject.GetAllEquipment())
                .Cast<IEquipmentModel>()
                .ToList() as IList<IEquipmentModel>;

            ToggleEditCommand = new RelayCommand(ToggleEdit);
            AddEquipmentCommand = new RelayCommand(AddEquipment);
            EditIconSource = LOCKED_IMAGE_PATH;

            if (_isDebugOn)
            {
                foreach (IEquipmentModel equipment in Equipment)
                {
                    Console.WriteLine(equipment.Name);
                }
            }
        }

        private async void GetEquipmentDetails()
        {
            CurrentEquipment = Equipment[SelectedEquipmentIndex];
            if (CurrentEquipment.IsDataComplete == false)
            {
                Equipment[SelectedEquipmentIndex] = (await _equipmentDataAccessObject.GetEquipment(Equipment[SelectedEquipmentIndex].Name)) as IEquipmentModel;

                // The monster api failed and returned null
                if (Equipment[SelectedEquipmentIndex] == null)
                {
                    Equipment[SelectedEquipmentIndex] = CurrentEquipment;
                    Messenger.Default.Send(new MessageWindowConfiguration
                    {
                        Message = "An error occurred while getting " + CurrentEquipment.Name + " data. Would you like to try again? " +
                        "Check you internet connection if you continue to see this message.",
                        IsOkVisible = false,
                        IsTrueFalseVisible = true,
                        Token = "ReloadMonster"
                    });
                }
                else
                {
                    Equipment[SelectedEquipmentIndex].IsDataComplete = true;
                    CurrentEquipment = Equipment[SelectedEquipmentIndex];
                }
            }

            if (_isDebugOn)
            {
                Console.Write(CurrentEquipment.EquipmentCategory.Name + " " + CurrentEquipment.GearCategory.Name);
            }
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

        private void AddEquipment()
        {
            Equipment.Add(new EquipmentModel
            {
                Name = "{{Name}}", Description = new List<DescriptionModel> { new DescriptionModel("{{Description}}") }
            });
        }

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\
        public int SelectedEquipmentIndex
        {
            get { return _selectedEquipmentIndex; }
            set
            {
                if (_selectedEquipmentIndex != value)
                {
                    _selectedEquipmentIndex = value;
                    if (_selectedEquipmentIndex > -1)
                    {
                        GetEquipmentDetails();
                    }
                    OnPropertyChanged();
                }
            }
        }

        public IEquipmentModel CurrentEquipment
        {
            get { return _currentEquipment; }
            set
            {
                if (_currentEquipment != value)
                {
                    _currentEquipment = value;
                    OnPropertyChanged();
                }
            }
        }

        public IList<IEquipmentModel> Equipment
        {
            get { return _equipment; }
            set
            {
                if (_equipment != value)
                {
                    _equipment = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Filter
        {
            get { return _filter; }
            set
            {
                if (_filter != value)
                {
                    _filter = value;
                    Equipment = _equipmentSearchAndFilter.Filter(_equipmentRaw, _filter);
                    OnPropertyChanged();
                }
            }
        }

        public bool IsEditEnabled
        {
            get { return _isEditEnabled; }
            set
            {
                if (_isEditEnabled != value)
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
                if (_editIconSource != value)
                {
                    _editIconSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ToggleEditCommand { get; set; }

        public ICommand AddEquipmentCommand { get; set; }
    }
}
