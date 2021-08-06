using Demo2020.Biz.ActorCatalog.Interfaces;
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
        private IActor _currentActor;
        private IList<IActor> _actors;
        private int _selectedMonsterIndex = -1;

        public IActor CurrentActor 
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

        public IList<IActor> Actors
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
