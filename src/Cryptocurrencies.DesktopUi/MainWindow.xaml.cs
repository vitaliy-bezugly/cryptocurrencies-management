using System.Windows;
using System.Windows.Input;
using MediatR;

namespace Cryptocurrencies.DesktopUi;

public partial class MainWindow : Window
{
    private readonly IMediator _mediator;
    
    public MainWindow(IMediator mediator)
    {
        _mediator = mediator;
        InitializeComponent();
    }
}