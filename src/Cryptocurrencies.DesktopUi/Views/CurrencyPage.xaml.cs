using System.Windows;
using System.Windows.Controls;
using Cryptocurrencies.DesktopUi.ViewModels;

namespace Cryptocurrencies.DesktopUi.Views;

public partial class CurrencyPage : Page
{
    public CurrencyPage(CurrencyViewModel viewModel)
    {
        InitializeComponent();
        
        DataContext = viewModel;
    }

    private async void Find_OnClick(object sender, RoutedEventArgs e)
    {
        var vm = DataContext as CurrencyViewModel;
        
        await vm!.FindCurrencyByIdAsync();
        await vm!.FindMarketsByCurrencyIdAsync();
        await vm!.FindHistoryByCurrencyIdAsync();
    }
}