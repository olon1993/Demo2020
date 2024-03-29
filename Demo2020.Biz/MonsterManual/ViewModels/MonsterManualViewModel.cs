﻿using Demo2020.Biz.Commons.Interfaces;
using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.MonsterManual.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo2020.Biz.MonsterManual.ViewModels
{
    public class MonsterManualViewModel : ObservableObject, IMonsterManualViewModel
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private IMonsterFactoryService _monsterFactory;
        private IMonsterDataAccessService _monsterDataAccessObject;
        private IMonsterSearchAndFilterService _searchAndFilterService;
        private IMonsterModel _currentMonster;
        private IList<IMonsterModel> _monsters;
        private IList<IMonsterModel> _monstersRaw;
        private int _selectedMonsterIndex = -1;
        private string _filter = "";
        private bool _isEditEnabled;
        private string _editIconSource;

        private const string UNLOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/UnlockIcon.png";
        private const string LOCKED_IMAGE_PATH = "/Demo2020;component/Resources/Images/LockIcon.png";

        public MonsterManualViewModel(IMonsterFactoryService monsterFactory, IMonsterDataAccessService monsterDataAccessObject, IMonsterSearchAndFilterService searchAndFilterService)
        {
            _monsterFactory = monsterFactory;
            _monsterDataAccessObject = monsterDataAccessObject;
            _searchAndFilterService = searchAndFilterService;

            ToggleEditCommand = new RelayCommand(ToggleEdit);
            AddMonsterCommand = new RelayCommand(AddMonster);
            EditIconSource = LOCKED_IMAGE_PATH;

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
            _monstersRaw = Monsters = (await _monsterDataAccessObject.GetAllMonsters())
                .Cast<IMonsterModel>()
                .ToList() as IList<IMonsterModel>;
        }

        private async void GetMonsterDetails()
        {
            CurrentMonster = Monsters[SelectedMonsterIndex];
            if (CurrentMonster.IsDataComplete == false)
            {
                Monsters[SelectedMonsterIndex] = (await _monsterDataAccessObject.GetMonster(Monsters[SelectedMonsterIndex].Name)) as IMonsterModel;

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

        private void ToggleEdit()
        {
            if (_isEditEnabled)
            {
                IsEditEnabled = false;
            }
            else
            {
                IsEditEnabled = true;
            }
        }

        private void AddMonster()
        {
            Monsters.Add(new MonsterModel
            {
                Name = "{{Name}}",
                MonsterType = "{{MonsterType}}",
                MonsterSubtype = "{{MonsterSubtype}}",
                Alignment = "{{Alignment}}",
                Size = "{{Size}}"
            });
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

        public IMonsterModel CurrentMonster
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

        public IList<IMonsterModel> Monsters
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

        public string Filter 
        {
            get { return _filter; }
            set
            {
                if(_filter != value)
                {
                    _filter = value;
                    Monsters = _searchAndFilterService.Filter(_monstersRaw, _filter);
                    OnPropertyChanged();
                }
            }
        }

        public bool IsEditEnabled
        {
            get { return _isEditEnabled; }
            set
            {
                if (_isEditEnabled != value)
                {
                    _isEditEnabled = value;
                    if (_isEditEnabled)
                    {
                        EditIconSource = UNLOCKED_IMAGE_PATH;
                    }
                    else
                    {
                        EditIconSource = LOCKED_IMAGE_PATH;
                    }
                    OnPropertyChanged();
                }
            }
        }

        public string EditIconSource
        {
            get { return _editIconSource; }
            set
            {
                if (_editIconSource != value)
                {
                    _editIconSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ToggleEditCommand { get; set; }

        public ICommand AddMonsterCommand { get; set; }

    }
}
