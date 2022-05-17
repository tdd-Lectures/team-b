using NUnit.Framework;

namespace Conways;

// Any live cell with fewer than two live neighbours dies, as if caused by under-population.
// Any live cell with two or three live neighbours lives on to the next generation.
// Any live cell with more than three live neighbours dies, as if by overcrowding.
// Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.
public class Tests
{
    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}