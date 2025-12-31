using Ex03.GarageLogic.Exceptions;
using System;

namespace Ex03.GarageLogic
{
    public class FuelEnergySource : EnergySource
    {
        private eFuelType m_FuelType;

        public eFuelType FuelType
        {
            get
            {
                return m_FuelType;
            }
            set
            {
                m_FuelType = value;
            }
        }

        public override void AddEnergy(float i_AmountToAdd, eFuelType? i_FuelType = null)
        {
            if (i_FuelType == null)
            {
                throw new ArgumentNullException("Fuel type must be provided when refueling a vehicle.");
            }

            refuel(i_AmountToAdd, i_FuelType.Value);
        }

        private void refuel(float i_AmountOfLitersToAdd, eFuelType i_FuelType)
        {
            if (CurrentAvailableEnergy + i_AmountOfLitersToAdd > MaxEnergyCapacity)
            {
                throw new ValueRangeException("Fuel tank capacity", 0, MaxEnergyCapacity);
            }

            if (i_FuelType != m_FuelType)
            {
                throw new ArgumentException($"Incorrect fuel type. Expected: {m_FuelType}, Provided: {i_FuelType}");
            }

            EnergyPercentage = ((CurrentAvailableEnergy + i_AmountOfLitersToAdd) / MaxEnergyCapacity) * 100;
        }
    }
}
