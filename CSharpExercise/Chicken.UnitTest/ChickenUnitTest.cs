using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Chicken.UnitTest
{
    [TestClass]
    public class ChickenUnitTest
    {
        [TestMethod]
        public void Chicken_Is_A_Bird()
        {
            var chicken = new Chicken();
            Assert.IsTrue(chicken is IBird);
        }

        [TestMethod]
        public void Chickens_Can_Make_New_Chickens()
        {
            var bird = (new Chicken() as IBird);
            Assert.IsTrue(bird.Lay().Hatch() is Chicken);
        }

        [TestMethod]
        public void Ostriches_Cant_Make_Chickens()
        {
            var otherBird = new Ostrich();
            Assert.IsFalse(otherBird.Lay().Hatch() is Chicken);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Egs_Cannot_Hatch_Twice()
        {
            var otherBird = new Ostrich();
            var egg = otherBird.Lay();
            egg.Hatch();
            egg.Hatch();
        }
    }

    class Ostrich : IBird
    {
        public Egg Lay()
        {
            return new Egg(() => new Ostrich());
        }
    }
}
