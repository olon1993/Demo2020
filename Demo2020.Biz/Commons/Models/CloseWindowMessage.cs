using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Commons.Models
{
    public class CloseWindowMessage
    {
        public CloseWindowMessage(ObservableObject dataContext)
        {
            DataContext = dataContext;
        }

        public ObservableObject DataContext { get; set; }
    }
}
