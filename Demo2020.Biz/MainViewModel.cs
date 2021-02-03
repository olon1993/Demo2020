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
        private IMonsterFactory _monsterFactory;
        private IMonsterApi _monsterApi;

        private ObservableObject _currentViewModel;

        // Pass in IMonsterManuelViewModel as dependency
        public MainViewModel(IMonsterFactory monsterFactory, IMonsterApi monsterApi)
        {
            _monsterFactory = monsterFactory;
            _monsterApi = monsterApi;

            CurrentViewModel = new MonsterManualViewModel(_monsterFactory, _monsterApi);
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

        public IContractResolver ContractResolver { get; set; }
    }
}
