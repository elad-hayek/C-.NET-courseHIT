namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseID;
        private Wheel[] m_Wheels;
        protected EnergySource m_EnergySource;
        protected eEnergyKind m_EnergyKind;

        protected Vehicle(string i_LicenseID, string i_ModelName)
        {
            r_LicenseID = i_LicenseID;
            r_ModelName = i_ModelName;
        }

        public string ModelName
        {
            get
            {
                return r_ModelName;
            }
        }

        public string LicenseID
        {
            get
            {
                return r_LicenseID;
            }
        }

        public Wheel[] Wheels
        {
            // TODO: implemet wheel logic
            get
            {
                return m_Wheels;
            }
            set
            {
                m_Wheels = value;
            }
        }

        protected float EnergyPercentage
        {
            get
            {
                return m_EnergySource.EnergyPercentage;
            }
            set
            {
                m_EnergySource.EnergyPercentage = value;
            }
        }

        public float MaxEnergyCapacity
        {
            get
            {
                return m_EnergySource.MaxEnergyCapacity;
            }
            set
            {
                m_EnergySource.MaxEnergyCapacity = value;
            }
        }

        public float CurrentAvailableEnergy
        {
            get
            {
                return m_EnergySource.CurrentAvailableEnergy;
            }
        }

        public eFuelType FuelType
        {
            get
            {
                eFuelType fuelType = eFuelType.None;

                switch (m_EnergyKind)
                {
                    case eEnergyKind.Fuel:
                        fuelType = ((FuelEnergySource)m_EnergySource).FuelType;
                        break;
                    case eEnergyKind.Electric:
                        fuelType = eFuelType.None;
                        break;
                    default:
                        // TODO: implement proper exception handling
                        throw new System.Exception("Unknown energy kind");
                }

                return fuelType;
            }
        }

        public void AddEnergy(float i_AmountToAdd, eFuelType? i_FuelType = null)
        {
            m_EnergySource.AddEnergy(i_AmountToAdd, i_FuelType);
        }
    }
}
