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
            GarageVehicle testVehicle1 = new GarageVehicle(new FuelTruck("123-45-678", "Test Truck"), "John Doe", "050-1234567")
            {
                VehicleStatus = eVehicleStatus.Repaired
            };

            GarageVehicle testVehicle2 = new GarageVehicle(new FuelCar("34343-2345-678", "Test Truck"), "John Doe2", "050-1234567")
            {
                VehicleStatus = eVehicleStatus.InRepair
            };

            GarageVehicle testVehicle3 = new GarageVehicle(new ElectricCar("86786-435-6232348", "Test Truck"), "John Doe3", "050-1234567")
            {
                VehicleStatus = eVehicleStatus.Paid
            };

            GarageVehicle testVehicle4 = new GarageVehicle(new FuelMotorcycle("85322-435-11111", "Test Truck"), "John Doe4", "050-1234567")
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
