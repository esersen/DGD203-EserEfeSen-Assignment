namespace FirstGame
{
    public interface IEngine
    {
        void Start();
        void Stop();
        float GetPowerOutput(); 
    }

    public interface ITurbo
    {
        bool IsTurboActive { get; }
        void ActivateTurbo();
        void DeactivateTurbo();
        float GetTurboBoost(); 
    }

    public class Vehicle
    {
        public float Fuel { get; protected set; }
        public float Speed { get; protected set; }
        
        public virtual void Drive()
        {
            
        }
    }

    public class Car : Vehicle
    {
        private readonly IEngine _engine;
        private readonly ITurbo _turbo;

        public Car(float fuelAmount, IEngine engine, ITurbo turbo = null)
        {
            Fuel = fuelAmount;
            _engine = engine;
            _turbo = turbo;
        }

        public void StartCar()
        {
            _engine.Start();
            
        }

        public void ActivateTurbo()
        {
            if (_turbo != null && !_turbo.IsTurboActive && Fuel > 0)
            {
                _turbo.ActivateTurbo();
                Console.WriteLine("Turbo activated!");
            }
            else
            {
                Console.WriteLine("Turbo unavailable or insufficient fuel.");
            }
        }

        public void DeactivateTurbo()
        {
            if (_turbo != null && _turbo.IsTurboActive)
            {
                _turbo.DeactivateTurbo();
                Console.WriteLine("Turbo deactivated.");
            }
        }

        public override void Drive()
        {
            float powerOutput = _engine.GetPowerOutput();
            if (_turbo != null && _turbo.IsTurboActive)
            {
                powerOutput += _turbo.GetTurboBoost();
                Fuel -= 0.2f; 
            }

            Fuel -= 0.1f; 
            Speed = powerOutput; 
            
            Console.WriteLine($"Driving at speed: {Speed}. Fuel remaining: {Fuel}");
        }
    }
}
