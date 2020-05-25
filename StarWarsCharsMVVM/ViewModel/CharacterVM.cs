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
    public class CharacterVM : INotifyPropertyChanged
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


        public ObservableCollection<Character> Characters { get; set; }


        private Character selectedCharacter;

        public Character SelectedCharacter
        {
            get { return selectedCharacter; }
            set 
            { 
                selectedCharacter = value;
                
                if (selectedCharacter != null)
                {
                    OnPropertyChanged("SelectedCharacter");
                    GetCharacterInfo();
                }
                
                
            }
        }


        /*
        private CharacterInfo characterInfo;

        public CharacterInfo CharacterInfo
        {
            get { return characterInfo; }
            set 
            { 
                characterInfo = value;
                OnPropertyChanged("CharacterInfo");
            }
        }
        */

        public SearchCommand SearchCommand { get; set; }




        public CharacterVM()
        {
            SearchCommand = new SearchCommand(this);

            Characters = new ObservableCollection<Character>();


        }



        

        private async void GetCharacterInfo()
        {
            Character CharacterInfo = new Character();
            Query = string.Empty;
            

            CharacterInfo = await SwapiHelper.GetCharacterInfo(SelectedCharacter.url);
            Characters.Clear();
        }
        
        
        public async void MakeQuery()
        {
            var characters = await SwapiHelper.GetCharacters(Query);

            Characters.Clear();

            foreach(var character in characters)
            {
                Characters.Add(character);
            }

        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
