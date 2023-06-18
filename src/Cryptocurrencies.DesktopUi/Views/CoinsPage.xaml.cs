using System.Windows;
using System.Windows.Controls;
using Cryptocurrencies.DesktopUi.ViewModels;

namespace Cryptocurrencies.DesktopUi.Views;

public partial class CoinsPage : Page
{
    public CoinsPage(CoinsViewModel coinsViewModel)
    {
        InitializeComponent();
        
        DataContext = coinsViewModel;
    }

    private async void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        var viewModel = DataContext as CoinsViewModel;
        await viewModel!.LoadCoinsAsync();
    }
}