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

        public void OpenCharacters()
        {
            CharacterWindow characterWindow = new CharacterWindow();
            characterWindow.ShowDialog();
        }
        

        public InitialVM()
        {
            OpenCharactersCommand = new OpenCharactersCommand(this);

        }


        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
