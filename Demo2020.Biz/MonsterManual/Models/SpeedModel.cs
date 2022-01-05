using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.MonsterManual.Interfaces;
using Newtonsoft.Json;

namespace Demo2020.Biz.MonsterManual.Models
{
    public class SpeedModel : ObservableObject, ISpeedModel
    {
        private string _walk;
        private string _fly;
        private string _swim;
        private string _burrow;
        private string _climb;
        private bool _hover;

        [JsonProperty("walk")]
        public string Walk
        {
            get { return _walk; }
            set
            {
                if (_walk != value)
                {
                    _walk = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("fly")]
        public string Fly
        {
            get { return _fly; }
            set
            {
                if (_fly != value)
                {
                    _fly = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("swim")]
        public string Swim
        {
            get { return _swim; }
            set
            {
                if (_swim != value)
                {
                    _swim = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("climb")]
        public string Climb
        {
            get { return _climb; }
            set
            {
                if (_climb != value)
                {
                    _climb = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("burrow")]
        public string Burrow
        {
            get { return _burrow; }
            set
            {
                if (_burrow != value)
                {
                    _burrow = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("hover")]
        public bool Hover
        {
            get { return _hover; }
            set
            {
                if (_hover != value)
                {
                    _hover = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
