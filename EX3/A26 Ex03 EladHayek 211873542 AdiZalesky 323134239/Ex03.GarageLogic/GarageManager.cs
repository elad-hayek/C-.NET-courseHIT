using Ex03.GarageLogic.Exceptions;
using System;
using System.Collections.Generic;

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
            // TODO: Implement loading logic
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
                throw new ArgumentNullException("The vehicle provided was null");
            }
        }

        private bool validateAndThrowVehicleIsNotNull(GarageVehicle i_GarageVehicle)
        {
            if (i_GarageVehicle == null)
            {
                throw new ArgumentNullException("The vehicle provided was null");
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
    }
}
