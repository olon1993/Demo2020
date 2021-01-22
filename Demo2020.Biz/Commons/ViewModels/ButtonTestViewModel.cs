using Demo2020.Biz.Commons.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo2020.Biz.Commons.ViewModels
{
    public class ButtonTestViewModel : ObservableObject
    {
        public ButtonTestViewModel()
        {
            TestButton = new RelayCommand(Test);
        }

        private void Test()
        {
            Console.WriteLine("BUTTON PRESSED!!!!");
        }

        public ICommand TestButton { get; set; }
    }
}
