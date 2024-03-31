using Demo2020.Biz.ActorCatalog.Interfaces;
using Demo2020.Biz.ActorCatalog.Models;
using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.ActorCatalog.ViewModels
{
    public class ActorCatalogViewModel : ObservableObject, IActorCatalogViewModel
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        //private IActorFactory _monsterFactory;
        //private IActorDataAccessObject _monsterDataAccessObject;
        private IActorSearchAndFilterService _actorSearchAndFilterService;
        private IMonsterDataAccessService _monsterDataAccessService;
        private ILootTableDataAccessService _lootTableDataAccessService;
        private IActorModel _currentActor;
        private IList<IActorModel> _actors;
        private IList<IActorModel> _actorsRaw;
        private int _selectedActorIndex = -1;
        private string _filter;

        public ActorCatalogViewModel(IActorSearchAndFilterService actorSearchAndFilterService, IMonsterDataAccessService monsterManualDataAccessService, ILootTableDataAccessService lootTableDataAccessService)
        {
            _actorSearchAndFilterService = actorSearchAndFilterService;
            _monsterDataAccessService = monsterManualDataAccessService;
            _lootTableDataAccessService = lootTableDataAccessService;

            Actors = _actorsRaw = new List<IActorModel>();
            Actors.Add(new ActorModel { Name = "Bandit", LootTableId = 1 });
            Actors.Add(new ActorModel { Name = "Cultist", LootTableId = 2 });
        }

        //**************************************************\\
        //******************** Methods *********************\\
        //**************************************************\\
        private async void GetActorDetails()
        {
            CurrentActor.StatBlock = await _monsterDataAccessService.GetMonster(Actors[_selectedActorIndex].Name);
        }

        private void GetLootTableDetails()
		{
            CurrentActor.LootTable = _lootTableDataAccessService.GetLootTable(CurrentActor.LootTableId);
		}

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\
        public int SelectedActorIndex
        {
            get { return _selectedActorIndex; }
            set
            {
                if (_selectedActorIndex != value)
                {
                    _selectedActorIndex = value;
                    if (_selectedActorIndex > -1)
                    {
                        CurrentActor = Actors[_selectedActorIndex];
                        GetActorDetails();
                        GetLootTableDetails();
                    }
                    OnPropertyChanged();
                }
            }
        }

        public string Filter
        {
            get { return _filter; }
            set
            {
                if (_filter != value)
                {
                    _filter = value;
                    Actors = _actorSearchAndFilterService.Filter(_actorsRaw, _filter);
                    OnPropertyChanged();
                }
            }
        }

        public IActorModel CurrentActor 
        { 
            get { return _currentActor; }
            set 
            {
                if (_currentActor != value)
                {
                    _currentActor = value;
                    OnPropertyChanged();
                }
            }
        }

        public IList<IActorModel> Actors
        {
            get { return _actors; }
            set
            {
                if (_actors != value)
                {
                    _actors = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
