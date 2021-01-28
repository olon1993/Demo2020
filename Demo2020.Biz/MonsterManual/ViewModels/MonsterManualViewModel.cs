using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.MonsterManual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.ViewModels
{
    public class MonsterManualViewModel : ObservableObject
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private IMonsterFactory _monsterFactory;
        private IMonster _currentMonster;

        public MonsterManualViewModel(IMonsterFactory monsterFactory)
        {
            _monsterFactory = monsterFactory;

            CurrentMonster = _monsterFactory.GetMonster();
        }

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\
        public IMonster CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                if (_currentMonster != value)
                {
                    _currentMonster = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
