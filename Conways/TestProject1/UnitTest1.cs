using ConsoleApp1;
using NUnit.Framework;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void Any_live_cell_with_1_neighbour_dies()
        {
            var cell = Conways.Execute(Cell.Alive, 1);

            Assert.AreEqual(Cell.Dead, cell);
        }

        [Test]
        public void Any_dead_cell_with_1_neighbour_stays_dead()
        {
            var cell = Conways.Execute(Cell.Dead, 1);

            Assert.AreEqual(Cell.Dead, cell);
        }

        [Test]
        public void Any_live_cell_with_0_neighbour_dies()
        {
            var cell = Conways.Execute(Cell.Alive, 0);

            Assert.AreEqual(Cell.Dead, cell);
        }
        
        [Test]
        public void Any_live_cell_with_2_neighbour_lives()
        {
            var cell = Conways.Execute(Cell.Alive, 2);

            Assert.AreEqual(Cell.Alive, cell);
        }  
        
        [Test]
        public void Any_live_cell_with_3_neighbour_lives()
        {
            var cell = Conways.Execute(Cell.Alive, 3);

            Assert.AreEqual(Cell.Alive, cell);
        }  
        
        [Test]
        public void Any_dead_cell_with_2_neighbour_stays_dead()
        {
            var cell = Conways.Execute(Cell.Dead, 2);

            Assert.AreEqual(Cell.Dead, cell);
        }  
        
        [Test]
        public void Any_live_cell_with_4_neighbour_dies()
        {
            var cell = Conways.Execute(Cell.Alive, 4);

            Assert.AreEqual(Cell.Dead, cell);
        } 
        
        [Test]
        public void Any_dead_cell_with_3_neighbour_lives()
        {
            var cell = Conways.Execute(Cell.Dead, 3);

            Assert.AreEqual(Cell.Alive, cell);
        }
        [Test]
        public void Any_dead_cell_with_4_neighbour_stays_dead()
        {
            var cell = Conways.Execute(Cell.Dead, 4);

            Assert.AreEqual(Cell.Dead, cell);
        }
    }
}
