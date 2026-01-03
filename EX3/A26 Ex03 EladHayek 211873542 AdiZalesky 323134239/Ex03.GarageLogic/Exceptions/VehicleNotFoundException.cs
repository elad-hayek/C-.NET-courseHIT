using System;

namespace Ex03.GarageLogic.Exceptions
{
    public class VehicleNotFoundException : Exception
    {
        private string m_LicenseNumber;

        public VehicleNotFoundException(string i_LicenseNumber)
            : base($"Vehicle with license number '{i_LicenseNumber}' was not found in the garage.")
        {
            m_LicenseNumber = i_LicenseNumber;
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }
    }
}
