namespace Tullvakt.Domain
{
    public class Truck : Vehicle
    {
        public Truck(int weight, bool enviromentVehicle)
            : base(weight, VehicalType.truck, enviromentVehicle)
        {

        }
    }
}