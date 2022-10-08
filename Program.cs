using System;


namespace Cars
{
    public delegate void CarParkedEventHandler(object source, EventArgs? args);
    public interface ICar
    {
        string? Type { get; set;}
        bool Nice { get; set;}
        double TireSize {get; set;}
        void Drive();
        void Brake();
        event CarParkedEventHandler? CarParked;
        void Parking();
    }
    
    public class Car: ICar
    {
        public string? Driver;
        public double Speed;
        public int Doors;

        public string? Type { get; set; }
        public bool Nice { get; set; }
        public double TireSize { get; set; }
        
        public event CarParkedEventHandler? CarParked;

        public void Parking(){
            Console.WriteLine("Parking car now");
            OnCarParked();
        }

        public void Drive(){
            Speed += 1.5;
            Console.WriteLine("Your car has increased speed! The current speed is " + Speed);

        }

        public void Brake(){
            if(Speed != 0.0){
                Speed -= 0.5;
                Console.WriteLine("Your car has decreased speed! The current speed is " + Speed);
            }else{
                Console.WriteLine("Your car isn't moving!");
            }
        }
        protected virtual void OnCarParked()
        {
            if (CarParked != null)
            {
                CarParked(this, null);
            }
        }
    }

    public class CarService
    {
        public void OnCarParked(object source, EventArgs? e)
        {
            Console.WriteLine("Your car has been parked!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var cS = new CarService();
            var BMW = new Car{Driver = "Imtiaz", Speed = 0.0, Doors = 4, Type = "Sedan", Nice = false, TireSize = 21.0};
            BMW.CarParked += cS.OnCarParked;
            BMW.Parking();
            BMW.Brake();
            BMW.Drive();
            BMW.Brake();

        }
    }

}



