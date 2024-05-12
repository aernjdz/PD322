using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TicTacToeLibrary {
    public class DelegateCommand : ICommand {
        private Action execute;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action execute) => this.execute = execute;

        public void Execute(object parameter) => execute();

        public bool CanExecute(object parameter) => true;
    }
}
