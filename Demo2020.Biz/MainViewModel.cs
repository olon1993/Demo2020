using Demo2020.Biz.Commons.Interfaces;
using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Commons.Services;
using Demo2020.Biz.Commons.ViewModels;
using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.MonsterManual.ViewModels;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz
{
    public class MainViewModel : ObservableObject, IMainViewModel
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private ObservableObject _currentViewModel;
        private IMonsterManualViewModel _monsterManualViewModel;

        public MainViewModel(IMonsterManualViewModel monsterManualViewModel)
        {
            _monsterManualViewModel = monsterManualViewModel;

            CurrentViewModel = (ObservableObject)_monsterManualViewModel;
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
    }
}
