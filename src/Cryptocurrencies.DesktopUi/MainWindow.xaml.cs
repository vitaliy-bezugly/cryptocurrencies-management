using System.Windows;
using Cryptocurrencies.DesktopUi.DIItems;
using Cryptocurrencies.DesktopUi.ViewModels;
using Cryptocurrencies.DesktopUi.Views;

namespace Cryptocurrencies.DesktopUi;

public partial class MainWindow : Window
{
    public MainWindow(CoinsPage coinsPage, MainWindowViewModel viewModel, IFrameContainer frameContainer)
    {
        InitializeComponent();
        
        DataContext = viewModel;
        
        NavigationFrame.NavigationService.Navigate(coinsPage);
        frameContainer.NavigationFrame = NavigationFrame;
    }
}