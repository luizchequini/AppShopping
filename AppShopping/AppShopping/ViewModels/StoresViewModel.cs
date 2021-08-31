﻿using AppShopping.Library.Enuns;
using AppShopping.Library.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppShopping.ViewModels
{
    public class StoresViewModel : BaseViewModel
    {
        public string SearchWord { get; set; }
        public ICommand SearchCommand { get; set; }

        private List<Establishment> _establishments;

        public List<Establishment> Establishments {
            get
            {
                return _establishments;
            }
            set 
            {
               SetProperty(ref _establishments, value);
            } 
        }

        private List<Establishment> _allEstablishments;

        public StoresViewModel()
        {
            SearchCommand = new Command(Search);

            var allEstablishments = new EstablishmentService().GetEstablishments();
            var allStores = allEstablishments.Where(a => a.Type == EstablishmentType.Store).ToList();

            Establishments = allStores;
            _allEstablishments = allStores;
        }

        private void Search()
        {
            Establishments = _allEstablishments.Where(a => a.Name.ToLower().Contains(SearchWord.ToLower())).ToList();
        }
    }
}
