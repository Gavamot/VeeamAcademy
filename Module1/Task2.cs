using System;
using NUnit.Framework;

namespace Module1;

public class Test
{
    [Test]
    public void Works()
    {
        Base b = new A();
        var resBase = b.GetInfo();
        Assert.AreEqual("Base class", resBase);
        Assert.Pass();
    }
}

public interface IGetInfo
{
    public Func<string> GetInfo { get; }
}

// Глупая реализация без возможности распоковки но условия задачи выполняются
struct Base : IGetInfo
{
    public Func<string> GetInfo => () => "Base class";
    
    public static implicit operator Base(A a)
    {
        var b = new Base();
        return b;
    }
}
struct A : IGetInfo
{
    public Func<string> GetInfo { get; init; } = () => "A class";

    public A()
    {
        GetInfo = new Base().GetInfo;
    }
    
    public A(Base b)
    {
        GetInfo = b.GetInfo;
    }
    public A(Base b, Func<string> getInfoAct) : this(b)
    {
        getInfoAct = this.GetInfo;
    }
}