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
        private bool _isDebugOn = true;

        private IEquipmentService _equipmentService;
        //private IEquipmentFactoryService _equipmentFactory;
        //private IEquipmentDataAccessService _equipmentDataAccessService;
        //private IEquipmentSearchAndFilterService _equipmentSearchAndFilter;
        private IEquipmentModel _currentEquipment;
        private IList<IEquipmentModel> _equipment;
        private IList<IEquipmentModel> _equipmentRaw;
        private string _filter = "";
        private int _selectedEquipmentIndex = -1;
        private bool _isEditEnabled;
        private bool _isSettingsVisible;
        private string _editIconSource;

        private const string UNLOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/UnlockIcon.png";
        private const string LOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/LockIcon.png";

        public EquipmentViewModel(IEquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
            //_equipmentFactory = equipmentFactory;
            //_equipmentDataAccessService = equipmentDataAccessObject;
            //_equipmentSearchAndFilter = equipmentSearchAndFilter;

            SaveCommand = new RelayCommand(SaveEquipment);
            DeleteCommand = new RelayCommand(DeleteEquipment);
            ShowSettingsCommand = new RelayCommand(() => SetSettingsVisibility(true));
            HideSettingsCommand = new RelayCommand(() => SetSettingsVisibility(false));

            //Messenger.Default.Register<MessageWindowResponse>(this, "GetEquipmentDetails", msg =>
            //{
            //    if (msg.Response)
            //    {
            //        GetEquipmentDetailsAsync();
            //    }
            //});

            GetEquipment();
        }

        //**************************************************\\
        //******************** Methods *********************\\
        //**************************************************\\
        private async void GetEquipmentAsync()
        {
            _equipmentRaw = Equipment = (await _equipmentService.GetAllEquipmentAsync())
                .Cast<IEquipmentModel>()
                .ToList() as IList<IEquipmentModel>;

            ToggleEditCommand = new RelayCommand(ToggleEdit);
            AddEquipmentCommand = new RelayCommand(AddEquipment);
            EditIconSource = LOCKED_IMAGE_PATH;
        }

        private void GetEquipment()
        {
            _equipmentRaw = Equipment = _equipmentService.Equipment;

            ToggleEditCommand = new RelayCommand(ToggleEdit);
            AddEquipmentCommand = new RelayCommand(AddEquipment);
            EditIconSource = LOCKED_IMAGE_PATH;
        }

        private async void GetEquipmentDetailsAsync()
        {
            CurrentEquipment = Equipment[SelectedEquipmentIndex];
            if (CurrentEquipment.IsDataComplete == false)
            {
                Equipment[SelectedEquipmentIndex] = (await _equipmentService.GetEquipmentAsync(Equipment[SelectedEquipmentIndex].Name)) as IEquipmentModel;

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
                        Token = "GetEquipmentDetails"
                    });
                }
                else
                {
                    Equipment[SelectedEquipmentIndex].IsDataComplete = true;
                    CurrentEquipment = Equipment[SelectedEquipmentIndex];
                }
            }
        }

        private void SaveEquipment()
        {
            _equipmentService.SaveEquipment(CurrentEquipment);
        }

        private void DeleteEquipment()
        {
            _equipmentService.DeleteEquipment(CurrentEquipment);
            _equipmentRaw = Equipment = _equipmentService.GetAllEquipment();
            CurrentEquipment = null;
        }

        private void SetSettingsVisibility(bool isVisible)
		{
            IsSettingsVisible = isVisible;
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
            int selectedIndex = _equipmentService.AddEquipment();
            _equipmentRaw = Equipment = _equipmentService.Equipment;
            SelectedEquipmentIndex = selectedIndex;
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
                        CurrentEquipment = Equipment[_selectedEquipmentIndex];
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
                    Equipment = _equipmentService.Filter(_filter);
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

        public bool IsSettingsVisible
		{
			get { return _isSettingsVisible; }
            set
			{
                if(_isSettingsVisible != value)
				{
                    _isSettingsVisible = value;
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

        public ICommand SaveCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand ShowSettingsCommand { get; set; }

        public ICommand HideSettingsCommand { get; set; }
    }
}
