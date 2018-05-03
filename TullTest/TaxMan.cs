using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tullvakt.Domain;

namespace TullTest
{
    [TestClass]
    public class TaxMan
    {
        private readonly Tullvakt.Domain.TaxMan _tull = new Tullvakt.Domain.TaxMan();

        [TestMethod]
        public void Assert_EnviromentVehicle_IsFree_OnWeekday()
        {
            Assert.AreEqual(0, _tull.GetCost(new PersonalCar(900, true), new DateTime(2018, 01, 08)));
            Assert.AreEqual(0, _tull.GetCost(new PersonalCar(1100, true), new DateTime(2018, 01, 08)));
            Assert.AreEqual(0, _tull.GetCost(new Truck(900, true), new DateTime(2018, 01, 08)));
            Assert.AreEqual(0, _tull.GetCost(new Truck(1100, true), new DateTime(2018, 01, 08)));
            Assert.AreEqual(0, _tull.GetCost(new MotorCycle(900, true), new DateTime(2018, 01, 08)));
            Assert.AreEqual(0, _tull.GetCost(new MotorCycle(1100, true), new DateTime(2018, 01, 08)));
        }

        [TestMethod]
        public void Assert_EnviromentVehicle_IsFree_OnRedday()
        {
            var redDay = new DateTime(2018,01,01);

            Assert.IsTrue(redDay.IsRedDay());

            Assert.AreEqual(0, _tull.GetCost(new PersonalCar(900, true), redDay));
            Assert.AreEqual(0, _tull.GetCost(new PersonalCar(1100, true), redDay));
            Assert.AreEqual(0, _tull.GetCost(new Truck(900, true), redDay));
            Assert.AreEqual(0, _tull.GetCost(new Truck(1100, true), redDay));
            Assert.AreEqual(0, _tull.GetCost(new MotorCycle(900, true), redDay));
            Assert.AreEqual(0, _tull.GetCost(new MotorCycle(1100, true), redDay));
        }

        [TestMethod]
        public void Assert_NonEnviromentVehicle_Costs_OnWeekday()
        {
            var weekday = new DateTime(2018,01,08);
            
            Assert.IsFalse(weekday.IsRedDay());

            Assert.AreNotEqual(0, _tull.GetCost(new PersonalCar(900, false), weekday));
            Assert.AreNotEqual(0, _tull.GetCost(new PersonalCar(1100, false), weekday));
            Assert.AreNotEqual(0, _tull.GetCost(new Truck(900, false), weekday));
            Assert.AreNotEqual(0, _tull.GetCost(new Truck(1100, false), weekday));
            Assert.AreNotEqual(0, _tull.GetCost(new MotorCycle(900, false), weekday));
            Assert.AreNotEqual(0, _tull.GetCost(new MotorCycle(1100, false), weekday));
        }

        [TestMethod]
        public void Assert_NonEnviromentVehicle_Costs_OnRedday()
        {
            var redDay = new DateTime(2018, 01, 01);

            Assert.IsTrue(redDay.IsRedDay());

            Assert.AreNotEqual(0, _tull.GetCost(new PersonalCar(900, false), redDay));
            Assert.AreNotEqual(0, _tull.GetCost(new PersonalCar(1100, false), redDay));
            Assert.AreNotEqual(0, _tull.GetCost(new Truck(900, false), redDay));
            Assert.AreNotEqual(0, _tull.GetCost(new Truck(1100, false), redDay));
            Assert.AreNotEqual(0, _tull.GetCost(new MotorCycle(900, false), redDay));
            Assert.AreNotEqual(0, _tull.GetCost(new MotorCycle(1100, false), redDay));
        }

        [TestMethod]
        public void Assert_IsRedDay()
        {
            Assert.AreEqual(false, new DateTime(2018,01,08).IsRedDay());
            Assert.AreEqual(false, new DateTime(2018,01,02).IsRedDay());
            Assert.AreEqual(false, new DateTime(2018,01,03).IsRedDay());
            Assert.AreEqual(false, new DateTime(2018,01,04).IsRedDay());
            Assert.AreEqual(false, new DateTime(2018,01,05).IsRedDay());
            Assert.AreEqual(true, new DateTime(2018,01,06).IsRedDay());
            Assert.AreEqual(true, new DateTime(2018,01,07).IsRedDay());

            Assert.AreEqual(true, new DateTime(2018,01,01).IsRedDay());

            Assert.IsTrue(new DateTime(2018,05,10).IsRedDay());
        }

        [TestMethod]
        public void AssertCost_ForPersonalCar_AreCorrect()
        {
            Assert.AreEqual(500, _tull.GetCost(new PersonalCar(900, false), new DateTime(2018, 01, 08, 07, 00, 00)));
            Assert.AreEqual(1000, _tull.GetCost(new PersonalCar(1100, false), new DateTime(2018,01,08,07,00,00)));

            Assert.AreEqual(250, _tull.GetCost(new PersonalCar(900, false), new DateTime(2018,01,08,05,00,00)));
            Assert.AreEqual(500, _tull.GetCost(new PersonalCar(1100, false), new DateTime(2018,01,08,05,00,00)));

            Assert.AreEqual(250, _tull.GetCost(new PersonalCar(900, false), new DateTime(2018,01,08,19,00,00)));
            Assert.AreEqual(500, _tull.GetCost(new PersonalCar(1100, false), new DateTime(2018,01,08,19,00,00)));

            Assert.AreEqual(1000, _tull.GetCost(new PersonalCar(900, false), new DateTime(2018, 01, 06, 05, 00, 00)));
            Assert.AreEqual(2000, _tull.GetCost(new PersonalCar(1100, false), new DateTime(2018, 01, 06, 05, 00, 00)));
       
            Assert.AreEqual(1000, _tull.GetCost(new PersonalCar(900, false), new DateTime(2018, 01, 06, 07, 00, 00)));
            Assert.AreEqual(2000, _tull.GetCost(new PersonalCar(1100, false), new DateTime(2018, 01, 06, 07, 00, 00)));
       
            Assert.AreEqual(1000, _tull.GetCost(new PersonalCar(900, false), new DateTime(2018, 01, 06, 19, 00, 00)));
            Assert.AreEqual(2000, _tull.GetCost(new PersonalCar(1100, false), new DateTime(2018, 01, 06, 19, 00, 00)));
        }

        [TestMethod]
        public void AssertCost_ForTruck_AreCorrect()
        {
            Assert.AreEqual(2000, _tull.GetCost(new Truck(900, false), new DateTime(2018,01,08,07,00,00)));
            Assert.AreEqual(2000, _tull.GetCost(new Truck(1100, false), new DateTime(2018,01,08,07,00,00)));

            Assert.AreEqual(1000, _tull.GetCost(new Truck(900, false), new DateTime(2018,01,08,05,00,00)));
            Assert.AreEqual(1000, _tull.GetCost(new Truck(1100, false), new DateTime(2018,01,08,05,00,00)));

            Assert.AreEqual(1000, _tull.GetCost(new Truck(900, false), new DateTime(2018,01,08,19,00,00)));
            Assert.AreEqual(1000, _tull.GetCost(new Truck(1100, false), new DateTime(2018,01,08,19,00,00)));

            Assert.AreEqual(4000, _tull.GetCost(new Truck(900, false), new DateTime(2018, 01, 06, 05, 00, 00)));
            Assert.AreEqual(4000, _tull.GetCost(new Truck(1100, false), new DateTime(2018, 01, 06, 05, 00, 00)));

            Assert.AreEqual(4000, _tull.GetCost(new Truck(900, false), new DateTime(2018, 01, 06, 07, 00, 00)));
            Assert.AreEqual(4000, _tull.GetCost(new Truck(1100, false), new DateTime(2018, 01, 06, 07, 00, 00)));

            Assert.AreEqual(4000, _tull.GetCost(new Truck(900, false), new DateTime(2018, 01, 06, 19, 00, 00)));
            Assert.AreEqual(4000, _tull.GetCost(new Truck(1100, false), new DateTime(2018, 01, 06, 19, 00, 00)));
        }

        [TestMethod]
        public void AssertCost_ForMotorcycle_AreCorrect()
        {
            Assert.AreEqual(350, _tull.GetCost(new MotorCycle(900, false), new DateTime(2018,01,08,07,00,00)));
            Assert.AreEqual(700, _tull.GetCost(new MotorCycle(1100, false), new DateTime(2018,01,08,07,00,00)));

            Assert.AreEqual(175, _tull.GetCost(new MotorCycle(900, false), new DateTime(2018,01,08,05,00,00)));
            Assert.AreEqual(350, _tull.GetCost(new MotorCycle(1100, false), new DateTime(2018,01,08,05,00,00)));

            Assert.AreEqual(175, _tull.GetCost(new MotorCycle(900, false), new DateTime(2018,01,08,19,00,00)));
            Assert.AreEqual(350, _tull.GetCost(new MotorCycle(1100, false), new DateTime(2018,01,08,19,00,00)));

            Assert.AreEqual(700, _tull.GetCost(new MotorCycle(900, false), new DateTime(2018, 01, 06, 05, 00, 00)));
            Assert.AreEqual(1400, _tull.GetCost(new MotorCycle(1100, false), new DateTime(2018, 01, 06, 05, 00, 00)));

            Assert.AreEqual(700, _tull.GetCost(new MotorCycle(900, false), new DateTime(2018, 01, 06, 07, 00, 00)));
            Assert.AreEqual(1400, _tull.GetCost(new MotorCycle(1100, false), new DateTime(2018, 01, 06, 07, 00, 00)));

            Assert.AreEqual(700, _tull.GetCost(new MotorCycle(900, false), new DateTime(2018, 01, 06, 19, 00, 00)));
            Assert.AreEqual(1400, _tull.GetCost(new MotorCycle(1100, false), new DateTime(2018, 01, 06, 19, 00, 00)));
        }
    }
}
