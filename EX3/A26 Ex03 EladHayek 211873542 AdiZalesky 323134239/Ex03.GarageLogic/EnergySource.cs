using Ex03.GarageLogic.Exceptions;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        protected float m_RemainingEnergy;
        private readonly float r_MaxEnergyCapacity;

        protected EnergySource(float i_MaxCapacity)
        {
            if (i_MaxCapacity <= 0)
            {
                throw new ValueRangeException("Max energy capacity", 0.1f, float.MaxValue);
            }

            r_MaxEnergyCapacity = i_MaxCapacity;
        }

        public float EnergyPercentage
        {
            get
            {
                return m_RemainingEnergy;
            }
            set
            {
                if (value < 0 || value > 100)
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
                return r_MaxEnergyCapacity;
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
        public abstract string GetEnergyPercentageQuestion();
    }
}
