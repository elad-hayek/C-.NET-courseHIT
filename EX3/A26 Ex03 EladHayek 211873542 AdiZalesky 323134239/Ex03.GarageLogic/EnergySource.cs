using Ex03.GarageLogic.Exceptions;

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
                if(value < 0 || value > 100)
                {
                    throw new ValueRangeException("Energy Percentage", 0, 100);
                }

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
                if(value <= 0)
                {
                    throw new ValueRangeException("Max Energy Capacity", 0.1f, float.MaxValue);
                }

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
