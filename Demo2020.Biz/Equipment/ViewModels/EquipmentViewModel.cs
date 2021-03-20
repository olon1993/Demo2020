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
        private IEquipmentFactory _equipmentFactory;
        private IEquipmentApi _equipmentApi;
        private IEquipment _currentEquipment;
        private IList<IEquipment> _equipment;
        private int _selectedEquipmentIndex = -1;

        public EquipmentViewModel(IEquipmentFactory equipmentFactory, IEquipmentApi equipmentApi)
        {
            _equipmentFactory = equipmentFactory;
            _equipmentApi = equipmentApi;

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
            Equipment = (await _equipmentApi.GetAllEquipment())
                .Cast<IEquipment>()
                .ToList() as IList<IEquipment>;

            foreach (IEquipment equipment in Equipment)
            {
                Console.WriteLine(equipment.Name);
            }
        }

        private async void GetEquipmentDetails()
        {
            CurrentEquipment = Equipment[SelectedEquipmentIndex];
            if (CurrentEquipment.IsDataComplete == false)
            {
                Equipment[SelectedEquipmentIndex] = (await _equipmentApi.GetEquipment(Equipment[SelectedEquipmentIndex].Name)) as IEquipment;

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

        public IEquipment CurrentEquipment { get; set; }
        public IList<IEquipment> Equipment { get; set; }
    }
}
