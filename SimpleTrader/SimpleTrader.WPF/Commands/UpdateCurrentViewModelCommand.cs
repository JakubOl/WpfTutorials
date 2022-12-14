using SimpleTrader.FinancialModelingPrepAPI.Services;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using SimpleTrader.WPF.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly INavigator _navigatior;
        private readonly ISimpleTraderViewModelAbstractFactory _viewModelFactory;

        public UpdateCurrentViewModelCommand(INavigator navigatior, ISimpleTraderViewModelAbstractFactory viewModelFactory)
        {
            _navigatior = navigatior;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if(parameter is ViewType)
            {
                var viewType = (ViewType)parameter;

                _navigatior.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
