using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190423_HomeWork
{
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
}
