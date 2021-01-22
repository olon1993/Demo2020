﻿using Demo2020.Biz.Commons.Interfaces;
using Demo2020.Biz.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz
{
    public class MainViewModel : ObservableObject, IMainViewModel
    {
        private IDataAccessService _dataAccessService;

        public MainViewModel(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        public string Test { get; set; } = "Testing View Model";
    }
}
