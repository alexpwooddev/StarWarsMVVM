using StarWarsCharsMVVM.Model;
using StarWarsCharsMVVM.ViewModel.Commands;
using StarWarsCharsMVVM.ViewModel.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharsMVVM.ViewModel
{
    public class PlanetVM : INotifyPropertyChanged
    {

        private string query;

        public string Query
        {
            get { return query; }
            set 
            { 
                query = value;
                OnPropertyChanged("Query");
            }
        }

        private Planet selectedPlanet;

        public Planet SelectedPlanet
        {
            get { return selectedPlanet; }
            set 
            { 
                selectedPlanet = value;
                if(selectedPlanet != null)
                {
                    OnPropertyChanged("SelectedPlanet");
                    GetPlanetInfo();

                }
            }
        }

        public PlanetSearchCommand PlanetSearchCommand { get; set; }

        public ObservableCollection<Planet> Planets { get; set; }


        public PlanetVM()
        {
            PlanetSearchCommand = new PlanetSearchCommand(this);

            Planets = new ObservableCollection<Planet>();
        }



        public async void MakeQuery()
        {
            var planets = await SwapiHelper.GetPlanets(Query);

            Planets.Clear();

            foreach(var planet in planets)
            {
                Planets.Add(planet);
            }
        }


        public async void GetPlanetInfo()
        {
            Planet planetInfo = new Planet();
            Query = string.Empty;

            planetInfo = await SwapiHelper.GetPlanetInfo(selectedPlanet.url);

            Planets.Clear();
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
