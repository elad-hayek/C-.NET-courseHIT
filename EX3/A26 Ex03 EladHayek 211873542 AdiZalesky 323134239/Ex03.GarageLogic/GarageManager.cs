using Ex03.GarageLogic.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Garage r_Garage;

        public GarageManager()
        {
            r_Garage = new Garage();
        }

        public List<string> GetLicenseNumbers(eVehicleStatus? filterStatus)
        {
            if (filterStatus == null)
            {
                return new List<string>(r_Garage.GarageVehicles.Keys);
            }
            else
            {
                List<string> filteredLicenseNumbers = new List<string>();

                foreach (KeyValuePair<string, GarageVehicle> garageVehiclePair in r_Garage.GarageVehicles)
                {
                    if (garageVehiclePair.Value.VehicleStatus == filterStatus)
                    {
                        filteredLicenseNumbers.Add(garageVehiclePair.Key);
                    }
                }

                return filteredLicenseNumbers;
            }
        }

        public void LoadGarageVehiclesFromFile(string i_FilePath)
        {
            string[] fileLines = File.ReadAllLines(i_FilePath);
            foreach (string line in fileLines)
            {
                try
                {
                    GarageVehicle garageVehicle = createGarageVehicleFromDataLine(line);
                    r_Garage.AddGarageVehicle(garageVehicle);
                }
                catch (Exception ex)
                {
                    // TODO: create dedicated exception for load errors
                    throw new Exception($"Error loading vehicle from line: {line}. Exception: {ex.Message}");
                }
            }
        }

        private GarageVehicle createGarageVehicleFromDataLine(string i_DataLine)
        {
            string[] vehicleData = i_DataLine.Split(',');

            if (vehicleData.Length < 4)
            {
                throw new FormatException("Insufficient data to create a GarageVehicle");
            }

            string vehicleType = vehicleData[0];
            if (!validateVehicleType(vehicleType))
            {
                throw new ArgumentException($"Unsupported vehicle type: {vehicleType}");
            }

            string licensePlate = vehicleData[1];
            string modelName = vehicleData[2];
            Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleType, licensePlate, modelName);
            vehicle.EnergyPercentage = float.Parse(vehicleData[3]);
            string tireModel = vehicleData[4];
            float tireAirPressure = float.Parse(vehicleData[5]);

            foreach (Wheel wheel in vehicle.Wheels)
            {
                wheel.ManufacturerName = tireModel;
                wheel.Inflate(tireAirPressure);
            }

            string ownerName = vehicleData[6];
            string ownerPhoneNumber = vehicleData[7];

            if (vehicleData.Length > 8)
            {
                string[] specificVehicleData = new string[vehicleData.Length - 8];

                for (int i = 8; i < vehicleData.Length; i++)
                {
                    specificVehicleData[i - 8] = vehicleData[i];
                }

                vehicle.SetSpecificVehicleData(specificVehicleData);
            }

            return new GarageVehicle(vehicle, ownerName, ownerPhoneNumber);
        }

        private bool validateVehicleType(string i_VehicleType)
        {
            return VehicleCreator.SupportedTypes.Contains(i_VehicleType);
        }

        public GarageVehicle GetVehicleByLicenseNumber(string i_LicenseNumber)
        {
            if (r_Garage.GarageVehicles.TryGetValue(i_LicenseNumber, out GarageVehicle garageVehicle))
            {
                return garageVehicle;
            }

            throw new VehicleNotFoundException(i_LicenseNumber);
        }

        public void ChangeVehicleStatus(GarageVehicle i_GarageVehicle, eVehicleStatus i_NewStatus)
        {
            if (i_GarageVehicle != null)
            {
                i_GarageVehicle.VehicleStatus = i_NewStatus;
            }
            else
            {
                throw new ArgumentNullException("i_GarageVehicle", "The vehicle provided was null");
            }
        }

        private bool validateAndThrowVehicleIsNotNull(GarageVehicle i_GarageVehicle)
        {
            if (i_GarageVehicle == null)
            {
                throw new ArgumentNullException("i_GarageVehicle", "The vehicle provided was null");
            }

            return true;
        }

        public void RefuelVehicle(GarageVehicle i_GarageVehicle, eFuelType i_FuelType, float i_AmountOfFuelToAdd)
        {
            validateAndThrowVehicleIsNotNull(i_GarageVehicle);

            if (i_GarageVehicle.Vehicle.EnergyKind != eEnergyKind.Fuel)
            {
                throw new ArgumentException("The vehicle provided is not runing of fuel");
            }

            i_GarageVehicle.Vehicle.AddEnergy(i_AmountOfFuelToAdd, i_FuelType);
        }

        public void RechargeVehicle(GarageVehicle i_GarageVehicle, float i_AmountOfMinutesToAdd)
        {
            validateAndThrowVehicleIsNotNull(i_GarageVehicle);

            if (i_GarageVehicle.Vehicle.EnergyKind != eEnergyKind.Electric)
            {
                throw new ArgumentException("The vehicle provided is not electric");
            }

            i_GarageVehicle.Vehicle.AddEnergy(i_AmountOfMinutesToAdd);
        }

        public void InflateTiresToMax(GarageVehicle i_GarageVehicle)
        {
            validateAndThrowVehicleIsNotNull(i_GarageVehicle);
            i_GarageVehicle.Vehicle.InflateTiresToMax();
        }

        public void AddVehicleToGarage(GarageVehicle i_GarageVehicle)
        {
            validateAndThrowVehicleIsNotNull(i_GarageVehicle);
            r_Garage.AddGarageVehicle(i_GarageVehicle);
        }
    }
}
