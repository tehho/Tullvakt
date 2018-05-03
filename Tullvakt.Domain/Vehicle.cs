using System;

namespace Tullvakt.Domain
{
    public abstract class Vehicle
    {
        public int Weight { get; set; }
        public VehicalType Type { get; set; }
        public bool EnviromentVehicle { get; set; }

        protected Vehicle(int weight, VehicalType type, bool enviromentVehicle)
        {
            Weight = weight;
            Type = type;
            EnviromentVehicle = enviromentVehicle;
        }
    }
}
