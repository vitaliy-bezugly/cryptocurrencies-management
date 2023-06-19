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
}