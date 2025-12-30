namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected float m_RemainingEnergy;
        private float m_MaxEnergyCapacity;

        protected EnergySource() { }

        public float EnergyPercentage
        {
            get
            {
                return m_RemainingEnergy;
            }
            set
            {
                // TODO: Add validation to ensure percentage is between 0 and 100
                m_RemainingEnergy = value;
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
                // TODO: Add validation to ensure capacity is positive
                m_MaxEnergyCapacity = value;
            }
        }

        public float CurrentAvailableEnergy
        {
            get
            {
                return (EnergyPercentage / 100) * MaxEnergyCapacity;
            }
        }

        public abstract void AddEnergy(float i_AmountToAdd, eFuelType? i_FuelType = null);
    }
}
