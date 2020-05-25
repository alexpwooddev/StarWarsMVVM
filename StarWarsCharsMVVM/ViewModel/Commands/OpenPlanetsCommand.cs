using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StarWarsCharsMVVM.ViewModel.Commands
{
    public class OpenPlanetsCommand : ICommand
    {

        public InitialVM IVM { get; set; }

        public OpenPlanetsCommand(InitialVM ivm)
        {
            IVM = ivm;
        }


        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            IVM.OpenPlanets();
        }
    }
}
