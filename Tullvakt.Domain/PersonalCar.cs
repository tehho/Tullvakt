namespace Tullvakt.Domain
{
    public class PersonalCar : Vehicle
    {
        public PersonalCar(int weight, bool enviromentVehicle)
            : base(weight, VehicalType.personalCar, enviromentVehicle)
        {
            
        }
    }
}