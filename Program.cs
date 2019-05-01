using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190423_HomeWork
{
    public enum VendorsBrand
    {
        Ford = 1,
        Chevrolet,
        Nissan = 11,
        Hyundai
    }

    public enum VehicleType
    {
        Truck,
        Car
    }

    public enum TruckType
    {
        Tractor,
        Van,
        Onboard
    }

    public enum CarType
    {
        Sedan,
        Hatchback,
        Crossover
    }

    static class VehicleNumerator
    {
        public static VendorsBrand vendorsBrand { get; set; }
        public static VehicleType vehicleType { get; set; }
        public static TruckType truckType { get; set; }
        public static CarType carType { get; set; }
    }

    public class Vendor
    {
        //public VendorsBrand vendorsBrand { get; protected set; }
        public VendorsBrand brand { get; protected set; }
        public Vehicle[] vehicles;

        public Vehicle this[int i]
        {
            get => vehicles[i];

            set => vehicles[i] = value;
        }

        public Vendor(VendorsBrand brand, int index)
        {
            this.brand = brand;
            vehicles = new Vehicle[index];
        }
    }

    #region VEHICLE
    public class Vehicle
    {
        public uint CurrenSpeed { get; internal set; }
        public uint CurrenCargo { get; internal set; }
        public uint MaxSpeed { get; protected set; }
        public uint MaxCargo { get; protected set; }
        private readonly VehicleType vehicleType;

        public Vehicle(VehicleType vehicleType, uint maxSpeed, uint maxCargo)
        {
            MaxSpeed = maxSpeed;
            MaxCargo = maxCargo;
            this.vehicleType = vehicleType;
        }

        public void SetSpeed(int speed)
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

        public void SetCargo(int cargo)
        {
            if (CurrenSpeed != 0) //Load cargo if vehicle is stop
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

        public virtual string GetVehicleType()
        {
            return Convert.ToString(vehicleType);
        }
    }
    #endregion VEHICLE

    #region TRUCK
    public class Truck : Vehicle //Tractor, Van, Onboard
    {
        private readonly TruckType truckType;

        public Truck(TruckType truckType, uint maxSpeed, uint maxCargo) : base(VehicleType.Truck, maxSpeed, maxCargo)
        {
            this.truckType = truckType;
        }

        public override string GetVehicleType()
        {
            return Convert.ToString(truckType);
        }
    }

    public class Tractor : Truck
    {
        public Tractor(uint maxSpeed, uint maxCargo) : base(TruckType.Tractor, maxSpeed, maxCargo)
        {
            //
        }
    }

    public class Van : Truck
    {
        public Van(uint maxSpeed, uint maxCargo) : base(TruckType.Van, maxSpeed, maxCargo)
        {
            //
        }
    }

    public class Onboard : Truck
    {
        public Onboard(uint maxSpeed, uint maxCargo) : base(TruckType.Onboard, maxSpeed, maxCargo)
        {
            //
        }
    }
    #endregion TRUCK

    #region CAR
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
        public Sedan(uint maxSpeed, uint maxCargo) : base(CarType.Sedan,  maxSpeed, maxCargo)
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
    #endregion CAR

    #region BODY PROGRAM
    class Program
    {
        static void DoSomethingWithVehicleList(Vendor vendor)
        {
            foreach (Vehicle vehicle in vendor.vehicles)
            {
                if (vehicle is Truck)
                {
                    //
                }
                else if (vehicle is Car)
                {
                    //
                }
            }
        }

        static void Main(string[] args)
        {
            Vendor toyota = new Vendor(VendorsBrand.Ford, 7);
            toyota.vehicles[0] = new Tractor(50, 10000);
            toyota.vehicles[6] = new Tractor(60, 20000);
            toyota.vehicles[1] = new Van(120, 8000);
            toyota.vehicles[2] = new Onboard(170, 5000);
            toyota.vehicles[3] = new Crossover(150, 400);
            toyota.vehicles[4] = new Sedan(170, 350);
            toyota.vehicles[5] = new Hatchback(160, 300);



            //List<Vehicle> cars = new List<Vehicle>();
            //cars.Add(new Tractor(50, 10000));
            //cars.Add(new Van(120, 8000));
            //cars.Add(new Onboard(170, 5000));

            //cars.Add(new Crossover(150, 400));
            //cars.Add(new Sedan(170, 350));
            //cars.Add(new Hatchback(160, 300));

            DoSomethingWithVehicleList(toyota);
        }
    }
    #endregion  BODY PROGRAM
}
