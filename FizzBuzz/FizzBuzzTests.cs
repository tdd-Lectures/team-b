using NUnit.Framework;

namespace FizzBuzz;

public class FizzBuzzTests
{
    // Write o console application that prints the numbers from 1 to 100
    // Multiple of 3 returns Fizz
    // Multiple of 5 returns Buzz
    // Multiple of 3 and 5 returns FizzBuzz
    // otherwise returns the given number

    [Test]
    public void Given_a_multiple_of_3_returns_Fizz([Values(3, 6)] int value)
    {
        var result = Buzzer(value);
        
        Assert.That(result, Is.EqualTo("Fizz"));
    }

    [Test]
    public void Given_a_multiple_of_5_returns_Buzz([Values(5, 10)] int value)
    {
        var result = Buzzer(value);
        
        Assert.That(result, Is.EqualTo("Buzz"));
    }

    [Test]
    public void Given_a_number_thats_not_a_multiple_of_3_or_5_returns_the_given_number([Values(1, 2, 4)] int value)
    {
        var result = Buzzer(value);
        
        Assert.That(result, Is.EqualTo(value.ToString()));
    }

    [Test]
    public void Given_a_multiple_of_3_and_5_returns_FizzBuzz([Values(15, 30)] int value)
    {
        var result = Buzzer(value);
        
        Assert.That(result, Is.EqualTo("FizzBuzz"));
    }

    private string Buzzer(int number)
    {
        if (number % 3 == 0 && number % 5 == 0) return "FizzBuzz";
        if (number % 3 == 0) return "Fizz";
        if (number % 5 == 0) return "Buzz";
        return number.ToString();
    }
}