using ConsoleApp1;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void Test()
        {
            var cell = Conways.Execute(Cell.Dead, -1);

            Assert.AreEqual(Cell.Dead, cell);
        }

    }
}
