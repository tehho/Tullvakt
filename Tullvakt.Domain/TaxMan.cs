using System;
using System.Numerics;

namespace Tullvakt.Domain
{
    public class TaxMan
    {
        public float GetCost(Vehicle vehicle, DateTime dateTime)
        {
            if (vehicle.EnviromentVehicle)
                return 0.0f;

            float cost = GetCostFromVehicle(vehicle);

            float multiplyer = GetMultiplyerFromTime(dateTime);

            return multiplyer * cost;
        }

        private static float GetMultiplyerFromTime(DateTime dateTime)
        {

            if (!dateTime.IsRedDay())
            {
                if (dateTime.TimeOfDay < new TimeSpan(6, 0, 0) ||
                    dateTime.TimeOfDay > new TimeSpan(18, 0, 0))
                {
                    return 0.5f;
                }

                return 1.0f;
            }
            else
            {
                return 2.0f;
            }
        }

        private static float GetCostFromVehicle(Vehicle vehicle)
        {

            switch (vehicle.Type)
            {
                case VehicalType.personalCar:
                    return vehicle.Weight >= 1000 ? 1000 : 500;

                case VehicalType.truck:
                    return 2000;

                case VehicalType.motorcycle:
                    return vehicle.Weight >= 1000 ? 700 : 350;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}