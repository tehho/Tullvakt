namespace Tullvakt.Domain
{
    public class MotorCycle : Vehicle
    {
        public MotorCycle(int weight, bool enviromentVehicle)
            : base(weight, VehicalType.motorcycle, enviromentVehicle)
        {

        }
    }
}