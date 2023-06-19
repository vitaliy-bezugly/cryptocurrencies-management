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
}