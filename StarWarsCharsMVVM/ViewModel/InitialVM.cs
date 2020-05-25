using StarWarsCharsMVVM.Model;
using StarWarsCharsMVVM.View;
using StarWarsCharsMVVM.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsCharsMVVM.ViewModel
{
    public class InitialVM : INotifyPropertyChanged
    {


        public OpenCharactersCommand OpenCharactersCommand { get; set; }
        public OpenStarshipsCommand OpenStarshipsCommand { get; set; }

        public OpenPlanetsCommand OpenPlanetsCommand { get; set; }


        public void OpenCharacters()
        {
            CharacterWindow characterWindow = new CharacterWindow();
            characterWindow.ShowDialog();
        }

        internal void OpenPlanets()
        {
            PlanetWindow planetWindow = new PlanetWindow();
            planetWindow.ShowDialog();
        }

        public void OpenStarships()
        {
            StarshipWindow starshipWindow = new StarshipWindow();
            starshipWindow.ShowDialog();
        }


        public InitialVM()
        {
            OpenCharactersCommand = new OpenCharactersCommand(this);
            OpenStarshipsCommand = new OpenStarshipsCommand(this);
            OpenPlanetsCommand = new OpenPlanetsCommand(this);

        }

        

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
