﻿using AppShopping.Library.Enuns;
using AppShopping.Library.Helpers.MVVM;
using AppShopping.Models;
using AppShopping.Services;
using Newtonsoft.Json;
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

        public ICommand DetailCommand { get; set; }

        public StoresViewModel()
        {
            SearchCommand = new Command(Search);
            DetailCommand = new Command<Establishment>(Detail);

            var allEstablishments = new EstablishmentService().GetEstablishments();
            var allStores = allEstablishments.Where(a => a.Type == EstablishmentType.Store).ToList();

            Establishments = allStores;
            _allEstablishments = allStores;
        }

        private void Detail(Establishment establishment)
        {
            string establishmentSerialized = JsonConvert.SerializeObject(establishment);
            Shell.Current.GoToAsync($"establishment/detail?establishmentSerialized={Uri.EscapeDataString(establishmentSerialized)}");
        }

        private void Search()
        {
            Establishments = _allEstablishments.Where(a => a.Name.ToLower().Contains(SearchWord.ToLower())).ToList();
        }
    }
}
