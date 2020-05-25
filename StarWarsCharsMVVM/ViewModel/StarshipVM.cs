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
using System.Windows.Input;

namespace StarWarsCharsMVVM.ViewModel
{
    public class StarshipVM : INotifyPropertyChanged
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



        private Starship selectedStarship;

        public Starship SelectedStarship
        {
            get { return selectedStarship; }
            set 
            { 
                selectedStarship = value; 
                if (selectedStarship != null)
                {
                    OnPropertyChanged("SelectedStarship");
                    GetStarshipInfo();
                }
            }
        }


        public ObservableCollection<Starship> Starships { get; set; }

        public StarshipSearchCommand StarshipSearchCommand { get; set; }



        public StarshipVM()
        {
            StarshipSearchCommand = new StarshipSearchCommand(this);

            Starships = new ObservableCollection<Starship>();
        }


        public async void GetStarshipInfo()
        {
            Starship StarshipInfo = new Starship();
            Query = string.Empty;

            StarshipInfo = await SwapiHelper.GetStarshipInfo(SelectedStarship.url);

            Starships.Clear();

        }


        internal async void MakeQuery()
        {
            var starships = await SwapiHelper.GetStarships(Query);

            Starships.Clear();

            foreach(var starship in starships)
            {
                Starships.Add(starship);
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
