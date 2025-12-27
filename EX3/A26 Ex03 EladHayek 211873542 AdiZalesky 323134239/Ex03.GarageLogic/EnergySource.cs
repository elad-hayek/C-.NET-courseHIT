namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected float m_RemainingEnergy;
        private float m_MaxEnergyCapacity;

        protected EnergySource() { }

        public float RemainingEnergy
        {
            get
            {
                return m_RemainingEnergy;
            }
        }

        public float MaxEnergyCapacity
        {
            get
            {
                return m_MaxEnergyCapacity;
            }
            set
            {
                m_MaxEnergyCapacity = value;
            }
        }

        protected float CurrentAvailableEnergy
        {
            get
            {
                return RemainingEnergy * MaxEnergyCapacity;
            }
        }
    }
}
