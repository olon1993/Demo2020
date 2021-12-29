using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.ViewModels
{
    public class EquipmentViewModel : ObservableObject, IEquipmentViewModel
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private bool _isDebugOn = false;

        private IEquipmentFactory _equipmentFactory;
        private IEquipmentDataAccessObject _equipmentDataAccessObject;
        private IEquipmentSearchAndFilter _equipmentSearchAndFilter;
        private IEquipment _currentEquipment;
        private IList<IEquipment> _equipment;
        private IList<IEquipment> _equipmentRaw;
        private string _filter = "";
        private int _selectedEquipmentIndex = -1;

        public EquipmentViewModel(IEquipmentFactory equipmentFactory, IEquipmentDataAccessObject equipmentDataAccessObject, IEquipmentSearchAndFilter equipmentSearchAndFilter)
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
                .Cast<IEquipment>()
                .ToList() as IList<IEquipment>;

            if (_isDebugOn)
            {
                foreach (IEquipment equipment in Equipment)
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
                Equipment[SelectedEquipmentIndex] = (await _equipmentDataAccessObject.GetEquipment(Equipment[SelectedEquipmentIndex].Name)) as IEquipment;

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

        public IEquipment CurrentEquipment
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

        public IList<IEquipment> Equipment
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
    }
}
