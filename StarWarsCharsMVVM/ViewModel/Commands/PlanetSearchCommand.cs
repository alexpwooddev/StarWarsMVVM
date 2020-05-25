using StarWarsCharsMVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StarWarsCharsMVVM.ViewModel.Commands
{
    public class PlanetSearchCommand : ICommand
    {

        public PlanetVM VM { get; set; }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public PlanetSearchCommand(PlanetVM vm)
        {
            VM = vm;
        }


        public bool CanExecute(object parameter)
        {
            string query = parameter as string;

            if (string.IsNullOrWhiteSpace(query))
            {
                return false;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            VM.MakeQuery();
        }
    }
}
