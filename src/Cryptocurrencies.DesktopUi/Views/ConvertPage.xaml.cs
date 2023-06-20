using System.Windows;
using System.Windows.Controls;
using Cryptocurrencies.DesktopUi.ViewModels;

namespace Cryptocurrencies.DesktopUi.Views;

public partial class ConvertPage : Page
{
    public ConvertPage(ConvertViewModel viewModel)
    {
        InitializeComponent();
        
        DataContext = viewModel;
    }
}