using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class VehicleNotFoundException : Exception
    {
        public VehicleNotFoundException(string i_LicenseNumber)
            : base($"Vehicle with license number '{i_LicenseNumber}' was not found in the garage.")
        {
        }
    }
}
