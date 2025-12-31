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
            r_Garage.GarageVehicles.TryGetValue(i_LicenseNumber, out GarageVehicle garageVehicle);
            return garageVehicle;
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
       
    }
}
