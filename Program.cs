using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190423_HomeWork
{

    interface IMyInterface {}

    public delegate int DelegateName(int param1);

    public enum Vendors
    {
        Ford = 1,
        Chevrolet,
        Nissan = 11,
        Hyundai
    }

    public class Vehicle
    {
        public Vendors Vendor { get; protected set; }
        public uint CurrenSpeed { get; internal set; }
        public uint CurrenCargo { get; internal set; }
        public uint MaxSpeed { get; protected set; }
        public uint MaxCargo { get; protected set; }

        public Vehicle(Vendors vendor, uint maxSpeed, uint maxCargo)
        {
            Vendor = vendor;
            MaxSpeed = maxSpeed;
            MaxCargo = MaxCargo;
        }

        public virtual void SetSpeed(int speed)
        {
            if (CurrenCargo >= MaxCargo) //cargo owerload
            {
                CurrenSpeed = 0;
                return;
            }

            for (int s = 1; s <= speed; s++)
            {   
                try
                {
                    CurrenSpeed = speed > 0 ? CurrenSpeed++ : CurrenSpeed--;
                }
                catch
                {
                    CurrenSpeed = 0; // CurrenSpeed = 0 - 1 = -1 uint!!!
                }

                if (CurrenSpeed == MaxSpeed || CurrenSpeed == 0)
                {
                    break;
                }
            }
        }

        public virtual void SetCargo(int cargo)
        {
            if (CurrenSpeed != 0) //Load cargo if auto is stop
            {
                return;
            }

            for (int c = 1; c <= cargo; c++)
            {
                try
                {
                    CurrenCargo = cargo > 0 ? CurrenCargo++ : CurrenCargo--;
                }
                catch
                {
                    CurrenCargo = 0; // CurrenSpeed = 0 - 1 = -1 uint!!!
                }

                if (CurrenCargo >= MaxCargo)
                {
                    CurrenSpeed = 0;
                    break;
                }
                else if (CurrenCargo == 0)
                {
                    break;
                }
            }
        }
    }

    public class Truck : Vehicle
    {
        public Truck(Vendors vendor, uint maxSpeed, uint maxCargo) : base(vendor, maxSpeed, maxCargo)
        {
            //
        }
        //Tractor, Van, Onboard
    }

    public class Tractor : Truck
    {
        //
        Tractor(Vendors vendor, uint maxSpeed, uint maxCargo) : base(vendor, maxSpeed, maxCargo)
        {
            //
        }
    }

    public class Van : Truck
    {
        //
        Van(Vendors vendor, uint maxSpeed, uint maxCargo) : base(vendor, maxSpeed, maxCargo)
        {
            //
        }
    }

    public class Onboard : Truck
    {
        //
        Onboard(Vendors vendor, uint maxSpeed, uint maxCargo) : base(vendor, maxSpeed, maxCargo)
        {
            //
        }
    }

    public class Car : Vehicle
    {
        public Car(Vendors vendor, uint maxSpeed, uint maxCargo) : base(vendor, maxSpeed, maxCargo)
        {
            //
        }
        //Sedan, Hatchback, Crossover
    }

    public class Crossover : Car
    {
        public Crossover(Vendors vendor, uint maxSpeed, uint maxCargo) : base(vendor, maxSpeed, maxCargo)
        {
            //
        }
    }

    public class Sedan : Car
    {
        //
        public Sedan(Vendors vendor, uint maxSpeed, uint maxCargo) : base(vendor,  maxSpeed, maxCargo)
        {
            //
        }
    }
    public class Hatchback : Car
    {
        //
        public Hatchback(Vendors vendor, uint maxSpeed, uint maxCargo) : base(vendor, maxSpeed, maxCargo)
        {
            //
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Crossover crossover = new Crossover(Vendors.Chevrolet, 170, 150);
        }
    }
}
