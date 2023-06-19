using System.Windows;
using System.Windows.Controls;
using Cryptocurrencies.DesktopUi.ViewModels;

namespace Cryptocurrencies.DesktopUi.Views;

public partial class CurrencyPage : Page
{
    public CurrencyPage(CoinViewModel viewModel)
    {
        InitializeComponent();
        
        DataContext = viewModel;
    }

    private async void Find_OnClick(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as CoinViewModel;
        
        await vm!.FindCoinByIdAsync();
    }
}