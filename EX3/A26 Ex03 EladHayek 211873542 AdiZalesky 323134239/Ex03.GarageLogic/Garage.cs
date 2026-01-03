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
            if (i_GarageVehicle == null)
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
