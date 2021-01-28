using Demo2020.Biz.Commons.Interfaces;
using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Commons.ViewModels;
using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.MonsterManual.ViewModels;
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
        private IDataAccessService _dataAccessService;
        private IMonsterFactory _monsterFactory;

        private ObservableObject _currentViewModel;

        // Pass in IMonsterManuelViewModel as dependency
        public MainViewModel(IDataAccessService dataAccessService, IMonsterFactory monsterFactory)
        {
            _dataAccessService = dataAccessService;
            _monsterFactory = monsterFactory;

            CurrentViewModel = new MonsterManualViewModel(_monsterFactory);
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
