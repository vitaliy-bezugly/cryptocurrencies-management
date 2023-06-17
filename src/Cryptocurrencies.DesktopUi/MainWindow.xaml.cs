using System;
using System.Windows;
using Cryptocurrencies.Application.Rates.GetRateByIdQuery;
using MediatR;

namespace Cryptocurrencies.DesktopUi
{
    public partial class MainWindow : Window
    {
        private readonly IMediator _mediator;
        public MainWindow(IMediator mediator)
        {
            _mediator = mediator;
            InitializeComponent();
        }

        private async void GetDataButton_OnClick(object sender, RoutedEventArgs e)
        {
            var rate = await _mediator.Send(new GetRateByIdQuery("ukrainian-hryvnia"));
            Data.Text = rate.ToString();
        }
    }
}