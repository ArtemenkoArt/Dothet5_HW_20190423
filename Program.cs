using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190423_HomeWork
{
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

            DoSomethingWithVehicleList(toyota);
        }
    }
}
