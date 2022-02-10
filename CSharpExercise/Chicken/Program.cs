using System;

namespace Chicken
{
    public interface IBird
    {
        Egg Lay();
    }

    // Chicken implements the IBird interface
    public class Chicken : IBird
    {
        public Chicken()
        {
            Console.WriteLine("I'm a chicken");
        }

        public Egg Lay(){
            //A Chicken lays an egg that will hatch into a new Chicken.
            return new Egg(new Func<Chicken>(() => new Chicken()));
        }
    }

    public class Egg
    {
        bool hatch = false;
        Func<IBird> create;

        public Egg(Func<IBird> createBird)
        {
            this.create = createBird;
        }

        public IBird Hatch()
        {
            if (!hatch)
            {
                Console.WriteLine("I have hatched an egg");
                hatch = true;
                return this.create();
            }
            else
                throw new System.InvalidOperationException();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var chicken1 = new Chicken();
            var eggChicken = chicken1.Lay();
            var childChicken = eggChicken.Hatch();
            eggChicken.Hatch(); //Hatching an egg for the second time throws a System.InvalidOperationException

            Console.ReadLine();
        }
    }
}
