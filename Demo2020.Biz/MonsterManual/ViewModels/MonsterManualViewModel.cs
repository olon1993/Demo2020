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
    public class MonsterManualViewModel : ObservableObject, IMonsterManualViewModel
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private IMonsterFactory _monsterFactory;
        private IMonsterApi _monsterApi;
        private IMonster _currentMonster;
        private IList<IMonster> _monsters;
        private int _selectedMonsterIndex;

        public MonsterManualViewModel(IMonsterFactory monsterFactory, IMonsterApi monsterApi)
        {
            _monsterFactory = monsterFactory;
            _monsterApi = monsterApi;
            GetMonsters();
        }

        //**************************************************\\
        //******************** Methods *********************\\
        //**************************************************\\
        private async void GetMonsters()
        {
            Monsters = (await _monsterApi.GetAllMonsters())
                .Cast<IMonster>()
                .ToList() as IList<IMonster>;
        }

        private async void GetMonsterDetails()
        {
            CurrentMonster = (await _monsterApi.GetMonster(Monsters[SelectedMonsterIndex].Name)) as IMonster;
        }

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\
        public int SelectedMonsterIndex
        {
            get { return _selectedMonsterIndex; }
            set 
            { 
                if(_selectedMonsterIndex != value)
                {
                    _selectedMonsterIndex = value;
                    if (_selectedMonsterIndex > -1)
                    {
                        GetMonsterDetails();
                    }
                    OnPropertyChanged();
                }
            }
        }

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
