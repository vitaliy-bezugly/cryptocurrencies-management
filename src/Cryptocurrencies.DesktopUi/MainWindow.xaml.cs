using System.Windows;
using Cryptocurrencies.DesktopUi.ViewModels;
using Cryptocurrencies.DesktopUi.Views;

namespace Cryptocurrencies.DesktopUi;

public partial class MainWindow : Window
{
    public MainWindow(CoinsPage coinsPage, MainWindowViewModel viewModel, FrameContainer frameContainer)
    {
        InitializeComponent();
        
        DataContext = viewModel;
        
        NavigationFrame.NavigationService.Navigate(coinsPage);
        frameContainer.NavigationFrame = NavigationFrame;
    }
}