using System;

namespace Ex03.GarageLogic
{
    public abstract class Motorcycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        protected Motorcycle(string i_LicenseID, string i_ModelName) : base(i_LicenseID, i_ModelName)
        {
            Wheels = new Wheel[2];

            for (int i = 0; i < Wheels.Length; i++)
            {
                Wheels[i] = new Wheel(29f);
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Engine capacity must be a positive integer.");
                }

                m_EngineCapacity = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}{3}License Type: {1}{3}Engine Capacity: {2}cc",
                base.ToString(),
                m_LicenseType,
                m_EngineCapacity,
                Environment.NewLine);
        }

        public override void SetSpecificVehicleData(string[] i_VehicleSpecificData)
        {
            string licenseTypeString = i_VehicleSpecificData[0];
            bool licenseTypeParseSuccedded = Enum.TryParse(licenseTypeString, out eLicenseType licenseType);

            if (licenseTypeParseSuccedded)
            {
                m_LicenseType = licenseType;
            }
            else
            {
                throw new FormatException("Invalid license type option.");
            }

            EngineCapacity = int.Parse(i_VehicleSpecificData[1]);
        }
    }
}
