﻿#pragma warning disable xUnit1026 // Theory methods should use all of their parameters

using Xunit;

public class xUnit1010
{
    [Theory]
    [InlineData("42")]
    public void TestMethod(int _) { }
}
