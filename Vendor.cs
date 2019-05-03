using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20190423_HomeWork
{
    public class Vendor
    {
        public VendorsBrand Brand { get; protected set; }
        public Vehicle[] vehicles;

        public Vehicle this[int i]
        {
            get => vehicles[i];

            set => vehicles[i] = value;
        }

        public Vendor(VendorsBrand brand, int index)
        {
            this.Brand = brand;
            vehicles = new Vehicle[index];
        }
    }
}
