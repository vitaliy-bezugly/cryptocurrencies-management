using System;
using System.Windows.Controls;

namespace Cryptocurrencies.DesktopUi;

public class FrameContainer
{
    public Guid UniqueId { get; set; } = Guid.NewGuid();
    public Frame NavigationFrame { get; set; }

    public FrameContainer()
    {
        NavigationFrame = new Frame();
    }
}