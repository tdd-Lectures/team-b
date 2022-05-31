using System;
using System.Linq;
using System.Net.Sockets;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace StringCalculatorTests;

public class Tests
{
    //method can take up tp two numbers, separeted by commas, and will return their sum
    //"" will return 0
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Given_Empty_string_Return_0()
    {
        Assert.That(Add(""), Is.EqualTo(0));
    }

    [Test]
    public void Given_string_with_1_Returns_1()
    {
        Assert.That(Add("1"), Is.EqualTo(1));
    }

    [Test]
    public void Given_string_with_2_Returns_2()
    {
        Assert.That(Add("2"), Is.EqualTo(2));
    }

    [Test]
    public void Given_string_with_3_Returns_3()
    {
        Assert.That(Add("3"), Is.EqualTo(3));
    }

    [Test]
    public void Given_string_A_Returns_0()
    {
        Assert.That(Add("A"), Is.EqualTo(0));
    }

    [Test]
    public void Given_string_null_Returns_0()
    {
        Assert.That(Add(null!), Is.EqualTo(0));
    }

    [Test]
    public void Given_string_with_1_comma_2_Returns_3()
    {
        Assert.That(Add("1,2"), Is.EqualTo(3));
    }

    [Test]
    public void Given_string_with_3_comma_2_Returns_5()
    {
        Assert.That(Add("3,2"), Is.EqualTo(5));
    }
    [Test]
    public void Given_string_with_32_comma_2_Returns_34()
    {
        Assert.That(Add("32,2"), Is.EqualTo(34));
    }
    [Test]
    public void Given_string_with_32_comma_d_Returns_0()
    {
        Assert.That(Add("32,d"), Is.EqualTo(0));
    }
    [Test]
    public void Given_string_with_34_comma_negative_1_Returns_33()
    {
        Assert.That(Add("34,-1"), Is.EqualTo(33));
    }
    
    
    
    private int Add(string i)
    {
        try
        {
            return SumNumbers(i);
        }
        catch (Exception e)
        { }
        
        return 0;
    }

    private static int SumNumbers(string i)
    {
        return i.Split(",")
            .Select(Int32.Parse)
            .Sum();
    }
}