using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190423_HomeWork
{
    public class Car : Vehicle //Sedan, Hatchback, Crossover
    {
        private readonly CarType carType;

        public Car(CarType carType, uint maxSpeed, uint maxCargo) : base(VehicleType.Car, maxSpeed, maxCargo)
        {
            this.carType = carType;
        }
    }

    public class Crossover : Car
    {
        public Crossover(uint maxSpeed, uint maxCargo) : base(CarType.Crossover, maxSpeed, maxCargo)
        {
            //
        }
    }

    public class Sedan : Car
    {
        public Sedan(uint maxSpeed, uint maxCargo) : base(CarType.Sedan, maxSpeed, maxCargo)
        {
            //
        }
    }
    public class Hatchback : Car
    {
        public Hatchback(uint maxSpeed, uint maxCargo) : base(CarType.Hatchback, maxSpeed, maxCargo)
        {
            //
        }
    }
}
