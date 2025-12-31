using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, GarageVehicle> r_GarageVehicles;

        public Garage()
        {
            r_GarageVehicles = new Dictionary<string, GarageVehicle>();

            // TODO: remove this test data
            GarageVehicle testVehicle1 = new GarageVehicle(new FuelTruck("111", "FuelTruck"), "John Doe", "050-1234567")
            {
                VehicleStatus = eVehicleStatus.Repaired
            };

            testVehicle1.Vehicle.FuelType = eFuelType.Soler;
            testVehicle1.Vehicle.EnergyPercentage = 33f;
            testVehicle1.Vehicle.MaxEnergyCapacity = 30f;

            GarageVehicle testVehicle2 = new GarageVehicle(new FuelCar("34343-2345-678", "FuelCar"), "John Doe2", "050-1234567")
            {
                VehicleStatus = eVehicleStatus.InRepair
            };

            GarageVehicle testVehicle3 = new GarageVehicle(new ElectricCar("222", "ElectricCar"), "John Doe3", "050-1234567")
            {
                VehicleStatus = eVehicleStatus.Paid
            };

            testVehicle3.Vehicle.EnergyPercentage = 25f;
            testVehicle3.Vehicle.MaxEnergyCapacity = 4.2f;

            GarageVehicle testVehicle4 = new GarageVehicle(new FuelMotorcycle("85322-435-11111", "FuelMotorcycle"), "John Doe4", "050-1234567")
            {
                VehicleStatus = eVehicleStatus.Paid
            };

            AddGarageVehicle(testVehicle1);
            AddGarageVehicle(testVehicle2);
            AddGarageVehicle(testVehicle3);
            AddGarageVehicle(testVehicle4);
        }

        public Dictionary<string, GarageVehicle> GarageVehicles
        {
            get
            {
                return r_GarageVehicles;
            }
        }

        public void AddGarageVehicle(GarageVehicle i_GarageVehicle)
        {
            // TODO: hanle null or existing logic
            r_GarageVehicles.Add(i_GarageVehicle.Vehicle.LicenseID, i_GarageVehicle);
        }
    }
}
