using System;

namespace FirstGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            IEngine engine = new BasicEngine();
            ITurbo turbo = new BasicTurbo();

            
            Car myCar = new Car(10f, engine, turbo);

            Console.WriteLine("Starting the car...");
            myCar.StartCar();

            Console.WriteLine("\nActivating turbo...");
            myCar.ActivateTurbo();

            Console.WriteLine("\nDriving the car with turbo...");
            for (int i = 0; i < 5; i++)
            {
                myCar.Drive();
                System.Threading.Thread.Sleep(500); 
            }

            Console.WriteLine("\nDeactivating turbo...");
            myCar.DeactivateTurbo();

            Console.WriteLine("\nDriving the car without turbo...");
            for (int i = 0; i < 5; i++)
            {
                myCar.Drive();
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
namespace FirstGame
{
    public class BasicEngine : IEngine
    {
        public void Start()
        {
            Console.WriteLine("Engine started.");
        }

        public void Stop()
        {
            Console.WriteLine("Engine stopped.");
        }

        public float GetPowerOutput()
        {
            return 100f; 
        }
    }

    public class BasicTurbo : ITurbo
    {
        public bool IsTurboActive { get; private set; } = false;

        public void ActivateTurbo()
        {
            IsTurboActive = true;
            Console.WriteLine("Turbo activated! Increased power output.");
        }

        public void DeactivateTurbo()
        {
            IsTurboActive = false;
            Console.WriteLine("Turbo deactivated.");
        }

        public float GetTurboBoost()
        {
            return 50f; 
        }
    }
}