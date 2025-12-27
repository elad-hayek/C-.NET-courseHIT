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
            // TODO: hanle null or existing logic
            r_GarageVehicles.Add(i_GarageVehicle.Vehicle.LicenseID, i_GarageVehicle);
        }
    }
}
