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
    }
}
