#pragma warning disable xUnit2015

using System;
using System.ComponentModel;
using Xunit;

public class xUnit2021 : INotifyPropertyChanged
{
    public int Property { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;
    public event EventHandler? SimpleEvent;
    public event EventHandler<int>? SimpleIntEvent;

    [Fact]
    public void TestMethod()
    {
        Assert.PropertyChangedAsync(this, nameof(Property), async () => throw new DivideByZeroException());

        Assert.RaisesAnyAsync(eh => SimpleEvent += eh, eh => SimpleEvent -= eh, async () => throw new DivideByZeroException());
        Assert.RaisesAnyAsync<int>(eh => SimpleIntEvent += eh, eh => SimpleIntEvent -= eh, async () => throw new DivideByZeroException());
        Assert.RaisesAsync<int>(eh => SimpleIntEvent += eh, eh => SimpleIntEvent -= eh, async () => throw new DivideByZeroException());

        Assert.ThrowsAnyAsync<Exception>(async () => throw new DivideByZeroException());
        Assert.ThrowsAsync(typeof(DivideByZeroException), async () => throw new DivideByZeroException());
        Assert.ThrowsAsync<DivideByZeroException>(async () => throw new DivideByZeroException());
        Assert.ThrowsAsync<ArgumentException>("argName", async () => throw new DivideByZeroException());
    }
}
