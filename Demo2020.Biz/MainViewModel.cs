using Demo2020.Biz.Commons.Interfaces;
using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Commons.Services;
using Demo2020.Biz.Commons.ViewModels;
using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.MonsterManual.ViewModels;
using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo2020.Biz
{
    public class MainViewModel : ObservableObject, IMainViewModel
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private ObservableObject _currentViewModel;
        private IMonsterManualViewModel _monsterManualViewModel;
        private IEquipmentViewModel _equipmentViewModel;
        private ILootTableViewModel _lootTableViewModel;

        public MainViewModel(IMonsterManualViewModel monsterManualViewModel, IEquipmentViewModel equipmentViewModel, ILootTableViewModel lootTableViewModel)
        {
            _monsterManualViewModel = monsterManualViewModel;
            _equipmentViewModel = equipmentViewModel;
            _lootTableViewModel = lootTableViewModel;

            MonsterManualCommand = new RelayCommand<ObservableObject>(x => ChangeView((ObservableObject)_monsterManualViewModel));
            EquipmentCommand = new RelayCommand<ObservableObject>(x => ChangeView((ObservableObject)_equipmentViewModel));
            LootCommand = new RelayCommand<ObservableObject>(x => ChangeView((ObservableObject)_lootTableViewModel));

            CurrentViewModel = (ObservableObject)_lootTableViewModel;
        }

        private void ChangeView(ObservableObject newView)
        {
            CurrentViewModel = newView;
        }

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\
        public ObservableObject CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if(_currentViewModel != value)
                {
                    _currentViewModel = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand MonsterManualCommand { get; set; }

        public ICommand EquipmentCommand { get; set; }
        public ICommand LootCommand { get; set; }
    }
}
