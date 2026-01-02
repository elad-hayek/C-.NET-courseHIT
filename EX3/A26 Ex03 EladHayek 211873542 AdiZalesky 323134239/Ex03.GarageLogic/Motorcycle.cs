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
    }
}
