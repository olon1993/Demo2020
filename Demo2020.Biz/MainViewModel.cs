using Demo2020.Biz.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Demo2020.Biz
{
    public class MainViewModel : ObservableObject
    {
        // ======================================================================== \\
        // ====                             Fields                             ==== \\
        // ======================================================================== \\
        private double _progress = 0;

        public MainViewModel()
        {
            Task.Run(async () => await LoadDependencies());
        }

        // ======================================================================== \\
        // ====                            Methods                             ==== \\
        // ======================================================================== \\
        private async Task LoadDependencies()
        {
            while (_progress < 1)
            {
                Progress += 0.1;

                Thread.Sleep(500);
            }
        }

        // ======================================================================== \\
        // ====                          Properties                            ==== \\
        // ======================================================================== \\
        public string Title { get; set; } = "Dungeon Assistant";
        public double Progress 
        {
            get { return _progress; }
            set
            {
                if(_progress != value)
                {
                    _progress = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
