using System;
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
            GarageVehicle testVehicle1 = new GarageVehicle(new FuelTruck("111", "Ferari"), "John Doe", "050-1234567")
            {
                VehicleStatus = eVehicleStatus.Repaired
            };

            testVehicle1.Vehicle.EnergyPercentage = 33f;

            GarageVehicle testVehicle2 = new GarageVehicle(new FuelCar("444", "Buick"), "John Doe2", "050-1234567")
            {
                VehicleStatus = eVehicleStatus.InRepair
            };

            GarageVehicle testVehicle3 = new GarageVehicle(new ElectricCar("222", "Mistubish"), "John Doe3", "050-1234567")
            {
                VehicleStatus = eVehicleStatus.Paid
            };

            testVehicle3.Vehicle.EnergyPercentage = 25f;

            GarageVehicle testVehicle4 = new GarageVehicle(new FuelMotorcycle("333", "Honda"), "John Doe4", "050-1234567")
            {
                VehicleStatus = eVehicleStatus.Paid
            };

            foreach (Wheel wheel in testVehicle4.Vehicle.Wheels)
            {
                wheel.Inflate(15f);
                wheel.ManufacturerName = "Goodyear";
            }

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
            if(i_GarageVehicle == null)
            {
                throw new ArgumentNullException("i_GarageVehicle", "Garage vehicle cannot be null.");
            }

            if (!r_GarageVehicles.ContainsKey(i_GarageVehicle.Vehicle.LicenseID))
            {
                r_GarageVehicles.Add(i_GarageVehicle.Vehicle.LicenseID, i_GarageVehicle);
            }
            else
            {
                throw new ArgumentException($"A vehicle with license ID {i_GarageVehicle.Vehicle.LicenseID} already exists in the garage.");
            }

        }
    }
}
