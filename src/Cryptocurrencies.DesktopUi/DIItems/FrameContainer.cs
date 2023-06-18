using System.Windows.Controls;

namespace Cryptocurrencies.DesktopUi.DIItems;

public class FrameContainer : IFrameContainer
{
    public FrameContainer()
    {
        NavigationFrame = new Frame();
    }

    public Frame NavigationFrame { get; set; }
}