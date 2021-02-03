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
        private IMonsterApi _monsterApi;
        private IMonster _currentMonster;
        private IList<IMonster> _monsters;

        public MonsterManualViewModel(IMonsterFactory monsterFactory, IMonsterApi monsterApi)
        {
            _monsterFactory = monsterFactory;
            _monsterApi = monsterApi;

            Task.Run(() => Monsters = _monsterApi.GetAllMonsters().Result.Cast<IMonster>().ToList() as IList<IMonster>);
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

        public IList<IMonster> Monsters
        {
            get { return _monsters; }
            set
            {
                if (_monsters != value)
                {
                    _monsters = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
