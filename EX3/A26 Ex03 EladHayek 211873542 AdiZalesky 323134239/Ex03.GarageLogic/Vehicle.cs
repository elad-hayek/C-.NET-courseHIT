namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly string r_ModelName;
        private readonly string r_LicenseID;
        private Wheel[] m_Wheels;
        protected EnergySource m_EnergySource;

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

        protected float RemainingEnergy
        {
            get
            {
                return m_EnergySource.RemainingEnergy;
            }
        }
    }
}
