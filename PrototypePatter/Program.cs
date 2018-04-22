
using System;

namespace PrototypePattern
{
    public class Form
    {
        private PartOriginCountry _handlebar;
        private PartOriginCountry _frame;
        private PartOriginCountry _brakes;
        private PartOriginCountry _wheels;

        public Form(PartOriginCountry handlebar, PartOriginCountry frame,
            PartOriginCountry breakes, PartOriginCountry wheels)
        {
            _handlebar = handlebar;
            _frame = frame;
            _brakes = breakes;
            _wheels = wheels;
        }

        public CustomBike ProduceBike()
        {
            var bike = new CustomBike(_handlebar, _frame, _brakes, _wheels);
            return bike;
        }
    }

    public enum PartOriginCountry
    {
        Poland,
        China,
        Germany,
        Italy,
        Norwey
    }

    public interface ICloneable
    {
        object Clone();
    }

    public class CustomBike : ICloneable
    {
        private PartOriginCountry _handlebar;
        private PartOriginCountry _frame;
        private PartOriginCountry _brakes;
        private PartOriginCountry _wheels;


        public CustomBike(PartOriginCountry handlebar, PartOriginCountry frame,
            PartOriginCountry brakes, PartOriginCountry wheels)
        {
            _handlebar = handlebar;
            _frame = frame;
            _brakes = brakes;
            _wheels = wheels;
        }

        public object Clone()
        {
            var clonedBike = this.MemberwiseClone();
            return clonedBike;
        }

        public override string ToString()
        {
            return String.Format("Handlebar: {0} \nFrame: {1} \nBrakes: {2}" +
                                 " \nWheels: {3}", _handlebar, _frame, _brakes, _wheels);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PartOriginCountry handlebar = PartOriginCountry.Norwey;
            PartOriginCountry frame = PartOriginCountry.China;
            PartOriginCountry brakes = PartOriginCountry.Germany;
            PartOriginCountry wheels = PartOriginCountry.Poland;

            var form = new Form(handlebar, frame, brakes, wheels);

            CustomBike bike = form.ProduceBike();

            var newBike = bike.Clone();

            Console.WriteLine("Custom bike:");
            Console.WriteLine(bike);
            Console.WriteLine();

            var customBike1 = bike.Clone();
            Console.WriteLine($"Cloned bike 1: \n{customBike1} \n");

            var customBike2 = bike.Clone();
            Console.WriteLine($"Cloned bike 2: \n{customBike2} \n");

            Console.ReadKey();
        }
    }
}