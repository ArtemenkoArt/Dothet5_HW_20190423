using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190423_HomeWork
{
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
}
