using System.Windows.Controls;
using Cryptocurrencies.DesktopUi.ViewModels;

namespace Cryptocurrencies.DesktopUi.Views;

public partial class CoinPage : Page
{
    public CoinPage(CoinViewModel viewModel)
    {
        InitializeComponent();
        
        DataContext = viewModel;
    }
}