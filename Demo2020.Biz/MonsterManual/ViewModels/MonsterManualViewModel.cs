using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.MonsterManual.Models;
using GalaSoft.MvvmLight.Messaging;
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
        private IMonsterDataAccessObject _monsterDataAccessObject;
        private IMonster _currentMonster;
        private IList<IMonster> _monsters;
        private int _selectedMonsterIndex = -1;

        public MonsterManualViewModel(IMonsterFactory monsterFactory, IMonsterDataAccessObject monsterDataAccessObject)
        {
            _monsterFactory = monsterFactory;
            _monsterDataAccessObject = monsterDataAccessObject;

            Messenger.Default.Register<MessageWindowResponse>(this, "ReloadMonster", msg => 
            {
                if (msg.Response)
                {
                    GetMonsterDetails();
                }
            });

            GetMonsters();
        }

        //**************************************************\\
        //******************** Methods *********************\\
        //**************************************************\\
        private async void GetMonsters()
        {
            Monsters = (await _monsterDataAccessObject.GetAllMonsters())
                .Cast<IMonster>()
                .ToList() as IList<IMonster>;
        }

        private async void GetMonsterDetails()
        {
            CurrentMonster = Monsters[SelectedMonsterIndex];
            if (CurrentMonster.IsDataComplete == false)
            {
                Monsters[SelectedMonsterIndex] = (await _monsterDataAccessObject.GetMonster(Monsters[SelectedMonsterIndex].Name)) as IMonster;

                // The monster api failed and returned null
                if (Monsters[SelectedMonsterIndex] == null)
                {
                    Monsters[SelectedMonsterIndex] = CurrentMonster;
                    Messenger.Default.Send(new MessageWindowConfiguration
                    {
                        Message = "An error occurred while getting " + CurrentMonster.Name + " data. Would you like to try again? " +
                        "Check you internet connection if you continue to see this message.",
                        IsOkVisible = false,
                        IsTrueFalseVisible = true,
                        Token = "ReloadMonster"
                    });
                }
                else
                {
                    Monsters[SelectedMonsterIndex].IsDataComplete = true;
                    CurrentMonster = Monsters[SelectedMonsterIndex];
                }
            }
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
