using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.TransactionSerivces;
using SimpleTrader.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
    public class BuyStockCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private BuyViewModel _buyViewModel;
        private IBuyStockService _buyStockService;

        public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService)
        {
            _buyViewModel = buyViewModel;
            _buyStockService = buyStockService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                Account account = await _buyStockService.BuyStock(new Account()
                {
                    Id = 1,
                    Balance = 500,
                    AssetTransactions = new List<AssetTransaction>()
                }
                , _buyViewModel.Symbol
                , _buyViewModel.SharesToBuy
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
