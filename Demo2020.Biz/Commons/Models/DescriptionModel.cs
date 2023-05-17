using Demo2020.Biz.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Commons.Models
{
    public class DescriptionModel : ObservableObject
    {
        private int _id;
        private string _text;

        public DescriptionModel(string text)
        {
            Text = text;
        }

        public DescriptionModel(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public int Id
        {
            get { return _id; }
            set
            {
                if(_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Text { 
            get { return _text; }
            set 
            {
                if(_text != value)
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
